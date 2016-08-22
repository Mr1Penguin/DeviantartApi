using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace DeviantartApi.Objects
{
    public class DeviationMetadata : BaseObject
    {
        [JsonProperty("metadata")]
        public List<MetadataClass> Metadata { get; set; }

        public class MetadataClass
        {
            [JsonProperty("deviationid")]
            public string DeviationId { get; set; }

            [JsonProperty("printid")]
            public string PrintId { get; set; }

            [JsonProperty("author")]
            public User Author { get; set; }

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
            public List<TagClass> Tags { get; set; }

            [JsonProperty("is_favourited")]
            public bool IsFavourited { get; set; }

            [JsonProperty("is_mature")]
            public bool IsMature { get; set; }

            [JsonProperty("submission")]
            public SubmissionClass Submission { get; set; }

            [JsonProperty("stats")]
            public StatsClass Stats { get; set; }

            [JsonProperty("camera")]
            public CameraClass Camera { get; set; }

            [JsonProperty("collections")]
            public List<CollectionClass> Collections { get; set; }

            public class TagClass
            {
                [JsonProperty("tag_name")]
                public string TagName { get; set; }

                [JsonProperty("sponsored")]
                public bool Sponsored { get; set; }

                [JsonProperty("sponsor")]
                public string Sponsor { get; set; }
            }

            public class SubmissionClass
            {
                [JsonProperty("creation_time")]
                [JsonConverter(typeof(IsoDateTimeConverter))]
                public DateTime CreationTime { get; set; }

                [JsonProperty("category")]
                public string Category { get; set; }

                [JsonProperty("file_size")]
                public string FileSize { get; set; }

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

                [JsonProperty("favourites")]
                public int Favourites { get; set; }

                [JsonProperty("comments")]
                public int Comments { get; set; }

                [JsonProperty("downloads")]
                public int Downloads { get; set; }

                [JsonProperty("downloads_today")]
                public int DownloadsToday { get; set; }
            }

            public class CameraClass
            {
                /* example required */
            }

            public class CollectionClass
            {
                [JsonProperty("folderid")]
                public string FolderId { get; set; }

                [JsonProperty("name")]
                public string Name { get; set; }
            }
        }
    }
}
