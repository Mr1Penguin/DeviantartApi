using Newtonsoft.Json;

namespace DeviantartApi.Objects
{
    public class DamnResponse : BaseObject
    {
        [JsonProperty("damntoken")]
        public string DamnToken { get; set; }
    }
}
