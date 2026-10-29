using System.Collections.Generic;
using CBS.Core;
using CBS.Models;
using CBS.Scriptable;
using UnityEngine;

namespace CBS.UI
{
	public class RecipeInventory : MonoBehaviour
	{
		[SerializeField]
		private BaseScroller ItemsScroller;

		private Dictionary<string, DraggableInventorySlot> SlotCache;

		private List<CBSInventoryItem> CurrentItems { get; set; }

		private ICBSInventory CBSInventory { get; set; }

		private CraftPrefabs CraftPrefabs { get; set; }

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDestroy()
		{
		}

		private void DrawItems()
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
	}
}
