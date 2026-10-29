using FunGames.Core.Settings;

namespace FunGames.Mediation.ApplovinMax
{
	public class FGMediationMaxBannerAd : FGMediationAdBannerAbstract<FGMediationMaxBannerAd, FGMax>
	{
		private bool _isCreated;

		protected override FGMediationAbstract<FGMax, IFGModuleSettings> MediationInstance => null;

		public override void InitializeCallbacks()
		{
		}

		protected override void ShowAd()
		{
		}

		protected override void HideAd()
		{
		}

		protected override void LoadAd()
		{
		}

		private void OnBannerAdLoaded(string adUnitId, MaxSdkBase.AdInfo adInfo)
		{
		}

		private void OnBannerAdImpressionEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
		{
		}

		private void OnBannerAdFailedToLoadEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo)
		{
		}

		private void OnBannerAdClickedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
		{
		}
	}
}
