using FunGames.Core;
using FunGames.Monetization.Ads.Mediation;

namespace FunGames.Mediation.ApplovinMax
{
	public class FGAdUnitRemote : FGAdUnitOrdered
	{
		private const string REMOTE_ADUNIT_REGEX = "^(?i)(INT|BN|RV|MREC|APPOPEN):\\d+:(ANDROID|IOS|AMAZON):[^:]+(?::(\\d+))?$";

		private const int AD_TYPE_INDEX = 0;

		private const int AD_PRIO_INDEX = 1;

		private const int AD_PLATFORM_INDEX = 2;

		private const int AD_UNITID_INDEX = 3;

		private const int AD_TIMEOUT = 4;

		private string _remoteAdUnit;

		public FGAdUnitRemote(string remoteAdUnit)
		{
		}

		private FGAdType ParseAdType(string str)
		{
			return FGAdType.Interstitial;
		}

		private FGPlatform ParsePlatform(string str)
		{
			return FGPlatform.IOS;
		}

		private int ParseInt(string str)
		{
			return 0;
		}

		public bool IsValid()
		{
			return false;
		}
	}
}
