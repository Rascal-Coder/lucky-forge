using UnityEngine;

public class WeaponTokenShop : MonoBehaviour
{
	[Header("Teklifler")]
	public WeaponTokenOffer[] offers;

	[Header("UI Referanslar\ufffd")]
	public WeaponTokenUI[] slotUIs;

	private int[] purchasedCounts;

	private const string KEY_COUNTS = "WeaponToken_PurchaseCounts";

	private const string KEY_RESET = "WeaponToken_LastResetTime";

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
