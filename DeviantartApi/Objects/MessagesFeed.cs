using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeviantartApi.Objects
{
    public class MessagesFeed : Pageable
    {
        [JsonProperty("results")]
        public List<SubObjects.Message> Results { get; set; }
    }
}
