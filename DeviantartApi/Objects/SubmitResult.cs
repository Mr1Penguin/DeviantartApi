using Newtonsoft.Json;

namespace DeviantartApi.Objects
{
    public class SubmitResult : BaseObject
    {
        [JsonProperty("itemid")]
        public long ItemId { get; set; }

        [JsonProperty("stack")]
        public string Stack { get; set; }

        [JsonProperty("stackid")]
        public long StackId { get; set; }
    }
}
