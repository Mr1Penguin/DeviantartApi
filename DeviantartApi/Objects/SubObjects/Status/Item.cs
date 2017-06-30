using Newtonsoft.Json;
using System;

namespace DeviantartApi.Objects.SubObjects.Status
{
    public enum StatusItemType
    {
        Deviation,
        Status,
        Unknown
    }

    public class Item
    {
        [JsonProperty("type")]
        [JsonConverter(typeof(StatusItemTypeEnumConverter))]
        public StatusItemType StatusItemType { get; set; }

        [JsonProperty("status")]
        public Objects.Status Status { get; set; }

        [JsonProperty("deviation")]
        public Objects.Deviation Deviation { get; set; }

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
