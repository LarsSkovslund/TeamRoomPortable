using System.Collections.Generic;

namespace TeamRoomPortable.RoomModel
{
    internal class RoomModelInfo
    {
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public bool CanManageUsers { get; set; }
        public string ServiceAccountId { get; set; }
        public UserChatPreferences UserChatPreferences { get; set; }
        public List<Member> Members { get; set; }
        public object TeamDefaults { get; set; }
    }
}
