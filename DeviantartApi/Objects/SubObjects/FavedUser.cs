using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeviantartApi.Objects.SubObjects
{
    public class FavedUser
    {
        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("time")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime Time { get; set; }

        private class UnixDateTimeConverter : JsonConverter
        {
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                var dateTime = (DateTime)value;
                writer.WriteValue((long)dateTime.Subtract(new DateTime(1970, 1, 1)).TotalSeconds);
            }

            public override bool CanConvert(Type objectType)
            {
                return objectType == typeof(long);
            }

            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                var unixTime = (long)reader.Value;
                var dateTime =
                    new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc).AddSeconds(unixTime).ToLocalTime();
                return dateTime;
            }
        }
    }
}
