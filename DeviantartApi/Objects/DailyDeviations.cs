using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeviantartApi.Objects
{
    public class DailyDeviations : BaseObject
    {
        [JsonProperty("results")]
        public List<Deviation> results { get; set; }
    }
}
