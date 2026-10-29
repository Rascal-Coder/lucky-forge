using CBS.Scriptable;
using UnityEngine;
using UnityEngine.UI;

namespace CBS.UI
{
	public class CurrencyPackItem : MonoBehaviour
	{
		[SerializeField]
		private Text Title;

		[SerializeField]
		private Text Description;

		[SerializeField]
		private Image Icon;

		[SerializeField]
		private Text Price;

		[SerializeField]
		private Transform CurrencySlots;

		private CBSCurrencyPack Pack { get; set; }

		private CurrencyPrefabs Prefabs { get; set; }

		private ICurrency Currency { get; set; }

		private ICBSInAppPurchase CBSPurchase { get; set; }

		private void Awake()
		{
		}

		public void Display(CBSCurrencyPack pack)
		{
		}

		public void PurchasePack()
		{
		}
	}
}
