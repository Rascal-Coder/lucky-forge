using System.Collections.Generic;
using GameAnalyticsSDK.Setup;

namespace GameAnalyticsSDK.State
{
	internal static class GAState
	{
		private static Settings _settings;

		public static void Init()
		{
		}

		private static bool ListContainsString(List<string> _list, string _string)
		{
			return false;
		}

		public static bool IsManualSessionHandlingEnabled()
		{
			return false;
		}

		public static bool HasAvailableResourceCurrency(string _currency)
		{
			return false;
		}

		public static bool HasAvailableResourceItemType(string _itemType)
		{
			return false;
		}

		public static bool HasAvailableCustomDimensions01(string _dimension01)
		{
			return false;
		}

		public static bool HasAvailableCustomDimensions02(string _dimension02)
		{
			return false;
		}

		public static bool HasAvailableCustomDimensions03(string _dimension03)
		{
			return false;
		}
	}
}
