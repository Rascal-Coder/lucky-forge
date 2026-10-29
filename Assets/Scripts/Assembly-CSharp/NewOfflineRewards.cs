using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NewOfflineRewards : MonoBehaviour
{
	public TextMeshProUGUI title;

	public TextMeshProUGUI subtitle;

	public TextMeshProUGUI getcollectedoffline;

	public TextMeshProUGUI getidle;

	public TextMeshProUGUI claim;

	public TextMeshProUGUI offlinerewards;

	public TextMeshProUGUI touchyanywhere;

	public TextMeshProUGUI rewardsclaimed;

	[Header("Seviyeye G\ufffdre Oran Sa\ufffdlay\ufffdc\ufffd")]
	public RewardRates rates;

	[Header("Inventory Manager Referans\ufffd")]
	public InventoryManager inventoryManager;

	[Header("UI References")]
	public Slider slider;

	public TextMeshProUGUI offlineTimeText;

	public TextMeshProUGUI[] rewardTexts;

	public GameObject[] rewardObjects;

	public GameObject[] gearRewardSlots;

	public int[] GearBolen = new int[]{15,20,15,10,15,25};

	[Header("Collect / Boost Buttons")]
	public Button collectButton;

	public Button boostButton;

	public TextMeshProUGUI boostButtonText;

	public TextMeshProUGUI boostCountText;

	private int energyCostForBoost = 30;

	[Header("PopUp UI")]
	public GameObject popUpObj;

	public TextMeshProUGUI[] POPUPrewardTexts;

	public GameObject[] POPUPrewardObjects;

	public GameObject[] POPUPgearRewardSlots;

	private DateTime lastOfflineTime;

	private bool hasUsedExtra;

	private DateTime lastBoostResetTime;

	public int boostRemaining;

	private Rewards baseRewards;

	private Rewards extraRewards;

	private int offlineGearCount;

	private List<GearInstance> offlineGear;

	private List<GearInstance> idleGear;

	private List<GearInstance> offlineGearPopUp;

	private int[] RandomSplit(int total, int count = 6)
	{
        // Original ARM64 0x201a580.
        if(total<1||count<=0)return new int[count];
        var cuts=new List<int>{0,total};for(int i=0;i<count-1;i++)cuts.Add(UnityEngine.Random.Range(0,total+1));
        cuts.Sort();var result=new int[count];for(int i=0;i<count;i++)result[i]=cuts[i+1]-cuts[i];return result;
	}

	private void Awake()
	{
        // Original ARM64 0x201a824.
        GearBolen=ES3.Load<int[]>("GearBolenOran",defaultValue:GearBolen);
        collectButton.onClick.AddListener(OnCollect);boostButton.onClick.AddListener(OnBoost);
        title.text=Lang.Get.IdleRewardsTitle;subtitle.text=Lang.Get.IdleRewardsSubtitle;
        getcollectedoffline.text=Lang.Get.GetCollectedOffline;getidle.text=Lang.Get.GetIdle;claim.text=Lang.Get.Claim;
        offlinerewards.text=Lang.Get.OfflineRewards;touchyanywhere.text=Lang.Get.taptocontinue;rewardsclaimed.text=Lang.Get.RewardsClaimed;
	}

	private void OnEnable()
	{
        // Original ARM64 0x201ab5c.
        rates=RewardRateProvider.GetRates(GameManager.Level);
        if(GameManager.ViPSinirsizidle)boostRemaining=3;
        CalculateBaseRewards();UpdateBoostUI();UpdateUI();
        // Original FGAnalytics IdleRewards event omitted.
	}

	public void OpenClose()
	{
        // Original ARM64 0x201b9ac.
        GameManager.PageAcildi=!gameObject.activeInHierarchy;gameObject.SetActive(!gameObject.activeInHierarchy);
        if(SoundManager.instance!=null)SoundManager.instance.CashSound(SoundManager._click);
	}

	public void LoadData()
	{
        // Original ARM64 0x201baf8.
        lastOfflineTime=ES3.KeyExists("NewlastOfflineTime")?ES3.Load<DateTime>("NewlastOfflineTime"):DateTime.Now;
        lastBoostResetTime=ES3.KeyExists("lastBoostResetTime")?ES3.Load<DateTime>("lastBoostResetTime"):DateTime.Now;
        boostRemaining=ES3.Load<int>("boostRemainingB",defaultValue:3);
	}

	private void CheckBoostReset()
	{
        // Original ARM64 0x201bc48.
        if(DateTime.Now-lastBoostResetTime>=TimeSpan.FromHours(24)){
         boostRemaining=2;lastBoostResetTime=DateTime.Now;
         ES3.Save<DateTime>("lastBoostResetTime",lastBoostResetTime);ES3.Save<int>("boostRemainingB",boostRemaining);
        }
	}

	public float CheckTimerInfo()
	{
        // Original ARM64 0x201bda0.
        return Mathf.Clamp((float)(DateTime.Now-lastOfflineTime).TotalMinutes,0f,600f);
	}

	private void CalculateBaseRewards()
	{
        // Original ARM64 0x201ad10.
        float minutes=Mathf.Clamp((float)(DateTime.Now-lastOfflineTime).TotalMinutes,0f,600f);
        slider.value=minutes;baseRewards=CalculateRewards((int)minutes);extraRewards=CalculateRewards(600);
        offlineGearCount=(int)Math.Floor((double)(float)(minutes/60f));
        if(offlineGearCount>=10)offlineGearCount=UnityEngine.Random.Range(10,13);
	}

	private Rewards CalculateRewards(int minutes)
	{
        // Original ARM64 0x201be68.
        float nativeMinutes=(float)minutes;
        var r=new Rewards{coin=(int)(float)(rates.coinPerMin*nativeMinutes),talentScroll=(int)(float)(rates.talentScrollPerMin*nativeMinutes),weaponToken=(int)(float)(rates.weaponTokenPerMin*nativeMinutes),gearScrolls=new int[6]};
        for(int i=0;i<6;i++)r.gearScrolls[i]=(int)(float)((float)((float)(rates.gearScrollsPerMin[i]*nativeMinutes)*(float)GearBolen[i])/100f);
        return r;
	}

	private void UpdateUI()
	{
        // Original ARM64 0x201b3e4.
        TimeSpan raw=DateTime.Now-lastOfflineTime;TimeSpan clamped=TimeSpan.FromMinutes(Mathf.Clamp((float)raw.TotalMinutes,0f,600f));
        offlineTimeText.text=string.Format("{0:D2}{1}:{2:D2}{3}",(int)clamped.TotalHours,Lang.Get.kisaltmasaat,clamped.Minutes,Lang.Get.kisaltmadakika);
        rewardTexts[0].text=baseRewards.coin.ToString();rewardObjects[0].SetActive(baseRewards.coin>0);
        rewardTexts[1].text=baseRewards.talentScroll.ToString();rewardObjects[1].SetActive(baseRewards.talentScroll>0);
        rewardTexts[2].text=baseRewards.weaponToken.ToString();rewardObjects[2].SetActive(baseRewards.weaponToken>0);
        for(int i=0;i<6;i++){rewardTexts[i+3].text=baseRewards.gearScrolls[i].ToString();rewardObjects[i+3].SetActive(baseRewards.gearScrolls[i]>0);}
        inventoryManager.GenerateOfflineRewards(offlineGearCount);offlineGear=new List<GearInstance>(inventoryManager.OfflinependingRewards);
        collectButton.interactable=raw.TotalMinutes>3d;ShowGeneratedRewards();
	}

	private void UpdateBoostUI()
	{
        // Original ARM64 0x201aeec.
        CheckBoostReset();boostButton.interactable=boostRemaining>=1&&Currencys.Energy>=energyCostForBoost;
        if(boostRemaining>=1)boostButtonText.text="<sprite=3>30";
        else{
         TimeSpan remaining=lastBoostResetTime.AddHours(24)-DateTime.Now;if(remaining<TimeSpan.Zero)remaining=TimeSpan.Zero;
         boostButtonText.text=string.Format("{0}{1}: {2}{3}",(int)remaining.TotalHours,Lang.Get.kisaltmasaat,remaining.Minutes,Lang.Get.kisaltmadakika);
        }
        boostCountText.text=GameManager.ViPSinirsizidle?Lang.Get.vipsinirsiz:boostRemaining.ToString()+" "+Lang.Get.attemptsremain;
	}

	private void OnBoost()
	{
        // Original ARM64 0x201c2b4.
        if(boostRemaining<=0&&!GameManager.ViPSinirsizidle)return;
        if(Currencys.Energy<energyCostForBoost)return;
        // Original first checks public Energy, then ignores SpendEnergy's returned bool.
        Currencys.SpendEnergy(energyCostForBoost,"Meta","IdleIncome");
        if(!GameManager.ViPSinirsizidle)boostRemaining--;
        hasUsedExtra=true;OnCollect();UpdateUI();UpdateBoostUI();
	}

	private void OnCollect()
	{
        // Original ARM64 0x201c430.
        offlineGearPopUp=offlineGear;
        if(SoundManager.instance!=null)SoundManager.instance.CashSound(SoundManager._collecting);
        if(hasUsedExtra){
         inventoryManager.GenerateidleRewards(10);idleGear=new List<GearInstance>(inventoryManager.OfidleRewards);
         inventoryManager.ClaimidleEquipments(1);AddToInventory(extraRewards);
         OpenPopUp(extraRewards.coin,extraRewards.talentScroll,extraRewards.weaponToken,extraRewards.gearScrolls,idleGear);
         ES3.Save<DateTime>("lastBoostResetTime",lastBoostResetTime);ES3.Save<int>("boostRemainingB",boostRemaining);
        }else{
         inventoryManager.ClaimOfflineEquipments(1);AddToInventory(baseRewards);
         OpenPopUp(baseRewards.coin,baseRewards.talentScroll,baseRewards.weaponToken,baseRewards.gearScrolls,offlineGearPopUp);
         lastOfflineTime=DateTime.Now;ES3.Save<DateTime>("NewlastOfflineTime",DateTime.Now);
         CalculateBaseRewards();UpdateUI();
        }
        GearBolen=RandomSplit(100,6);ES3.Save<int[]>("GearBolenOran",GearBolen);hasUsedExtra=false;
        // Original FGAnalytics claim events omitted.
	}

	private void AddToInventory(Rewards r)
	{
        // Original ARM64 0x201c874.
        Currencys.AddCoin((double)r.coin,"Meta","IdleIncome");Currencys.AddTalentScroll(r.talentScroll,"Meta","IdleIncome");Currencys.AddWeaponToken(r.weaponToken,"Meta","IdleIncome");
        for(int i=0;i<6;i++)Currencys.AddGearScroll(i,r.gearScrolls[i],"Meta","IdleIncome");
	}

	private void ShowGeneratedRewards()
	{
        // Original ARM64 0x201c028.
        for(int i=0;i<12;i++){
         if(i<inventoryManager.OfflinependingRewards.Count){
          var gear=inventoryManager.OfflinependingRewards[i];
          var inside=gearRewardSlots[i].transform.GetChild(0).GetChild(0);
          inside.GetChild(0).GetComponent<Image>().color=inventoryManager.RarityColors[(int)gear.rarity];
          inside.GetChild(1).GetComponent<Image>().sprite=gear.template.icon;
          gearRewardSlots[i].SetActive(true);
         }else gearRewardSlots[i].SetActive(false);
        }
	}

	private void ShowGeneratedPopUpRewards(List<GearInstance> list)
	{
        // Original ARM64 0x201cc04.
        for(int i=0;i<12;i++){
         if(i<list.Count){
          var gear=list[i];
          var inside=POPUPgearRewardSlots[i].transform.GetChild(0).GetChild(0);
          inside.GetChild(0).GetComponent<Image>().color=inventoryManager.RarityColors[(int)gear.rarity];
          inside.GetChild(1).GetComponent<Image>().sprite=gear.template.icon;
          POPUPgearRewardSlots[i].SetActive(true);
         }else POPUPgearRewardSlots[i].SetActive(false);
        }
	}

	public void OpenPopUp(int coin, int talent, int weapon, int[] scrolls, List<GearInstance> list)
	{
        // Original ARM64 0x201c998.
        popUpObj.SetActive(true);
        POPUPrewardTexts[0].text=coin.ToString();POPUPrewardObjects[0].SetActive(coin>0);
        POPUPrewardTexts[1].text=talent.ToString();POPUPrewardObjects[1].SetActive(talent>0);
        POPUPrewardTexts[2].text=weapon.ToString();POPUPrewardObjects[2].SetActive(weapon>0);
        for(int i=0;i<6;i++){POPUPrewardTexts[i+3].text=scrolls[i].ToString();POPUPrewardObjects[i+3].SetActive(scrolls[i]>0);}
        ShowGeneratedPopUpRewards(list);
	}

	public void ClosePopUp()
	{
        // Original ARM64 0x201ce78.
        popUpObj.SetActive(false);
	}
}
