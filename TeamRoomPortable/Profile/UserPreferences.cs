using PropertyChanged;
namespace TeamRoomPortable.Profile
{
    [ImplementPropertyChanged]
    public class UserPreferences
	{
		public string CustomDisplayName { get; set; }
		public string PreferredEmail { get; set; }
		public bool IsEmailConfirmationPending { get; set; }
		public object Theme { get; set; }
		public string TimeZoneId { get; set; }
		public int? Lcid { get; set; }
		public object Calendar { get; set; }
		public string DatePattern { get; set; }
		public string TimePattern { get; set; }
		public bool BasicAuthenticationConfigured { get; set; }
		public bool BasicAuthenticationDisabled { get; set; }
		public string BasicAuthenticationUsername { get; set; }
		public object BasicAuthenticationPassword { get; set; }
	}
}