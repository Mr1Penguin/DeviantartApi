using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeviantartApi.Objects
{
    public class ArrayOfItems<T> : Pageable
    {
        [JsonProperty("items")]
        public List<T> Items { get; set; }
    }
}
