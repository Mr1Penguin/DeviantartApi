using Newtonsoft.Json;
using System;

namespace DeviantartApi.Objects.SubObjects.Watch
{
    public class CollectionInfo
    {
        [JsonProperty("folderid")]
        public string FolderId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        [JsonConverter(typeof(Converters.UriConverter))]
        public Uri Url { get; set; }

        [JsonProperty("size")]
        public int Size { get; set; }
    }
}
