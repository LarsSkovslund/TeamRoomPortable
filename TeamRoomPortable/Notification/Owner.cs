using Newtonsoft.Json;
using PropertyChanged;

namespace TeamRoomPortable.Notification
{
    [ImplementPropertyChanged]
    public class Owner
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }
    }
}
