using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace DeviantartApi.Objects.SubObjects
{
    public class ProfileFeedItem
    {
        [JsonProperty("ts")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime TimeStamp { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("by_user")]
        public User ByUser { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }

        [JsonProperty("deviations")]
        public List<Deviation> Deviations { get; set; }

        [JsonProperty("comment")]
        public Comment Comment { get; set; }

        [JsonProperty("comment_parent")]
        public Comment CommentParent { get; set; }

        [JsonProperty("comment_deviation")]
        public Deviation CommentDeviation { get; set; }

        [JsonProperty("comment_profile")]
        public User CommentProfile { get; set; }

        [JsonProperty("critique_text")]
        public string CritiqueText { get; set; }

        [JsonProperty("collection")]
        public SubObjects.Collection Collection { get; set; }

        [JsonProperty("formerly")]
        public string Formerly { get; set; }

        [JsonProperty("poll")]
        public SubObjects.Poll Poll { get; set; }
    }
}
