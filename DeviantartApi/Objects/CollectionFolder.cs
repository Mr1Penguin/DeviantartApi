using Newtonsoft.Json;
using System.Collections.Generic;

namespace DeviantartApi.Objects
{
    public class CollectionFolder : Pageable
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("results")]
        public List<Deviation> Results { get; set; }
    }
}
