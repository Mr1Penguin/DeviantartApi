using Newtonsoft.Json;

namespace DeviantartApi.Objects.SubObjects
{
    public class GalleryFolder : CollectionFolder
    {
        [JsonProperty("parent")]
        public string Parent { get; set; }
    }
}
