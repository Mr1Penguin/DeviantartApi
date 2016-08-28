using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace DeviantartApi.Objects
{
    public class Notifications : Pageable
    {
        [JsonProperty("items")]
        public List<Notification> Items { get; set; }

        public class Notification
        {
            [JsonProperty("ts")]
            [JsonConverter(typeof(IsoDateTimeConverter))]
            public DateTime TimeStamp { get; set; }

            [JsonProperty("type")]
            [JsonConverter(typeof(EventTypeEnumConverter))]
            public EventType Type { get; set; }

            [JsonProperty("by_user")]
            public User ByUser { get; set; }

            [JsonProperty("deviations")]
            public List<Deviation> Deviations { get; set; }

            [JsonProperty("comment")]
            public Comment Comment { get; set; }

            [JsonProperty("comment_parent")]
            public Comment CommentParent { get; set; }

            [JsonProperty("comment_deviation")]
            public Deviation CommentDeviation { get; set; }

            [JsonProperty("comment_profile")]
            public User CommentProfile { get; set; }

            [JsonProperty("status")]
            public Status Status { get; set; }

            [JsonProperty("comment_status")]
            public Status CommentStatus { get; set; }

            public enum EventType
            {
                Reply,
                CommentDeviation,
                CommentProfile,
                MentionDeviationInDeviation,
                MentionUserInDeviation,
                MentionDeviationInComment,
                MentionUserInComment,
                MentionDeviationInStatus,
                MentionUserInStatus,
                Watch,
                Favourite,
                Unknown
            }

            private class EventTypeEnumConverter : JsonConverter
            {
                public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
                {
                    var eventType = (EventType)value;
                    var str = Regex.Replace(eventType.ToString(), @"(?<!_)([A-Z])", "_$1");
                    if (eventType.ToString()[0] != str[0])
                        str = str.Remove(0, 1);
                    writer.WriteValue(str.ToLower());
                }

                public override bool CanConvert(Type objectType)
                {
                    return objectType == typeof(string);
                }

                public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
                {
                    var enumString = (string)reader.Value;
                    var eventType = EventType.Unknown;

                    switch (enumString)
                    {
                        case "reply":
                            eventType = EventType.Reply;
                            break;

                        case "comment_deviation":
                            eventType = EventType.CommentDeviation;
                            break;

                        case "comment_profile":
                            eventType = EventType.CommentProfile;
                            break;

                        case "mention_deviation_in_deviation":
                            eventType = EventType.MentionDeviationInDeviation;
                            break;

                        case "mention_user_in_deviation":
                            eventType = EventType.MentionUserInDeviation;
                            break;

                        case "mention_deviation_in_comment":
                            eventType = EventType.MentionDeviationInComment;
                            break;

                        case "mention_user_in_comment":
                            eventType = EventType.MentionUserInComment;
                            break;

                        case "mention_deviation_in_status":
                            eventType = EventType.MentionDeviationInStatus;
                            break;

                        case "mention_user_in_status":
                            eventType = EventType.MentionUserInStatus;
                            break;

                        case "watch":
                            eventType = EventType.Watch;
                            break;

                        case "favourite":
                            eventType = EventType.Favourite;
                            break;
                    }

                    return eventType;
                }
            }
        }
    }
}
