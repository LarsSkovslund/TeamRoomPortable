using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamRoomPortable.Chat;
using TeamRoomPortable.Profile;

namespace TeamRoomPortable
{
    internal class TeamRoomClient : ITeamRoomClient
    {
        private readonly TeamRoomRestApi _api;

        /// <summary>
        /// Constructs a new team room client API for a given Team Foundation Service account, 
        /// using basic authentication (user name, password).
        /// </summary>
        /// <param name="account"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public TeamRoomClient(string account, string userName, string password)
            : this(new Uri(string.Format("https://{0}.visualstudio.com", account)), userName, password)
        { }

        public TeamRoomClient(Uri tfsAccountUri, string userName, string password)
        {
            if (tfsAccountUri == null) throw new ArgumentNullException("tfsAccountUri");
            if (userName == null) throw new ArgumentNullException("userName");
            if (password == null) throw new ArgumentNullException("password");

            _api = new TeamRoomRestApi(tfsAccountUri, userName, password);
        }

        public UserProfile Profile { get; protected set; }

        public async Task<TeamRoom> GetTeamRoomAsync(string teamRoomName)
        {
            if (teamRoomName == null) throw new ArgumentNullException("teamRoomName");

            var rooms = await _api.GetTeamRoomsAsync();

            return rooms.FirstOrDefault(r => r.Name == teamRoomName);
        }

        public async Task<IEnumerable<TeamRoom>> GetTeamRoomsAsync()
        {
            var rooms = await _api.GetTeamRoomsAsync();

            return rooms;
        }

        public async Task<ITeamRoomSession> Join(TeamRoom teamRoom)
        {
            if (teamRoom == null) throw new ArgumentNullException("teamRoom");

            var members = await _api.GetTeamMembersAsync(teamRoom);
            await _api.JoinTeamRoomAsync(teamRoom, Profile);

            return new TeamRoomSession(_api, teamRoom, Profile, members);
        }

        public async Task<IEnumerable<User>> GetUsersAsync(TeamRoom teamRoom)
        {
            if (teamRoom == null) throw new ArgumentNullException("teamRoom");

            var users = await _api.GetUsersAsync(teamRoom);

            return users;
        }

        public async Task<TeamRoom> CreateTeamRoomAsync(string name, string description)
        {
            if (name == null) throw new ArgumentNullException("name");

            var teamRoom = await _api.CreateTeamRoomAsync(name, description ?? string.Empty);

            return teamRoom;
        }

        public async Task DeleteTeamRoomAsync(TeamRoom teamRoom)
        {
            if (teamRoom == null) throw new ArgumentNullException("teamRoom");

            await _api.DeleteTeamRoomAsync(teamRoom);
        }

        public async Task Initialize()
        {
            Profile = await _api.GetUserProfileAsync();
        }
    }
}
