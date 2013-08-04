using System;
using Newtonsoft.Json;
using PropertyChanged;

namespace TeamRoomPortable.Chat
{
    [ImplementPropertyChanged]
	public class Message<TMessageType>
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("content")]
        public TMessageType Content { get; set; }

		[JsonProperty("messageType")]
		public string MessageType { get; set; }

		[JsonProperty("postedTime")]
		public DateTime PostedTime { get; set; }

		[JsonProperty("postedRoomId")]
		public int PostedRoomId { get; set; }

		[JsonProperty("postedByUserTfid")]
		public string PostedByUserTfid { get; set; }
    }
}