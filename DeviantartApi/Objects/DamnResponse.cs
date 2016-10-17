using Newtonsoft.Json;

namespace DeviantartApi.Objects
{
    internal class DamnResponse : BaseObject
    {
        [JsonProperty("damntoken")]
        public string DamnToken { get; set; }
    }
}
