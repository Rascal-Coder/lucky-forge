using UnityEngine;

namespace FunGames.Analytics.GA
{
	[CreateAssetMenu(fileName = "Assets/Resources/FunGames/FGGameAnalyticsSettings", menuName = "FunGames/FGGameAnalyticsSettings", order = 10)]
	public class FGGameAnalyticsSettings : FGModuleSettingsAbstract<FGGameAnalyticsSettings>
	{
		public const string NAME = "FGGameAnalyticsSettings";

		private const string PATH = "FunGames/FGGameAnalyticsSettings";

		private const string AndroidGameKeyParam = "AndroidGameKey";

		private const string AndroidSecretKeyParam = "AndroidSecretKey";

		private const string IosGameKeyParam = "IosGameKey";

		private const string IosSecretKeyParam = "IosSecretKey";

		[Header("GameAnalytics")]
		[Tooltip("GameAnalytics Ios Game Key")]
		public string gameAnalyticsIosGameKey;

		[Tooltip("GameAnalytics Ios Secret Key")]
		public string gameAnalyticsIosSecretKey;

		[Tooltip("GameAnalytics Android Game Key")]
		public string gameAnalyticsAndroidGameKey;

		[Tooltip("GameAnalytics Android Secret Key")]
		public string gameAnalyticsAndroidSecretKey;

		protected override FGGameAnalyticsSettings LoadResources()
		{
			return null;
		}
	}
}
