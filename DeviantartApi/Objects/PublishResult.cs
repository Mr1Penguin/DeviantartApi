﻿using Newtonsoft.Json;

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
