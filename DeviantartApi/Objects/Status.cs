using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DeviantartApi.Objects
{
    public class Status : BaseObject
    {
        [JsonProperty("statusid")]
        public string StatusId { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("ts")]
        public string TS { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("comments_count")]
        public int CommentsCount { get; set; }

        [JsonProperty("is_share")]
        public bool IsShare { get; set; }

        [JsonProperty("is_deleted")]
        public bool IsDeleted { get; set; }

        [JsonProperty("author")]
        public User Author { get; set; }

        [JsonProperty("items")]
        public List<Item> Items { get; set; }

        public class Item
        {
            [JsonProperty("type")]
            [JsonConverter(typeof(StatusItemTypeEnumConverter))]
            public StatusItemType Type { get; set; }

            [JsonProperty("status")]
            public Status Status { get; set; }

            [JsonProperty("deviation")]
            public Deviation Deviation { get; set; }

            public enum StatusItemType
            {
                Deviation,
                Status,
                Unknown
            }

            private class StatusItemTypeEnumConverter : JsonConverter
            {
                public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
                {
                    var statusItemType = (StatusItemType)value;
                    writer.WriteValue(statusItemType.ToString().ToLower());
                }

                public override bool CanConvert(Type objectType)
                {
                    return objectType == typeof(string);
                }

                public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
                {
                    var enumString = (string)reader.Value;
                    var statusItemType = StatusItemType.Unknown;

                    switch (enumString)
                    {
                        case "deviation":
                            statusItemType = StatusItemType.Deviation;
                            break;

                        case "status":
                            statusItemType = StatusItemType.Status;
                            break;
                    }

                    return statusItemType;
                }
            }
        }
    }
}
