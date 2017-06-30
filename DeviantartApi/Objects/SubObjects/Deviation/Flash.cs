using Newtonsoft.Json;
using System;

namespace DeviantartApi.Objects.SubObjects.Deviation
{
    public class Flash
    {
        [JsonProperty("src")]
        [JsonConverter(typeof(Converters.UriConverter))]
        public Uri Src { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }
    }
}
