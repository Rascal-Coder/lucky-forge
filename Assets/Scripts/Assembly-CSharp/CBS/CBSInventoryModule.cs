using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CBS.Models;
using CBS.Playfab;
using CBS.Scriptable;
using PlayFab.ClientModels;

namespace CBS
{
	public class CBSInventoryModule : CBSModule, ICBSInventory
	{
		private readonly string ItemsCatalog;

		[CompilerGenerated]
		private Action<ItemUsesCountChange> m_OnItemUsageCountChange;

		[CompilerGenerated]
		private Action<CBSInventoryItem> m_OnItemEquiped;

		[CompilerGenerated]
		private Action<CBSInventoryItem> m_OnItemUnEquiped;

		[CompilerGenerated]
		private Action<CBSInventoryItem> m_OnItemAdded;

		[CompilerGenerated]
		private Action<string> m_OnItemRemoved;

		[CompilerGenerated]
		private Action<CBSInventoryItem> m_OnLootboxAdded;

		[CompilerGenerated]
		private Action<LootboxBundle> m_OnLootboxOpen;

		[CompilerGenerated]
		private Action<CBSLootboxInventoryItem> m_OnLootboxTimerUnlocked;

		private IAuth Auth { get; set; }

		private IFabInventory FabInventory { get; set; }

		private IProfile Profile { get; set; }

		private ICBSItems Items { get; set; }

		private AuthData AuthData { get; set; }

		public Dictionary<string, CBSInventoryItem> InventoryCache { get; private set; }

		public Dictionary<string, CBSLootboxInventoryItem> LootBoxCache { get; private set; }

		public event Action<ItemUsesCountChange> OnItemUsageCountChange
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<CBSInventoryItem> OnItemEquiped
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<CBSInventoryItem> OnItemUnEquiped
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<CBSInventoryItem> OnItemAdded
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<string> OnItemRemoved
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<CBSInventoryItem> OnLootboxAdded
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<LootboxBundle> OnLootboxOpen
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<CBSLootboxInventoryItem> OnLootboxTimerUnlocked
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		protected override void Init()
		{
		}

		public void GetInventory(Action<CBSGetInventoryResult> result)
		{
		}

		public void GetInventoryByCategory(string category, Action<CBSGetInventoryResult> result)
		{
		}

		public void GetProfileInventoryByProfileID(string profileID, Action<CBSGetInventoryResult> result)
		{
		}

		public void GetInventoryByCategoryByProfileID(string profileID, string category, Action<CBSGetInventoryResult> result)
		{
		}

		public CBSGetInventoryResult GetInventoryFromCache(Action<CBSGetInventoryResult> result = null)
		{
			return null;
		}

		public void GetItemByInstanceID(string inventoryItemID, Action<CBSGetInventoryItemResult> result)
		{
		}

		public void RemoveInventoryItem(string instanceID, Action<CBSRemoveItemsResult> result)
		{
		}

		public void RemoveInventoryItems(string[] instanceIDs, Action<CBSRemoveItemsResult> result)
		{
		}

		public void RemoveInventoryItemFromProfile(string profileID, string instanceItemID, Action<CBSRemoveItemsResult> result)
		{
		}

		public void RemoveInventoryItemsFromProfile(string profileID, string[] instanceIDs, Action<CBSRemoveItemsResult> result)
		{
		}

		public void ModifyUsesCount(string instanceId, int modifyCount, Action<CBSModifyItemUsesCountResult> result)
		{
		}

		public void ConsumeItem(string instanceId, Action<CBSConsumeInventoryItemResult> result)
		{
		}

		public void ConsumeItem(string instanceId, int count, Action<CBSConsumeInventoryItemResult> result)
		{
		}

		public void GetLootboxes(Action<CBSGetLootboxesResult> result)
		{
		}

		public void GetLootboxesBadge(Action<CBSBadgeResult> result)
		{
		}

		public CBSBadgeResult GetLootboxesBadgeFromCache(Action<CBSBadgeResult> result = null)
		{
			return null;
		}

		public void GetLootboxesByCategory(string category, Action<CBSGetLootboxesResult> result)
		{
		}

		public CBSGetLootboxesResult GetLootboxesFromCache(Action<CBSGetLootboxesResult> result = null)
		{
			return null;
		}

		public void EquipItem(string instanceId, Action<CBSChangeEquipStateResult> result)
		{
		}

		public void UnEquipItem(string instanceId, Action<CBSChangeEquipStateResult> result)
		{
		}

		public void SetItemDataByKey(string instanceId, string dataKey, string dataValue, Action<CBSSetInventoryDataResult> result)
		{
		}

		public void OpenLootbox(string itemID, string instanceId, Action<CBSOpenLootboxResult> result)
		{
		}

		public void UnlockLootboxTimer(string instanceId, Action<CBSUnlockLootboxTimerResult> result)
		{
		}

		public CBSInventoryItem GetInventoryItemFromCache(string inventoryItemId)
		{
			return null;
		}

		private void InternalGetProfileInventory(string profileID, string specificCategory, Action<CBSGetInventoryResult> result)
		{
		}

		private void InternalGetProfileLootboxes(string profileID, string specificCategory, Action<CBSGetLootboxesResult> result)
		{
		}

		public void InternalConsumeItem(string profileID, string inventoryItemID, int consumeCount, Action<CBSConsumeInventoryItemResult> result)
		{
		}

		public void InternalModifyItemUsesCount(string profileID, string inventoryItemID, int countToModify, Action<CBSModifyItemUsesCountResult> result)
		{
		}

		private void InternalEquipUnequipItem(string profileID, string inventoryItemId, bool equip, Action<CBSChangeEquipStateResult> result)
		{
		}

		private void InternalRevokeInventoryItems(string profileID, string[] inventoryItemsIDs, Action<CBSRemoveItemsResult> result)
		{
		}

		internal List<CBSInventoryItem> ParseInventory(List<ItemInstance> items)
		{
			return null;
		}

		internal void AddRequest(CBSInventoryItem item)
		{
		}

		internal void AddRequest(List<CBSInventoryItem> items)
		{
		}

		internal void UpdateRequest(List<CBSInventoryItem> items)
		{
		}

		internal void UpdateRequest(CBSInventoryItem item)
		{
		}

		internal void RevokeRequest(string itemInventoryID)
		{
		}

		internal void RevokeRequest(List<string> itemsIDs)
		{
		}

		internal void ConsumeSpendRequest(string inventoryID, uint spendCount)
		{
		}

		internal void ConsumeSpendRequest(Dictionary<string, uint> spendDict)
		{
		}

		protected override void OnLogout()
		{
		}

		private void OnLoginSuccess(CBSLoginResult result)
		{
		}
	}
}
