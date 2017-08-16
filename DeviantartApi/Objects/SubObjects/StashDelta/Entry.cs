using Newtonsoft.Json;

namespace DeviantartApi.Objects.SubObjects.StashDelta
{
    public class Entry
    {
        [JsonProperty("itemid")]
        public long ItemId { get; set; }

        [JsonProperty("stackid")]
        public long? StackId { get; set; }

        [JsonProperty("metadata")]
        public Objects.StashMetadata Metadata { get; set; }

        [JsonProperty("position")]
        public int Position { get; set; }
    }
}
