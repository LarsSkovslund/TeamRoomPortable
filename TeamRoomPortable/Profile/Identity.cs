using PropertyChanged;
using System.Collections.Generic;

namespace TeamRoomPortable.Profile
{
    [ImplementPropertyChanged]
    public class Identity
	{
		public string IdentityType { get; set; }
		public string FriendlyDisplayName { get; set; }
		public string DisplayName { get; set; }
		public string SubHeader { get; set; }
		public string TeamFoundationId { get; set; }
		public List<object> Errors { get; set; }
		public List<object> Warnings { get; set; }
		public string Domain { get; set; }
		public string AccountName { get; set; }
		public bool IsWindowsUser { get; set; }
	}
}