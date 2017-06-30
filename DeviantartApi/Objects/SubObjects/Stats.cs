using Newtonsoft.Json;

namespace DeviantartApi.Objects.SubObjects
{
    public class Stats
    {
        [JsonProperty("comments")]
        public int Comments { get; set; }

        [JsonProperty("favourites")]
        public int Favourites { get; set; }
    }
}
