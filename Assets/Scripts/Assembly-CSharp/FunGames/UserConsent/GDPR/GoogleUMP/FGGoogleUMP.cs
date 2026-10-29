using GoogleMobileAds.Api;
using GoogleMobileAds.Ump.Api;

namespace FunGames.UserConsent.GDPR.GoogleUMP
{
	public class FGGoogleUMP : FGGdprTcfAbstract<FGGoogleUMP, FGGoogleUMPSettings>
	{
		private ConsentForm _consentForm;

		public override FGGoogleUMPSettings Settings => null;

		protected override string EventName => null;

		protected override string RemoteConfigKey => null;

		protected override int RemoteConfig => 0;

		protected override void OnAwake()
		{
		}

		protected override void OnStart()
		{
		}

		protected override void InitSdk()
		{
		}

		protected override void RequestShow()
		{
		}

		private void OnInitialized(InitializationStatus instanceStatus)
		{
		}

		private void OnConsentInfoUpdated(FormError error)
		{
		}

		private void LoadConsentForm()
		{
		}

		private void OnLoadConsentForm(ConsentForm consentForm, FormError error)
		{
		}

		private void OnShowForm(FormError error)
		{
		}

		private void HandleError(FormError error)
		{
		}

		protected override string GetTcfString()
		{
			return null;
		}

		private void HandleStatus()
		{
		}
	}
}
