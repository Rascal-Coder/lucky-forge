using System.Collections.Generic;
using CBS.Models;
using UnityEngine;
using UnityEngine.UI;

namespace CBS.UI
{
	public class SpecialOfferWindow : SpecialOfferFrame
	{
		[SerializeField]
		private Text DisplayName;

		[SerializeField]
		private Text Descrition;

		[SerializeField]
		private Transform PriceRoot;

		private List<GameObject> CurrencyPool { get; set; }

		private IStore Store { get; set; }

		protected override void Awake()
		{
		}

		public override void Load(CBSSpecialOffer offer)
		{
		}

		private void SpawnPrices()
		{
		}

		private void PurchaseRequest(string code, int value)
		{
		}

		private void OnPurchaseItem(CBSPurchaseStoreItemResult result)
		{
		}

		private void OnPurchaseItemWithRM(CBSPurchaseStoreItemWithRMResult result)
		{
		}

		public void CloseWindow()
		{
		}
	}
}
