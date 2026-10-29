using System;
using System.Collections.Generic;
using CBS.Core;
using CBS.Models;
using CBS.Scriptable;
using UnityEngine;
using UnityEngine.UI;

namespace CBS.UI
{
	public class StoreItem : MonoBehaviour, IScrollableItem<CBSStoreItem>
	{
		[SerializeField]
		private Text DisplayName;

		[SerializeField]
		private Text Description;

		[SerializeField]
		private Text Notification;

		[SerializeField]
		private Image Icon;

		[SerializeField]
		private Transform PriceRoot;

		private List<GameObject> CurrencyPool { get; set; }

		private CBSStoreItem Item { get; set; }

		private StorePrefabs Prefabs { get; set; }

		private IStore Store { get; set; }

		private DateTime? LimitResetDate { get; set; }

		private void Awake()
		{
		}

		private void OnDisable()
		{
		}

		public void Display(CBSStoreItem item)
		{
		}

		private void DisplayNotification(StoreLimitationInfo limitInfo)
		{
		}

		private void SpawnPrices()
		{
		}

		private void ResetButtonsActivity()
		{
		}

		private void CheckButtonsActivity(StoreLimitationInfo limitInfo)
		{
		}

		private void PurchaseRequest(string code, int value)
		{
		}

		private void LateUpdate()
		{
		}

		private void DisplayLimitationTimer()
		{
		}

		private void OnPurchaseItem(CBSPurchaseStoreItemResult result)
		{
		}

		private void OnPurchaseItemWithRM(CBSPurchaseStoreItemWithRMResult result)
		{
		}
	}
}
