using System.Collections.Generic;

namespace GameAnalyticsSDK.Events
{
	public static class GA_Design
	{
		public static void NewEvent(string eventName, float eventValue, IDictionary<string, object> fields, bool mergeFields)
		{
		}

		public static void NewEvent(string eventName, IDictionary<string, object> fields, bool mergeFields)
		{
		}

		private static void CreateNewEvent(string eventName, float? eventValue, IDictionary<string, object> fields, bool mergeFields)
		{
		}
	}
}
