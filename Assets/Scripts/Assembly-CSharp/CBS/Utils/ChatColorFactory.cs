using System.Collections.Generic;
using CBS.Scriptable;
using UnityEngine;

namespace CBS.Utils
{
	public static class ChatColorFactory
	{
		private static Dictionary<string, Color> CacheProfileColor;

		private static ChatLocalConfig ChatData;

		private static List<Color> ColorList;

		private static int ColorIndex;

		private static bool IsInited;

		public static Color GetProfileColor(string profileID)
		{
			return default;
		}

		public static Color GetTagColor()
		{
			return default;
		}

		private static void InitFactory()
		{
		}

		private static Color GetNextAvailableColor()
		{
			return default;
		}
	}
}
