using Newtonsoft.Json;

namespace DeviantartApi.Objects.SubObjects.StashMetadata
{
    public class MetadataSubmission
    {
        [JsonProperty("file_size")]
        [JsonConverter(typeof(Converters.StringToIntConverter))]
        public int FileSize { get; set; }

        [JsonProperty("resolution")]
        public string Resolution { get; set; }

        [JsonProperty("submitted_with")]
        public SubmittedWith SubmittedWith { get; set; }
    }
}
