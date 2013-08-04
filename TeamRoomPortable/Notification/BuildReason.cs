using Newtonsoft.Json;
using PropertyChanged;

namespace TeamRoomPortable.Notification
{
    [ImplementPropertyChanged]
    public class BuildReason
    {
        [JsonProperty("reason")]
        public string Reason { get; set; }

        [JsonProperty("requestedBy")]
        public string RequestedBy { get; set; }

        [JsonProperty("requestedFor")]
        public string RequestedFor { get; set; }
    }
}