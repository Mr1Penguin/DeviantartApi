using Newtonsoft.Json;

namespace DeviantartApi.Objects
{
    public class StashItem : StashMetadata
    {
        [JsonProperty("itemid")]
        new public int ItemId { get; set; }
    }
}
