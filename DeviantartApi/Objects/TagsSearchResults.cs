using Newtonsoft.Json;
using System.Collections.Generic;

namespace DeviantartApi.Objects
{
    public class TagsSearchResults : BaseObject
    {
        [JsonProperty("results")]
        public List<TagNameClass> Results { get; set; }

        public class TagNameClass
        {
            [JsonProperty("tag_name")]
            public string TagName { get; set; }
        }
    }
}
