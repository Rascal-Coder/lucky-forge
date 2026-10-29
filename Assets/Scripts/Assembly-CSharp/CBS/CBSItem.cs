using System.Collections.Generic;
using CBS.Models;
using PlayFab.ClientModels;

namespace CBS
{
	public class CBSItem : CBSBaseItem
	{
		public bool IsConsumable { get; private set; }

		public bool IsStackable { get; private set; }

		public bool IsTradable { get; private set; }

		public bool HasLifeTime { get; private set; }

		public int UsageCount { get; private set; }

		public int LifeTime { get; private set; }

		public bool IsEquippable { get; private set; }

		public bool IsRecipe { get; private set; }

		public CBSItemRecipe RecipeData { get; private set; }

		public bool IsUpgradable { get; private set; }

		private List<CBSItemUpgradeState> UpgradeData { get; set; }

		public CBSItem(CatalogItem item, CBSItemRecipe recipeData, List<CBSItemUpgradeState> upgradeInfo)
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
