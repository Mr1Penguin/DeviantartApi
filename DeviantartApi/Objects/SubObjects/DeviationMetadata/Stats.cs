using Newtonsoft.Json;

namespace DeviantartApi.Objects.SubObjects.DeviationMetadata
{
    public class Stats
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
}
