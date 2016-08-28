using Newtonsoft.Json;
using System.Collections.Generic;

namespace DeviantartApi.Objects
{
    public class Deviations : Pageable
    {
        [JsonProperty("results")]
        public List<Deviation> results { get; set; }
    }
}
