using Newtonsoft.Json;

namespace DeviantartApi.Objects.SubObjects.StashMetadata
{
    public class SubmittedWith
    {
        [JsonProperty("app")]
        public string App { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
