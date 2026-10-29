using System;
using System.Collections.Generic;
using FunGames.Core;
using FunGames.Monetization.Ads.Mediation;

namespace FunGames.Mediation.ApplovinMax
{
	public class FGMaxAdContainer
	{
		public List<IFGMediationAd> AdUnitsOrdered;

		public Dictionary<IFGMediationAd, bool> LoadingAdUnits;

		private int _cycle;

		private int _currentIndex;

		private bool _showRequested;

		private string currentPlacement;

		private Action<bool> currentCallback;

		public FGAdType AdType { get; }

		public FGMaxAdContainer(FGAdType adType)
		{
		}

		public List<IFGMediationAd> CreateInstances<T>(List<T> adUnitsOrdered) where T : FGAdUnitOrdered
		{
			return null;
		}

		public void LoadFirst()
		{
		}

		public void LoadNext()
		{
		}

		public void Show(string placementName, Action<bool> callback)
		{
		}

		private List<T> GetOrderedAds<T>(FGAdType adType, List<T> list) where T : FGAdUnitOrdered
		{
			return null;
		}

		private IFGMediationAd CreateInstance(FGAdUnitOrdered fgAdUnit)
		{
			return null;
		}

		private void OnDisplayFailed(IFGMediationAd ad)
		{
		}

		private void OnAdClosed(IFGMediationAd ad)
		{
		}

		private void OnLoadFailed(IFGMediationAd ad)
		{
		}

		private void OnAdLoaded(IFGMediationAd ad)
		{
		}

		private List<FGAdUnitRemote> GetRemoteAdUnitIds(FGAdType adType)
		{
			return null;
		}

		private FGAdUnitOrdered GetDefaultAdUnits(FGAdType adType)
		{
			return null;
		}

		private bool IsForCurrentPlatform(FGAdUnit fgAdUnit)
		{
			return false;
		}

		private FGPlatform GetCurrentPlatform()
		{
			return FGPlatform.IOS;
		}

		private bool IsAtLeastOneAdReady()
		{
			return false;
		}

		private bool IsAdShowing()
		{
			return false;
		}
	}
}
