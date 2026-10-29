using System;

namespace FunGames.Tools.Utils
{
	public static class LocalisationUtils
	{
		private static string[] _countryCodesGdpr;

		static LocalisationUtils()
		{
		}

		public static void GetLocalisationCode(Action<Location> callback)
		{
		}

		public static bool isGDPRApplied(Location location)
		{
			return false;
		}

		public static bool isEEA(Location location)
		{
			return false;
		}

		private static string[] GetCountryCodesGDPR()
		{
			return null;
		}
	}
}
