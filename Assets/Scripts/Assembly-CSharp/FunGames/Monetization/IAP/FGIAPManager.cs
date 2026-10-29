using System;
using System.Collections.Generic;
using FunGames.Core.Modules;

namespace FunGames.Monetization.IAP
{
	public class FGIAPManager : FGModuleAbstract<FGIAPManager, FGIAPCallbacks, FGIAPSettings>
	{
		private Action _initialization;

		private Dictionary<string, FGProductInfo> _productInfos;

		private Dictionary<string, FGSubscriptionInfo> _subscriptionInfos;

		public override FGIAPSettings Settings => null;

		protected override FGModule Parent => null;

		protected override string EventName => null;

		protected override string RemoteConfigKey => null;

		protected override void OnAwake()
		{
		}

		protected override void OnStart()
		{
		}

		protected override void InitializeModule()
		{
		}

		protected override void InitializeCallbacks()
		{
		}

		public void BuyProduct(string id)
		{
		}

		public void Restore()
		{
		}

		public void AddProductInfo(FGProductInfo productInfo)
		{
		}

		public void AddSubscriptionInfo(FGSubscriptionInfo subscriptionInfo)
		{
		}

		public FGProductInfo GetProductInfo(string id)
		{
			return null;
		}

		public FGSubscriptionInfo GetSubscriptionInfo(string id)
		{
			return null;
		}

		internal void StorePurchaseInfo(string productId, FGIAPPurchaseInfo purchaseInfo)
		{
		}

		internal FGIAPPurchaseInfo GetPurchaseInfo(string productId)
		{
			return null;
		}

		protected override void ClearInitialization()
		{
		}
	}
}
