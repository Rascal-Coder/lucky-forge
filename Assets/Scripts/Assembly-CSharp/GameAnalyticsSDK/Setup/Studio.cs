using System.Collections.Generic;

namespace GameAnalyticsSDK.Setup
{
	public class Studio
	{
		public string Name { get; private set; }

		public string ID { get; private set; }

		public string OrganizationID { get; private set; }

		public List<Game> Games { get; private set; }

		public Studio(string name, string id, string orgId, List<Game> games)
		{
		}

		public static string[] GetStudioNames(List<Studio> studios, bool addFirstEmpty = true)
		{
			return null;
		}

		public static string[] GetGameNames(int index, List<Studio> studios)
		{
			return null;
		}
	}
}
