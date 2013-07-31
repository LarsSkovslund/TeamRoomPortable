using System;
using Newtonsoft.Json;

namespace TeamRoomPortable.Chat
{
	public class TeamRoom
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }

		[JsonProperty("lastActivity")]
		public string LastActivity { get; set; }

		[JsonProperty("isClosed")]
		public bool IsClosed { get; set; }

		[JsonProperty("creatorUserTfId")]
		public string CreatorUserTfId { get; set; }

		[JsonProperty("createdDate")]
		public DateTime CreatedDate { get; set; }

        [JsonProperty("hasAdminPermissions")]
        public bool HasAdminPermissions { get; set; }

        [JsonProperty("hasReadWritePermissions")]
        public bool HasReadWritePermissions { get; set; }
	}
}