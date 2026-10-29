using System;
using CBS.Models;

namespace CBS
{
	public interface ICBSInAppPurchase
	{
		bool IsInitialized { get; }

		bool IsEnabled { get; }

		event Action<IAPInitializeResult> OnInitialize;

		void PurchaseItem(string itemID, string catalogID, Action<IAPPurchaseItemResult> result);

		void PurchaseItem(string itemID, string catalogID, string storeID, Action<IAPPurchaseItemResult> result);
	}
}
