using Newtonsoft.Json;
using System;

namespace DeviantartApi.Objects.SubObjects.Deviation
{
    public class MotionBook
    {
        [JsonProperty("embed_url")]
        [JsonConverter(typeof(Converters.UriConverter))]
        public Uri EmbedUrl { get; set; }
    }
}
