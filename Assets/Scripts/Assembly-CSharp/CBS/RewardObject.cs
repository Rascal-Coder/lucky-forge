using System;
using System.Collections.Generic;

namespace CBS
{
	[Serializable]
	public class RewardObject
	{
		public List<string> BundledItems;

		public List<string> Lootboxes;

		public Dictionary<string, uint> BundledVirtualCurrencies;

		public bool AddExpirience;

		public int ExpirienceValue;

		public bool IsEmpty()
		{
			return false;
		}

		public int GetPositionCount()
		{
			return 0;
		}

		public RewardObject MergeReward(RewardObject rewardToMerge)
		{
			return null;
		}
	}
}
