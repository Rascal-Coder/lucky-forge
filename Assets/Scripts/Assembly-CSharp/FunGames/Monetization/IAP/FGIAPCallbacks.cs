using System;
using FunGames.Core.Modules;

namespace FunGames.Monetization.IAP
{
	public class FGIAPCallbacks : FGModuleCallbacks
	{
		internal Action<FGIAPProduct> _OnPurchaseRequested;

		internal Action _OnRestoreRequested;

		internal Action<FGIAPProduct, FGIAPPurchaseInfo, IFGReceiptValidator[]> _OnPurchaseSucceeded;

		internal Action<FGIAPProduct, string> _OnPurchaseFailed;

		internal Action<FGIAPProduct, FGIAPPurchaseInfo, IFGReceiptValidator[]> _OnRestorationSucceeded;

		internal Action<FGIAPProduct, string> _OnRestorationFailed;

		public event Action<FGIAPProduct> OnPurchaseRequested
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action OnRestoreRequested
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action<FGIAPProduct, FGIAPPurchaseInfo, IFGReceiptValidator[]> OnPurchaseSucceeded
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action<FGIAPProduct, string> OnPurchaseFailed
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action<FGIAPProduct, FGIAPPurchaseInfo, IFGReceiptValidator[]> OnRestorationSucceeded
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action<FGIAPProduct, string> OnRestorationFailed
		{
			add
			{
			}
			remove
			{
			}
		}

		public override void Clear()
		{
		}
	}
}
