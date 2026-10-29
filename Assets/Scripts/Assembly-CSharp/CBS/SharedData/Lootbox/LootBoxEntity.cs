using System.Collections.Generic;

namespace CBS.SharedData.Lootbox
{
	public class LootBoxEntity
	{
		public string ItemID;

		public bool TimerLocked;

		public int LockSeconds;

		public List<DropSlot> Slots;

		public void AddSlot(DropSlot slot)
		{
		}

		public void RemoveSlot(DropSlot slot)
		{
		}
	}
}
