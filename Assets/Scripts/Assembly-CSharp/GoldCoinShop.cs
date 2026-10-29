using UnityEngine;

public class GoldCoinShop : MonoBehaviour
{
	[Header("Teklifler")]
	public CoinOffer[] offers;

	[Header("UI Referanslar\ufffd")]
	public CoinSlotUI[] slotUIs;

	private int[] purchasedCounts;

	private const string KEY_COUNTS = "GoldCoin_PurchaseCounts";

	private const string KEY_RESET = "GoldCoin_LastResetTime";

	public CanvasJobs canvasJobs;

	private void Start()
	{
	}

	private void ResetDailyCounts()
	{
	}

	private void UpdateUI()
	{
	}

	public void BuyOffer(int index)
	{
	}
}
