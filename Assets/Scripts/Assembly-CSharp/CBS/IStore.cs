using System;
using CBS.Models;

namespace CBS
{
	public interface IStore
	{
		event Action<CBSPurchaseStoreItemResult> OnItemPurchased;

		event Action<CBSPurchaseStoreItemWithRMResult> OnItemPurchasedWithRM;

		void GetStores(Action<CBSGetStoresResult> result);

		void GetStoreTitles(Action<CBSGetStoreTitlesResult> result);

		void GetStoreByID(string storeID, Action<CBSGetStoreResult> result);

		void GetStoreItemByID(string storeID, string itemID, Action<CBSGetStoreItemResult> result);

		void PurchaseStoreItem(string itemID, string storeID, string currencyCode, int currencyValue, Action<CBSPurchaseStoreItemResult> result);

		void PurchaseStoreItemWithRealMoney(string itemID, string storeID, Action<CBSPurchaseStoreItemWithRMResult> result);

		void RevokeItemStoreLimitation(string storeID, string itemID, Action<CBSRevokeLimitationResult> result);

		void GetSpecialOffers(Action<CBSGetSpecialOffersResult> result);

		void GrantSpecialOfferToProfile(string itemID, Action<CBSSpecialOfferResult> result);
	}
}
