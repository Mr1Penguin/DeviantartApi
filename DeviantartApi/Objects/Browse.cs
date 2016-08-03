using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeviantartApi.Objects
{
    public class Browse : Pageable
    {
        [JsonProperty("results")]
        public List<Deviation> results { get; set; }
    }
}
