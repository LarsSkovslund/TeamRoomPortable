using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeamRoomPortable.Chat;
using TeamRoomPortable.Profile;

namespace TeamRoomPortable
{
    public interface ITeamRoomClient
    {
        /// <summary>
        /// Gets profile information from logged in TFS user.
        /// </summary>
        UserProfile Profile { get; }

        /// <summary>
        /// Get a specific team room.
        /// </summary>
        /// <param name="teamRoomName">Name of team room to get</param>
        /// <returns>Team room</returns>
        Task<TeamRoom> GetTeamRoomAsync(string teamRoomName);

        /// <summary>
        /// Gets all team rooms.
        /// </summary>
        /// <returns>List of team rooms</returns>
        Task<IEnumerable<TeamRoom>> GetTeamRoomsAsync();

        /// <summary>
        /// Join a team room.
        /// </summary>
        /// <param name="teamRoom">Team room to join</param>
        /// <returns>Session for joined team room</returns>
        Task<ITeamRoomSession> Join(TeamRoom teamRoom);

        /// <summary>
        /// Gets all users for a given team room.
        /// </summary>
        /// <param name="teamRoom"></param>
        /// <returns></returns>
        Task<IEnumerable<User>> GetUsersAsync(TeamRoom teamRoom);

        /// <summary>
        /// Create a new team room.
        /// </summary>
        /// <remarks>Please note that when you create a new team room to you to manage users and events through web access.</remarks>
        /// <exception cref="ArgumentNullException">if name is null</exception>
        /// <param name="name">Name of team room</param>
        /// <param name="description">Description of team room</param>
        /// <returns>Newly created team room</returns>
        Task<TeamRoom> CreateTeamRoomAsync(string name, string description);

        /// <summary>
        /// Delete an existing team room.
        /// </summary>
        /// <exception cref="ArgumentNullException">if team room is null</exception>
        /// <param name="teamRoom">Team room to delete</param>
        Task DeleteTeamRoomAsync(TeamRoom teamRoom);
    }
}