using Newtonsoft.Json;
using System;

namespace DeviantartApi.Objects.SubObjects
{
    public class MotionBook
    {
        [JsonProperty("embed_url")]
        [JsonConverter(typeof(Converters.UriConverter))]
        public Uri EmbedUrl { get; set; }
    }
}
