using Newtonsoft.Json;

namespace DeviantartApi.Objects.SubObjects.Deviation
{
    public class ChallengeEntry
    {
        [JsonProperty("challengeid")]
        public string ChallengeId { get; set; }

        [JsonProperty("challenge_title")]
        public string ChallengeTitle { get; set; }

        [JsonProperty("challenge")]
        public Objects.Deviation Challenge { get; set; }

        [JsonProperty("timed_duration")]
        public int TimedDuration { get; set; }

        [JsonProperty("submission_time")]
        public string SubmissionTime { get; set; }
    }
}
