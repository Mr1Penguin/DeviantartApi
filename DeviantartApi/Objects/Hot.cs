using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeviantartApi.Objects
{
    public class Hot : Pageable
    {
        [JsonProperty("results")]
        public List<Deviation> results { get; set; }
    }
}
