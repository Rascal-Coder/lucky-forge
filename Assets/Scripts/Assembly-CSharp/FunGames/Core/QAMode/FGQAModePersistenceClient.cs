namespace FunGames.Core.QAMode
{
	internal static class FGQAModePersistenceClient
	{
		private const string KEY_API_TOKEN = "fg_qa_token";

		private const string KEY_MODE = "fg_qa_mode";

		private const string KEY_ADS_ENABLED = "fg_qa_mode_ads_enabled";

		private const string VALUE_AUTO_MODE = "auto";

		private const string VALUE_MANUAL_MODE = "manual";

		private static readonly string AllVariablesCachePath;

		private static readonly string LiveVariablesCachePath;

		private static readonly string EnabledVariableIdsCachePath;

		public static string GetApiToken()
		{
			return null;
		}

		public static void SaveApiToken(string passphrase)
		{
		}

		public static FGQAMode GetQAMode()
		{
			return FGQAMode.unknown;
		}

		public static void SaveQAMode(FGQAMode mode)
		{
		}

		public static bool GetAdsEnabled()
		{
			return false;
		}

		public static void SaveAdsEnabled(bool enabled)
		{
		}

		public static string GetAllVariables()
		{
			return null;
		}

		public static void SaveAllVariables(string variables)
		{
		}

		public static string GetLiveVariables()
		{
			return null;
		}

		public static void SaveLiveVariables(string variables)
		{
		}

		public static string GetEnabledVariableIds()
		{
			return null;
		}

		public static void SaveEnabledVariableIds(string variables)
		{
		}

		public static void DeleteDeprecatedData()
		{
		}
	}
}
