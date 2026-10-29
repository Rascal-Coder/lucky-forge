using FunGames.Core;
using FunGames.Core.Settings;

namespace FunGames.Mediation
{
	public abstract class FGMediationAdInterstitialAbstract<M, MP> : FGMediationAdAbstract<M, MP> where M : FGMediationAdAbstract<M, MP> where MP : FGMediationAbstract<MP, IFGModuleSettings>
	{
		public override FGAdType adType => FGAdType.Interstitial;

		protected abstract void ShowAd(string placementName);

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
