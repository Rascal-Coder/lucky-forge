using System;
using System.Runtime.CompilerServices;
using CBS.Models;
using CBS.Playfab;

namespace CBS
{
	public class CBSStoreModule : CBSModule, IStore
	{
		[CompilerGenerated]
		private Action<CBSPurchaseStoreItemResult> m_OnItemPurchased;

		[CompilerGenerated]
		private Action<CBSPurchaseStoreItemWithRMResult> m_OnItemPurchasedWithRM;

		private IProfile Profile { get; set; }

		private IFabStore FabStore { get; set; }

		private ICBSItems Items { get; set; }

		private ICBSInAppPurchase InAppPurchase { get; set; }

		public event Action<CBSPurchaseStoreItemResult> OnItemPurchased
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<CBSPurchaseStoreItemWithRMResult> OnItemPurchasedWithRM
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		protected override void Init()
		{
		}

		public void GetStoreTitles(Action<CBSGetStoreTitlesResult> result)
		{
		}

		public void GetStores(Action<CBSGetStoresResult> result)
		{
		}

		public void GetStoreByID(string storeID, Action<CBSGetStoreResult> result)
		{
		}

		public void GetStoreItemByID(string storeID, string itemID, Action<CBSGetStoreItemResult> result)
		{
		}

		public void PurchaseStoreItem(string itemID, string storeID, string currencyCode, int currencyValue, Action<CBSPurchaseStoreItemResult> result)
		{
		}

		public void PurchaseStoreItemWithRealMoney(string itemID, string storeID, Action<CBSPurchaseStoreItemWithRMResult> result)
		{
		}

		public void RevokeItemStoreLimitation(string storeID, string itemID, Action<CBSRevokeLimitationResult> result)
		{
		}

		public void GetSpecialOffers(Action<CBSGetSpecialOffersResult> result)
		{
		}

		public void GrantSpecialOfferToProfile(string itemID, Action<CBSSpecialOfferResult> result)
		{
		}

		private void InternalPurchaseCBSItemWithCurrency(string itemID, string storeID, string currencyCode, int currencyValue, Action<CBSPurchaseStoreItemResult> result)
		{
		}

		private void InternalPurchaseStoreItemWithRealMoney(string itemID, string storeID, Action<CBSPurchaseStoreItemWithRMResult> result)
		{
		}
	}
}
