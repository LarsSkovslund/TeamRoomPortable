using System.Collections.Generic;
using Newtonsoft.Json;

namespace TeamRoomPortable.Profile
{
	/// <summary>
	/// Represents the currently logged on users profile
	/// </summary>
	public class UserProfile
	{
		[JsonProperty("identity")]
		public Identity Identity { get; set; }

		[JsonProperty("providerDisplayName")]
		public string ProviderDisplayName { get; set; }

		[JsonProperty("defaultMailAddress")]
		public string DefaultMailAddress { get; set; }

		[JsonProperty("basicAuthenticationEnabled")]
		public bool BasicAuthenticationEnabled { get; set; }

		[JsonProperty("userPreferences")]
		public UserPreferences UserPreferences { get; set; }

		[JsonProperty("allThemes")]
		public List<AllTheme> AllThemes { get; set; }

		[JsonProperty("allTimeZones")]
		public List<AllTimeZone> AllTimeZones { get; set; }

		[JsonProperty("allCultures")]
		public List<AllCulture> AllCultures { get; set; }
	}
}