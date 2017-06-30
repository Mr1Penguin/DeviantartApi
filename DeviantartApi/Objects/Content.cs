using Newtonsoft.Json;
using System.Collections.Generic;

namespace DeviantartApi.Objects
{
    public class Content : BaseObject
    {
        [JsonProperty("html")]
        public string Html { get; set; }

        [JsonProperty("css")]
        public string Css { get; set; }

        [JsonProperty("css_fonts")]
        public List<string> CssFonts { get; private set; }
    }
}
