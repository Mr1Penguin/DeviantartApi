using Newtonsoft.Json;
using System;

namespace DeviantartApi.Objects.SubObjects
{
    public class Friend
    {
        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("is_watching")]
        public bool IsWatching { get; set; }

        [JsonProperty("watches_you")]
        public bool WatchesYou { get; set; }

        [JsonProperty("lastvisit")]
        [JsonConverter(typeof(Converters.NullableIsoDateTimeConverter))]
        public DateTime? LastVisit { get; set; }
    }
}
