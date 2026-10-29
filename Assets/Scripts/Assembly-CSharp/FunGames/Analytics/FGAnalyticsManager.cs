using System;
using System.Collections.Generic;
using FunGames.Core.Modules;

namespace FunGames.Analytics
{
	public class FGAnalyticsManager : FGModuleAbstract<FGAnalyticsManager, FGAnalyticsCallbacks, FGAnalyticsSettings>
	{
		private Action _onInitialized;

		public override FGAnalyticsSettings Settings => null;

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

		protected override void InitializeModule()
		{
		}

		public void SendProgressionEvent(LevelStatus levelStatus, string prog01, int score)
		{
		}

		public void SendProgressionEvent(LevelStatus levelStatus, string prog01, string prog02, int score)
		{
		}

		public void SendProgressionEvent(LevelStatus levelStatus, string prog01, string prog02, string prog03, int score)
		{
		}

		public void SendDesignEventSimple(string eventId, float eventValue)
		{
		}

		public void SendDesignEventDictio(string eventId, Dictionary<string, object> customFields, float eventValue)
		{
		}

		public void SendAdEvent(AdAction adAction, AdType adType, string adSdkName, string adPlacement)
		{
		}

		protected override void ClearInitialization()
		{
		}
	}
}
