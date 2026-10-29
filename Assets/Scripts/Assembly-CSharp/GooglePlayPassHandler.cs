using System;
using System.Runtime.CompilerServices;
using FunGames.Monetization.IAP;
using UnityEngine;
using UnityEngine.Purchasing;

public class GooglePlayPassHandler : MonoBehaviour
{
	private const string PlayerPrefsKey_GooglePlayPassUserSent = "fg_gpp_google_play_pass_user_sent";

	private const string PlayerPrefsKey_GooglePlayPassDropUserSent = "fg_gpp_google_play_pass_drop_user_sent";

	private static bool isActive;

	public const string productID = "google_play_pass";

	[CompilerGenerated]
	private static Action m_OnPurchase;

	[CompilerGenerated]
	private static Action m_OnDeactivate;

	public Sprite gppSprite;

	public static GooglePlayPassHandler i;

	public static bool IsActive
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public static bool HasAdFreeExperience => false;

	public static string AdSpriteTag => null;

	public static string AdWatchLabel => null;

	public static string AdWatchButtonText => null;

	public static event Action OnPurchase
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

	public static event Action OnDeactivate
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

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnFgiapInitialized(bool success)
	{
	}

	private static void TryDetectFromProductInfo()
	{
	}

	private static bool IsPlayPassEntitledFromFgiap()
	{
		return false;
	}

	private static bool IsPlayPassEntitled(Product product)
	{
		return false;
	}

	private void OnPurchaseRestored(FGIAPProduct product, FGIAPPurchaseInfo info, IFGReceiptValidator[] arg3)
	{
	}

	private void OnPurchaseSucceeded(FGIAPProduct product, FGIAPPurchaseInfo info, IFGReceiptValidator[] arg3)
	{
	}

	public void BuyGPP()
	{
	}

	[ContextMenu("Open Persistent Location")]
	public void OpenPersistentLocation()
	{
	}

	private static void TryOpenFolderWithProcess(string fileName, string argument)
	{
	}

	public static void OnPurchaseNow()
	{
	}

	public static void OnDeactivateNow()
	{
	}

	public static void OnInit(IStoreController controller)
	{
	}

	public static void CheckPurchase(Product args)
	{
	}

	private static void SetActive(bool active)
	{
	}

	private static void TrySendGppAnalytics(bool wasActive, bool isActiveNow)
	{
	}
}
