using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace DeviantartApi.Objects
{
    public class User : BaseObject
    {
        [JsonProperty("userid")]
        public string UserId { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("usericon")]
        public string UserIcon { get; set; }

        [JsonProperty("type")]
        [JsonConverter(typeof(UserTypeEnumConverter))]
        public UserType Type { get; set; }

        [JsonProperty("is_watching")]
        public bool IsWatching { get; set; }

        [JsonProperty("details")]
        public UserDetails Details { get; set; }

        [JsonProperty("geo")]
        public UserGeo Geo { get; set; }

        [JsonProperty("profile")]
        public UserProfile Profile { get; set; }

        [JsonProperty("stats")]
        public UserStats Stats { get; set; }

        public enum UserType
        {
            Regular,
            Premium,
            Unknown
        }

        public class UserDetails
        {
            [JsonProperty("sex")]
            public string Sex { get; set; }

            [JsonProperty("age")]
            public int Age { get; set; }

            [JsonProperty("joindate")]
            [JsonConverter(typeof(IsoDateTimeConverter))]
            public DateTime? JoinDate { get; set; }
        }

        public class UserGeo
        {
            [JsonProperty("country")]
            public string Country { get; set; }

            [JsonProperty("countryid")]
            public int CountryId { get; set; }

            [JsonProperty("timezone")]
            public string Timezone { get; set; }
        }

        public class UserProfile
        {
            [JsonProperty("user_is_artist")]
            public bool UserIsArtist { get; set; }

            [JsonProperty("artist_level")]
            public string ArtistLevel { get; set; }

            [JsonProperty("artist_speciality")]
            public string ArtistSpeciality { get; set; }

            [JsonProperty("real_name")]
            public string RealName { get; set; }

            [JsonProperty("tagline")]
            public string TagLine { get; set; }

            [JsonProperty("website")]
            public string Website { get; set; }

            [JsonProperty("cover_photo")]
            public string CoverPhoto { get; set; }

            [JsonProperty("profile_pic")]
            public Deviation ProfilePic { get; set; }
        }

        public class UserStats
        {
            [JsonProperty("watchers")]
            public int Watchers { get; set; }

            [JsonProperty("friends")]
            public int Friends { get; set; }
        }

        private class UserTypeEnumConverter : JsonConverter
        {
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                var userType = (UserType)value;
                writer.WriteValue(userType.ToString().ToLower());
            }

            public override bool CanConvert(Type objectType)
            {
                return objectType == typeof(string);
            }

            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                var enumString = (string)reader.Value;
                var userType = UserType.Unknown;

                switch (enumString)
                {
                    case "regular":
                        userType = UserType.Regular;
                        break;

                    case "premium":
                        userType = UserType.Premium;
                        break;
                }

                return userType;
            }
        }
    }
}
