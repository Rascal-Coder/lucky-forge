using System.Collections.Generic;
using FunGames.Core.Modules;
using FunGames.Core.Settings;

namespace FunGames.Monetization.IAP
{
	public abstract class FGIAPAbstract<M, S> : FGModuleAbstract<M, FGIAPCallbacks, S> where M : FGModuleAbstract<M, FGIAPCallbacks, S> where S : IFGModuleSettings
	{
		private List<string> _appliedProducts;

		protected override FGModule Parent => null;

		protected abstract void RequestPurchase(FGIAPProduct product);

		protected abstract void RequestRestore();

		protected override void InitializeCallbacks()
		{
		}

		protected void PurchaseRequestedEvent(FGIAPProduct product)
		{
		}

		protected void PurchaseSucceededEvent(FGIAPProduct product, FGIAPPurchaseInfo purchaseInfo, IFGReceiptValidator[] receiptValidators)
		{
		}

		protected void PurchaseFailedEvent(FGIAPProduct product, string message)
		{
		}

		protected void RestorationSucceededEvent(FGIAPProduct product, FGIAPPurchaseInfo purchaseInfo, IFGReceiptValidator[] receiptValidators)
		{
		}

		protected void RestorationFailedEvent(FGIAPProduct product, string message)
		{
		}

		protected override void ClearInitialization()
		{
		}
	}
}
