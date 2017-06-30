using Newtonsoft.Json;
using System;

namespace DeviantartApi.Objects.SubObjects.DeviationMetadata
{
    public class SubmittedWith
    {
        [JsonProperty("app")]
        public string App { get; set; }

        [JsonProperty("url")]
        [JsonConverter(typeof(Converters.UriConverter))]
        public Uri Url { get; set; }
    }
}
