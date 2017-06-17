using Newtonsoft.Json;

namespace DeviantartApi.Objects.SubObjects
{
    public class PollAnswer
    {
        [JsonProperty("answer")]
        public string Answer { get; set; }

        [JsonProperty("votes")]
        public int Votes { get; set; }
    }
}
