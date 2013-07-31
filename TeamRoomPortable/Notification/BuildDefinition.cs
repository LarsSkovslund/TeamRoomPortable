using Newtonsoft.Json;

namespace TeamRoomPortable.Notification
{
    public class BuildDefinition
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("uri")]
        public string Uri { get; set; }
    }
}