using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace DeviantartApi.Objects.Converters
{
    public class NullableIsoDateTimeConverter : IsoDateTimeConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            string val = (string)reader.Value;
            if (string.IsNullOrWhiteSpace(val)) return null;
            return base.ReadJson(reader, objectType, existingValue, serializer);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
                writer.WriteNull();
            else base.WriteJson(writer, value, serializer);
        }
    }
}
