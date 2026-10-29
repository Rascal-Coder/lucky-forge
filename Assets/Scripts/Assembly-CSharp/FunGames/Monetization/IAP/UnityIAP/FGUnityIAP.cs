using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.Purchasing.Security;

namespace FunGames.Monetization.IAP.UnityIAP
{
	public class FGUnityIAP : FGIAPAbstract<FGUnityIAP, FGUnityIAPSettings>
	{
		public class FGUnityIAPListener : IStoreListener
		{
			public IStoreController controller;

			public IExtensionProvider extensions;

			public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
			{
			}

			private void InitializeProductInfos()
			{
			}

			public void OnInitializeFailed(InitializationFailureReason error)
			{
			}

			public void OnInitializeFailed(InitializationFailureReason error, string message)
			{
			}

			public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs e)
			{
				return PurchaseProcessingResult.Complete;
			}

			public void OnPurchaseFailed(Product product, PurchaseFailureReason e)
			{
			}

			private ProductType ToProductType(FGProductType fgProductType)
			{
				return ProductType.Consumable;
			}

			public Product ToProduct(FGIAPProduct fgProduct)
			{
				return null;
			}

			private FGSubscriptionInfo StoreSubscription(Product product)
			{
				return null;
			}

			public void Validate(Product product)
			{
			}

			private List<IFGReceiptValidator> CreateFGReceiptValidators(IPurchaseReceipt[] receipts, FGIAPPurchaseInfo purchaseInfo)
			{
				return null;
			}
		}

		private FGUnityIAPListener _iapListener;

		[HideInInspector]
		public FGIAPProduct CurrentRequestedProduct;

		protected override string EventName => null;

		protected override string RemoteConfigKey => null;

		public override FGUnityIAPSettings Settings => null;

		public FGUnityIAPListener IapListener => null;

		protected override void OnAwake()
		{
		}

		protected override void OnStart()
		{
		}

		protected override void InitializeModule()
		{
		}

		protected override void RequestPurchase(FGIAPProduct fgProduct)
		{
		}

		protected override void RequestRestore()
		{
		}

		private FGProductInfo ToProductInfo(Product product)
		{
			return null;
		}

		private FGSubscriptionInfo ToSubscriptionInfo(SubscriptionInfo subscriptionInfo)
		{
			return null;
		}
	}
}
