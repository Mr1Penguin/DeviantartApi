using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeviantartApi.Objects.SubObjects
{
    public class Country
    {
        [JsonProperty("countryid")]
        public int CountryId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
