using System;
using System.Collections.Generic;
using FunGames.Core.Modules;
using FunGames.Core.Settings;

namespace FunGames.Analytics
{
	public abstract class FGAnalyticsAbstract<M, C, S> : FGModuleAbstract<M, C, S> where M : FGModuleAbstract<M, C, S> where C : FGAnalyticsCallbacks, new() where S : IFGModuleSettings
	{
		public List<Action> PoolEvents;

		protected abstract void Init();

		protected override void InitializeCallbacks()
		{
		}

		protected override void InitializeModule()
		{
		}

		protected abstract void ProgressionEvent(LevelStatus levelStatus, string prog01, int score = -1);

		protected abstract void ProgressionEvent(LevelStatus levelStatus, string prog01, string prog02, int score = -1);

		protected abstract void ProgressionEvent(LevelStatus levelStatus, string prog01, string prog02, string prog03, int score = -1);

		protected abstract void DesignEventSimple(string eventId, float eventValue);

		protected abstract void DesignEventDictio(string eventId, Dictionary<string, object> customFields);

		protected abstract void AdEvent(AdAction adAction, AdType adType, string adSdkName, string adPlacement);

		public void SendProgressionEvent(LevelStatus levelStatus, string prog01, int score = -1)
		{
		}

		public void SendProgressionEvent(LevelStatus levelStatus, string prog01, string prog02, int score = -1)
		{
		}

		public void SendProgressionEvent(LevelStatus levelStatus, string prog01, string prog02, string prog03, int score = -1)
		{
		}

		public void SendDesignEventSimple(string eventId, float eventValue)
		{
		}

		public void SendDesignEventDictio(string eventId, Dictionary<string, object> customFields, float eventValue = 0f)
		{
		}

		public void SendAdEvent(AdAction adAction, AdType adType, string adSdkName, string adPlacement)
		{
		}

		protected void EventReceived(string eventName, bool eventReceived)
		{
		}

		private void SendAllPoolEvents(bool moduleInitialized)
		{
		}

		protected override void ClearInitialization()
		{
		}
	}
}
