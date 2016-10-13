using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeviantartApi.Objects
{
    public class UserData : BaseObject
    {
        [JsonProperty("features")]
        public List<string> Features { get; set; }

        [JsonProperty("agreements")]
        public List<string> Agreements { get; set; }
    }
}
