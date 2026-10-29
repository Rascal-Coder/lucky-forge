using System;
using CBS.Models;
using PlayFab;
using PlayFab.ClientModels;
using PlayFab.CloudScriptModels;

namespace CBS.Playfab
{
	public class FabStore : FabExecuter, IFabStore
	{
		public void GetAllStores(string profileID, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void GetAllStoreTitles(string profileID, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void GetStoreByID(string profileID, string storeID, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void GetStoreItemByID(string profileID, string storeID, string itemID, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void PrePurchaseValidation(string profileID, string storeID, string itemID, Action<ExecuteFunctionResult> onValidate, Action<PlayFabError> onFailed)
		{
		}

		public void PurchaseItem(FabPurchaseRequest purchaseRequest, Action<PurchaseItemResult, FunctionPostStorePurchaseResult, CBSError> onPurchase, Action<PlayFabError> onFailed)
		{
		}

		public void RevokeItemLimitation(string profileID, string storeID, string itemID, Action<ExecuteFunctionResult> onRevoke, Action<PlayFabError> onFailed)
		{
		}

		public void GetSpecialOffers(string profileID, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void GrantSpecialOfferToProfile(string profileID, string itemID, Action<ExecuteFunctionResult> onGrant, Action<PlayFabError> onFailed)
		{
		}
	}
}
