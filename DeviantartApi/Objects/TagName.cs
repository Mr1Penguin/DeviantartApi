using Newtonsoft.Json;

namespace DeviantartApi.Objects
{
    public class TagNameItem
    {
        [JsonProperty("tag_name")]
        public string TagName { get; set; }
    }
}
