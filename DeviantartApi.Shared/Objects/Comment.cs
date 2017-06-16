using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Text.RegularExpressions;

namespace DeviantartApi.Objects
{
    public class Comment : BaseObject
    {
        [JsonProperty("commentid")]
        public string CommentId { get; set; }

        [JsonProperty("parentid")]
        public string ParentId { get; set; }

        [JsonProperty("posted")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime? Posted { get; set; }

        [JsonProperty("replies")]
        public int Replies { get; set; }

        [JsonProperty("hidden")]
        [JsonConverter(typeof(HideReasonEnumConverter))]
        public HideReason? Hidden { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        public enum HideReason
        {
            HiddenByOwner,
            HiddenByAdmin,
            HiddenByCommenter,
            HiddenAsSpam
        }

        private class HideReasonEnumConverter : JsonConverter
        {
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                var hideReason = (HideReason?)value;
                if (hideReason == null)
                    writer.WriteValue("null");
                else
                {
                    var str = Regex.Replace(hideReason.ToString(), @"(?<!_)([A-Z])", "_$1");
                    if (hideReason.ToString()[0] != str[0])
                        str = str.Remove(0, 1);
                    writer.WriteValue(str.ToLower());
                }
            }

            public override bool CanConvert(Type objectType)
            {
                return objectType == typeof(string);
            }

            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                var enumString = (string)reader.Value;
                HideReason? hideReason = null;

                switch (enumString)
                {
                    case "hidden_by_owner":
                        hideReason = HideReason.HiddenByOwner;
                        break;

                    case "hidden_by_admin":
                        hideReason = HideReason.HiddenByAdmin;
                        break;

                    case "hidden_by_commenter":
                        hideReason = HideReason.HiddenByCommenter;
                        break;

                    case "hidden_as_spam":
                        hideReason = HideReason.HiddenAsSpam;
                        break;
                }

                return hideReason;
            }
        }
    }
}
