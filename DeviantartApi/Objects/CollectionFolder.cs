using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

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
