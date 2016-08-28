using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeviantartApi.Objects
{
    public class Information : BaseObject
    {
        [JsonProperty("text")]
        public string Text { get; set; }
    }
}
