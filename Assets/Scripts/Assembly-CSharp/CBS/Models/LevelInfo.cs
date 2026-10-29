using System;

namespace CBS.Models
{
	[Serializable]
	public class LevelInfo
	{
		public string TargetID;

		public CBSEntityType Type;

		public int CurrentLevel;

		public int PrevLevelExp;

		public int NextLevelExp;

		public int CurrentExp;

		public RewardObject NextLevelReward;

		public bool ReachMaxLevel => false;

		public FunctionAddExpirienceResult ToAddExpResult(bool reachNewLevel, GrantRewardResult newLevelReward)
		{
			return null;
		}
	}
}
