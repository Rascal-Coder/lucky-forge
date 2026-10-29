using UnityEngine;
using UnityEngine.UI;

namespace FunGames.UserConsent.GDPR.CustomGDPR
{
	public class FGGdprDisplaySimpleWithSettings : FGGDPRDisplayAbstract
	{
		public Button confirmChoicesButton;

		public Toggle acceptTargetedAdvertising;

		public Toggle acceptAnalytics;

		public Toggle isAboveAgeLimit;

		public GameObject confirmButtonOverlay;

		public GameObject firstFrame;

		public GameObject secondFrame;

		public Button AgreeButton;

		public Button SettingsButton;

		private int activeButton;

		protected override void OnAwake()
		{
		}

		private void OnClickSettings()
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
