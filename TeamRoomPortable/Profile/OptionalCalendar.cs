using System.Collections.Generic;

namespace TeamRoomPortable.Profile
{
	public class OptionalCalendar
	{
		public string DisplayName { get; set; }
		public List<DateFormat> DateFormats { get; set; }
		public List<TimeFormat> TimeFormats { get; set; }
	}
}