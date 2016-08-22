using Newtonsoft.Json;
using System.Collections.Generic;

namespace DeviantartApi.Objects
{
    public class DeviationComments : Pageable
    {
        [JsonProperty("thread")]
        public List<Comment> Comments { get; set; }
    }
}
