using DeviantartApi.Objects.SubObjects.Status;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace DeviantartApi.Objects
{
    public class Status : BaseObject
    {
        [JsonProperty("statusid")]
        public string StatusId { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("ts")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime TimeStamp { get; set; }

        [JsonProperty("url")]
        [JsonConverter(typeof(Converters.UriConverter))]
        public Uri Url { get; set; }

        [JsonProperty("comments_count")]
        public int CommentsCount { get; set; }

        [JsonProperty("is_share")]
        public bool IsShare { get; set; }

        [JsonProperty("is_deleted")]
        public bool IsDeleted { get; set; }

        [JsonProperty("author")]
        public User Author { get; set; }

        [JsonProperty("items")]
        public List<Item> Items { get; private set; }
    }
}
