using Newtonsoft.Json;
using System.Collections.Generic;

namespace DeviantartApi.Objects.SubObjects.Deviation
{
    public class Challenge
    {
        [JsonProperty("type")]
        public List<string> Type { get; private set; }

        [JsonProperty("completed")]
        public bool Completed { get; set; }

        [JsonProperty("tags")]
        public List<string> Tags { get; private set; }

        [JsonProperty("locked")]
        public bool? Locked { get; set; }

        [JsonProperty("credit_deviation")]
        public string CreditDeviation { get; set; }

        [JsonProperty("media")]
        public List<string> Media { get; private set; }

        [JsonProperty("level_label")]
        public string LevelLabel { get; set; }

        //seconds?
        [JsonProperty("time_limit")]
        public int? TimeLimit { get; set; }

        [JsonProperty("levels")]
        public List<string> Levels { get; private set; }
    }
}
