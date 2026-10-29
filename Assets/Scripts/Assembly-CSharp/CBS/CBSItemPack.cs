using System.Collections.Generic;
using CBS.Models;
using PlayFab.ClientModels;

namespace CBS
{
	public class CBSItemPack : CBSBaseItem
	{
		public List<string> PackItemsIDs { get; private set; }

		public Dictionary<string, uint> PackCurrecnies { get; private set; }

		public CBSItemPack(CatalogItem item)
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
