using Newtonsoft.Json;

namespace DeviantartApi.Objects.SubObjects.DeviationMetadata
{
    public class Tag
    {
        [JsonProperty("tag_name")]
        public string TagName { get; set; }

        [JsonProperty("sponsored")]
        public bool Sponsored { get; set; }

        [JsonProperty("sponsor")]
        public string Sponsor { get; set; }
    }
}
