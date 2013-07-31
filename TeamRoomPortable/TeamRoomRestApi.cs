using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TeamRoomPortable.Chat;
using TeamRoomPortable.Profile;

namespace TeamRoomPortable
{
	/// <summary>
	/// Represents a raw Team Room REST api for Team Foundation Service.
	/// </summary>
	public class TeamRoomRestApi
	{
		/// <summary>
		/// REST resources used
		/// </summary>
		private static class Resources
		{
			public const string Rooms = "/DefaultCollection/_apis/Chat/rooms";
            public const string RoomById = "/DefaultCollection/_apis/Chat/rooms/{0}";
            public const string Messages = "/DefaultCollection/_apis/Chat/rooms/{0}/Messages";
			public const string MessagesWithFilter = "/DefaultCollection/_apis/Chat/rooms/{0}/Messages?$filter={1}";
			public const string Users = "/DefaultCollection/_apis/Chat/rooms/{0}/Users";
			public const string SpecificUser = "/DefaultCollection/_apis/Chat/rooms/{0}/Users/{1}";
			public const string UserProfile = "/DefaultCollection/_api/_common/GetUserProfile?__v=4";
		}

		private readonly Uri _tfsBaseUri;
		private readonly HttpMessageHandler _messageHandler;

		/// <summary>
		/// Instanciate an instance
		/// </summary>
		/// <param name="tfsBaseUri">Base uri for Team Foundation Service e.g. https://{account}.visualstudio.com</param>
        /// <param name="userName">User name (secondary)</param>
		/// <param name="password">Password in plain text</param>
        public TeamRoomRestApi(Uri tfsBaseUri, string userName, string password)
		{
			if (tfsBaseUri == null) throw new ArgumentNullException("tfsBaseUri");
			if (userName == null) throw new ArgumentNullException("userName");
			if (password == null) throw new ArgumentNullException("password");

			_tfsBaseUri = tfsBaseUri;
			_messageHandler = new BasicAuthenticationMessageHandler(userName, password);
		}

		/// <summary>
		/// Get profile information on signed in user.
		/// </summary>
		/// <returns>Profile information or null if not found</returns>
		public async Task<UserProfile> GetUserProfileAsync()
		{
			return await GetAsync<UserProfile>(GetUri(Resources.UserProfile));
		}

		/// <summary>
		/// Gets the rooms available for user.
		/// </summary>
		/// <remarks>All available team rooms are returned even if you don't have access to it.</remarks>
		/// <returns>List of team rooms</returns>
		public async Task<IEnumerable<TeamRoom>> GetTeamRoomsAsync()
		{
            var rooms = await GetAsync<TeamRoomContainer>(GetUri(Resources.Rooms));
			return rooms.Rooms ?? Enumerable.Empty<TeamRoom>();
		}

		/// <summary>
		/// Get messages for a given team room async.
		/// </summary>
		/// <param name="teamRoom">Chat room to get message from</param>
		/// <returns>List of chat messages</returns>
		public async Task<IEnumerable<Message<object>>> GetMessagesAsync(TeamRoom teamRoom)
		{
			if (teamRoom == null) throw new ArgumentNullException("teamRoom");

			var messages = await GetAsync<MessagesContainer>(GetUri(Resources.Messages, teamRoom.Id));
			return messages.Messages ?? Enumerable.Empty<Message<object>>();
		}

		/// <summary>
		/// Get chat messages with a filter applied
		/// </summary>
		/// <remarks>
		/// The only OData filter supported by the API is currently PostedDate.
		/// Date needs to be formated according to the UserProfile
		/// </remarks>
		/// <example>PostedTime ge 06/10/2013 and PostedTime lt 06/20/2013</example>
		/// <param name="teamRoom"></param>
		/// <param name="filter"></param>
		/// <returns></returns>
        public async Task<IEnumerable<Message<dynamic>>> GetMessagesAsync(TeamRoom teamRoom, string filter)
		{
			if (teamRoom == null) throw new ArgumentNullException("teamRoom");

			var messages = await GetAsync<MessagesContainer>(GetUri(Resources.MessagesWithFilter, teamRoom.Id, filter));
            return messages.Messages ?? Enumerable.Empty<Message<object>>();
		}

		/// <summary>
		/// Post a message to a given team room
		/// </summary>
		/// <param name="teamRoom">Team room to post message to</param>
		/// <param name="message">Message to post</param>
		/// <returns>The message posted</returns>
		public async Task<Message<string>> PostMessageAsync(TeamRoom teamRoom, string message)
		{
			if (teamRoom == null) throw new ArgumentNullException("teamRoom");
			if (message == null) throw new ArgumentNullException("message");

            return await PostAsync<Message<string>>(new { content = message }, GetUri(Resources.Messages, teamRoom.Id));
		}

		/// <summary>
		/// Get users with access to a given team room.
		/// </summary>
		/// <param name="teamRoom">Team room to query for users</param>
		/// <returns>Users in team room</returns>
		public async Task<IEnumerable<User>> GetUsersAsync(TeamRoom teamRoom)
		{
			if (teamRoom == null) throw new ArgumentNullException("teamRoom");

            var users = await GetAsync<UsersContainer>(GetUri(Resources.Users, teamRoom.Id));
			return users.Users ?? Enumerable.Empty<User>();
		}

		/// <summary>
		/// Join me to a team room
		/// </summary>
		/// <param name="teamRoom">Team room to join</param>
		/// <param name="profile">Profile to join with</param>
		public async Task JoinTeamRoomAsync(TeamRoom teamRoom, UserProfile profile)
		{
			if (teamRoom == null) throw new ArgumentNullException("teamRoom");
			if (profile == null) throw new ArgumentNullException("profile");

			await PutAsync<string>(
				new { UserId = profile.Identity.TeamFoundationId },
				GetUri(Resources.SpecificUser, teamRoom.Id, profile.Identity.TeamFoundationId)
            );
		}

		/// <summary>
		/// Leave team room
		/// </summary>
		/// <param name="teamRoom">Team room to leave</param>
		/// <param name="profile">Me</param>
		public async Task LeaveTeamRoomAsync(TeamRoom teamRoom, UserProfile profile)
		{
			if (teamRoom == null) throw new ArgumentNullException("teamRoom");
			if (profile == null) throw new ArgumentNullException("profile");

			await DeleteAsync(GetUri(Resources.SpecificUser, teamRoom.Id, profile.Identity.TeamFoundationId));
		}

        /// <summary>
        /// Create a new team room.
        /// </summary>
        /// <remarks>Please note that when you create a new team room to you to manage users and events through web access.</remarks>
        /// <exception cref="ArgumentNullException">if name is null</exception>
        /// <param name="name">Name of team room</param>
        /// <param name="description">Description of team room</param>
        /// <returns>Newly created team room</returns>
	    public async Task<TeamRoom> CreateTeamRoomAsync(string name, string description)
	    {
	        if (name == null) throw new ArgumentNullException("name");

	        var room = new {Name = name, Description = description ?? string.Empty};
	        var roomCreated = await PostAsync<TeamRoom>(room, GetUri(Resources.Rooms));

	        return roomCreated;
	    }

        /// <summary>
        /// Delete an existing team room.
        /// </summary>
        /// <exception cref="ArgumentNullException">if team room is null</exception>
        /// <param name="teamRoom">Team room to delete</param>
        /// <returns></returns>
	    public async Task DeleteTeamRoomAsync(TeamRoom teamRoom)
        {
            if (teamRoom == null) throw new ArgumentNullException("teamRoom");

            await DeleteAsync(GetUri(Resources.RoomById, teamRoom.Id));
        }


        protected virtual async Task<TResult> PostAsync<TResult>(object content, Uri requestUri)
		{
			var client = new HttpClient(_messageHandler);

			var postMessage = JsonConvert.SerializeObject(content);
			var response = await client.PostAsync(requestUri, new StringContent(postMessage, Encoding.UTF8, "application/json"));
			response.EnsureSuccessStatusCode();

			var result = await response.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<TResult>(result);
		}

        protected virtual async Task<TResult> PutAsync<TResult>(object content, Uri requestUri)
		{
			var client = new HttpClient(_messageHandler);

			var postMessage = JsonConvert.SerializeObject(content);
			var response = await client.PutAsync(requestUri, new StringContent(postMessage, Encoding.UTF8, "application/json"));
			response.EnsureSuccessStatusCode();

			var result = await response.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<TResult>(result);
		}

        protected virtual async Task DeleteAsync(Uri requestUri)
		{
			var client = new HttpClient(_messageHandler);

			var response = await client.DeleteAsync(requestUri);
			response.EnsureSuccessStatusCode();
		}

        protected virtual async Task<TResult> GetAsync<TResult>(Uri requestUri)
		{
			var client = new HttpClient(_messageHandler);

			var result = await client.GetStringAsync(requestUri);
			return JsonConvert.DeserializeObject<TResult>(result);
		}

	    private Uri GetUri(string resource, params object[] args)
	    {
            return new Uri(_tfsBaseUri, string.Format(resource, args));
	    }
	}
}
