using System.Collections.Generic;

namespace CBS
{
	public class BaseTaskState
	{
		public bool IsComplete;

		public int CurrentStep;

		public bool Rewarded;

		public bool IsAvailable;

		public int TierIndex;

		public List<int> GrantedRewards;

		public void MarkRewardsAsGranted()
		{
		}
	}
}
