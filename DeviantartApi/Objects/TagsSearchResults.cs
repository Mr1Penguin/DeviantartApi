using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

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
