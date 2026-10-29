using System;

namespace FunGames.Core.QAMode
{
	internal static class FGQAModeWebClient
	{
		private static string remoteConfigUrl => null;

		public static void FetchAllVariables(string token, Action<bool, string> onComplete)
		{
		}

		public static void FetchLiveVariables(string token, Action<bool, string> onComplete)
		{
		}

		private static void MakeGetRequest(string url, string token, bool qa, Action<bool, string> onComplete)
		{
		}

		private static void SetDefaultRequestHeaders(string url, string token, bool qa)
		{
		}
	}
}
