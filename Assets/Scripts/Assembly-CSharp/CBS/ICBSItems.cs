using System;
using System.Collections.Generic;
using CBS.Models;

namespace CBS
{
	public interface ICBSItems
	{
		List<CBSItem> AllItems { get; }

		List<CBSItemPack> AllPacks { get; }

		List<CBSLootbox> AllLootboxes { get; }

		CBSRecipeContainer Recipes { get; }

		CBSItemUpgradesContainer Upgrades { get; }

		Dictionary<string, CBSBaseItem> ItemsDictionary { get; }

		string[] ItemCategories { get; }

		string[] PackCategories { get; }

		string[] LootboxCategories { get; }

		event Action<CBSPurchaseItemWithCurrencyResult> OnItemPurchased;

		event Action<CBSPurchaseItemWithRealMoneyResult> OnItemPurchasedWithRealMoney;

		event Action<CBSGrantItemsResult> OnItemGranted;

		void FetchAll(Action<CBSFetchAllResult> result);

		void GetCategories(ItemType type, Action<CBSGetCategoriesResult> result);

		void GetCBSItems(CBSGetItemsRequest request, Action<CBSGetItemsResult> result);

		void GetCBSItemByID(string itemID, Action<CBSGetItemResult> result);

		void PurchaseCBSItemWithCurrency(string itemID, string currencyCode, int currencyValue, Action<CBSPurchaseItemWithCurrencyResult> result);

		void PurchaseCBSItemWithRealMoney(string itemID, Action<CBSPurchaseItemWithRealMoneyResult> result);

		void GrantItem(string itemID, Action<CBSGrantItemsResult> result);

		void GrantItems(string[] itemsID, Action<CBSGrantItemsResult> result);

		void GrantItemToProfile(string profileID, string itemID, Action<CBSGrantItemsResult> result);

		void GrantItemsToProfile(string profileID, string[] itemsIDs, Action<CBSGrantItemsResult> result);

		CBSBaseItem GetFromCache(string itemID);
	}
}
