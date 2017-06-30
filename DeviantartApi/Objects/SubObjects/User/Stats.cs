using Newtonsoft.Json;

namespace DeviantartApi.Objects.SubObjects.User
{
    public class Stats
    {
        [JsonProperty("watchers")]
        public int Watchers { get; set; }

        [JsonProperty("friends")]
        public int Friends { get; set; }
    }
}
