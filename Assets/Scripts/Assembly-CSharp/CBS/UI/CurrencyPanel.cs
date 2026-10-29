using System.Collections.Generic;
using CBS.Models;
using CBS.Scriptable;
using UnityEngine;

namespace CBS.UI
{
	public class CurrencyPanel : MonoBehaviour
	{
		[SerializeField]
		private CurrencyDisplayOptions DisplayOption;

		[SerializeField]
		private string[] SelectedCurrencies;

		private List<CurrencyItem> CurrenciesUI;

		private CurrencyPrefabs Prefabs { get; set; }

		private AuthData AuthData { get; set; }

		private ICurrency Currencies { get; set; }

		private void Start()
		{
		}

		private void OnDestroy()
		{
		}

		private void SpawnItems(Dictionary<string, CBSCurrency> currencies)
		{
		}

		private void OnCurrenciesGet(CBSGetCurrenciesResult result)
		{
		}

		private void OnCurrencyUpdated(CBSCurrency currency)
		{
		}

		private Dictionary<string, CBSCurrency> GetSelectedCurrencies(Dictionary<string, CBSCurrency> inputCurrencies)
		{
			return null;
		}
	}
}
