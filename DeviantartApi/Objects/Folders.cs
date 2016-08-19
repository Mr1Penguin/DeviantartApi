using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeviantartApi.Objects
{
    public class Folders : Pageable
    {
        [JsonProperty("results")]
        public List<FolderClass> Results { get; set; }

        public class FolderClass
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
}
