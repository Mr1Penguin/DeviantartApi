﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeviantartApi.Objects.SubObjects
{
    public class Poll
    {
        [JsonProperty("question")]
        public string Question { get; set; }

        [JsonProperty("total_votes")]
        public int TotalVotes { get; set; }

        [JsonProperty("answers")]
        public List<PollAnswer> Answers { get; set; }
    }
}
