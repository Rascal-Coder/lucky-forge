using System;

namespace CBS.Models
{
	public class BattlePassLevelInfo
	{
		public string BattlePassID { get; private set; }

		public BattlePassLevel LevelDetail { get; private set; }

		public int LevelIndex { get; private set; }

		public int ProfilePassLevel { get; private set; }

		public int ExpOfCurrentLevel { get; private set; }

		public int ExpStep { get; private set; }

		public bool IsPassActive { get; private set; }

		public bool PremiumAccess { get; private set; }

		public bool ExtraLevelAccess { get; private set; }

		public bool IsExtraLevel { get; private set; }

		public bool IsPremiumRewardCollected { get; private set; }

		public bool IsDefaultRewardCollected { get; private set; }

		public bool IsLast { get; private set; }

		public int MaxIndex { get; private set; }

		private BattlePassInstance PassInstance { get; set; }

		private BattlePassUserInfo State { get; set; }

		public BattlePassLevelInfo(BattlePassInstance instance, BattlePassUserInfo profileState, BattlePassLevel level, int index, int maxIndex)
		{
		}

		public void RebuildLevel(BattlePassLevel level, int index)
		{
		}

		public void ForceEnablePass()
		{
		}

		public void CollectReward(BattlePassRewardType type)
		{
		}

		public bool RewardIsActive(BattlePassRewardType type)
		{
			return false;
		}

		public bool IsRewardAvailableToCollect(BattlePassRewardType type)
		{
			return false;
		}

		public bool IsRewardCollected(BattlePassRewardType type)
		{
			return false;
		}

		public RewardObject GetReward(BattlePassRewardType type)
		{
			return null;
		}

		public bool IsRewardLocked(BattlePassRewardType type)
		{
			return false;
		}

		public bool IsRewardLockedByTimer(DateTime? requestDate = null)
		{
			return false;
		}

		public DateTime? GetLimitDate(DateTime? requestDate = null)
		{
			return null;
		}

		public bool IsExtraLevelLocked()
		{
			return false;
		}

		public bool IsCurrent()
		{
			return false;
		}

		public bool IsPassed()
		{
			return false;
		}
	}
}
