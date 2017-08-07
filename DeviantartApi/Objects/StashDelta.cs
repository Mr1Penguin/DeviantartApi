using DeviantartApi.Objects.SubObjects.StashDelta;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DeviantartApi.Objects
{
    public class StashDelta : Pageable
    {
        [JsonProperty("reset")]
        public bool Reset { get; set; }

        [JsonProperty("entries")]
        public List<Entry> Entries { get; set; }
    }
}
