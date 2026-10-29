using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MistikResetUi : MonoBehaviour
{
	public Commander targetCommander;

	public TextMeshProUGUI title;

	public Image[] icons;

	public TextMeshProUGUI sollvl;

	public TextMeshProUGUI saglvl;

	public TextMeshProUGUI refundText;

	public TextMeshProUGUI costText;

	public TextMeshProUGUI goldcoinT;

	public TextMeshProUGUI mistikTokenT;

	private int mistikTokenN;

	private double goldCoinN;

	public ParticleSystem resetparyicle;

	public CurrencyCollectedUi collectedUi;

	public HeroUpgradeUI heroUpgradeUI;

	public RewardAdsManager rewardedAds;

	public static bool ResetSatinAlinidi;

	[Header("Details")]
	public TextMeshProUGUI detailtitle;

	public TextMeshProUGUI detail1;

	public TextMeshProUGUI detail2;

	public TextMeshProUGUI detailmistikseviyesi;

	public TextMeshProUGUI detailmaliyet;

	public TextMeshProUGUI[] detailfiyatlar;

	public GameObject detailspage;

	private string GetResetCostText(int level)
	{
		return null;
	}

	private void CalculateRefunds(int level, out int mistikToken, out double goldCoin)
	{
		mistikToken = default;
		goldCoin = default;
	}

	private double GetUpgradePriceForLevel(int level)
	{
		return 0.0;
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void Openit(Commander comma)
	{
	}

	private void RefreshUI()
	{
	}

	public void OnResetButtonClicked()
	{
	}

	public void Resetle()
	{
	}

	public void SetCommander(Commander commander)
	{
	}

	public void closeit()
	{
	}

	public void OpenCloseDetails()
	{
	}

	private void OnEnable()
	{
	}
}
