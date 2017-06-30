using DeviantartApi.Objects.SubObjects.DeviationMetadata;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DeviantartApi.Objects
{
    public class DeviationMetadata : BaseObject
    {
        [JsonProperty("metadata")]
        public List<Metadata> Metadata { get; private set; }
    }
}
