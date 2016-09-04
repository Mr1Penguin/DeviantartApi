using Newtonsoft.Json;
using System.Collections.Generic;

namespace DeviantartApi.Objects
{
    public class Browse : ArrayOfResults<Deviation>
    {
        [JsonProperty("estimated_total")]
        public int EstimatedTotal { get; set; }
    }
}
