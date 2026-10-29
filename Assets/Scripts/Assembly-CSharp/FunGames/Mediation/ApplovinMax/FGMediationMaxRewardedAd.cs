using FunGames.Core.Settings;

namespace FunGames.Mediation.ApplovinMax
{
	public class FGMediationMaxRewardedAd : FGMediationAdRewardedAbstract<FGMediationMaxRewardedAd, FGMax>
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

		protected override void ShowAd()
		{
		}

		private void OnRewardedAdLoadedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
		{
		}

		private void OnRewardedAdDisplayedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
		{
		}

		private void OnRewardedAdDismissedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
		{
		}

		private void OnRewardedAdClickedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
		{
		}

		private void OnRewardedAdReceivedRewardEvent(string adUnitId, MaxSdkBase.Reward reward, MaxSdkBase.AdInfo adInfo)
		{
		}

		private void OnRewardedAdFailedToLoadEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo)
		{
		}

		private void OnRewardedAdFailedToDisplayEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo, MaxSdkBase.AdInfo adInfo)
		{
		}

		private void OnRewardedAdImpressionEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
		{
		}
	}
}
