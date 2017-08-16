using Newtonsoft.Json;

namespace DeviantartApi.Objects
{
    public class StashItem : StashMetadata
    {
        [JsonProperty("itemid")]
        new public long ItemId { get; set; }
    }
}
