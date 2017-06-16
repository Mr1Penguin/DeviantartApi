using System;
using System.Runtime.CompilerServices;

namespace DeviantartApi.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class ParameterAttribute : Attribute
    {
        public string RequestParameterName { get; private set; }

        public string PropertyName { get; private set; }

        public ParameterAttribute(string requestParameterName = null, [CallerMemberName] string propertyName = null)
        {
            RequestParameterName = requestParameterName;
            PropertyName = propertyName;
        }
    }
}
