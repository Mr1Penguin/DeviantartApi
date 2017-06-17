using Newtonsoft.Json;

namespace DeviantartApi.Objects.SubObjects
{
    public class Collection
    {
        [JsonProperty("folderid")]
        public string FolderId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("size")]
        public int Size { get; set; }
    }
}
