using Newtonsoft.Json;

namespace DeviantartApi.Objects.SubObjects.Deviation
{
    public class Image
    {
        [JsonProperty("src")]
        public string Src { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("transparency")]
        public bool Transparency { get; set; }

        [JsonProperty("filesize")]
        public int Filesize { get; set; }
    }
}
