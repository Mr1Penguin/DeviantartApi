using Newtonsoft.Json;
using System.Collections.Generic;

namespace DeviantartApi.Objects
{
    public class Folders<Folder> : Pageable where Folder : SubObjects.CollectonFolder
    {
        [JsonProperty("results")]
        public List<Folder> Results { get; set; }
    }
}
