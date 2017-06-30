using Newtonsoft.Json;

namespace DeviantartApi.Objects.SubObjects.Profile
{
    public class Stats
    {
        [JsonProperty("user_deviations")]
        public int UserDeviations { get; set; }

        [JsonProperty("user_favourites")]
        public int UserFavourites { get; set; }

        [JsonProperty("user_comments")]
        public int UserComments { get; set; }

        [JsonProperty("profile_pageviews")]
        public int ProfilePageViews { get; set; }

        [JsonProperty("profile_comments")]
        public int ProfileComments { get; set; }
    }
}
