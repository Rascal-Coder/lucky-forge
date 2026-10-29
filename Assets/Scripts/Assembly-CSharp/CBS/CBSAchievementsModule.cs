using System;
using System.Runtime.CompilerServices;
using CBS.Models;
using CBS.Playfab;

namespace CBS
{
	public class CBSAchievementsModule : CBSModule, IAchievements
	{
		[CompilerGenerated]
		private Action<CBSTask> m_OnCompleteAchievement;

		[CompilerGenerated]
		private Action<CBSTask> m_OnCompleteAchievementTier;

		[CompilerGenerated]
		private Action<GrantRewardResult> m_OnProfileRewarded;

		private IProfile Profile { get; set; }

		private IFabAchievements FabAchievements { get; set; }

		public event Action<CBSTask> OnCompleteAchievement
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<CBSTask> OnCompleteAchievementTier
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<GrantRewardResult> OnProfileRewarded
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		protected override void Init()
		{
		}

		public void GetAchievementsTable(Action<CBSGetAchievementsTableResult> result)
		{
		}

		public void GetActiveAchievementsTable(Action<CBSGetAchievementsTableResult> result)
		{
		}

		public void GetCompletedAchievementsTable(Action<CBSGetAchievementsTableResult> result)
		{
		}

		public void AddAchievementPoint(string achievementID, Action<CBSModifyAchievementPointResult> result)
		{
		}

		public void AddAchievementPoint(string achievementID, int points, Action<CBSModifyAchievementPointResult> result)
		{
		}

		public void UpdateAchievementPoint(string achievementID, int points, Action<CBSModifyAchievementPointResult> result)
		{
		}

		public void PickupAchievementReward(string achievementID, Action<CBSPickupAchievementRewardResult> result)
		{
		}

		public void ResetAchievement(string achievementID, Action<CBSResetAchievementResult> result)
		{
		}

		public void GetAchievementsBadge(Action<CBSBadgeResult> result)
		{
		}

		private void InternalModifyPoints(string achievementID, int points, ModifyMethod modify, Action<CBSModifyAchievementPointResult> result)
		{
		}

		private void InternalGetAchievements(TasksState queryType, Action<CBSGetAchievementsTableResult> result)
		{
		}
	}
}
