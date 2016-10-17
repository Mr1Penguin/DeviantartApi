using Newtonsoft.Json;

namespace DeviantartApi.Objects
{
    public class StatusPostResponse : BaseObject
    {
        [JsonProperty("statusid")]
        public string StatusId { get; set; }
    }
}
