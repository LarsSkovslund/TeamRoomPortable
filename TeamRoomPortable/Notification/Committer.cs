using Newtonsoft.Json;

namespace TeamRoomPortable.Notification
{
    public class Committer
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }
    }
}
