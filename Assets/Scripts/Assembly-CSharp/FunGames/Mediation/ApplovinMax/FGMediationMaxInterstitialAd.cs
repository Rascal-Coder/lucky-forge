using FunGames.Core.Settings;

namespace FunGames.Mediation.ApplovinMax
{
	public class FGMediationMaxInterstitialAd : FGMediationAdInterstitialAbstract<FGMediationMaxInterstitialAd, FGMax>
	{
		protected override FGMediationAbstract<FGMax, IFGModuleSettings> MediationInstance => null;

		public override void InitializeCallbacks()
		{
		}

		protected override void LoadImpl()
		{
		}

		public override bool IsReady()
		{
			return false;
		}

		protected override void ShowAd(string placementName)
		{
		}

		private void OnInterstitialLoadedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
		{
		}

		private void OnInterstitialDisplayedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
		{
		}

		private void OnInterstitialDismissedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
		{
		}

		private void OnInterstitialClickedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
		{
		}

		private void OnInterAdImpressionEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
		{
		}

		private void OnInterstitialFailedToLoadEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo)
		{
		}

		private void OnInterstitialFailedToDisplayEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo, MaxSdkBase.AdInfo adInfo)
		{
		}
	}
}
