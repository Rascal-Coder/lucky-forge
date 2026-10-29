using System;
using System.Collections.Generic;
using CBS.Models;
using CBS.Scriptable;
using UnityEngine;

namespace CBS.UI
{
	public class ProfileInventoryInsideClan : MonoBehaviour
	{
		[SerializeField]
		private SimpleItemScroller Scroller;

		public Action UpdateRequest;

		private ICBSInventory CBSInventory { get; set; }

		private IClanEconomy ClanEconomy { get; set; }

		private InventoryPrefabs Prefabs { get; set; }

		private Action<CBSInventoryItem> SelectAction { get; set; }

		private void Awake()
		{
		}

		public void Show(Action<CBSInventoryItem> selectAction)
		{
		}

		public void LoadInventory()
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
	}
}
