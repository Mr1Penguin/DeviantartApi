using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeviantartApi.Objects
{
    public class Fave : BaseObject
    {
        [JsonProperty("favourites")]
        public int Favourites { get; set; }
    }
}
