using Newtonsoft.Json;

namespace DeviantartApi.Objects
{
    public class Space : BaseObject
    {
        [JsonProperty("available_space")]
        public int AvailableSpace { get; set; }

        [JsonProperty("total_space")]
        public int TotalSpace { get; set; }
    }
}
