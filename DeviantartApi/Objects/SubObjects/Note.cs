using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeviantartApi.Objects.SubObjects
{
    public class Note
    {
        [JsonProperty("noteid")]
        public string NoteId { get; set; }

        [JsonProperty("ts")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime TimeStamp { get; set; }

        [JsonProperty("unread")]
        public bool Unread { get; set; }

        [JsonProperty("starred")]
        public bool Starred { get; set; }

        [JsonProperty("sent")]
        public bool Sent { get; set; }

        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("preview")]
        public string Preview { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("recipients")]
        public List<User> Recipients { get; set; }
    }
}
