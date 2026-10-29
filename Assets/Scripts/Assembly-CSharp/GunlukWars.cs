using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GunlukWars : MonoBehaviour
{
	public TextMeshProUGUI missiontitle;

	public TextMeshProUGUI _TotalHaftalikSayi;

	public Button[] warButtons;

	public GameObject[] doneicons;

	public Slider progressSlider;

	public TextMeshProUGUI nextWarTimerText;

	public TextMeshProUGUI nextbattlereadyin;

	private const string LastWarTimeKey = "LastDailyWarTime";

	private DateTime nextWarTime;

	public static int dailyWars;

	public bool[] TotalHaftalikOdulToplandi;

	private readonly int[] rewardMilestones;

	public Button[] topOdulBtns;

	public static GameObject enemyOrdu;

	public GecisControl gecisControl;

	public Commander[] Heros;

	public TextMeshProUGUI guidetext1;

	public TextMeshProUGUI guidetext2;

	public TextMeshProUGUI guidetext3;

	public TextMeshProUGUI guidemingugaciklama;

	public TextMeshProUGUI guidetext4;

	public TextMeshProUGUI taptocontinue;

	public GameObject guidepage;

	public GameObject warinfoiconbtn;

	public GameObject dailywarbtn;

	public RectTransform rect;

	private float guidetimer;

	private float time1;

	public double CoinReward(int rewardkac)
	{
		return 0.0;
	}

	private void Start()
	{
	}

	private void OnEnable()
	{
	}

	public void OpenCloseGuide(bool durum)
	{
	}

	public void OyunBaslayincaCek()
	{
	}

	public void TopOdulTopla(int sira)
	{
	}

	private void UpdateUI()
	{
	}

	private void UpdateTimer()
	{
	}

	public void WinWar()
	{
	}

	private bool CanStartNextWar()
	{
		return false;
	}

	public void GoWar()
	{
	}

	public void OpenPage(bool durum)
	{
	}

	private void Update()
	{
	}
}
