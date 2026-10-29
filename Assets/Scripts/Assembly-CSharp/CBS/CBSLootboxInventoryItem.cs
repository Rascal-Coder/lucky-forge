using System;
using System.Collections.Generic;
using CBS.SharedData.Lootbox;
using PlayFab.ClientModels;

namespace CBS
{
	public class CBSLootboxInventoryItem : CBSInventoryItem
	{
		public bool LockedByTimer => false;

		public DateTime? UnlockDate { get; private set; }

		public List<DropSlot> RewardSlots { get; private set; }

		private LootBoxEntity Entity { get; set; }

		private bool ForceUnlocked { get; set; }

		public CBSLootboxInventoryItem(ItemInstance inventoryItem, CBSBaseItem baseItem)
			: base(null, null)
		{
		}

		public int GetLeftSecondsToUnlock()
		{
			return 0;
		}
	}
}
