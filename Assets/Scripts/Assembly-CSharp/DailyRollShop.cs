using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DailyRollShop : MonoBehaviour
{
	public HeroController heroController;

	public RewardAdsManager rewardAdsManager;

	public CanvasJobs canvasJobs;

	[Header("Roll Se\ufffdenekleri")]
	public Commander[] possibleCommanders;

	public int[] possibleCurrencyAmounts;

	public Sprite currencyIcon;

	public int currencyBasePrice;

	public int crystalRerollPrice;

	[Header("UI Referanslar\ufffd")]
	public RollSlotUI[] slotUIs;

	public Button FreeRerollButton;

	public Button adRerollButton;

	public TextMeshProUGUI rerollPriceText;

	public TextMeshProUGUI adRerollCountText;

	public TextMeshProUGUI autoRerollTimerText;

	public TextMeshProUGUI refreshin;

	public double[] commanderFiyats;

	private DailyShopSlotData[] slots;

	public TextMeshProUGUI freererolltxt;

	public TextMeshProUGUI adrerolltxt;

	private const string KEY_LAST_ROLL = "DailyShop_LastRollTime";

	private const string KEY_SLOTS = "DailyShop_Slots";

	private const string KEY_AD_COUNT = "DailyShop_AdRerollsUsed";

	private const string KEY_AD_RESET_TIME = "DailyShop_LastAdResetTime";

	private int adRerollsUsed;

	private const int MAX_AD_REROLLS = 2;

	private const string KEY_FREE_COUNT = "DailyShop_FreeRerollsUsed";

	private const string KEY_FREE_RESET_TIME = "DailyShop_LastFreeResetTime";

	private int freeRerollsUsed;

	private const int MAX_FREE_REROLLS = 1;

	private bool IsReadyForUi => false;

	private void Start()
	{
	}

	private void CheckAll()
	{
	}

	private void OnEnable()
	{
	}

	public void ApplyGppUi(bool hideAds)
	{
	}

	private void GenerateNewSlots()
	{
	}

	private void SaveSlots()
	{
	}

	private void LoadSlots()
	{
	}

	public void OnBuy(int slotIndex)
	{
	}

	public void FreeReroll()
	{
	}

	public void ShowAds()
	{
	}

	public void ReklamIzlendi()
	{
	}

	private void UpdateUI()
	{
	}

	private void UpdateAutoRerollTimer()
	{
	}
}
