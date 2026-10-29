using CBS.Models;
using CBS.Scriptable;
using UnityEngine;
using UnityEngine.UI;

namespace CBS.UI
{
	public class CurrencyItem : MonoBehaviour
	{
		[SerializeField]
		private Text ValueTitle;

		[SerializeField]
		private Image IconImage;

		[SerializeField]
		private CurrencyRechargeTimer Timer;

		private CBSCurrency Currency { get; set; }

		private CurrencyPrefabs Prefabs { get; set; }

		private void Awake()
		{
		}

		public void Display(CBSCurrency currency)
		{
		}

		public void UpdateCurrency(CBSCurrency currency)
		{
		}

		private void CheckTimer()
		{
		}

		public void ShowCurrenciesWindow()
		{
		}
	}
}
