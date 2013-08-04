using Newtonsoft.Json;
using PropertyChanged;

namespace TeamRoomPortable.Notification
{
    [ImplementPropertyChanged]
    public class CodeReviewChangedEventData
    {
        [JsonProperty("requestor")]
        public string Requestor { get; set; }

        [JsonProperty("workItemId")]
        public int WorkItemId { get; set; }

        [JsonProperty("workItemType")]
        public string WorkItemType { get; set; }

        [JsonProperty("changes")]
        public Changes Changes { get; set; }
    }
}
