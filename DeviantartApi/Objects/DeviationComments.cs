using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeviantartApi.Objects
{
    public class DeviationComments : Pageable
    {
        [JsonProperty("thread")]
        public List<Comment> Comments { get; set; }
    }
}
