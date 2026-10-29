using FunGames.Tools.Utils;

namespace FunGames.RemoteConfig
{
	public static class Cache
	{
		public static string CachePath;

		public static void Initialize()
		{
		}

		public static bool IsVariableCached(string key)
		{
			return false;
		}

		public static JSONNode GetRoot()
		{
			return null;
		}

		public static void SaveCache(JSONNode cacheJson)
		{
		}

		public static void AddNode(JSONNode node, string key = "")
		{
		}

		public static void RemoveNode(string key)
		{
		}

		private static void CheckInitialization()
		{
		}
	}
}
