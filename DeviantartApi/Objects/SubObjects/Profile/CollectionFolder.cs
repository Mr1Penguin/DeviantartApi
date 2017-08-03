using Newtonsoft.Json;
using System.Collections.Generic;

namespace DeviantartApi.Objects.SubObjects.Profile
{
    public class CollectionFolder : BaseObject
    {
        [JsonProperty("folderid")]
        public string FolderId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("size")]
        public int Size { get; set; }

        [JsonProperty("deviations")]
        public List<Objects.Deviation> Deviations { get; private set; }
    }
}
