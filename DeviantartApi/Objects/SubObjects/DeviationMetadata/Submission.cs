using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace DeviantartApi.Objects.SubObjects.DeviationMetadata
{
    public class Submission
    {
        [JsonProperty("creation_time")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime CreationTime { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("file_size")]
        public string FileSize { get; set; }

        [JsonProperty("resolution")]
        public string Resolution { get; set; }

        [JsonProperty("submitted_with")]
        public SubmittedWith SubmittedWith { get; set; }
    }
}
