using DeviantartApi.Objects.SubObjects.FeedSettings;
using Newtonsoft.Json;

namespace DeviantartApi.Objects
{
    /// <summary>
    /// If you need fields not described here leave an issue
    /// or create Request class returns FeedSettings where
    /// Includes is <c>Dictionary{string,string}</c> or <c>Dictionary{string, bool}</c>
    /// </summary>
    public class FeedSettings : BaseObject
    {
        [JsonProperty("includes")]
        public Includes Includes { get; set; }
    }
}
