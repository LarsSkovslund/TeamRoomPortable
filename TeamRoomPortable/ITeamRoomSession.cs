using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeamRoomPortable.Chat;

namespace TeamRoomPortable
{
    public interface ITeamRoomSession
    {
        /// <summary>
        /// Name of team room
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Description of team room
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Leave team room.
        /// </summary>
        /// <returns></returns>
        Task Leave();

        /// <summary>
        /// Gets todays messages from team room
        /// </summary>
        /// <returns>List of messages</returns>
        Task<IEnumerable<Message<object>>> GetMessagesAsync();

        /// <summary>
        /// Get a list of messages from <see cref="fromDate"/> to <see cref="toDate"/>
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns>List of messages</returns>
        Task<IEnumerable<Message<object>>> GetMessagesAsync(DateTime fromDate, DateTime toDate);

        /// <summary>
        /// Post chat message to team room
        /// </summary>
        /// <param name="message">Message to post</param>
        /// <returns>Message posted</returns>
        Task<Message<string>> PostMessageAsync(string message);
    }
}