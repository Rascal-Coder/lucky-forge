using System;

namespace FunGames.Mediation
{
	public class FGMediation
	{
		public static FGMediationCallbacks Callbacks => null;

		public static bool IsBannerReady => false;

		public static bool IsInterstitialReady => false;

		public static bool IsRewardedReady => false;

		public static bool IsMrecReady => false;

		public static bool IsAppOpenReady => false;

		public static float TimeSinceLastInterstitial => 0f;

		public static void ShowInterstitial(string placementName = "default", Action<bool> displayCallback = null)
		{
		}

		public static void ShowRewarded(Action<bool> rewardedCallback, string placementName = "default")
		{
		}

		public static void ShowBanner(string placementName = "default")
		{
		}

		public static void HideBanner()
		{
		}

		public static void ShowAppOpen(string placementName = "default", Action<bool> displayCallback = null)
		{
		}

		public static void AddAppOpenCondition(Func<bool> condition)
		{
		}

		public static void ShowMrec(string placementName = "default", Action<bool> displayCallback = null)
		{
		}

		public static void HideMrec()
		{
		}

		public static void ForceInitializeAds()
		{
		}
	}
}
