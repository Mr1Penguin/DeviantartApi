using Newtonsoft.Json;
using System.Collections.Generic;

namespace DeviantartApi.Objects
{
    public class Userdata : BaseObject
    {
        [JsonProperty("features")]
        public List<string> Features { get; private set; }

        [JsonProperty("agreements")]
        public List<string> Agreements { get; private set; }
    }
}
