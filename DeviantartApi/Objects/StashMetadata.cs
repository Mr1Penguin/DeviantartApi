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

        [JsonProperty("Submission")]
        public SumbissionClass Submission { get; set; }

        [JsonProperty("stats")]
        public StatsClass Stats { get; set; }

        [JsonProperty("camera")]
        public Dictionary<string, string> Camera { get; set; }

        [JsonProperty("stackid")]
        public int StackId { get; set; }

        [JsonProperty("itemid")]
        public int? ItemId { get; set; }

        [JsonProperty("tags")]
        public List<string> Tags { get; set; }

        public class SumbissionClass
        {
            [JsonProperty("file_size")]
            [JsonConverter(typeof(Converters.StringToIntConverter))]
            public int FileSize { get; set; }

            [JsonProperty("resolution")]
            public string Resolution { get; set; }

            [JsonProperty("submitted_with")]
            public SubmittedWithClass SubmittedWith { get; set; }

            public class SubmittedWithClass
            {
                [JsonProperty("app")]
                public string App { get; set; }

                [JsonProperty("url")]
                public string Url { get; set; }
            }
        }

        public class StatsClass
        {
            [JsonProperty("views")]
            public int Views { get; set; }

            [JsonProperty("views_today")]
            public int ViewsToday { get; set; }

            [JsonProperty("downloads")]
            public int Downloads { get; set; }

            [JsonProperty("downloads_today")]
            public int DownloadsToday { get; set; }
        }
    }
}
