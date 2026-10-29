using System.Collections.Generic;

namespace CBS.SharedData.Lootbox
{
	public class CBSLootboxTable
	{
		public Dictionary<string, LootBoxEntity> LootBoxDropTable;

		public LootBoxEntity GetDropEntityForItem(string itemID)
		{
			return null;
		}

		public void RemoveEntity(string itemID)
		{
		}

		public bool ContainItem(string itemID)
		{
			return false;
		}
	}
}
