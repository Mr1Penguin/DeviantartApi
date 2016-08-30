using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeviantartApi.Objects.SubObjects
{
    public class GalleryFolder : CollectonFolder
    {
        [JsonProperty("parent")]
        public string Parent { get; set; }
    }
}
