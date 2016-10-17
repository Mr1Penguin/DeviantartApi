using Newtonsoft.Json;

namespace DeviantartApi.Objects
{
    public class Download : BaseObject
    {
        [JsonProperty("src")]
        public string Src { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("filesize")]
        public int Filesize { get; set; }
    }
}
