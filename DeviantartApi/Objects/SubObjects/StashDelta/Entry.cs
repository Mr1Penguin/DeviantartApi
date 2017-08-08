using Newtonsoft.Json;

namespace DeviantartApi.Objects.SubObjects.StashDelta
{
    public class Entry
    {
        [JsonProperty("itemid")]
        public int ItemId { get; set; }

        [JsonProperty("stackid")]
        public int? StackId { get; set; }

        [JsonProperty("metadata")]
        public Objects.StashMetadata Metadata { get; set; }

        [JsonProperty("position")]
        public int Position { get; set; }
    }
}
