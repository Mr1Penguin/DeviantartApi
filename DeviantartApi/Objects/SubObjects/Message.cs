using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeviantartApi.Objects.SubObjects
{
    public class Message
    {
        [JsonProperty("messageid")]
        public string MessageId { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }//would be nice if someone collect all types

        [JsonProperty("orphaned")]
        public bool Orphaned { get; set; }

        [JsonProperty("ts")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime TimeStamp { get; set; }

        [JsonProperty("stackid")]
        public string StackId { get; set; }

        [JsonProperty("stack_count")]
        public int StackCount { get; set; }

        [JsonProperty("originator")]
        public User Originator { get; set; }

        [JsonProperty("subject")]
        public MessageSubject Subject { get; set; }

        [JsonProperty("html")]
        public string Html { get; set; }

        [JsonProperty("profile")]
        public User Profile { get; set; }

        [JsonProperty("deviation")]
        public Deviation Deviation { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }

        [JsonProperty("comment")]
        public Comment Comment { get; set; }

        [JsonProperty("collection")]
        public Collection Collection { get; set; }

        public class MessageSubject
        {
            [JsonProperty("profile")]
            public User Profile { get; set; }

            [JsonProperty("deviation")]
            public Deviation Deviation { get; set; }

            [JsonProperty("status")]
            public Status Status { get; set; }

            [JsonProperty("comment")]
            public Comment Comment { get; set; }

            [JsonProperty("collection")]
            public Collection Collection { get; set; }

            [JsonProperty("gallery")]
            public Collection Gallery { get; set; }
        }
    }
}
