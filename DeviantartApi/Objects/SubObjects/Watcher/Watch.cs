using Newtonsoft.Json;

namespace DeviantartApi.Objects.SubObjects.Watcher
{
    public class Watch
    {
        [JsonProperty("friend")]
        public bool Friend { get; set; }

        [JsonProperty("deviations")]
        public bool Deviations { get; set; }

        [JsonProperty("journals")]
        public bool Journals { get; set; }

        [JsonProperty("forum_threads")]
        public bool ForumThreads { get; set; }

        [JsonProperty("critiques")]
        public bool Critiques { get; set; }

        [JsonProperty("scraps")]
        public bool Scraps { get; set; }

        [JsonProperty("activity")]
        public bool Activity { get; set; }

        [JsonProperty("collections")]
        public bool Collections { get; set; }
    }
}
