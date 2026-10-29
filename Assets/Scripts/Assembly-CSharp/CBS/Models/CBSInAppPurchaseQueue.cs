using System;

namespace CBS.Models
{
	public class CBSInAppPurchaseQueue
	{
		public string ItemID;

		public string CatalogID;

		public string TransactionID;

		public string StoreID;

		public Action<IAPPurchaseItemResult> Result;

		public bool IsPack()
		{
			return false;
		}
	}
}
