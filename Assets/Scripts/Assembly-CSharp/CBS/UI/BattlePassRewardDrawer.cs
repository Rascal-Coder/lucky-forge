using CBS.Scriptable;
using UnityEngine;

namespace CBS.UI
{
	public class BattlePassRewardDrawer : RewardDrawer
	{
		private BattlePassPrefabs PassPrefabs { get; set; }

		protected override GameObject RewardPrefab => null;

		public override void Init()
		{
		}

		public void MarkAsRewarded(bool isRewarded)
		{
		}

		public void MarkAsLocked(bool isLocked)
		{
		}
	}
}
