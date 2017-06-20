using Newtonsoft.Json;
using System.Collections.Generic;

namespace DeviantartApi.Objects
{
    public class MltPreview : BaseObject
    {
        [JsonProperty("seed")]
        public string Seed { get; set; }

        [JsonProperty("Author")]
        public User Author { get; set; }

        [JsonProperty("more_from_artist")]
        public List<Deviation> MoreFromArtist { get; set; }

        [JsonProperty("more_from_da")]
        public List<Deviation> MoreFromDa { get; set; }
    }
}
