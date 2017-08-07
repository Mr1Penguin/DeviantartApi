using Newtonsoft.Json;
using System.Collections.Generic;

namespace DeviantartApi.Objects
{
    public class MoveStackResponse : BaseObject
    {
        [JsonProperty("target")]
        public StashMetadata Target { get; set; }

        [JsonProperty("changes")]
        public List<StashMetadata> Changes { get; set; }
    }
}
