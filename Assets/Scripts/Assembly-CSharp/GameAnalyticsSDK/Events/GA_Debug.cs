using System.Collections.Generic;
using UnityEngine;

namespace GameAnalyticsSDK.Events
{
	public static class GA_Debug
	{
		public static int MaxErrorCount;

		private static int _errorCount;

		private static bool _showLogOnGUI;

		public static List<string> Messages;

		public static void HandleLog(string logString, string stackTrace, LogType type)
		{
		}

		private static void SubmitError(string message, LogType type)
		{
		}

		public static void EnabledLog()
		{
		}
	}
}
