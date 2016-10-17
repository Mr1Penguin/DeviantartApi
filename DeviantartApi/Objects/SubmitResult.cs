using Newtonsoft.Json;

namespace DeviantartApi.Objects
{
    public class SubmitResult : BaseObject
    {
        [JsonProperty("itemid")]
        public int ItemId { get; set; }

        [JsonProperty("stack")]
        public string Stack { get; set; }

        [JsonProperty("stackid")]
        public int StackId { get; set; }
    }
}
