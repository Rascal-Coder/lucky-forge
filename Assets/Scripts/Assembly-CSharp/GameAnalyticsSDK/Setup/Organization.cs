using System.Collections.Generic;

namespace GameAnalyticsSDK.Setup
{
	public class Organization
	{
		public string Name { get; private set; }

		public string ID { get; private set; }

		public List<Studio> Studios { get; private set; }

		public Organization(string name, string id)
		{
		}

		public static string[] GetOrganizationNames(List<Organization> organizations, bool addFirstEmpty = true)
		{
			return null;
		}
	}
}
