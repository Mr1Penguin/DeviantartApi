using Newtonsoft.Json;
using System.Collections.Generic;

namespace DeviantartApi.Objects
{
    public class Countries : BaseObject
    {
        [JsonProperty("results")]
        public List<Country> Results { get; set; }

        public class Country
        {
            [JsonProperty("countryid")]
            public int CountryId { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }
        }
    }
}
