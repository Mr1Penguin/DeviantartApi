using Newtonsoft.Json;
using System.Collections.Generic;

namespace DeviantartApi.Objects.SubObjects.Watch
{
    public class Poll
    {
        [JsonProperty("question")]
        public string Question { get; set; }

        [JsonProperty("total_votes")]
        public int TotalVotes { get; set; }

        [JsonProperty("answers")]
        public List<PollAnswer> Answers { get; private set; }
    }
}
