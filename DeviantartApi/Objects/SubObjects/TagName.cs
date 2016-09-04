using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeviantartApi.Objects.SubObjects
{
    public class TagNameItem
    {
        [JsonProperty("tag_name")]
        public string TagName { get; set; }
    }
}
