using System;
using FunGames.Core;
using FunGames.Core.Modules;
using FunGames.Core.Settings;

namespace FunGames.Mediation
{
	public abstract class FGMediationAbstract<M, S> : FGModuleAbstract<M, FGMediationCallbacks, S> where M : FGModuleAbstract<M, FGMediationCallbacks, S> where S : IFGModuleSettings
	{
		internal FGAdInfo _loadedBannerAd;

		private int _loadingAdIndex;

		protected override FGModule Parent => null;

		protected abstract void LoadAds();

		protected abstract void ShowBannerAd(string placementName);

		protected abstract void HideBannerAd();

		protected abstract void ShowInterstitialAd(Action<bool> callback, string placementName);

		protected abstract void ShowRewardedAd(Action<bool> callback, string placementName);

		protected abstract void ShowAppOpen(Action<bool> callback, string placementName);

		protected abstract void ShowMrecAd(Action<bool> callback, string placementName);

		protected abstract void HideMrecAd();

		protected override void InitializeCallbacks()
		{
		}

		protected void InitializeAds()
		{
		}

		public void ShowAd(FGAdType adType, string adUnit, string placementName, Action<bool> callback)
		{
		}

		private static bool isRequestedAd(IFGMediationAd mediationAd, FGAdType adType, string adUnit)
		{
			return false;
		}

		private static bool isAvailableAdOfSameType(IFGMediationAd mediationAd, FGAdType adType)
		{
			return false;
		}

		protected override void ClearInitialization()
		{
		}
	}
}
