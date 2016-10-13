using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeviantartApi.Objects
{
    public class PublishResult : BaseObject
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("deviationid")]
        public string DeviationId { get; set; }
    }
}
