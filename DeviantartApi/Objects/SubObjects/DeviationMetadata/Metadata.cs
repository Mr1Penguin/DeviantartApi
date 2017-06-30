using Newtonsoft.Json;
using System.Collections.Generic;

namespace DeviantartApi.Objects.SubObjects.DeviationMetadata
{
    public class Metadata
    {
        [JsonProperty("deviationid")]
        public string DeviationId { get; set; }

        [JsonProperty("printid")]
        public string PrintId { get; set; }

        [JsonProperty("author")]
        public Objects.User Author { get; set; }

        [JsonProperty("is_watching")]
        public bool IsWatching { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("license")]
        public string License { get; set; }

        [JsonProperty("allow_comments")]
        public bool AllowComments { get; set; }

        [JsonProperty("tags")]
        public List<Tag> Tags { get; private set; }

        [JsonProperty("is_favourited")]
        public bool IsFavourited { get; set; }

        [JsonProperty("is_mature")]
        public bool IsMature { get; set; }

        [JsonProperty("submission")]
        public Submission Submission { get; set; }

        [JsonProperty("stats")]
        public Stats Stats { get; set; }

        [JsonProperty("camera")]
        public Dictionary<string, string> Camera { get; private set; }
        
        [JsonProperty("collections")]
        public List<CollectionInfo> Collections { get; private set; }
    }
}
