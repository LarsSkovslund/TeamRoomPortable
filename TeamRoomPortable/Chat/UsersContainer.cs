using System.Collections.Generic;
using Newtonsoft.Json;

namespace TeamRoomPortable.Chat
{
	/// <summary>
	/// Standard container class for TFS, only used internaly and converted to IEnumerable externally.
	/// </summary>
	internal class UsersContainer
	{
		[JsonProperty("count")]
		public int Count { get; set; }

		[JsonProperty("value")]
		public List<User> Users { get; set; }
	}
}