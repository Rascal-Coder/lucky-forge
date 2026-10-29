using System;
using GoogleMobileAds.Api;

namespace FunGames.UserConsent.GDPR.GoogleUMP
{
	public class FGGoogleMobileAdsSDK : FGSingleton<FGGoogleMobileAdsSDK>
	{
		private bool _isInitialized;

		private bool _initializationRequested;

		private InitializationStatus _initializationStatus;

		private Action<InitializationStatus> _onInitializationComplete;

		public bool IsInitialized => false;

		public InitializationStatus Status => null;

		public event Action<InitializationStatus> OnInitializationComplete
		{
			add
			{
			}
			remove
			{
			}
		}

		public void Initialize()
		{
		}

		private void OnInitialized(InitializationStatus obj)
		{
		}
	}
}
