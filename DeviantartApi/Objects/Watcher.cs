using DeviantartApi.Objects.SubObjects.Watcher;
using Newtonsoft.Json;

namespace DeviantartApi.Objects
{
    public class Watcher : Friend
    {
        [JsonProperty("watch")]
        public Watch Watch { get; set; }
    }
}
