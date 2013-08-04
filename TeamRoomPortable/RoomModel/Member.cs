using Newtonsoft.Json;
using PropertyChanged;

namespace TeamRoomPortable.RoomModel
{
    [ImplementPropertyChanged]
    public class Member
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("isContainer")]
        public bool IsContainer { get; set; }

        [JsonProperty("isActive")]
        public bool IsActive { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("customDisplayName")]
        public string CustomDisplayName { get; set; }

        [JsonProperty("providerDisplayName")]
        public string ProviderDisplayName { get; set; }

        [JsonProperty("uniqueName")]
        public string UniqueName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
