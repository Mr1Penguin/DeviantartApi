using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeviantartApi.Objects.SubObjects
{
    public class FavedUser
    {
        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("time")]
        [JsonConverter(typeof(Converters.UnixDateTimeConverter))]
        public DateTime Time { get; set; }
    }
}
