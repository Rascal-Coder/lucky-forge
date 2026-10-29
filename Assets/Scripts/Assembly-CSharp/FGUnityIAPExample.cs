using FunGames.Monetization.IAP;
using UnityEngine;

public class FGUnityIAPExample : MonoBehaviour
{
	public const string NON_CONSUMABLE_PRODUCT1 = "com.myNonConsumable1.product";

	public const string NON_CONSUMABLE_PRODUCT2 = "com.myNonConsumable2.product";

	public const string CONSUMABLE_PRODUCT1 = "com.myConsumable1.product";

	public const string CONSUMABLE_PRODUCT2 = "com.myConsumable2.product";

	public const string SUBSCRIPTION_PRODUCT1 = "com.mSubscription1.product";

	public const string SUBSCRIPTION_PRODUCT2 = "com.mSubscription2.product";

	private void Awake()
	{
	}

	private void OnInitialized(bool obj)
	{
	}

	private void OnPurchaseSucceeded(FGIAPProduct product, FGIAPPurchaseInfo purchaseInfo, IFGReceiptValidator[] arg3)
	{
	}

	private void OnPurchaseRestored(FGIAPProduct product, FGIAPPurchaseInfo purchaseInfo, IFGReceiptValidator[] arg3)
	{
	}

	public void ApplyNonConsumable1()
	{
	}

	public void ApplyNonConsumable2()
	{
	}

	public void ApplyConsumable1()
	{
	}

	public void ApplyConsumable2()
	{
	}

	public void ApplySubscription1()
	{
	}

	public void ApplySubscription2()
	{
	}
}
