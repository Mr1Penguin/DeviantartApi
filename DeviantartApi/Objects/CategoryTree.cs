using DeviantartApi.Objects.SubObjects.CategoryTree;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DeviantartApi.Objects
{
    public class CategoryTree : BaseObject
    {
        [JsonProperty("categories")]
        public List<Category> Categories { get; set; }
    }
}
