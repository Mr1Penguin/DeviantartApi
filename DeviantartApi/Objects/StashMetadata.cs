using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeviantartApi.Objects
{
    public class StashMetadata : BaseObject
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("size")]
        public int Size { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("parentid")]
        public int ParentId { get; set; }

        [JsonProperty("thump")]
        public SubObjects.Image Thumb { get; set; }

        [JsonProperty("artist_comments")]
        public string ArtistComment { get; set; }

        [JsonProperty("original_url")]
        public string OriginalUrl { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("creation_time")]
        [JsonConverter(typeof(Converters.UnixDateTimeConverter))]
        public DateTime CreationTime { get; set; }

        [JsonProperty("files")]
        public List<SubObjects.Image> Files { get; set; }

        [JsonProperty("submission")]
        public SubObjects.MetadataSubmission Submission { get; set; }

        [JsonProperty("stats")]
        public SubObjects.MetadataStats Stats { get; set; }

        [JsonProperty("camera")]
        public Dictionary<string, string> Camera { get; set; }

        [JsonProperty("stackid")]
        public int StackId { get; set; }

        [JsonProperty("itemid")]
        public int? ItemId { get; set; }

        [JsonProperty("tags")]
        public List<string> Tags { get; set; }
    }
}
