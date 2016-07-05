using Newtonsoft.Json;

namespace DeviantartApi.Objects
{
    public class BaseObject
    {
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("error")]
        public string Error { get; set; }
        [JsonProperty("error_description")]
        public string ErrorDescription { get; set; }
        [JsonProperty("error_code")]
        public int ErrorCode { get; set; }
    }
}
