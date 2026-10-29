using System.Collections.Generic;
using CBS.Core;
using CBS.Models;
using CBS.Scriptable;
using UnityEngine;
using UnityEngine.UI;

namespace CBS.UI
{
	public class Inventory : MonoBehaviour
	{
		[SerializeField]
		private ToggleGroup CategoryGroup;

		[SerializeField]
		private BaseScroller CategoryScroller;

		[SerializeField]
		private BaseScroller ItemsScroller;

		private Dictionary<string, InventorySlot> SlotCache;

		private string[] CurrentCategories { get; set; }

		private List<CBSInventoryItem> CurrentItems { get; set; }

		private string CurrentCategory { get; set; }

		private ICBSItems Items { get; set; }

		private ICBSInventory CBSInventory { get; set; }

		private ICrafting Crafting { get; set; }

		private InventoryPrefabs InventoryPrefabs { get; set; }

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void DisplayCategories()
		{
		}

		private void DrawItems()
		{
		}

		private void OnCategorySpawned(GameObject uiItem, int index)
		{
		}

		private void OnCategorySelected(string category)
		{
		}

		private void OnGetInventory(CBSGetInventoryResult result)
		{
		}

		private void OnItemSpawn(GameObject uiItem, int index)
		{
		}

		private void OnItemClicked(CBSInventoryItem item)
		{
		}

		private void OnItemEquipmentChange(CBSInventoryItem item)
		{
		}

		private void OnItemConsumed(ItemUsesCountChange changeResult)
		{
		}

		private void OnItemRemoved(string inventoryItemID)
		{
		}

		private void OnItemUpgraded(CBSInventoryItem item)
		{
		}
	}
}
