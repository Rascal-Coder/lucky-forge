using System;
using CBS.Models;

namespace CBS
{
	public interface IAchievements
	{
		event Action<CBSTask> OnCompleteAchievement;

		event Action<CBSTask> OnCompleteAchievementTier;

		event Action<GrantRewardResult> OnProfileRewarded;

		void GetAchievementsTable(Action<CBSGetAchievementsTableResult> result);

		void GetActiveAchievementsTable(Action<CBSGetAchievementsTableResult> result);

		void GetCompletedAchievementsTable(Action<CBSGetAchievementsTableResult> result);

		void AddAchievementPoint(string achievementID, Action<CBSModifyAchievementPointResult> result);

		void AddAchievementPoint(string achievementID, int points, Action<CBSModifyAchievementPointResult> result);

		void UpdateAchievementPoint(string achievementID, int points, Action<CBSModifyAchievementPointResult> result);

		void PickupAchievementReward(string achievementID, Action<CBSPickupAchievementRewardResult> result);

		void ResetAchievement(string achievementID, Action<CBSResetAchievementResult> result);

		void GetAchievementsBadge(Action<CBSBadgeResult> result);
	}
}
