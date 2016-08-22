using Newtonsoft.Json;
using System.Collections.Generic;

namespace DeviantartApi.Objects
{
    public class Browse : Pageable
    {
        [JsonProperty("estimated_total")]
        public int EstimatedTotal { get; set; }

        [JsonProperty("results")]
        public List<Deviation> results { get; set; }
    }
}
