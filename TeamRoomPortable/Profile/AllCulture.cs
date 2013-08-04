using PropertyChanged;
using System.Collections.Generic;

namespace TeamRoomPortable.Profile
{
    [ImplementPropertyChanged]
    public class AllCulture
	{
		public string DisplayName { get; set; }
		public List<OptionalCalendar> OptionalCalendars { get; set; }
		public int LCID { get; set; }
	}
}