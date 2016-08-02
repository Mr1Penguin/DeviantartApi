using Newtonsoft.Json;

namespace DeviantartApi.Objects
{
    public abstract class Pageable : BaseObject
    {
        [JsonProperty("cursor")]
        public string Cursor { get; set; }
        [JsonProperty("has_more")]
        public bool HasMore { get; set; }
        [JsonProperty("next_offset")]
        public int? NextOffset { get; set; }
    }
}
