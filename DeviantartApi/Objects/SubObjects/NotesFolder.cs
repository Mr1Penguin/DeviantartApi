using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeviantartApi.Objects.SubObjects
{
    public class NotesFolder
    {
        [JsonProperty("folder")]
        public string Folder { get; set; }

        [JsonProperty("parentid")]
        public string ParentId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("count")]
        [JsonConverter(typeof(Converters.StringToIntConverter))]
        public int Count { get; set; }
    }
}
