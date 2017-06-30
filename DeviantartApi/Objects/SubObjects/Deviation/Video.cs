using Newtonsoft.Json;
using System;

namespace DeviantartApi.Objects.SubObjects.Deviation
{
    public class Video
    {
        [JsonProperty("src")]
        [JsonConverter(typeof(Converters.UriConverter))]
        public Uri Src { get; set; }

        [JsonProperty("quality")]
        public string Quality { get; set; }

        [JsonProperty("filesize")]
        public int Filesize { get; set; }

        [JsonProperty("duration")]
        public int Duration { get; set; }
    }
}
