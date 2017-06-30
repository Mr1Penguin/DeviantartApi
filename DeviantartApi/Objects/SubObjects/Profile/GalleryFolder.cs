using Newtonsoft.Json;

namespace DeviantartApi.Objects.SubObjects.Profile
{
    public class GalleryFolder : CollectionFolder
    {
        [JsonProperty("parent")]
        public string Parent { get; set; }
    }
}
