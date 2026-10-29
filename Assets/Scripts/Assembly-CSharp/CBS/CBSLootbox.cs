using System.Collections.Generic;
using CBS.Models;
using CBS.SharedData.Lootbox;
using PlayFab.ClientModels;

namespace CBS
{
	public class CBSLootbox : CBSBaseItem
	{
		public List<string> RandomItemsIDs { get; private set; }

		public Dictionary<string, uint> PackCurrecnies { get; private set; }

		public CBSLootboxTable LootboxTable { get; private set; }

		public CBSLootbox(CatalogItem item, CBSLootboxTable lootboxTable)
		{
		}

		public override CBSItemRecipe GetRecipeData()
		{
			return null;
		}

		public override List<CBSItemUpgradeState> GetUpgradeList()
		{
			return null;
		}
	}
}
