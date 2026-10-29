using System;
using CBS.Models;

namespace CBS
{
	public interface ICrafting
	{
		event Action<CBSInventoryItem> OnItemCrafted;

		event Action<CBSInventoryItem> OnItemUpgraded;

		void GetRecipeDependencyState(string itemID, Action<CBSGetRecipeDependencyStateResult> result);

		void GetRecipeDependencyStateFromCache(string itemID, Action<CBSGetRecipeDependencyStateResult> result);

		void CraftItemFromRecipe(string recipeInventoryID, Action<CBSCraftResult> result);

		void CraftItemFromRecipeTemplate(string recipeID, Action<CBSCraftResult> result);

		void GetItemNextUpgradeState(string inventoryItemID, Action<CBSGetNextUpgradeStateResult> result);

		void GetItemNextUpgradeStateFromCache(string inventoryItemID, Action<CBSGetNextUpgradeStateResult> result);

		void UpgradeItemToNextLevel(string inventoryItemID, Action<CBSUpgradeItemResult> result);
	}
}
