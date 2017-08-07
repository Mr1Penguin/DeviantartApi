using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace DeviantartApi
{
    public static class Extentions
    {
        public static void Add<TK, TV>(this Dictionary<TK, TV> dict, KeyValuePair<TK, TV> pair)
        {
            dict.Add(pair.Key, pair.Value);
        }

        public static void AddHashSetParameter<T>(this Dictionary<string, string> dict, Expression<Func<HashSet<T>>> value, ulong start = 0)
        {
            var memberExpression = value.Body as MemberExpression;
            var paramAttr = (Attributes.ParameterAttribute)CustomAttributeExtensions.GetCustomAttribute(memberExpression.Member, typeof(Attributes.ParameterAttribute));
            if (paramAttr == null)
                throw new Exception("ParameterAttribute not found");
            var requestParameter = paramAttr.RequestParameterName;
            if (string.IsNullOrWhiteSpace(requestParameter))
            {
                if (string.IsNullOrWhiteSpace(paramAttr.PropertyName))
                    throw new Exception("PropertyName can't be null, empty or contain only whitespaces");
                requestParameter = paramAttr.PropertyName;
            }
            var val = value.Compile()();
            var expandsAttr = (Attributes.ExpandsAttribute)CustomAttributeExtensions.GetCustomAttribute(memberExpression.Member, typeof(Attributes.ExpandsAttribute));
            if (expandsAttr != null)
            {
                var strVal = string.Join(",", val.Select(x => requestParameter + "." + x.ToString().ToLower()).ToList());
                if (dict.TryGetValue("expand", out var oldExpand))
                {
                    dict["expand"] = oldExpand + "," + strVal;
                }
                else
                {
                    dict.Add("expand", strVal);
                }
                return;
            }
            foreach (var arg in val)
                dict.Add(requestParameter + $"[{start++}]", arg is string ? arg.ToString() : arg.ToString().ToLower());
        }

        public static void AddParameter<T>(this Dictionary<string, string> dict, Expression<Func<T>> value)
        {
            //todo: find a way to check if generic
            /*if (typeof(T).GetGenericTypeDefinition() == typeof(HashSet<>))
            {
                throw new ArgumentException("HashSet is not allowed here");
            }*/
            var memberExpression = value.Body as MemberExpression;
            var paramAttr = (Attributes.ParameterAttribute)CustomAttributeExtensions.GetCustomAttribute(memberExpression.Member, typeof(Attributes.ParameterAttribute));
            if (paramAttr == null)
                throw new Exception("ParameterAttribute not found");
            var requestParameter = paramAttr.RequestParameterName;
            if (string.IsNullOrWhiteSpace(requestParameter))
            {
                if (string.IsNullOrWhiteSpace(paramAttr.PropertyName))
                    throw new Exception("PropertyName can't be null, empty or contain only whitespaces");
                requestParameter = paramAttr.PropertyName;
            }
            var val = value.Compile()();
            if (val == null)
            {
                return;
            }

            var enumToNumAttr = (Attributes.EnumToNumAttribute)CustomAttributeExtensions.GetCustomAttribute(memberExpression.Member, typeof(Attributes.EnumToNumAttribute));
            var noFirstLevelEnumAttr = (Attributes.NoFirstLetterEnumAttribute)CustomAttributeExtensions.GetCustomAttribute(memberExpression.Member, typeof(Attributes.NoFirstLetterEnumAttribute));
            if (!typeof(T).GetTypeInfo().IsEnum && (enumToNumAttr != null || noFirstLevelEnumAttr != null))
                throw new Exception("Type of property is not an enum");
            var strVal = val?.ToString();
            if (enumToNumAttr != null)
                strVal = Convert.ToInt32(val).ToString();
            if (noFirstLevelEnumAttr != null)
                strVal = strVal.Substring(1);
            if (typeof(T) != typeof(string))
                strVal = strVal?.ToLower();
            var dateTimeFormatAttr = (Attributes.DateTimeFormatAttribute)CustomAttributeExtensions.GetCustomAttribute(memberExpression.Member, typeof(Attributes.DateTimeFormatAttribute));
            if (dateTimeFormatAttr != null)
            {
                if (typeof(T) != typeof(DateTime) && typeof(T) != typeof(DateTime?))
                    throw new Exception("Type of property is not a DateTime or DateTime?");
                strVal = (val as DateTime?)?.ToString(dateTimeFormatAttr.ToStringFormat);
            }

            dict.Add(requestParameter, strVal);
        }

        public static string ToGetParameters(this Dictionary<string, string> dict)
        {
            return string.Join("&", (from pair in dict
                                     select pair.Key + "=" + (pair.Value == null ? pair.Value : Uri.EscapeDataString(pair.Value))).ToList());
        }
    }
}
