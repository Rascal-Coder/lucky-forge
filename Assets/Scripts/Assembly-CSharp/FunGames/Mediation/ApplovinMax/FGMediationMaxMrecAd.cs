using FunGames.Core.Settings;

namespace FunGames.Mediation.ApplovinMax
{
	public class FGMediationMaxMrecAd : FGMediationAdMrecAbstract<FGMediationMaxMrecAd, FGMax>
	{
		protected override FGMediationAbstract<FGMax, IFGModuleSettings> MediationInstance => null;

		public override void InitializeCallbacks()
		{
		}

		protected override void LoadImpl()
		{
		}

		protected override void ShowAd()
		{
		}

		protected override void HideAd()
		{
		}

		public override void UpdateAutoRefresh()
		{
		}

		private void OnMRecAdLoadedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
		{
		}

		private void OnMRecAdClickedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
		{
		}

		private void OnMRecAdRevenuePaidEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
		{
		}

		private void OnMRecAdExpandedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
		{
		}

		private void OnMRecAdCollapsedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
		{
		}

		private void OnMRecAdLoadFailedEvent(string adUnitId, MaxSdkBase.ErrorInfo adInfo)
		{
		}
	}
}
