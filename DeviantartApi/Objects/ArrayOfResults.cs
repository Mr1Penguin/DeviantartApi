using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeviantartApi.Objects
{
    public class ArrayOfResults<T> : Pageable
    {
        [JsonProperty("results")]
        public List<T> Results { get; set; }
    }
}
