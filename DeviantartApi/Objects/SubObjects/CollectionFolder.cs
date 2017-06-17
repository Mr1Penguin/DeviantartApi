using Newtonsoft.Json;
using System.Collections.Generic;

namespace DeviantartApi.Objects.SubObjects
{
    public class CollectionFolder
    {
        [JsonProperty("folderid")]
        public string FolderId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("size")]
        public int Size { get; set; }

        [JsonProperty("deviations")]
        public List<Deviation> Deviation { get; set; }
    }
}
