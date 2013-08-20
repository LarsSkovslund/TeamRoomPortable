using Newtonsoft.Json;
using PropertyChanged;

namespace TeamRoomPortable.Notification
{
    [ImplementPropertyChanged]
    public class WorkItemChangedEventData
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("rev")]
        public int Rev { get; set; }

        [JsonProperty("workItemType")]
        public string WorkItemType { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("changedBy")]
        public string ChangedBy { get; set; }

        [JsonProperty("isNewWorkItem")]
        public bool IsNewWorkItem { get; set; }

        [JsonProperty("stateChangedValue")]
        public string StateChangedValue { get; set; }

        [JsonProperty("assignedToChangedValue")]
        public string AssignedToChangedValue { get; set; }
    }
}