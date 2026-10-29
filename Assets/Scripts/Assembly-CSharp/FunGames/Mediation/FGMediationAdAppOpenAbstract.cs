using FunGames.Core;
using FunGames.Core.Settings;

namespace FunGames.Mediation
{
	public abstract class FGMediationAdAppOpenAbstract<M, MP> : FGMediationAdAbstract<M, MP> where M : FGMediationAdAbstract<M, MP> where MP : FGMediationAbstract<MP, IFGModuleSettings>
	{
		private const string PP_APPOPEN_FREQ = "AppOpenFrequency";

		private const string PP_APPOPEN_CD = "AppOpenCoolDown";

		private int AppOpenCoolDown;

		private int AppOpenFrequency;

		private int _lastAdIteration;

		private bool _hotStart;

		private bool _neverDisplayed;

		private float _timeWhenAppPaused;

		private float _timeSpentOutOfApp;

		public override FGAdType adType => FGAdType.Interstitial;

		protected abstract void InitializeCallbacksImpl();

		protected abstract void ShowAd();

		public override void InitializeCallbacks()
		{
		}

		private void OnApplicationPause(bool pauseStatus)
		{
		}

		protected override void ShowImpl()
		{
		}

		protected override void HideImpl()
		{
		}

		private void ShowFirstTime(FGAdInfo adInfo)
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

		private void InitializePlayerPref()
		{
		}

		private bool AppOpenFrequencyCondition()
		{
			return false;
		}

		private bool AppOpenFirstSessionCondition()
		{
			return false;
		}

		private bool AppOpenFirstColdStartCondition()
		{
			return false;
		}

		private bool AppOpenCoolDownCondition()
		{
			return false;
		}
	}
}
