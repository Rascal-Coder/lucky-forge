using System.Collections.Generic;
using FunGames.Core.Modules;

namespace FunGames.RemoteConfig
{
	public static class FGRemoteConfig
	{
		public static FGModuleCallbacks Callbacks => null;

		public static FGABTest CurrentABTest => null;

		public static void AddDefaultValue(string key, object value)
		{
		}

		public static void OverrideDefaultValue(string key, object value)
		{
		}

		public static void AddDefaultValues(Dictionary<string, object> defaultValues)
		{
		}

		public static int GetIntValue(string key)
		{
			return 0;
		}

		public static double GetDoubleValue(string key)
		{
			return 0.0;
		}

		public static float GetFloat(string key)
		{
			return 0f;
		}

		public static bool GetBooleanValue(string key)
		{
			return false;
		}

		public static string GetStringValue(string key)
		{
			return null;
		}

		private static object GetValueByKey(string key)
		{
			return null;
		}
	}
}
