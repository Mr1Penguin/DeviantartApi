using Newtonsoft.Json;
using System;

namespace DeviantartApi.Objects.SubObjects.User
{
    public class Details
    {
        [JsonProperty("sex")]
        public string Sex { get; set; }

        [JsonProperty("age")]
        public int? Age { get; set; }

        [JsonProperty("joindate")]
        [JsonConverter(typeof(Converters.NullableIsoDateTimeConverter))]
        public DateTime? JoinDate { get; set; }
    }
}
