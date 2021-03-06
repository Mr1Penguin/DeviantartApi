﻿using Newtonsoft.Json;

namespace DeviantartApi.Objects.SubObjects.StashMetadata
{
    public class MetadataStats
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
