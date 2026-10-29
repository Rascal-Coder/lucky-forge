using UnityEngine;

public class MistikTokenShop : MonoBehaviour
{
	[Header("Teklifler")]
	public MysticOffer[] offers;

	[Header("UI Referanslar\ufffd")]
	public MysticSlotUI[] slotUIs;

	private int[] purchasedCounts;

	private const string KEY_COUNTS = "MysticShop_PurchaseCounts";

	private const string KEY_RESET = "MysticShop_LastResetTime";

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
