using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeviantartApi.Objects.SubObjects
{
    public class PollAnswer
    {
        [JsonProperty("answer")]
        public string Answer { get; set; }

        [JsonProperty("votes")]
        public int Votes { get; set; }
    }
}
