using Newtonsoft.Json;

namespace TeamRoomPortable.RoomModel
{
    internal class RoomModelRootObject
    {
        [JsonProperty("roomModel")]
        public RoomModelInfo RoomModel { get; set; }
    }
}
