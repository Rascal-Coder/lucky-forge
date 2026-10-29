using UnityEngine;

namespace FunGames.Mediation.ApplovinMax
{
	[CreateAssetMenu(fileName = "Assets/Resources/FunGames/FGApplovinMaxSettings", menuName = "FunGames/FGApplovinMaxSettings", order = 10)]
	public class FGApplovinMaxSettings : FGModuleSettingsAbstract<FGApplovinMaxSettings>
	{
		public const string NAME = "FGApplovinMaxSettings";

		private const string PATH = "FunGames/FGApplovinMaxSettings";

		private const string IosInterstitialAdUnitIdParam = "IosInterstitialAdUnitId";

		private const string IosRewardedAdUnitIdParam = "IosRewardedAdUnitId";

		private const string IosBannerAdUnitIdParam = "IosBannerAdUnitId";

		private const string IosAppOpenAdUnitIdParam = "IosAppOpenAdUnitId";

		private const string IosMrecAdUnitIdParam = "IosMrecAdUnitId";

		private const string AndroidInterstitialAdUnitIdParam = "AndroidInterstitialAdUnitId";

		private const string AndroidRewardedAdUnitIdParam = "AndroidRewardedAdUnitId";

		private const string AndroidBannerAdUnitIdParam = "AndroidBannerAdUnitId";

		private const string AndroidAppOpenAdUnitIdParam = "AndroidAppOpenAdUnitId";

		private const string AndroidMrecAdUnitIdParam = "AndroidMrecAdUnitId";

		private const string AmazonInterstitialAdUnitIdParam = "AmazonInterstitialAdUnitId";

		private const string AmazonRewardedAdUnitIdParam = "AmazonRewardedAdUnitId";

		private const string AmazonBannerAdUnitIdParam = "AmazonBannerAdUnitId";

		private const string AmazonAppOpenAdUnitIdParam = "AmazonAppOpenAdUnitId";

		private const string AmazonMrecAdUnitIdParam = "AmazonMrecAdUnitId";

		[Tooltip("Max Sdk Key")]
		public string maxSdkKey;

		[Header("Default iOS Units")]
		public string iOSInterstitialAdUnitId;

		public string iOSRewardedAdUnitId;

		public string iOSBannerAdUnitId;

		public string iOSAppOpenAdUnitId;

		public string iOSMrecAdUnitId;

		[Header("Default Android Units")]
		public string androidInterstitialAdUnitId;

		public string androidRewardedAdUnitId;

		public string androidBannerAdUnitId;

		public string androidAppOpenAdUnitId;

		public string androidMrecAdUnitId;

		[Header("Default Amazon Units")]
		public string amazonInterstitialAdUnitId;

		public string amazonRewardedAdUnitId;

		public string amazonBannerAdUnitId;

		public string amazonAppOpenAdUnitId;

		public string amazonMrecAdUnitId;

		[Header("Banner Settings")]
		public Color BannerBackgroundColor;

		public MaxSdkBase.BannerPosition BannerPosition;

		public string DefaultInterstitialId => null;

		public string DefaultRewardedId => null;

		public string DefaultBannerId => null;

		public string DefaultAppOpenId => null;

		public string DefaultMrecId => null;

		protected override FGApplovinMaxSettings LoadResources()
		{
			return null;
		}
	}
}
