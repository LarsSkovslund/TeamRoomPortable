using PropertyChanged;
using System.Collections.Generic;

namespace TeamRoomPortable.Profile
{
    [ImplementPropertyChanged]
    public class OptionalCalendar
	{
		public string DisplayName { get; set; }
		public List<DateFormat> DateFormats { get; set; }
		public List<TimeFormat> TimeFormats { get; set; }
	}
}