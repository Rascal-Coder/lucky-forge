using System;
using TMPro;
using UnityEngine;

public class inGameEvents : MonoBehaviour
{
	[Serializable]
	public class UpgradeBonus
	{
		public int calisanATK_eventcoinli;

		public float calisanCrit_eventcoinli;

		public float calisanCritDmg_eventcoinli;

		public float calisanAtkSpeed_eventcoinli;

		public int calisanATK_eventcrystalli;

		public float calisanCrit_eventcrystalli;

		public float calisanCritDmg_eventcrystalli;

		public float calisanAtkSpeed_eventcrystalli;

		public float calisanMovementSpeed_eventcrystalli;

		public int calisanSayisi_eventcrystalli;

		public int coinIncome_eventcrystalli;
	}

	public static bool EventON;

	[Header("HaritaKazmaEventi")]
	public static int EventKazilanFloor;

	public static double EventCoin;

	public static int EventCrystal;

	public static int EventKey;

	public static int EventLeaderboardCoin;

	public GameObject[] EventZamaniKapatilacaklar;

	public GameObject[] EventZamaniAcilacaklar;

	public TextMeshProUGUI _eventcoin;

	public TextMeshProUGUI _eventkristal;

	public TextMeshProUGUI _eventbitistarihi;

	private double oldpara;

	private int oldcrystal;

	public static UpgradeBonus Upgrades;

	private void Start()
	{
	}

	public static void SaveUpgrades()
	{
	}

	private void Update()
	{
	}
}
