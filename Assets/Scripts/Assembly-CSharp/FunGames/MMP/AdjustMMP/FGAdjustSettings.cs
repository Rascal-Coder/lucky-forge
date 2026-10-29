using System;
using AdjustSdk;
using UnityEngine;

namespace FunGames.MMP.AdjustMMP
{
	[CreateAssetMenu(fileName = "Assets/Resources/FunGames/FGAdjustSettings", menuName = "FunGames/FGAdjustSettings", order = 10)]
	public class FGAdjustSettings : FGModuleSettingsAbstract<FGAdjustSettings>
	{
		public const string NAME = "FGAdjustSettings";

		private const string PATH = "FunGames/FGAdjustSettings";

		private const string AppTokenParam = "AppToken";

		private const string AdjustEventInterIdParam = "AdjustEventInterID";

		private const string AdjustEventRewardedIdParam = "AdjustEventRewardedID";

		[Tooltip("Adjust App Token")]
		public string AppToken;

		[Tooltip("Adjust Log Level")]
		public AdjustLogLevel logLevel;

		public bool sendInBackground;

		public bool setLaunchDeferredDeeplink;

		public string AdjustEventInterID;

		public string AdjustEventRewardedID;

		[Header("Retention Event")]
		public FGRetentionEventTrigger[] RetentionEventTriggers;

		[Obsolete]
		[HideInInspector]
		public string AdjustTokenRet1;

		[Obsolete]
		[HideInInspector]
		public string AdjustTokenRet3;

		[Obsolete]
		[HideInInspector]
		public string AdjustTokenRet5;

		[Obsolete]
		[HideInInspector]
		public string AdjustTokenRet7;

		[Header("Rewarded event")]
		public FGAdImpressionEventTrigger[] RvEventTriggers;

		[Obsolete]
		[HideInInspector]
		public int nbRV1;

		[Obsolete]
		[HideInInspector]
		public string nbRV1Token;

		[Obsolete]
		[HideInInspector]
		public int nbRV2;

		[Obsolete]
		[HideInInspector]
		public string nbRV2Token;

		[Obsolete]
		[HideInInspector]
		public int nbRV3;

		[Obsolete]
		[HideInInspector]
		public string nbRV3Token;

		[Obsolete]
		[HideInInspector]
		public int nbRV4;

		[Obsolete]
		[HideInInspector]
		public string nbRV4Token;

		[Obsolete]
		[HideInInspector]
		public int nbRV5;

		[Obsolete]
		[HideInInspector]
		public string nbRV5Token;

		[Header("Interstitial event")]
		public FGAdImpressionEventTrigger[] InterstitialEventTriggers;

		protected override FGAdjustSettings LoadResources()
		{
			return null;
		}

		public FGRetentionEventTrigger GetRetentionEventTrigger(int dayNumber)
		{
			return null;
		}

		public FGAdImpressionEventTrigger GetRvEventTrigger(int rvCount)
		{
			return null;
		}

		public FGAdImpressionEventTrigger GetInterstitialEventTrigger(int interstitialsCount)
		{
			return null;
		}
	}
}
