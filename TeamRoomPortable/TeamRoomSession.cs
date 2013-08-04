using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeamRoomPortable.Chat;
using TeamRoomPortable.Profile;
using TeamRoomPortable.RoomModel;

namespace TeamRoomPortable
{
    internal class TeamRoomSession : ITeamRoomSession
    {
        private readonly TeamRoomRestApi _api;
        private readonly TeamRoom _teamRoom;
        private readonly UserProfile _profile;

        public TeamRoomSession(TeamRoomRestApi api, TeamRoom teamRoom, UserProfile profile, IEnumerable<Member> members)
        {
            if (api == null) throw new ArgumentNullException("api");
            if (teamRoom == null) throw new ArgumentNullException("teamRoom");
            if (profile == null) throw new ArgumentNullException("profile");
            if (members == null) throw new ArgumentNullException("members");

            _api = api;
            _teamRoom = teamRoom;
            _profile = profile;

            Members = members;
            Name = _teamRoom.Name;
            Description = _teamRoom.Description;
        }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public IEnumerable<Member> Members { get; private set; }

        public async Task Leave()
        {
            await _api.LeaveTeamRoomAsync(_teamRoom, _profile);
        }

        public async Task<IEnumerable<Message<object>>> GetMessagesAsync()
        {
            return await _api.GetMessagesAsync(_teamRoom);
        }

        public async Task<IEnumerable<Message<object>>> GetMessagesAsync(DateTime fromDate, DateTime toDate)
        {
            // Date format must match the selected settings from the users profile in WebAccess.
            var dateFormatPattern = _profile.UserPreferences.DatePattern;
            var filter = string.Format("postedtime ge {0} and postedtime lt {1}", fromDate.ToString(dateFormatPattern), toDate.ToString(dateFormatPattern));

            return await _api.GetMessagesAsync(_teamRoom, filter);
        }

        public async Task<Message<string>> PostMessageAsync(string message)
        {
            if (message == null) throw new ArgumentNullException("message");

            var msg = await _api.PostMessageAsync(_teamRoom, message);
            return msg;
        }
    }
}