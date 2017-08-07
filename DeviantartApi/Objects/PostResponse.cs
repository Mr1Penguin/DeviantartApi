using Newtonsoft.Json;

namespace DeviantartApi.Objects
{
    public class PostResponse : BaseObject
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
    }
}
