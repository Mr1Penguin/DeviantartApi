using Newtonsoft.Json;

namespace DeviantartApi.Objects
{
    public class Folder : ArrayOfResults<Deviation>
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
