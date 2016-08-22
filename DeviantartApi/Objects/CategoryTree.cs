using Newtonsoft.Json;
using System.Collections.Generic;

namespace DeviantartApi.Objects
{
    public class CategoryTree : BaseObject
    {
        [JsonProperty("categories")]
        public List<Category> Categories { get; set; }

        public class Category
        {
            [JsonProperty("catpath")]
            public string Catpath { get; set; }

            [JsonProperty("title")]
            public string Title { get; set; }

            [JsonProperty("has_subcategory")]
            public bool HasSubcategory { get; set; }

            [JsonProperty("parent_catpath")]
            public string ParentCatpath { get; set; }
        }
    }
}
