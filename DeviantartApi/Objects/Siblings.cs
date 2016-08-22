using Newtonsoft.Json;

namespace DeviantartApi.Objects
{
    public class Siblings : DeviationComments
    {
        [JsonProperty("context")]
        public ContextClass Context { get; set; }

        public class ContextClass
        {
            [JsonProperty("parent")]
            public Comment Parent { get; set; }

            [JsonProperty("item_profile")]
            public User ItemProfile { get; set; }

            [JsonProperty("item_devation")]
            public Deviation ItemDeviation { get; set; }

            [JsonProperty("item_status")]
            public Status ItemStatus { get; set; }
        }
    }
}
