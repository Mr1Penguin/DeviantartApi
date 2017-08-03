using DeviantartApi.Objects.SubObjects.Siblings;
using Newtonsoft.Json;

namespace DeviantartApi.Objects
{
    public class Siblings : Comments
    {
        [JsonProperty("context")]
        public Context Context { get; set; }
    }
}
