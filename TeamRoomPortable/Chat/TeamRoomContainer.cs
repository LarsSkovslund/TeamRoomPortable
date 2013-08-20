using System.Collections.Generic;
using Newtonsoft.Json;

namespace TeamRoomPortable.Chat
{
	/// <summary>
	/// Standard container class for TFS, only used internally and converted to IEnumerable externally.
	/// </summary>
	internal class TeamRoomContainer
	{
		[JsonProperty("count")]
		public int Count { get; set; }

		[JsonProperty("value")]
		public List<TeamRoom> Rooms { get; set; }
	}
}