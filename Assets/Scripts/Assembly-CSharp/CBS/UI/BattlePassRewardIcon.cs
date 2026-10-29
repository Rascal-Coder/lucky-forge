using UnityEngine;

namespace CBS.UI
{
	public class BattlePassRewardIcon : SimpleIcon
	{
		[SerializeField]
		private GameObject RewardedObject;

		[SerializeField]
		private GameObject LockObject;

		public void MarkAsRewarded(bool isRewarded)
		{
		}

		public void MarkAsLocked(bool isLocked)
		{
		}
	}
}
