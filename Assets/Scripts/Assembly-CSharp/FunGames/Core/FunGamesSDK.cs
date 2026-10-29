namespace FunGames.Core
{
	public class FunGamesSDK
	{
		public static FGCoreCallbacks Callbacks => null;

		public static bool IsInitialized => false;

		public static bool IsFirstConnection => false;

		public static bool IsConnectedToInternet => false;

		public static int DaysSinceFirstCo => 0;

		public static int DaysSinceLastCo => 0;

		public static int CurrentSessionNumber => 0;

		public static void RemoveAds(params FGAdType[] ads)
		{
		}

		public static void RestoreAds()
		{
		}

		public static bool IsNoAd(FGAdType ad)
		{
			return false;
		}
	}
}
