using Newtonsoft.Json;

namespace DeviantartApi.Objects.SubObjects
{
    public class MetadataSubmission
    {
        [JsonProperty("file_size")]
        [JsonConverter(typeof(Converters.StringToIntConverter))]
        public int FileSize { get; set; }

        [JsonProperty("resolution")]
        public string Resolution { get; set; }

        [JsonProperty("submitted_with")]
        public SubmittedWithClass SubmittedWith { get; set; }

        public class SubmittedWithClass
        {
            [JsonProperty("app")]
            public string App { get; set; }

            [JsonProperty("url")]
            public string Url { get; set; }
        }
    }
}
