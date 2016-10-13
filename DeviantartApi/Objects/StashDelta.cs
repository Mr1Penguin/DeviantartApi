using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

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
            public int ItemId { get; set; }

            [JsonProperty("stackid")]
            public int? StackId { get; set; }

            [JsonProperty("metadata")]
            public StashMetadata Metadata { get; set; }

            [JsonProperty("position")]
            public int Position { get; set; }
        }
    }
}
