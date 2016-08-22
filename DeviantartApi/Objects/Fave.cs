using Newtonsoft.Json;

namespace DeviantartApi.Objects
{
    public class Fave : BaseObject
    {
        [JsonProperty("favourites")]
        public int Favourites { get; set; }
    }
}
