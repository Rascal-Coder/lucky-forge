using FunGames.Core.Settings;

namespace FunGames.Mediation.ApplovinMax
{
	public class FGMediationMaxAppOpenAd : FGMediationAdAppOpenAbstract<FGMediationMaxAppOpenAd, FGMax>
	{
		protected override FGMediationAbstract<FGMax, IFGModuleSettings> MediationInstance => null;

		protected override void InitializeCallbacksImpl()
		{
		}

		protected override void ShowAd()
		{
		}

		protected override void LoadImpl()
		{
		}

		public override bool IsReady()
		{
			return false;
		}

		private void OnAppOpenLoadedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
		{
		}

		private void OnAppOpenDisplayedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
		{
		}

		public void OnAppOpenDismissedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
		{
		}

		private void OnAppOpenClickedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
		{
		}

		private void OnAppOpenAdImpressionEvent(string adType, MaxSdkBase.AdInfo adInfo)
		{
		}

		private void OnAppOpenFailedToLoadEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo)
		{
		}

		private void OnAppOpenFailedToDisplayEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo, MaxSdkBase.AdInfo adInfo)
		{
		}
	}
}
