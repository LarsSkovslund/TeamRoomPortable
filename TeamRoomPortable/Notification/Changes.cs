using Newtonsoft.Json;
using PropertyChanged;

namespace TeamRoomPortable.Notification
{
    [ImplementPropertyChanged]
    public class Changes
    {
        [JsonProperty("add")]
        public int Add { get; set; }

        [JsonProperty("delete")]
        public int Delete { get; set; }

        [JsonProperty("edit")]
        public int Edit { get; set; }
    }
}
