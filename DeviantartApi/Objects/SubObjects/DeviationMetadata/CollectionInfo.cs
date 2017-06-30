using Newtonsoft.Json;

namespace DeviantartApi.Objects.SubObjects.DeviationMetadata
{
    public class CollectionInfo
    {
        [JsonProperty("folderid")]
        public string FolderId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
