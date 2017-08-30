using DeviantartApi.Objects.SubObjects.StashMetadata;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

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
        public long ParentId { get; set; }

        [JsonProperty("thumb")]
        public SubObjects.Deviation.Image Thumb { get; set; }

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
        public List<SubObjects.Deviation.Image> Files { get; set; }

        [JsonProperty("submission")]
        public MetadataSubmission Submission { get; set; }

        [JsonProperty("stats")]
        public MetadataStats Stats { get; set; }

        [JsonProperty("camera")]
        public Dictionary<string, string> Camera { get; set; }

        [JsonProperty("stackid")]
        public long StackId { get; set; }

        [JsonProperty("itemid")]
        public long? ItemId { get; set; }

        [JsonProperty("tags")]
        public List<string> Tags { get; set; }
    }
}
