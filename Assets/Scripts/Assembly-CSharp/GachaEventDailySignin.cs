using System;
using TMPro;
using UnityEngine;

public class GachaEventDailySignin : MonoBehaviour
{
	public TextMeshProUGUI title;

	public TextMeshProUGUI subtitle;

	public TextMeshProUGUI[] toptexts;

	public TextMeshProUGUI[] fiyatlar;

	public GameObject[] satinalimbtns;

	public GameObject[] rewardButtons;

	public int[] Oduls;

	public DateTime eventStartDate;

	public bool hasPremium;

	public bool hasDeluxe;

	public static bool alindiPremium;

	public static bool alindiDeluxe;

	public SquareGachaSystem gachaSystem;

	private int daysSinceStart;

	private bool[,] claimedRewards;

	private bool btnsadded;

	private const string SaveKey = "GachaEventClaimedRewardsX";

	private void Start()
	{
	}

	private void OnEnable()
	{
	}

	public void ApplyGppUi(bool hideIap)
	{
	}

	private void Update()
	{
	}

	private void UpdateRewardUI()
	{
	}

	private void ClaimReward(int tier, int day)
	{
	}

	private void SaveClaimedRewards()
	{
	}

	private void LoadClaimedRewards()
	{
	}

	public void ResetRewards()
	{
	}

	private void PremiumAlindi()
	{
	}

	private void DeluxAlindi()
	{
	}

	public void BuyPremium()
	{
	}

	public void BuyDeluxe()
	{
	}
}
