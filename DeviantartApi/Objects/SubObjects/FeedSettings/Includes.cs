using Newtonsoft.Json;

namespace DeviantartApi.Objects.SubObjects.FeedSettings
{
    public class Includes
    {
        [JsonProperty("statuses")]
        public bool Statuses { get; set; }

        [JsonProperty("deviations")]
        public bool Deviations { get; set; }

        [JsonProperty("journals")]
        public bool Journals { get; set; }

        [JsonProperty("group_deviations")]
        public bool GroupDeviations { get; set; }

        [JsonProperty("collections")]
        public bool Collections { get; set; }

        [JsonProperty("misc")]
        public bool Misc { get; set; }
    }
}
