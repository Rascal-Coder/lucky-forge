using FunGames.Core;
using FunGames.Core.Settings;

namespace FunGames.Mediation
{
	public abstract class FGMediationAdMrecAbstract<M, MP> : FGMediationAdAbstract<M, MP> where M : FGMediationAdAbstract<M, MP> where MP : FGMediationAbstract<MP, IFGModuleSettings>
	{
		private bool _isMrecLoaded;

		private bool _showMrecAsked;

		private bool _isMrecShowing;

		public override FGAdType adType => FGAdType.Interstitial;

		protected abstract void ShowAd();

		protected abstract void HideAd();

		public abstract void UpdateAutoRefresh();

		public override bool IsReady()
		{
			return false;
		}

		protected override void ShowImpl()
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
