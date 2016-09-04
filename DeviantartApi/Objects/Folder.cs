using Newtonsoft.Json;
using System.Collections.Generic;

namespace DeviantartApi.Objects
{
    public class Folder : ArrayOfResults<Deviation>
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
