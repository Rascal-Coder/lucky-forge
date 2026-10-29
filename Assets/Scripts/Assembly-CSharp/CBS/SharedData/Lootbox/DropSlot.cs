using System.Collections.Generic;

namespace CBS.SharedData.Lootbox
{
	public class DropSlot
	{
		public DropBehavior DropBehavior;

		public SlotDropType SlotDropType;

		public float DropChance;

		public List<DropItem> ItemsToDrop;

		public List<DropCurrency> CurrenciesToDrop;

		public void AddItem(DropItem item)
		{
		}

		public void RemoveItem(DropItem item)
		{
		}

		public void AddCurrency(DropCurrency item)
		{
		}

		public void RemoveCurrency(DropCurrency item)
		{
		}
	}
}
