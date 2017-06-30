using DeviantartApi.Objects.SubObjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DeviantartApi.Objects
{
    public class Deviation : BaseObject
    {
        [JsonProperty("deviationid")]
        public string DeviationId { get; set; }

        [JsonProperty("printId")]
        public string PrintId { get; set; }

        [JsonProperty("url")]
        [JsonConverter(typeof(Converters.UriConverter))]
        public Uri Url { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("category_path")]
        public string CategoryPath { get; set; }

        [JsonProperty("is_favourited")]
        public bool IsFavourited { get; set; }

        [JsonProperty("is_deleted")]
        public bool IsDeleted { get; set; }

        [JsonProperty("author")]
        public User Author { get; set; }

        [JsonProperty("stats")]
        public Stats Stats { get; set; }

        [JsonProperty("published_time")]
        [JsonConverter(typeof(Converters.UnixDateTimeConverter))]
        public DateTime PublishedTime { get; set; }

        [JsonProperty("allows_comments")]
        public bool AllowComments { get; set; }

        [JsonProperty("preview")]
        public Image Preview { get; set; }

        [JsonProperty("content")]
        public Image Content { get; set; }

        [JsonProperty("thumbs")]
        public List<Image> Thumbs { get; private set; }

        [JsonProperty("videos")]
        public List<Video> Videos { get; private set; }

        [JsonProperty("flash")]
        public Flash Flash { get; set; }

        [JsonProperty("daily_deviation")]
        public DailyDeviation DailyDeviation { get; set; }

        [JsonProperty("excerpt")]
        public string Excerpt { get; set; }

        [JsonProperty("is_mature")]
        public bool IsMature { get; set; }

        [JsonProperty("id_downloadable")]
        public bool IsDownloadable { get; set; }

        [JsonProperty("download_filesize")]
        public int DownloadFilesize { get; set; }

        [JsonProperty("challenge")]
        public Dictionary<string, object> Challenge { get; private set; }

        [JsonProperty("challenge_entry")]
        public ChallengeEntry ChallengeEntry { get; set; }

        [JsonProperty("motion_book")]
        public MotionBook MotionBook { get; set; }
    }
}
