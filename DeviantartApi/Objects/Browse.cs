using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

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
