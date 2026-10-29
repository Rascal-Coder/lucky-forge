using UnityEngine.UI;

namespace FunGames.UserConsent.GDPR.CustomGDPR
{
	public class FGGdprDisplaySimple : FGGDPRDisplayAbstract
	{
		public Button confirmChoicesButton;

		public Toggle acceptTargetedAdvertising;

		public Toggle acceptAnalytics;

		public Toggle isAboveAgeLimit;

		protected override void OnAwake()
		{
		}

		private void TargetAdvertisingChanged(bool arg0)
		{
		}

		private void AnalyticsChanged(bool arg0)
		{
		}

		private void AgeLimitChanged(bool arg0)
		{
		}

		protected void HandleFlexibility()
		{
		}
	}
}
