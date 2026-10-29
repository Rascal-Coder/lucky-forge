using System.Collections.Generic;
using CBS.Core;
using CBS.Models;
using CBS.Scriptable;
using UnityEngine;

namespace CBS.UI
{
	public class Equipments : MonoBehaviour
	{
		[SerializeField]
		private BaseScroller ItemsScroller;

		private List<CBSInventoryItem> CurrentItems { get; set; }

		private ICBSInventory CBSInventory { get; set; }

		private InventoryPrefabs Prefabs { get; set; }

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void DisplayEquipments()
		{
		}

		private void OnGetInvertory(CBSGetInventoryResult result)
		{
		}

		private void DrawItems()
		{
		}

		private void OnItemSpawn(GameObject uiItem, int index)
		{
		}

		private void OnItemEquipmentChange(CBSInventoryItem item)
		{
		}

		private void OnItemClicked(CBSInventoryItem item)
		{
		}
	}
}
