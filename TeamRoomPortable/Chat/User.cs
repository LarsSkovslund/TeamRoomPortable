using System;
using Newtonsoft.Json;

namespace TeamRoomPortable.Chat
{
	public class User
	{
		[JsonProperty("roomId")]
		public int RoomId { get; set; }

		/// <summary>
		/// TFS user identity
		/// </summary>
		[JsonProperty("userId")]
		public string UserId { get; set; }

		[JsonProperty("lastActivity")]
		public string LastActivity { get; set; }

		[JsonProperty("joinedDate")]
		public DateTime JoinedDate { get; set; }

		[JsonProperty("isOnline")]
		public bool IsOnline { get; set; }
	}
}