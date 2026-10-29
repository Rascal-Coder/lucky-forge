using System;
using System.Collections.Generic;
using CBS.Models;
using CBS.Scriptable;
using UnityEngine;
using UnityEngine.UI;

namespace CBS.UI
{
	public class SelectItemPopup : MonoBehaviour
	{
		[SerializeField]
		private SimpleItemScroller Scroller;

		[SerializeField]
		private GameObject SendButton;

		[SerializeField]
		private ToggleGroup Group;

		private ICBSInventory CBSInventory { get; set; }

		private ChatPrefabs ChatPrefabs { get; set; }

		private Action<CBSInventoryItem> SelectAction { get; set; }

		private CBSInventoryItem SelectedItem { get; set; }

		private void Awake()
		{
		}

		public void Show(Action<CBSInventoryItem> selectAction)
		{
		}

		private void LoadItems()
		{
		}

		private void DisplayItems(List<CBSInventoryItem> items)
		{
		}

		private void OnGetItems(CBSGetInventoryResult result)
		{
		}

		private void OnSelectItem(CBSInventoryItem item)
		{
		}

		public void SelectItemHandler()
		{
		}
	}
}
