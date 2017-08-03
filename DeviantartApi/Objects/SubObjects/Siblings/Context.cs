using Newtonsoft.Json;

namespace DeviantartApi.Objects.SubObjects.Siblings
{
    public class Context
    {
        [JsonProperty("parent")]
        public Comment Parent { get; set; }

        [JsonProperty("item_profile")]
        public Objects.User ItemProfile { get; set; }

        [JsonProperty("item_devation")]
        public Objects.Deviation ItemDeviation { get; set; }

        [JsonProperty("item_status")]
        public Objects.Status ItemStatus { get; set; }
    }
}
