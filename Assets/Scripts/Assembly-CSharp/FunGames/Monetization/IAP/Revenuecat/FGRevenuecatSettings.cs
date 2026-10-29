using UnityEngine;

namespace FunGames.Monetization.IAP.Revenuecat
{
	[CreateAssetMenu(fileName = "Resources/FunGames/FGRevenuecatSettings", menuName = "FunGames/FGRevenuecatSettings", order = 10)]
	public class FGRevenuecatSettings : FGModuleSettingsAbstract<FGRevenuecatSettings>
	{
		public const string NAME = "FGRevenuecatSettings";

		private const string PATH = "FunGames/FGRevenuecatSettings";

		private const string AndroidPublicApiKeyParam = "AndroidPublicApiKey";

		private const string IosPublicApiKeyParam = "IosPublicApiKey";

		private const string AmazonPublicApiKeyParam = "AmazonPublicApiKey";

		[Header("Revenuecat")]
		[Tooltip("Android public API Key")]
		public string androidPublicAPIKey;

		[Tooltip("IOS public API Key")]
		public string iOSPublicAPIKey;

		[Tooltip("Amazon public API Key")]
		public string amazonPublicAPIKey;

		[Tooltip("Set this to MyApp if you have your own IAP implementation and want to use only RevenueCat's backend.")]
		public Purchases.PurchasesAreCompletedBy purchasesAreCompletedBy;

		[Tooltip("It is recommended to use 'StoreKit1' if you're using Unity IAP 4 and below, 'StoreKit2' for Unity IAP 5 and above. \nSet to 'Default' if \"Purchases Are Completed By\" is set to 'RevenueCat'")]
		public Purchases.StoreKitVersion storeKitVersion;

		public Purchases.LogLevel logLevel;

		public string ApiKey => null;

		protected override FGRevenuecatSettings LoadResources()
		{
			return null;
		}
	}
}
