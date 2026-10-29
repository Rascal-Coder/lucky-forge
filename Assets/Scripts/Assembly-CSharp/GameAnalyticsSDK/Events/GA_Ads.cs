using System.Collections.Generic;

namespace GameAnalyticsSDK.Events
{
	public static class GA_Ads
	{
		public static void NewEvent(GAAdAction adAction, GAAdType adType, string adSdkName, string adPlacement, long duration, IDictionary<string, object> fields, bool mergeFields)
		{
		}

		public static void NewEvent(GAAdAction adAction, GAAdType adType, string adSdkName, string adPlacement, GAAdError noAdReason, IDictionary<string, object> fields, bool mergeFields = false)
		{
		}

		public static void NewEvent(GAAdAction adAction, GAAdType adType, string adSdkName, string adPlacement, IDictionary<string, object> fields, bool mergeFields = false)
		{
		}
	}
}
