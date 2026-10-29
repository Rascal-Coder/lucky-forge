using System;
using System.Collections.Generic;
using FunGames.Core;
using FunGames.Core.Modules;
using UnityEngine;

namespace FunGames.Mediation
{
	public class FGMediationManager : FGModuleAbstract<FGMediationManager, FGMediationCallbacks, FGMediationSettings>
	{
		private float _timeSinceLastInterstitial;

		public const string RC_APPOPEN_FREQ = "AppOpenFrequency";

		public const string RC_APPOPEN_CD = "AppOpenCoolDown";

		public const string RC_APPOPEN_FIRST_SESSION = "AppOpenFirstSession";

		public const string RC_APPOPEN_COLD_START = "AppOpenColdStart";

		public const string DEFAULT_PLACEMENT_NAME = "default";

		public const string FAILED_LOAD_PLACEMENT_NAME = "fail_load";

		private List<Func<bool>> _appOpenConditions;

		public List<IFGMediationAd> AllAdUnits;

		[HideInInspector]
		public int CurrentLoadingAdIndex;

		[HideInInspector]
		public bool IsShowBannerRequested;

		private Action _manualInitializeAds;

		public override FGMediationSettings Settings => null;

		protected override FGModule Parent => null;

		protected override string EventName => null;

		protected override string RemoteConfigKey => null;

		public bool IsBannerReady => false;

		public bool IsInterstitialReady => false;

		public bool IsRewardedReady => false;

		public bool IsMrecReady => false;

		public bool IsAppOpenReady => false;

		public float TimeSinceLastInterstitial => 0f;

		public event Action ManualInitializeAds
		{
			add
			{
			}
			remove
			{
			}
		}

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

		private void Update()
		{
		}

		public void ShowBanner(string placementName)
		{
		}

		public void HideBanner()
		{
		}

		public void ShowInterstitial(Action<bool> endOfAdCallback, string placementName)
		{
		}

		public void ShowRewarded(Action<bool> rewardedCallback, string placementName)
		{
		}

		public void ShowMrec(Action<bool> endOfAdCallback, string placementName)
		{
		}

		public void HideMrec()
		{
		}

		public void ShowAppOpen(Action<bool> endOfAdCallback, string placementName)
		{
		}

		public void AddAppOpenCondition(Func<bool> condition)
		{
		}

		public bool MatchAppOpenCondition()
		{
			return false;
		}

		public bool IsAdReady(FGAdType adType)
		{
			return false;
		}

		public bool IsAdShowing(FGAdType adType)
		{
			return false;
		}

		private bool isAdReady(IFGMediationAd mediationAd, FGAdType adType)
		{
			return false;
		}

		private bool isAdShowing(IFGMediationAd mediationAd, FGAdType adType)
		{
			return false;
		}

		private bool CalculateCondition(Func<bool>[] conditions)
		{
			return false;
		}

		public void ForceInitializeAds()
		{
		}

		protected override void ClearInitialization()
		{
		}
	}
}
