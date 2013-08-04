using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamRoomPortable.RoomModel
{
    [ImplementPropertyChanged]
    internal class UserChatPreferences
    {
        public bool AudioNotificationState { get; set; }
    }

}
