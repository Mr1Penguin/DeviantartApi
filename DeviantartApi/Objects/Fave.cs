using Newtonsoft.Json;

namespace DeviantartApi.Objects
{
    public class Fave : PostResponse
    {
        [JsonProperty("favourites")]
        public int Favourites { get; set; }
    }
}
