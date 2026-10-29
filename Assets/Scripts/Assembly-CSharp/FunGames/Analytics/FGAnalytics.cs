using System.Collections.Generic;

namespace FunGames.Analytics
{
	public static class FGAnalytics
	{
		public const int NO_SCORE = -1;

		public static FGAnalyticsCallbacks Callbacks => null;

		public static void NewProgressionEvent(LevelStatus status, string prog01, int score = -1)
		{
		}

		public static void NewProgressionEvent(LevelStatus status, string prog01, string prog02, int score = -1)
		{
		}

		public static void NewProgressionEvent(LevelStatus status, string prog01, string prog02, string prog03, int score = -1)
		{
		}

		public static void NewDesignEvent(string eventId, float eventValue = 0f)
		{
		}

		public static void NewDesignEvent(string eventId, Dictionary<string, object> customFields, float eventValue = 0f)
		{
		}

		public static void NewAdEvent(AdAction adAction, AdType adType, string adSdkName, string adPlacement)
		{
		}

		public static string CreateEventId(params string[] strings)
		{
			return null;
		}
	}
}
