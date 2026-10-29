using System;
using System.Collections.Generic;
using CBS.Models;

namespace CBS
{
	public interface ICurrency
	{
		Dictionary<string, CBSCurrency> CacheCurrencies { get; }

		event Action<CBSCurrency> OnCurrencyUpdated;

		void GetProfileCurrencies(Action<CBSGetCurrenciesResult> result = null);

		void GetProfileCurrencies(string profileID, Action<CBSGetCurrenciesResult> result);

		void AddCurrencyToProfile(string code, int amount, Action<CBSUpdateCurrencyResult> result = null);

		void SubtractCurrencyFromProfile(string profileID, string code, int amount, Action<CBSUpdateCurrencyResult> result = null);

		void AddCurrencyToProfile(string profileID, string code, int amount, Action<CBSUpdateCurrencyResult> result = null);

		void SubtractCurrencyFromProfile(string code, int amount, Action<CBSUpdateCurrencyResult> result = null);

		void GetCurrenciesPacks(Action<CBSGetCurrenciesPacksResult> result);

		void GetPacksByTag(string tag, Action<CBSGetCurrenciesPacksResult> result);

		void GrantCurrencyPack(string packID, Action<CBSGrandPackResult> result);

		void PurchasePackWithRealMoney(string packID, Action<CBSPurchasePackWithRealMoneyResult> result);
	}
}
