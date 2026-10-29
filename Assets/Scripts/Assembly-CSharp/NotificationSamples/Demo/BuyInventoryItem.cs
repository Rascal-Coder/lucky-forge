using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NotificationSamples.Demo
{
	public class BuyInventoryItem : MonoBehaviour
	{
		[SerializeField]
		protected TextMeshProUGUI titleLabel;

		[SerializeField]
		protected TextMeshProUGUI timeLabel;

		[SerializeField]
		protected TextMeshProUGUI costLabel;

		[SerializeField]
		protected Image icon;

		[SerializeField]
		protected Button buyButton;

		[SerializeField]
		protected Image progressImage;

		private Action<BuyInventoryItem> bought;

		private DateTime? deliveryTime;

		private float initialTimeRemaining;

		private int currency;

		public string Title => null;

		public string Description { get; private set; }

		public float Minutes { get; set; }

		public int Cost { get; set; }

		public InventoryItemData ItemData { get; private set; }

		public void Initialise(InventoryItemData itemData, Action<BuyInventoryItem> buyAction)
		{
		}

		public void OnBuy()
		{
		}

		public void OnBuySuccess(DateTime boughtDeliveryTime)
		{
		}

		public void UpdateControls()
		{
		}

		public void OnCurrencyChanged(int newCurrency)
		{
		}

		public void OnDeliveredItem(InventoryItemData itemData)
		{
		}

		private float GetTimeRemaining()
		{
			return 0f;
		}

		private void Update()
		{
		}

		private void UpdateBuyButton()
		{
		}

		private void UpdateProgress()
		{
		}
	}
}
