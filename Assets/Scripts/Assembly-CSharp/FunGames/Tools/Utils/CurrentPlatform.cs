namespace FunGames.Tools.Utils
{
	public class CurrentPlatform
	{
		public static bool IsFireOS => false;

		public static bool Is(Platform platform)
		{
			return false;
		}

		public static void GetAdvertisingId(out string advertisingID, out bool limitAdvertising)
		{
			advertisingID = null;
			limitAdvertising = default;
		}

		public static string GetOsVersion()
		{
			return null;
		}
	}
}
