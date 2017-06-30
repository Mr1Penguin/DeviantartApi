using Newtonsoft.Json;

namespace DeviantartApi.Objects.SubObjects.Watch
{
    public class PollAnswer
    {
        [JsonProperty("answer")]
        public string Answer { get; set; }

        [JsonProperty("votes")]
        public int Votes { get; set; }
    }
}
