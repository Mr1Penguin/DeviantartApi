using Newtonsoft.Json;

namespace DeviantartApi.Objects.SubObjects.User
{
    public class Geo
    {
        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("countryid")]
        public int CountryId { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }
    }
}
