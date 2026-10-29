using System;
using System.Collections.Generic;
using FunGames.Core;
using FunGames.Core.Settings;

namespace FunGames.Mediation.ApplovinMax
{
	public class FGMax : FGMediationAbstract<FGMax, IFGModuleSettings>
	{
		public const int MAXCOUNT_RC_AD_UNITS = 100;

		public const string RC_MAX_AD_UNIT_PREFIX = "max_ad_unit_";

		public const string MAX_EVENT_LOADING_TIME = "MaxAdLoadingTime";

		private FGMediationMaxBannerAd currentBannerAd;

		private Action _updateConsentCallback;

		public const string RC_AUTO_RETRIES = "fg_applovin_auto_retry";

		public const string RC_BACKTOBACK = "fg_applovin_backtoback";

		private const string DISABLE_AUTO_RETRIES = "disable_auto_retries";

		private const string DISABLE_B2B_AD_UNIT_IDS = "disable_b2b_ad_unit_ids";

		private List<FGMaxAdContainer> adContainers;

		public override IFGModuleSettings Settings => null;

		protected override string EventName => null;

		protected override string RemoteConfigKey => null;

		public IFGMediationAd DefaultBanner => null;

		public IFGMediationAd DefaultInterstitial => null;

		public IFGMediationAd DefaultRewarded => null;

		public IFGMediationAd DefaultAppOpen => null;

		public IFGMediationAd DefaultMrec => null;

		protected override void InitializeCallbacks()
		{
		}

		protected override void OnAwake()
		{
		}

		protected override void OnStart()
		{
		}

		protected override void InitializeModule()
		{
		}

		private void UpdateConsent()
		{
		}

		private void InitializeMaxAds()
		{
		}

		protected override void LoadAds()
		{
		}

		internal void ShowDefault(FGAdType adType, string placementName, Action<bool> callback)
		{
		}

		protected override void ShowBannerAd(string placementName)
		{
		}

		protected override void ShowInterstitialAd(Action<bool> callback, string placementName)
		{
		}

		protected override void ShowRewardedAd(Action<bool> callback, string placementName)
		{
		}

		protected override void ShowAppOpen(Action<bool> callback, string placementName)
		{
		}

		protected override void ShowMrecAd(Action<bool> callback, string placementName)
		{
		}

		protected override void HideBannerAd()
		{
		}

		protected override void HideMrecAd()
		{
		}

		internal FGAdInfo FGAdInfo(MaxSdkBase.AdInfo adinfo)
		{
			return null;
		}

		private FGMaxAdContainer GetMaxAdContainer(FGAdType adType)
		{
			return null;
		}

		private void SetDefaultRemoteAdUnitIds()
		{
		}

		public IFGMediationAd GetDefaultAdUnit(FGAdType adType)
		{
			return null;
		}

		private void SetAutoRetries()
		{
		}

		private void SetBackToBack()
		{
		}

		protected override void ClearInitialization()
		{
		}
	}
}
