using PropertyChanged;
namespace TeamRoomPortable.Profile
{
    [ImplementPropertyChanged]
    public class AllTimeZone
	{
		public string DisplayName { get; set; }
		public string Id { get; set; }
	}
}