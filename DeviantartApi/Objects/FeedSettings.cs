using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeviantartApi.Objects
{
    /// <summary>
    /// If you need fields not described here leave an issue
    /// or create Request class returns FeedSettings where
    /// Includes is Dictionary<string,string> or Dictionary<string, bool>
    /// </summary>
    public class FeedSettings
    {
        [JsonProperty("includes")]
        public IncludesClass Includes { get; set; }

        public class IncludesClass
        {
            [JsonProperty("statuses")]
            public bool Statuses { get; set; }

            [JsonProperty("deviations")]
            public bool Deviations { get; set; }

            [JsonProperty("journals")]
            public bool Journals { get; set; }

            [JsonProperty("group_deviations")]
            public bool GroupDeviations { get; set; }

            [JsonProperty("collections")]
            public bool Collections { get; set; }

            [JsonProperty("misc")]
            public bool Misc { get; set; }
        }
    }
}
