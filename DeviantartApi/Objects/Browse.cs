using Newtonsoft.Json;

namespace DeviantartApi.Objects
{
    public class Browse : ArrayOfResults<Deviation>
    {
        [JsonProperty("estimated_total")]
        public int EstimatedTotal { get; set; }
    }
}
