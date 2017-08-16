using Newtonsoft.Json;
using System.Collections.Generic;

namespace DeviantartApi.Objects
{
    public class StashDelta : Pageable
    {
        [JsonProperty("reset")]
        public bool Reset { get; set; }

        [JsonProperty("entries")]
        public List<EntryClass> Entries { get; set; }

        public class EntryClass
        {
            [JsonProperty("itemid")]
            public long ItemId { get; set; }

            [JsonProperty("stackid")]
            public long? StackId { get; set; }

            [JsonProperty("metadata")]
            public StashMetadata Metadata { get; set; }

            [JsonProperty("position")]
            public int Position { get; set; }
        }
    }
}
