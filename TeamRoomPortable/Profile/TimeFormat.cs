using PropertyChanged;
namespace TeamRoomPortable.Profile
{
    [ImplementPropertyChanged]
    public class TimeFormat
	{
		public string Format { get; set; }
		public string DisplayFormat { get; set; }
	}
}