using System.Collections.Generic;

namespace GameAnalyticsSDK.Events
{
	public static class GA_Progression
	{
		public static void NewEvent(GAProgressionStatus progressionStatus, string progression01, IDictionary<string, object> fields, bool mergeFields)
		{
		}

		public static void NewEvent(GAProgressionStatus progressionStatus, string progression01, string progression02, IDictionary<string, object> fields, bool mergeFields)
		{
		}

		public static void NewEvent(GAProgressionStatus progressionStatus, string progression01, string progression02, string progression03, IDictionary<string, object> fields, bool mergeFields)
		{
		}

		public static void NewEvent(GAProgressionStatus progressionStatus, string progression01, int score, IDictionary<string, object> fields, bool mergeFields)
		{
		}

		public static void NewEvent(GAProgressionStatus progressionStatus, string progression01, string progression02, int score, IDictionary<string, object> fields, bool mergeFields)
		{
		}

		public static void NewEvent(GAProgressionStatus progressionStatus, string progression01, string progression02, string progression03, int score, IDictionary<string, object> fields, bool mergeFields)
		{
		}

		private static void CreateEvent(GAProgressionStatus progressionStatus, string progression01, string progression02, string progression03, int? score, IDictionary<string, object> fields, bool mergeFields)
		{
		}
	}
}
