using Newtonsoft.Json;
using System.Collections.Generic;

namespace DeviantartApi.Objects
{
    public class ArrayOfItems<T> : Pageable
    {
        [JsonProperty("items")]
        public List<T> Items { get; set; }
    }
}
