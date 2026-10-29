using FunGames.Core;

namespace FunGames.Mediation
{
	public class FGMediationImpressionCounter
	{
		private const string PP_NB_RV = "count_RV";

		private const string PP_NB_INT = "count_INT";

		private const string PP_NB_BN = "count_BN";

		private const string PP_NB_MREC = "count_MREC";

		private const string PP_NB_APP_OPEN = "count_APPOPEN";

		public static void IncrementCount(FGAdType adType)
		{
		}

		public static int GetTotalCount(FGAdType adType)
		{
			return 0;
		}

		private static string GetPlayerPrefKey(FGAdType adType)
		{
			return null;
		}
	}
}
