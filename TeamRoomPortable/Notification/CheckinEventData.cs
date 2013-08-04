using Newtonsoft.Json;
using PropertyChanged;

namespace TeamRoomPortable.Notification
{
    [ImplementPropertyChanged]
    public class CheckinEventData
    {
        [JsonProperty("changeSetNumber")]
        public int ChangeSetNumber { get; set; }

        [JsonProperty("comment")]
        public string Comment { get; set; }

        [JsonProperty("owner")]
        public Owner Owner { get; set; }

        [JsonProperty("committer")]
        public Committer Committer { get; set; }

        [JsonProperty("changes")]
        public Changes Changes { get; set; }
    }
}
