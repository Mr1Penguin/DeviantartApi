using DeviantartApi.Objects.SubObjects.User;
using Newtonsoft.Json;
using System;

namespace DeviantartApi.Objects
{
    public enum UserType
    {
        Regular,
        Premium,
        Unknown
    }

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
        public UserType UserType { get; set; }

        [JsonProperty("is_watching")]
        public bool IsWatching { get; set; }

        [JsonProperty("details")]
        public Details Details { get; set; }

        [JsonProperty("geo")]
        public Geo Geo { get; set; }

        [JsonProperty("profile")]
        public Profile Profile { get; set; }

        [JsonProperty("stats")]
        public Stats Stats { get; set; }

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
