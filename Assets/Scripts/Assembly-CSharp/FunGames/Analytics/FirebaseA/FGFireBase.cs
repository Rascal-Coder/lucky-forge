using System;
using System.Collections.Generic;
using Firebase;
using FunGames.Core.Modules;

namespace FunGames.Analytics.FirebaseA
{
	public class FGFireBase : FGAnalyticsAbstract<FGFireBase, FGAnalyticsCallbacks, FGFirebaseSettings>
	{
		private Action<string, FGAdInfo> _interImpressionCallback;

		private Action<string, FGAdInfo> _bannerImpressionCallback;

		private Action<string, FGAdInfo> _rewardedImpressionCallback;

		private Action<string, FGAdInfo> _crosspromoImpressionCallback;

		private Action<string, FGAdInfo> _mrecImpressionCallback;

		public override FGFirebaseSettings Settings => null;

		protected override FGModule Parent => null;

		protected override string EventName => null;

		protected override string RemoteConfigKey => null;

		protected override void InitializeCallbacks()
		{
		}

		protected override void OnAwake()
		{
		}

		protected override void OnStart()
		{
		}

		protected override void Init()
		{
		}

		private void DependencyCheckCompleted(DependencyStatus status)
		{
		}

		protected override void ProgressionEvent(LevelStatus levelStatus, string prog01, int score = -1)
		{
		}

		protected override void ProgressionEvent(LevelStatus levelStatus, string prog01, string prog02, int score = -1)
		{
		}

		protected override void ProgressionEvent(LevelStatus levelStatus, string prog01, string prog02, string prog03, int score = -1)
		{
		}

		private void SendProgressionEvent(LevelStatus levelStatus, string paramValue)
		{
		}

		private string BuildProgressionParameterValue(int score = -1, params string[] prog)
		{
			return null;
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

		private string ValidEventName(string eventName)
		{
			return null;
		}

		protected override void ClearInitialization()
		{
		}

		private void SendAdImpressionEvent(string format, FGAdInfo adInfo)
		{
		}
	}
}
