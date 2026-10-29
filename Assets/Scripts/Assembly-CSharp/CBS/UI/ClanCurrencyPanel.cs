using System.Collections.Generic;
using CBS.Models;
using CBS.Scriptable;
using UnityEngine;

namespace CBS.UI
{
	public class ClanCurrencyPanel : MonoBehaviour
	{
		[SerializeField]
		private CurrencyDisplayOptions DisplayOption;

		[SerializeField]
		private string[] SelectedCurrencies;

		private Dictionary<string, CurrencyItem> CurrenciesUI;

		private CurrencyPrefabs Prefabs { get; set; }

		private AuthData AuthData { get; set; }

		private IClanEconomy ClanEconomy { get; set; }

		private IProfile Profile { get; set; }

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void SpawnItems(Dictionary<string, CBSCurrency> currencies)
		{
		}

		private void OnCurrenciesGet(CBSGetCurrenciesResult result)
		{
		}

		private Dictionary<string, CBSCurrency> GetSelectedCurrencies(Dictionary<string, CBSCurrency> inputCurrencies)
		{
			return null;
		}
	}
}
