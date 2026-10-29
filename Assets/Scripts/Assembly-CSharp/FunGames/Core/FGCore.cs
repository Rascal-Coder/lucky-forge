using System.Collections.Generic;
using FunGames.Core.Modules;
using FunGames.Core.QAMode;
using UnityEngine;

namespace FunGames.Core
{
	[DefaultExecutionOrder(-43)]
	public class FGCore : FGModuleAbstract<FGCore, FGCoreCallbacks, FGMainSettings>
	{
		public FGNoInternetPopup NoInternetPopup;

		public FGUpdatePopup UpdateVersionPopup;

		[SerializeField]
		private FGQAModeConsole qaModePrefab;

		[SerializeField]
		private GameObject customQaModeMenu;

		public const string RC_LOG_LEVEL = "FGLogLevel";

		public const string RC_NO_ADS = "FGNoAds";

		public const string FG_DEEPLINK_SCHEME = "fgsdk";

		public const string PP_NO_ADS = "no_ads";

		public const string PP_DATE_FIRST_CO = "dateFirstCo";

		public const string PP_DATE_LAST_CO = "dateLastCo";

		public const string PP_CURRENT_SESSION_NUMBER = "CurrentSessionNumber";

		private List<FGAdType> _noAds;

		private bool _isFirstConnection;

		private int _daysSinceFirstConnection;

		private int _daysSinceLastConnection;

		private int _currentSessionNumber;

		public override FGMainSettings Settings => null;

		protected override FGModule Parent { get; }

		protected override string EventName => null;

		protected override string RemoteConfigKey => null;

		public bool HasCustomQaModeMenu => false;

		protected override void InitializeCallbacks()
		{
		}

		protected override void OnAwake()
		{
		}

		protected override void OnStart()
		{
		}

		protected override void InitializeModule()
		{
		}

		public void RemoveAds(params FGAdType[] ads)
		{
		}

		public void RemoveAdsForSession(params FGAdType[] ads)
		{
		}

		private void RemoveAllAds()
		{
		}

		public bool IsNoAd(FGAdType ad)
		{
			return false;
		}

		public void RestoreAds()
		{
		}

		private void CheckPlayerPref()
		{
		}

		private string NoAdPlayerPref(FGAdType adType)
		{
			return null;
		}

		public bool IsFirstConnection()
		{
			return false;
		}

		public int DaysSinceFirstConnection()
		{
			return 0;
		}

		public int DaysSinceLastConnection()
		{
			return 0;
		}

		public int GetCurrentSessionNumber()
		{
			return 0;
		}

		public bool HasInternetConnection()
		{
			return false;
		}

		private void OnRemoteConfigInitialized(bool obj)
		{
		}

		protected override void ClearInitialization()
		{
		}

		private void InitializeNoInternetPopup()
		{
		}

		private void InitializeUpdatePopup()
		{
		}

		private void InitializeQAMode()
		{
		}

		public void ToggleCustomQaModeMenu()
		{
		}

		private void TrackDeviceInfo()
		{
		}

		private void SendAnalytics(bool success)
		{
		}

		private List<FGModule> GetAllModulesRecursively(FGModule module)
		{
			return null;
		}

		private void CleanEventSystem()
		{
		}

		private void InitializeDeeplinks()
		{
		}

		private void OnDeepLinkActivated(string url)
		{
		}
	}
}
