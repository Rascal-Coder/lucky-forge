using System;
using TMPro;
using UnityEngine;

public class EnergyRightsCanvas : MonoBehaviour
{
	[Header("UI References")]
	public TextMeshProUGUI claimEnergy;

	public TextMeshProUGUI x10Energy;

	public TextMeshProUGUI x30Energy;

	public TextMeshProUGUI adEnergyText;

	public TextMeshProUGUI adCooldownText;

	public TextMeshProUGUI crystalEnergyText;

	public TextMeshProUGUI crystalCooldownText;

	private const int AdMaxUses = 2;

	private const int CrystalMaxUses = 4;

	private static readonly TimeSpan ResetInterval = TimeSpan.FromHours(24.0);

	private int adRemaining;

	private int crystalRemaining;

	private DateTime adResetTime;

	private DateTime crystalResetTime;

	public CanvasJobs canvasJobs;

	public RewardAdsManager rewardAdsManager;

	private void Awake()
	{
		// Native RVA0x2205cec. Original local defaults and >48h future-date repair.
		adRemaining=ES3.Load<int>("AdEnergyRemaining",defaultValue:2);
		adResetTime=ES3.Load<DateTime>("AdEnergyResetTime",defaultValue:DateTime.UtcNow);
		crystalRemaining=ES3.Load<int>("CrystalEnergyRemaining",defaultValue:4);
		crystalResetTime=ES3.Load<DateTime>("CrystalEnergyResetTime",defaultValue:DateTime.UtcNow);
		if(adResetTime>DateTime.UtcNow.AddHours(48)){adResetTime=DateTime.UtcNow;ES3.Save<DateTime>("AdEnergyResetTime",adResetTime);}
		if(crystalResetTime>DateTime.UtcNow.AddHours(48)){crystalResetTime=DateTime.UtcNow;ES3.Save<DateTime>("CrystalEnergyResetTime",crystalResetTime);}
	}

	private void OnEnable()
	{
		// Native RVA0x2205f2c. Existing quota/labels update on entry, not an invented Update loop.
		RefreshRights();UpdateUI();
		claimEnergy.text=Lang.Get.GetEnergy;
		x10Energy.text="x10 "+Lang.Get.Energy;
		x30Energy.text="x30 "+Lang.Get.Energy;
	}

	private void RefreshRights()
	{
		// Native RVA0x2206090. Catch up original rolling24h windows without stacking extra uses.
		var now=DateTime.UtcNow;
		if(now-adResetTime>=ResetInterval){
		    adRemaining=2;
		    while(now-adResetTime>=ResetInterval)adResetTime=adResetTime+ResetInterval;
		    ES3.Save<int>("AdEnergyRemaining",adRemaining);ES3.Save<DateTime>("AdEnergyResetTime",adResetTime);
		}
		if(now-crystalResetTime>=ResetInterval){
		    crystalRemaining=4;
		    while(now-crystalResetTime>=ResetInterval)crystalResetTime=crystalResetTime+ResetInterval;
		    ES3.Save<int>("CrystalEnergyRemaining",crystalRemaining);ES3.Save<DateTime>("CrystalEnergyResetTime",crystalResetTime);
		}
	}

	private void UpdateUI()
	{
		// Native RVA0x220644c. Original strings, component Hours/Minutes and expiry fallback.
		var now=DateTime.UtcNow;
		adEnergyText.text=adRemaining.ToString()+" "+Lang.Get.attemptsremain;
		if(adRemaining>0)adCooldownText.text=GooglePlayPassHandler.AdSpriteTag+Lang.Get.free;
		else{
		    var left=adResetTime+ResetInterval-now;
		    adCooldownText.text=left.TotalSeconds>0?string.Format("{0}h {1}m",left.Hours,left.Minutes):GooglePlayPassHandler.AdSpriteTag+Lang.Get.free;
		}
		crystalEnergyText.text=crystalRemaining.ToString()+" "+Lang.Get.attemptsremain;
		if(crystalRemaining>0)crystalCooldownText.text="<sprite=1>100";
		else{
		    var left=crystalResetTime+ResetInterval-now;
		    crystalCooldownText.text=left.TotalSeconds>0?string.Format("{0}h {1}m",left.Hours,left.Minutes):"<sprite=1>100";
		}
	}

	public void ReklamIzlendi()
	{
	}

	public void Reklamizle()
	{
	}

	public void CrystalHarcandi()
	{
		// Native RVA0x2206b78. Preserve visible-balance precheck and ignored Spend return; no cap guard.
		if(crystalRemaining<1)return;
		if(Currencys.Crystal<100){canvasJobs.OpenGoldYok(4);SoundManager.instance.CashSound(SoundManager._close);return;}
		Currencys.SpendCrystal(100,"Meta","EnergyPurchaseCR100");
		Currencys.AddEnergy(30,"Meta","EnergyPurchaseCR100");
		crystalRemaining=unchecked(crystalRemaining-1);
		if(crystalRemaining==3){crystalResetTime=DateTime.UtcNow;ES3.Save<DateTime>("CrystalEnergyResetTime",crystalResetTime);}
		ES3.Save<int>("CrystalEnergyRemaining",crystalRemaining);
		UpdateUI();
		SoundManager.instance.CashSound(SoundManager.herostone);
		BuyukParticle.Playit(BuyukParticle.Energy);
	}

	public void OpenClose()
	{
		// Native RVA0x2206e64. Original hierarchy-active toggle, no energy-full/page-open guard.
		gameObject.SetActive(!gameObject.activeInHierarchy);
		SoundManager.instance.CashSound(SoundManager._click);
	}

	public void Close()
	{
		// Native RVA0x2206f50. Original inactive-self guard suppresses redundant close sound.
		if(gameObject.activeSelf){gameObject.SetActive(false);SoundManager.instance.CashSound(SoundManager._close);}
	}
}
