using System.Collections.Generic;
using CBS.SharedData.Lootbox;
using PlayFab.ClientModels;

namespace CBS.Models
{
	public class FunctionFetchItemsResult
	{
		public GetCatalogItemsResult ItemsResult;

		public Dictionary<string, string> Categories;

		public CBSRecipeContainer Recipes;

		public CBSItemUpgradesContainer Upgrades;

		public CBSLootboxTable LootboxTable;
	}
}
