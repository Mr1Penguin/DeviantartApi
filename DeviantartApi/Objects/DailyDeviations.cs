using Newtonsoft.Json;
using System.Collections.Generic;

namespace DeviantartApi.Objects
{
    public class DailyDeviations : BaseObject
    {
        [JsonProperty("results")]
        public List<Deviation> results { get; set; }
    }
}
