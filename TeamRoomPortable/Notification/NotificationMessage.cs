using Newtonsoft.Json;

namespace TeamRoomPortable.Notification
{
    public class NotificationMessage
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("data")]
        public object Data { get; set; }
    }
}
