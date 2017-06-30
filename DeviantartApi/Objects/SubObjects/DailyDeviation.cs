using Newtonsoft.Json;

namespace DeviantartApi.Objects.SubObjects
{
    public class DailyDeviation
    {
        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("time")]
        public string Time { get; set; }

        [JsonProperty("giver")]
        public User Giver { get; set; }

        [JsonProperty("suggester")]
        public User Suggester { get; set; }
    }
}
