using DeviantartApi.Objects.SubObjects;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DeviantartApi.Objects
{
    public class Profile : BaseObject
    {
        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("is_watching")]
        public bool IsWatching { get; set; }

        [JsonProperty("profile_url")]
        public string ProfileUrl { get; set; }

        [JsonProperty("user_is_artist")]
        public bool UserIsArtist { get; set; }

        [JsonProperty("artist_level")]
        public string ArtistLevel { get; set; }

        [JsonProperty("artist_specialty")]
        public string ArtistSpecialty { get; set; }

        [JsonProperty("real_name")]
        public string RealName { get; set; }

        [JsonProperty("tagline")]
        public string TagLine { get; set; }

        [JsonProperty("countryid")]
        public int CountrtId { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("website")]
        public string Website { get; set; }

        [JsonProperty("bio")]
        public string Bio { get; set; }

        [JsonProperty("cover_photo")]
        public string CoverPhoto { get; set; }

        [JsonProperty("profile_pic")]
        public Deviation ProfilePic { get; set; }

        [JsonProperty("last_status")]
        public Status LastStatus { get; set; }

        [JsonProperty("stats")]
        public StatsClass Stats { get; set; }

        [JsonProperty("collections")]
        public List<CollectionFolder> Collections { get; set; }

        [JsonProperty("galleries")]
        public List<GalleryFolder> Galleries { get; set; }

        public class StatsClass
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
}
