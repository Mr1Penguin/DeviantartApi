using Newtonsoft.Json;

namespace DeviantartApi.Objects.SubObjects.Message
{
    public class Subject
    {
        [JsonProperty("profile")]
        public Objects.User Profile { get; set; }

        [JsonProperty("deviation")]
        public Objects.Deviation Deviation { get; set; }

        [JsonProperty("status")]
        public Objects.Status Status { get; set; }

        [JsonProperty("comment")]
        public Comment Comment { get; set; }

        [JsonProperty("collection")]
        public Profile.CollectionFolder Collection { get; set; }

        [JsonProperty("gallery")]
        public Profile.CollectionFolder Gallery { get; set; }
    }
}
