using System;
using CBS.Models;
using PlayFab;
using PlayFab.ClientModels;
using PlayFab.CloudScriptModels;

namespace CBS.Playfab
{
	public class FabItems : FabExecuter, IFabItems
	{
		public void FetchItems(Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void GetItems(ItemType type, string category, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void GetItemByID(string itemID, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void GetCategories(Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void PurchaseItem(FabPurchaseRequest purchaseRequest, Action<PurchaseItemResult, FunctionPostPurchaseResult, CBSError> onPurchase, Action<PlayFabError> onFailed)
		{
		}

		public void GrantItems(string profileID, string[] itemsIDs, bool containPack, Action<ExecuteFunctionResult> onGrant, Action<PlayFabError> onFailed)
		{
		}
	}
}
