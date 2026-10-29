using System.Collections.Generic;
using FunGames.Core.Modules;
using GameAnalyticsSDK;
using UnityEngine;

namespace FunGames.Analytics.GA
{
	public class FGGameAnalytics : FGAnalyticsAbstract<FGGameAnalytics, FGAnalyticsCallbacks, FGGameAnalyticsSettings>
	{
		private const string RC_HEALTH_EVENTS = "fg_health_events";

		private bool isInit;

		public const string HIGH_END = "HighEnd";

		public const string LOW_END = "LowEnd";

		public override FGGameAnalyticsSettings Settings => null;

		protected override FGModule Parent => null;

		protected override string EventName => null;

		protected override string RemoteConfigKey => null;

		private string DeviceQuality => null;

		protected override void OnAwake()
		{
		}

		protected override void OnStart()
		{
		}

		protected override void Init()
		{
		}

		private static void AddOrUpdatePlatform(RuntimePlatform platform, string gameKey, string secretKey)
		{
		}

		private static void RemovePlatform(RuntimePlatform platform)
		{
		}

		protected override void ProgressionEvent(LevelStatus levelStatus, string progression01, int score = -1)
		{
		}

		protected override void ProgressionEvent(LevelStatus levelStatus, string progression01, string progression02, int score = -1)
		{
		}

		protected override void ProgressionEvent(LevelStatus levelStatus, string progression01, string progression02, string progression03, int score = -1)
		{
		}

		protected override void DesignEventSimple(string eventId, float eventValue)
		{
		}

		protected override void DesignEventDictio(string eventId, Dictionary<string, object> customFields)
		{
		}

		protected override void AdEvent(AdAction adAction, AdType adType, string adSdkName, string adPlacement)
		{
		}

		protected override void ClearInitialization()
		{
		}

		private string ValidEventName(string str)
		{
			return null;
		}

		private string ValidParameter(string str)
		{
			return null;
		}

		private GAProgressionStatus GetGAStatus(LevelStatus levelStatus)
		{
			return GAProgressionStatus.Undefined;
		}
	}
}
