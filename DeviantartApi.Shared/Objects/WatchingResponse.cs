using Newtonsoft.Json;

namespace DeviantartApi.Objects
{
    public class WatchingResponse : BaseObject
    {
        [JsonProperty("watching")]
        public bool Watching { get; set; }
    }
}
