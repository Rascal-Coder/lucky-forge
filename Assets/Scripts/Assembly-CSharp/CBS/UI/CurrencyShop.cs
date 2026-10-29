using System.Collections.Generic;
using CBS.Models;
using CBS.Scriptable;
using UnityEngine;

namespace CBS.UI
{
	public class CurrencyShop : MonoBehaviour
	{
		[SerializeField]
		private Transform RootContent;

		private CurrencyPrefabs Prefabs { get; set; }

		private ICurrency Currencies { get; set; }

		private void Start()
		{
		}

		private void SpawnPacks(List<CBSCurrencyPack> packs)
		{
		}

		public void OnCloseWindow()
		{
		}

		public void OnPackGetted(CBSGetCurrenciesPacksResult result)
		{
		}
	}
}
