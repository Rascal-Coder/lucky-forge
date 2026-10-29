using System;
using FunGames.Core;

namespace FunGames.Mediation
{
	public interface IFGMediationAd
	{
		string AdUnitId { get; set; }

		FGAdType adType { get; }

		event Action<IFGMediationAd> OnAdLoaded;

		event Action<IFGMediationAd> OnAdLoadFailed;

		event Action<IFGMediationAd> OnAdClosed;

		event Action<IFGMediationAd> OnAdDisplayFailed;

		void InitializeCallbacks();

		void Load();

		void LoadWithDelay(float delay);

		void Show(string placementName = "default", Action<bool> callback = null);

		void Hide();

		bool IsReady();

		bool IsShowing();

		bool IsLoading();
	}
}
