using System;
using PlayFab;
using PlayFab.CloudScriptModels;

namespace CBS.Playfab
{
	public class FabCrafting : FabExecuter, IFabCrafting
	{
		public void GetRecipeDependencyState(string profileID, string itemID, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void CraftItemFromRecipe(string profileID, string recipeInventoryID, Action<ExecuteFunctionResult> onCraft, Action<PlayFabError> onFailed)
		{
		}

		public void CraftItemWithoutRecipe(string profileID, string recipeID, Action<ExecuteFunctionResult> onCraft, Action<PlayFabError> onFailed)
		{
		}

		public void GetItemNextUpgradeState(string profileID, string inventoryItemID, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void UpgradeItemWithNextState(string profileID, string inventoryItemID, Action<ExecuteFunctionResult> onUpgrade, Action<PlayFabError> onFailed)
		{
		}
	}
}
