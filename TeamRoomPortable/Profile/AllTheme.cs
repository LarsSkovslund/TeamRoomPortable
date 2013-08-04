using PropertyChanged;
namespace TeamRoomPortable.Profile
{
    [ImplementPropertyChanged]
    public class AllTheme
	{
		public string DisplayName { get; set; }
		public string ThemeName { get; set; }
	}
}