using FunGames.Core;
using FunGames.Core.Settings;

namespace FunGames.Mediation
{
	public abstract class FGMediationAdBannerAbstract<M, MP> : FGMediationAdAbstract<M, MP> where M : FGMediationAdAbstract<M, MP> where MP : FGMediationAbstract<MP, IFGModuleSettings>
	{
		private bool _isBannerLoaded;

		private bool _showBannerAsked;

		private bool _isBannerShowing;

		public override FGAdType adType => FGAdType.Interstitial;

		protected abstract void LoadAd();

		protected abstract void ShowAd();

		protected abstract void HideAd();

		public override bool IsReady()
		{
			return false;
		}

		protected override void LoadImpl()
		{
		}

		protected override void ShowImpl()
		{
		}

		private void ShowOnceLoaded(FGAdInfo adInfo)
		{
		}

		protected override void HideImpl()
		{
		}

		protected override void TriggerLoadedEventImpl()
		{
		}

		protected override void TriggerDisplayedEventImpl()
		{
		}

		protected override void TriggerClosedEventImpl()
		{
		}

		protected override void TriggerClickedEventImpl()
		{
		}

		protected override void TriggerImpressionEventImpl()
		{
		}

		protected override void TriggerLoadFailedEventImpl()
		{
		}

		protected override void TriggerDisplayFailedEventImpl()
		{
		}
	}
}
