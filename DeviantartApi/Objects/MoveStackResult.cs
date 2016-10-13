using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeviantartApi.Objects
{
    public class MoveStackResult : BaseObject
    {
        [JsonProperty("target")]
        public StashMetadata Target { get; set; }

        [JsonProperty("changes")]
        public List<StashMetadata> Changes { get; set; }
    }
}
