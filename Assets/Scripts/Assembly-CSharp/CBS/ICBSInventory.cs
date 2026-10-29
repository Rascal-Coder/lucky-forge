using System;
using CBS.Models;

namespace CBS
{
	public interface ICBSInventory
	{
		event Action<ItemUsesCountChange> OnItemUsageCountChange;

		event Action<CBSInventoryItem> OnItemEquiped;

		event Action<CBSInventoryItem> OnItemUnEquiped;

		event Action<CBSInventoryItem> OnItemAdded;

		event Action<string> OnItemRemoved;

		event Action<CBSInventoryItem> OnLootboxAdded;

		event Action<LootboxBundle> OnLootboxOpen;

		void GetInventory(Action<CBSGetInventoryResult> OnGetResult);

		void GetInventoryByCategory(string category, Action<CBSGetInventoryResult> OnGetResult);

		void GetProfileInventoryByProfileID(string profileID, Action<CBSGetInventoryResult> result);

		void GetInventoryByCategoryByProfileID(string profileID, string category, Action<CBSGetInventoryResult> result);

		void ModifyUsesCount(string instanceId, int modifyCount, Action<CBSModifyItemUsesCountResult> result);

		void ConsumeItem(string instanceId, Action<CBSConsumeInventoryItemResult> result);

		void ConsumeItem(string instanceId, int count, Action<CBSConsumeInventoryItemResult> result);

		void GetItemByInstanceID(string instanceID, Action<CBSGetInventoryItemResult> result);

		void SetItemDataByKey(string instanceId, string dataKey, string dataValue, Action<CBSSetInventoryDataResult> result);

		void EquipItem(string instanceId, Action<CBSChangeEquipStateResult> result);

		void UnEquipItem(string instanceId, Action<CBSChangeEquipStateResult> result);

		void GetLootboxes(Action<CBSGetLootboxesResult> result);

		void GetLootboxesBadge(Action<CBSBadgeResult> result);

		CBSBadgeResult GetLootboxesBadgeFromCache(Action<CBSBadgeResult> result = null);

		void GetLootboxesByCategory(string category, Action<CBSGetLootboxesResult> result);

		void OpenLootbox(string itemID, string instanceId, Action<CBSOpenLootboxResult> result);

		void UnlockLootboxTimer(string instanceId, Action<CBSUnlockLootboxTimerResult> result);

		CBSGetInventoryResult GetInventoryFromCache(Action<CBSGetInventoryResult> result = null);

		CBSGetLootboxesResult GetLootboxesFromCache(Action<CBSGetLootboxesResult> result = null);

		CBSInventoryItem GetInventoryItemFromCache(string inventoryItemId);

		void RemoveInventoryItem(string instanceID, Action<CBSRemoveItemsResult> result);

		void RemoveInventoryItems(string[] instanceIDs, Action<CBSRemoveItemsResult> result);

		void RemoveInventoryItemFromProfile(string profileID, string instanceID, Action<CBSRemoveItemsResult> result);

		void RemoveInventoryItemsFromProfile(string profileID, string[] instanceIDs, Action<CBSRemoveItemsResult> result);
	}
}
