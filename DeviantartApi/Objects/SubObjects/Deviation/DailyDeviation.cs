using Newtonsoft.Json;

namespace DeviantartApi.Objects.SubObjects.Deviation
{
    public class DailyDeviation
    {
        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("time")]
        public string Time { get; set; }

        [JsonProperty("giver")]
        public Objects.User Giver { get; set; }

        [JsonProperty("suggester")]
        public Objects.User Suggester { get; set; }
    }
}
