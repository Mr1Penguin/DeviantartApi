using Newtonsoft.Json;

namespace DeviantartApi.Objects
{
    public class Country
    {
        [JsonProperty("countryid")]
        public int CountryId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
