using System;
using System.Collections.Generic;

namespace CBS
{
	[Serializable]
	public class LevelRewardObject
	{
		public List<LevelRewardItem> BundledItems;

		public List<LevelRewardItem> Lootboxes;

		public List<LevelRewardCurrency> BundledVirtualCurrencies;

		public bool AddExpirience;

		public bool ExpirienceOnce;

		public int ExpirienceValue;

		public bool IsEmpty()
		{
			return false;
		}

		public int GetPositionCount()
		{
			return 0;
		}
	}
}
