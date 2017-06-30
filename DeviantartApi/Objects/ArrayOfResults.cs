using Newtonsoft.Json;
using System.Collections.Generic;

namespace DeviantartApi.Objects
{
    public class ArrayOfResults<T> : Pageable
    {
        [JsonProperty("results")]
        public List<T> Results { get; private set; }
    }
}
