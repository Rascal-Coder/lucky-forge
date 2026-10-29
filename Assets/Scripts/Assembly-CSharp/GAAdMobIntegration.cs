using System;
using GoogleMobileAds.Api;

public class GAAdMobIntegration
{
	[Serializable]
	public class AdMobImpressionData
	{
		public string adunit_id;

		public string currency;

		public int precision;

		public string adunit_format;

		public string network_class_name;

		public long revenue;
	}

	public static void ListenForImpressions(string adUnitId, BannerView ad, Action<string, string> callback)
	{
	}

	public static void ListenForImpressions(string adUnitId, InterstitialAd ad, Action<string, string> callback)
	{
	}

	public static void ListenForImpressions(string adUnitId, RewardedAd ad, Action<string, string> callback)
	{
	}

	public static void ListenForImpressions(string adUnitId, RewardedInterstitialAd ad, Action<string, string> callback)
	{
	}

	public static void ListenForImpressions(string adUnitId, AppOpenAd ad, Action<string, string> callback)
	{
	}
}
