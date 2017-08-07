using Newtonsoft.Json;

namespace DeviantartApi.Objects
{
    public class SendNoteResponse : PostResponse
    {
        [JsonProperty("user")]
        User User { get; set; }
    }
}
