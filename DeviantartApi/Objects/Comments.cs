using Newtonsoft.Json;
using System.Collections.Generic;

namespace DeviantartApi.Objects
{
    public class Comments : Pageable
    {
        [JsonProperty("thread")]
        public List<Comment> Thread { get; private set; }
    }
}
