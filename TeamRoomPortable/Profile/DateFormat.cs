using PropertyChanged;
namespace TeamRoomPortable.Profile
{
    [ImplementPropertyChanged]
    public class DateFormat
	{
		public string Format { get; set; }
		public string DisplayFormat { get; set; }
	}
}