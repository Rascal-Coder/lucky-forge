using System.Collections.Generic;
using CBS.Core;
using CBS.Models;
using CBS.Scriptable;
using UnityEngine;
using UnityEngine.UI;

namespace CBS.UI
{
	public class LootBoxWindow : MonoBehaviour
	{
		[SerializeField]
		private GameObject OpenBtn;

		[SerializeField]
		private GameObject UnlockBtn;

		[SerializeField]
		private BaseScroller Scroller;

		[SerializeField]
		private ToggleGroup Group;

		private ICBSInventory CBSInventory { get; set; }

		private List<CBSLootboxInventoryItem> CurrentBoxes { get; set; }

		private LootboxPrefabs Prefabs { get; set; }

		private CBSLootboxInventoryItem SelectedBox { get; set; }

		private LootBoxSlot SelectedSlot { get; set; }

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		private void OnEnable()
		{
		}

		private void GetLootBoxes()
		{
		}

		private void OnLootBoxGetted(CBSGetLootboxesResult result)
		{
		}

		private void OnItemSpawn(GameObject uiItem, int index)
		{
		}

		private void OnBoxSelected(CBSLootboxInventoryItem box, LootBoxSlot slot)
		{
		}

		public void OpenLootBox()
		{
		}

		public void UnlockLootBox()
		{
		}

		private void OnOpenLootBox(CBSOpenLootboxResult result)
		{
		}

		private void LootboxUnlocked(CBSUnlockLootboxTimerResult result)
		{
		}
	}
}
