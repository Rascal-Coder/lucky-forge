using System;
using FunGames.Core.Modules;

namespace FunGames.Mediation
{
	public class FGMediationCallbacks : FGModuleCallbacks
	{
		internal Action _InitializeAds;

		internal Action<string> _ShowBanner;

		internal Action _HideBanner;

		internal Action<FGAdInfo> _OnBannerAdLoaded;

		internal Action<FGAdInfo> _OnBannerAdClicked;

		internal Action<string, FGAdInfo> _OnBannerAdImpression;

		internal Action _OnBannerAdFailedToLoad;

		internal Action<Action<bool>, string> _ShowInter;

		internal Action<FGAdInfo> _OnInterstitialAdLoaded;

		internal Action<FGAdInfo> _OnInterstitialAdDisplayed;

		internal Action<FGAdInfo> _OnInterstitialAdDismissed;

		internal Action<FGAdInfo> _OnInterstitialAdClicked;

		internal Action<string, FGAdInfo> _OnInterstitialAdImpression;

		internal Action _OnInterstitialAdFailedToLoad;

		internal Action<FGAdInfo> _OnInterstitialAdFailedToDisplay;

		internal Action<Action<bool>, string> _ShowRV;

		internal Action<FGAdInfo> _OnRewardedLoaded;

		internal Action<FGAdInfo> _OnRewardedDisplayed;

		internal Action<FGAdInfo> _OnRewardedDismissed;

		internal Action<FGAdInfo> _OnRewardedClicked;

		internal Action<string, FGAdInfo> _OnRewardedAdImpression;

		internal Action<FGAdInfo> _OnRewardReceived;

		internal Action _OnRewardedFailedToLoad;

		internal Action<FGAdInfo> _OnRewardedFailedToDisplay;

		internal Action<Action<bool>, string> _ShowAppOpen;

		internal Action<FGAdInfo> _OnAppOpenAdLoaded;

		internal Action<FGAdInfo> _OnAppOpenAdDisplayed;

		internal Action<FGAdInfo> _OnAppOpenAdDismissed;

		internal Action<FGAdInfo> _OnAppOpenAdClicked;

		internal Action<string, FGAdInfo> _OnAppOpenAdImpression;

		internal Action _OnAppOpenAdFailedToLoad;

		internal Action<FGAdInfo> _OnAppOpenAdFailedToDisplay;

		internal Action<Action<bool>, string> _ShowMrec;

		internal Action _HideMrec;

		internal Action<FGAdInfo> _OnMrecAdLoaded;

		internal Action<FGAdInfo> _OnMrecAdClicked;

		internal Action<string, FGAdInfo> _OnMrecAdImpression;

		internal Action _OnMrecAdFailedToLoad;

		internal Action<FGAdInfo> _OnMrecAdDisplayed;

		internal Action<FGAdInfo> _OnMrecAdClosed;

		internal Action<string, FGAdInfo> _OnCrosspromoAdImpression;

		public event Action InitializeAds
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action<string> ShowBanner
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action HideBanner
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action<FGAdInfo> OnBannerAdLoaded
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action<FGAdInfo> OnBannerAdDisplayed
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action<FGAdInfo> OnBannerAdClicked
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action OnBannerAdFailedToLoad
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action<string, FGAdInfo> OnBannerAdImpression
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action<Action<bool>, string> ShowInterstitial
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action<FGAdInfo> OnInterstitialAdLoaded
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action<FGAdInfo> OnInterstitialAdDisplayed
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action<FGAdInfo> OnInterstitialClosed
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action<FGAdInfo> OnInterstitialAdClicked
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action<string, FGAdInfo> OnInterstitialAdImpression
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action OnInterstitialAdFailedToLoad
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action<FGAdInfo> OnInterstitialAdFailedToDisplay
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action<Action<bool>, string> ShowRewarded
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action<FGAdInfo> OnRewardedAdLoaded
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action<FGAdInfo> OnRewardedAdDisplayed
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action<FGAdInfo> OnRewardedAdClosed
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action<FGAdInfo> OnRewardedAdClicked
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action<string, FGAdInfo> OnRewardedAdImpression
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action<FGAdInfo> OnRewardedAdRewardReceived
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action OnRewardedAdFailedToLoad
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action<FGAdInfo> OnRewardedAdFailedToDisplay
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action<Action<bool>, string> ShowAppOpen
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action<FGAdInfo> OnAppOpenAdLoaded
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action<FGAdInfo> OnAppOpenDisplayed
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action<FGAdInfo> OnAppOpenClosed
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action<FGAdInfo> OnAppOpenAdClicked
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action<FGAdInfo> OnAppOpenAdClosed
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action<string, FGAdInfo> OnAppOpenAdImpression
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action OnAppOpenAdFailedToLoad
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action<FGAdInfo> OnAppOpenAdFailedToDisplay
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action<Action<bool>, string> ShowMrec
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action HideMrec
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action<FGAdInfo> OnMrecAdLoaded
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action<FGAdInfo> OnMrecAdClicked
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action<string, FGAdInfo> OnMrecAdImpression
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action OnMrecAdFailedToLoad
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action<FGAdInfo> OnMrecAdClosed
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action<FGAdInfo> OnMrecAdDisplayed
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action<string, FGAdInfo> OnCrosspromoAdImpression
		{
			add
			{
			}
			remove
			{
			}
		}

		public override void Clear()
		{
		}
	}
}
