using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeviantartApi.Objects
{
    public class StashItem : StashMetadata
    {
        [JsonProperty("itemid")]
        new public int ItemId { get; set; }
    }
}
