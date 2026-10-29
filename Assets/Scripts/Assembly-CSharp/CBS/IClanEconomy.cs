using System;
using CBS.Models;

namespace CBS
{
	public interface IClanEconomy
	{
		void GetClanInventory(string clanID, Action<CBSGetInventoryResult> result);

		void GrantItemToClan(string clanID, string itemID, Action<CBSGrantItemsResult> result);

		void GrantItemsToClan(string clanID, string[] itemsID, Action<CBSGrantItemsResult> result);

		void GetClanCurrencies(string clanID, Action<CBSGetCurrenciesResult> result);

		void AddCurrencyToClan(string clanID, string code, int amount, Action<CBSUpdateCurrencyResult> result = null);

		void SubtractCurrencyFromClan(string clanID, string code, int amount, Action<CBSUpdateCurrencyResult> result = null);

		void TransferItemFromProfileToClan(string itemInstanceID, Action<CBSClanTransferItemResult> result);

		void TransferItemFromClanToProfile(string itemInstanceID, Action<CBSClanTransferItemResult> result);
	}
}
