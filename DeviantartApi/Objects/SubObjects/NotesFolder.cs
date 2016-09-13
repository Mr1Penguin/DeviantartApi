using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeviantartApi.Objects.SubObjects
{
    public class NotesFolder
    {
        [JsonProperty("folder")]
        public string Folder { get; set; }

        [JsonProperty("parentid")]
        public string ParentId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("count")]
        [JsonConverter(typeof(CountConverter))]
        public int Count { get; set; }

        private class CountConverter : JsonConverter
        {
            public override bool CanConvert(Type objectType)
            {
                return objectType == typeof(string);
            }

            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                try
                {
                    return int.Parse((string)reader.Value);
                }
                catch
                {
                    return 0;
                }
            }

            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                writer.WriteValue(value.ToString());
            }
        }
    }
}
