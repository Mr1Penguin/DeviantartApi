using Newtonsoft.Json;

namespace DeviantartApi.Objects.SubObjects
{
    public class TagNameItem
    {
        [JsonProperty("tag_name")]
        public string TagName { get; set; }
    }
}
