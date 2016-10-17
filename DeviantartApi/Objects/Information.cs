using Newtonsoft.Json;

namespace DeviantartApi.Objects
{
    public class Information : BaseObject
    {
        [JsonProperty("text")]
        public string Text { get; set; }
    }
}
