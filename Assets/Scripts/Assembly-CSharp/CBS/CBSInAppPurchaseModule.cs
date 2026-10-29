using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CBS.Models;
using CBS.Scriptable;

namespace CBS
{
	public class CBSInAppPurchaseModule : CBSModule, ICBSInAppPurchase
	{
		public class JsonData
		{
			public string orderId;

			public string packageName;

			public string productId;

			public long purchaseTime;

			public int purchaseState;

			public string purchaseToken;
		}

		public class PayloadData
		{
			public JsonData JsonData;

			public string signature;

			public string json;

			public static PayloadData FromJson(string json)
			{
				return null;
			}
		}

		public class GooglePurchase
		{
			public PayloadData PayloadData;

			public string Store;

			public string TransactionID;

			public string Payload;

			public static GooglePurchase FromJson(string json)
			{
				return null;
			}
		}

		public class ApplePurchase
		{
			public string Store;

			public string TransactionID;

			public string Payload;

			public static ApplePurchase FromJson(string json)
			{
				return null;
			}
		}

		[CompilerGenerated]
		private Action<IAPInitializeResult> m_OnInitialize;

		public bool IsInitialized => false;

		private IAPConfig IAPConfig { get; set; }

		public bool IsEnabled => false;

		private Dictionary<string, CBSInAppPurchaseQueue> ResultList { get; set; }

		public event Action<IAPInitializeResult> OnInitialize
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

		public void SetupStore(List<string> itemsIDs, List<string> currenciesPacksIDs, List<string> calendarsIDs, List<string> ticketsIDs)
		{
		}

		public void PurchaseItem(string itemID, string catalogID, Action<IAPPurchaseItemResult> result)
		{
		}

		public void PurchaseItem(string itemID, string catalogID, string storeID, Action<IAPPurchaseItemResult> result)
		{
		}

		private void RegisterPurchaseAction(string id, CBSInAppPurchaseQueue queue)
		{
		}

		private void UnRegisterPurchaseAction(string id)
		{
		}
	}
}
