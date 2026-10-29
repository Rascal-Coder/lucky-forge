using System.Collections.Generic;

namespace CBS.Models
{
	public class CalendarProfileMeta
	{
		public Dictionary<int, bool> RewardedItems;

		public bool IsRewarded(int positionIndex)
		{
			return false;
		}

		public void AddReward(int index)
		{
		}
	}
}
