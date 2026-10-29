using System;
using PlayFab;
using PlayFab.CloudScriptModels;

namespace CBS.Playfab
{
	public class FabInventory : FabExecuter, IFabInventory
	{
		public void GetInventory(string profileID, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void GetItemByInventoryID(string profileID, string inventoryItemID, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void GetLootBoxes(string profileID, string lootboxesIDsRaw, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void GetLootBoxesBadge(string profileID, string lootboxesIDsRaw, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void SetItemEquipState(string profileID, string inventoryItemID, bool state, Action<ExecuteFunctionResult> onRemove, Action<PlayFabError> onFailed)
		{
		}

		public void RemokeInventoryItemsFromProfile(string profileID, string[] inventoryIDs, Action<ExecuteFunctionResult> onRemove, Action<PlayFabError> onFailed)
		{
		}

		public void ConsumeItem(string profileID, string instanceID, int count, Action<ExecuteFunctionResult> onConsume, Action<PlayFabError> onFailed)
		{
		}

		public void ModifyItemUsesCount(string profileID, string instanceID, int count, Action<ExecuteFunctionResult> onModify, Action<PlayFabError> onFailed)
		{
		}

		public void UpdateItemDataByKey(string profileID, string inventoryItemID, string dataKey, string dataValue, Action<ExecuteFunctionResult> onUpdate, Action<PlayFabError> onFailed)
		{
		}

		public void UnlockContainer(string profileID, string itemID, string inventoryItemID, Action<ExecuteFunctionResult> onUnlock, Action<PlayFabError> onFailed)
		{
		}

		public void UnlockLootboxTimer(string profileID, string inventoryItemID, Action<ExecuteFunctionResult> onUnlock, Action<PlayFabError> onFailed)
		{
		}
	}
}
