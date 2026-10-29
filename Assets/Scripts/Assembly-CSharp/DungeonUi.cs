using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DungeonUi : MonoBehaviour
{
	public GameObject[] insidePages;

	public GameObject[] bottomBtns;

	public TextMeshProUGUI[] bottombtntexts;

	public Transform bottombtnlight;

	public GameObject[] bottominfos;

	public TextMeshProUGUI titledungeons;

	public TextMeshProUGUI[] dungeonnames;

	public TextMeshProUGUI[] dungeonlevels;

	public TextMeshProUGUI[] dungeonkeys;

	public static int choosenDungeon;

	public static bool DungeonCleared;

	public WarController warController;

	public TextMeshProUGUI _dungeonTimerKac;

	public RewardAdsManager rewardAdsManager;

	public TextMeshProUGUI[] rewardnediryazi;

	public TextMeshProUGUI[] chancesLefttxt;

	public TextMeshProUGUI[] rewardleveltxt;

	[Header("OneCikan")]
	public GameObject onecikanobj;

	public TextMeshProUGUI onecikandungeonname;

	public TextMeshProUGUI onecikandungensubtitle;

	public TextMeshProUGUI onecikandungeonlevel;

	public TextMeshProUGUI onecikandungeonlvltxt;

	public TextMeshProUGUI onecikanrewardtxt;

	public GameObject[] onecikandungeonicon;

	public TextMeshProUGUI onecikandungeonkey;

	public TextMeshProUGUI sweeptxt;

	public TextMeshProUGUI challangetxt;

	public Button sweepbtn;

	public Button challangebtn;

	public TextMeshProUGUI sweepedtxt;

	public GameObject sweepedobj;

	public GecisControl gecisControl;

	public GameManager gameManager;

	public Image backgroundDungeon;

	public Sprite[] backgrounds;

	public GameObject rewwardShowObj;

	public TextMeshProUGUI rewardcollectedtxt;

	public TextMeshProUGUI taptocontinue;

	public TextMeshProUGUI coinrewardtxt;

	public TextMeshProUGUI talentrewardtxt;

	public TextMeshProUGUI herostonerewardtxt;

	public TextMeshProUGUI weapontokenrewardtxt;

	public TextMeshProUGUI mistiktokenrewardtxt;

	public TextMeshProUGUI crystalrewardtxt;

	public TextMeshProUGUI energyrewardtxt;

	public TextMeshProUGUI SHOWcoinrewardtxt;

	public TextMeshProUGUI SHOWtalentrewardtxt;

	public TextMeshProUGUI SHOWherostonerewardtxt;

	public TextMeshProUGUI SHOWweapontokenrewardtxt;

	public TextMeshProUGUI SHOWmistiktokenrewardtxt;

	public TextMeshProUGUI SHOWcrystalrewardtxt;

	public TextMeshProUGUI SHOWenergyrewardtxt;

	public TextMeshProUGUI[] SHOWgearscrollrewardtxt;

	public GameObject[] ShowAllRewards;

	[Header("TIMER")]
	private string LastRewardTimeKey = "dungeonKeyTimer";

	private TimeSpan rewardInterval = TimeSpan.FromHours(12);

	private DateTime lastRewardTime;

	public static bool duelgroundacildi;

	[Header("REKLAM")]
	public int[] reklamhaklari = new int[3];

	public static bool dungeonuiacildi;

	private int[] gears = new int[]{0,1,2,3,4,5};

	private bool started;

	public double CoinReward(int sweep)
	{
		// Offline recovery candidate; native RVA 0x21ff17c.
		int baseAmount = unchecked(Mathf.Min(unchecked((GameManager.DungeonLevels[2]-sweep)*100),80000)+500);
		double multiplier = PlayerData.dailyFortune.DungeonDrops > 0f ? (double)PlayerData.dailyFortune.DungeonDrops : 1.0;
		return (double)baseAmount*multiplier;
	}

	public int TalentReward(int sweep)
	{
		// Offline recovery candidate; native RVA 0x21ff284.
		int amount = unchecked(Mathf.Min(unchecked((GameManager.DungeonLevels[2]-sweep)*4),300)+30);
		float multiplier = PlayerData.dailyFortune.DungeonDrops > 0f ? PlayerData.dailyFortune.DungeonDrops : 1f;
		return (int)(float)((float)amount*multiplier);
	}

	public int HeroStoneReward(int sweep)
	{
		// Offline recovery candidate; native RVA 0x21ff398.
		if (PlayerData.dailyFortune.DungeonDrops <= 0f) return 5;
		return (int)(double)(float)(PlayerData.dailyFortune.DungeonDrops*5f);
	}

	public int WeaponTokenReward(int sweep)
	{
		// Offline recovery candidate; native RVA 0x21ff44c.
		int amount = unchecked(Mathf.Min(unchecked((GameManager.DungeonLevels[2]-sweep)*2),100)+10);
		float multiplier = PlayerData.dailyFortune.DungeonDrops > 0f ? PlayerData.dailyFortune.DungeonDrops : 1f;
		return (int)(float)((float)amount*multiplier);
	}

	public int MistikTokenReward(int sweep)
	{
		// Offline recovery candidate; native RVA 0x21ff560.
		if (PlayerData.dailyFortune.DungeonDrops <= 0f) return 5;
		return (int)(double)(float)(PlayerData.dailyFortune.DungeonDrops*5f);
	}

	public int CrystalReward(int sweep)
	{
		// Offline recovery candidate; native RVA 0x21ff614.
		int amount = unchecked(Mathf.Min(unchecked((GameManager.DungeonLevels[1]-sweep)*2),150)+10);
		float multiplier = PlayerData.dailyFortune.DungeonDrops > 0f ? PlayerData.dailyFortune.DungeonDrops : 1f;
		return (int)(float)((float)amount*multiplier);
	}

	public int GearScrollReward(int sweep)
	{
		// Offline recovery candidate; native RVA 0x21ff728.
		float random = UnityEngine.Random.Range(1f,20f);
		float multiplier = PlayerData.dailyFortune.DungeonDrops > 0f ? PlayerData.dailyFortune.DungeonDrops : 1f;
		int amount = unchecked(Mathf.Min((int)(float)(random*(float)unchecked(GameManager.DungeonLevels[0]-sweep+1)),500)+30);
		return (int)(float)((float)amount*multiplier);
	}

	public int EnergyReward(int sweep)
	{
		// Offline recovery candidate; native RVA 0x21ff86c.
		if (PlayerData.dailyFortune.DungeonDrops <= 0f) return 10;
		return (int)(double)(float)(PlayerData.dailyFortune.DungeonDrops*10f);
	}

	public void OpenInsidePage(int who)
	{
		// Offline recovery candidate; native RVA 0x21ff920.
		for (int i=0;i<insidePages.Length;i++)
		{
		 insidePages[i].SetActive(i==who);
		 if (i==who) bottombtnlight.position=bottomBtns[who].transform.position;
		}
		if(who==0) bottominfos[0].SetActive(false);
		if(who==1){bottominfos[1].SetActive(false);duelgroundacildi=true;}
		GameManager.PageAcildi=true;
		gameObject.SetActive(true);
		SoundManager.instance.CashSound(SoundManager._click);
	}

	private void Start()
	{
		// Offline recovery candidate; native RVA 0x21ffb74.
		InitializeRewardTime();
		CheckReward();
		titledungeons.text=Lang.Get.Dungeon;
		for(int i=0;i<3;i++) dungeonnames[i].text=Lang.GetDungeonNames(i);
		onecikanrewardtxt.text=Lang.Get.reward;
		onecikandungeonlvltxt.text=Lang.Get.seviye;
		sweeptxt.text=Lang.Get.sweepprevius;
		challangetxt.text=Lang.Get.challange;
		sweepedtxt.text=Lang.Get.sweepsucces;
		taptocontinue.text=Lang.Get.taptocontinue;
		rewardcollectedtxt.text=Lang.Get.RewardsCollected;
		rewardnediryazi[0].text=Lang.Get.EarnRandomGearScroll;
		rewardnediryazi[1].text=Lang.Get.EarnEnergyAndCrystal;
		rewardnediryazi[2].text=Lang.Get.EarnRandomCurrencies;
		for(int i=0;i<3;i++){chancesLefttxt[i].text=Lang.Get.ChancesLeft;rewardleveltxt[i].text=Lang.Get.RewardLevel;}
		bottombtntexts[0].text=Lang.Get.dungeontxt;
		bottombtntexts[1].text=Lang.Get.dailywars;
		started=true;
		if(ES3.KeyExists("DungeonReklamHak"))reklamhaklari=ES3.Load<int[]>("DungeonReklamHak");
	}

	private void UpdateData()
	{
		// Offline recovery candidate; native RVA 0x22003d4.
		for(int i=0;i<3;i++) dungeonlevels[i].text=unchecked(GameManager.DungeonLevels[i]+1).ToString();
		int[] keys={Currencys.Dungeon_1_Key,Currencys.Dungeon_2_Key,Currencys.Dungeon_3_Key};
		for(int i=0;i<3;i++)
		{
		 if(keys[i]>0)dungeonkeys[i].text=keys[i].ToString();
		 else if(reklamhaklari[i]>0)dungeonkeys[i].text="<sprite=2>"+reklamhaklari[i].ToString();
		 else dungeonkeys[i].text="<sprite=10>"+keys[i].ToString();
		}
	}

	public void OneCikar(int kim)
	{
		// Offline recovery candidate; native RVA 0x2200a8c.
		UpdateData();
		choosenDungeon=kim;
		onecikandungeonname.text=Lang.GetDungeonNames(kim);
		onecikandungensubtitle.text=Lang.GetDungeonSubtitles(kim);
		onecikandungeonlevel.text=unchecked(GameManager.DungeonLevels[kim]+1).ToString();
		onecikandungeonkey.text=dungeonkeys[kim].text;
		for(int i=0;i<onecikandungeonicon.Length;i++)onecikandungeonicon[i].SetActive(i==kim);
		if(kim==1){energyrewardtxt.text=EnergyReward(0).ToString();crystalrewardtxt.text=CrystalReward(0).ToString();}
		if(kim==2){coinrewardtxt.text=ShortScaleString.parseDouble(CoinReward(0),1,1000000.0,false);talentrewardtxt.text=TalentReward(0).ToString();herostonerewardtxt.text=HeroStoneReward(0).ToString();weapontokenrewardtxt.text=WeaponTokenReward(0).ToString();mistiktokenrewardtxt.text=MistikTokenReward(0).ToString();}
		if(kim>=0 && kim<=2)
		{
		 int key=kim==0?Currencys.Dungeon_1_Key:kim==1?Currencys.Dungeon_2_Key:Currencys.Dungeon_3_Key;
		 challangebtn.interactable=key>0 || reklamhaklari[kim]>0;
		 sweepbtn.interactable=key>0;
		 WarController.DungeonLevel=GameManager.DungeonLevels[kim];
		}
		sweepbtn.gameObject.SetActive(GameManager.DungeonLevels[kim]>0);
		onecikanobj.SetActive(true);
		SoundManager.instance.CashSound(SoundManager._click);
	}

	public void CloseOneCikan()
	{
		// Offline recovery candidate; native RVA 0x2201350.
		onecikanobj.SetActive(false);
		SoundManager.instance.CashSound(SoundManager._close);
	}

	public void CloseSweeped()
	{
		// Offline recovery candidate; native RVA 0x2201410.
		sweepedobj.SetActive(false);
		SoundManager.instance.CashSound(SoundManager._close);
	}

	public bool HandleBackButton()
	{
		// Offline recovery candidate; native RVA 0x22014d0.
		if(!gameObject.activeInHierarchy)return false;
		if(rewwardShowObj!=null && rewwardShowObj.activeInHierarchy)closerewards();
		else if(sweepedobj!=null && sweepedobj.activeInHierarchy)CloseSweeped();
		else if(onecikanobj!=null && onecikanobj.activeInHierarchy)CloseOneCikan();
		else Closedungeonpage();
		return true;
	}

	public void SweepThis()
	{
	}

	private void ShowRewards(int kim, int sweep)
	{
		// Offline recovery candidate; native RVA 0x2201a4c.
		rewwardShowObj.SetActive(true);
		foreach(GameObject item in ShowAllRewards)item.SetActive(false);
		if(kim==0)
		{
		 int forced1=UnityEngine.Random.Range(0,3);
		 int forced2=UnityEngine.Random.Range(3,5);
		 int[] selected=GearSelect(gears,forced1,forced2,.25f);
		 foreach(int gear in selected)
		 {
		  int amount=GearScrollReward(sweep);
		  Currencys.AddGearScroll(gear,amount,"Meta","DungeonReward");
		  SHOWgearscrollrewardtxt[gear].text=amount.ToString();
		  SHOWgearscrollrewardtxt[gear].transform.parent.parent.parent.gameObject.SetActive(true);
		 }
		 BuyukParticle.Playit(BuyukParticle._konfeti);
		}
		if(kim==1)
		{
		 Currencys.AddEnergy(EnergyReward(sweep),"Meta","DungeonReward");
		 Currencys.AddCrystal(CrystalReward(sweep),"Meta","DungeonReward");
		 SHOWenergyrewardtxt.text=EnergyReward(sweep).ToString();
		 SHOWcrystalrewardtxt.text=CrystalReward(sweep).ToString();
		 SHOWenergyrewardtxt.transform.parent.parent.parent.gameObject.SetActive(true);
		 SHOWcrystalrewardtxt.transform.parent.parent.parent.gameObject.SetActive(true);
		 BuyukParticle.Playit(BuyukParticle.Crystal_Particle);
		}
		if(kim==2)
		{
		 Currencys.AddCoin(CoinReward(sweep),"Meta","DungeonReward");
		 SHOWcoinrewardtxt.text=CoinReward(sweep).ToString();
		 SHOWcoinrewardtxt.transform.parent.parent.parent.gameObject.SetActive(true);
		 BuyukParticle.Playit(BuyukParticle.Para_Particle);
		 if(UnityEngine.Random.value<.7f)
		 {
		  Currencys.AddTalentScroll(TalentReward(sweep),"Meta","DungeonReward");
		  SHOWtalentrewardtxt.text=TalentReward(sweep).ToString();
		  SHOWtalentrewardtxt.transform.parent.parent.parent.gameObject.SetActive(true);
		 }
		 if(UnityEngine.Random.value<.1f)
		 {
		  Currencys.AddHeroStone(HeroStoneReward(sweep),"Meta","DungeonReward");
		  SHOWherostonerewardtxt.text=HeroStoneReward(sweep).ToString();
		  SHOWherostonerewardtxt.transform.parent.parent.parent.gameObject.SetActive(true);
		 }
		 if(UnityEngine.Random.value<.4f)
		 {
		  Currencys.AddWeaponToken(WeaponTokenReward(sweep),"Meta","DungeonReward");
		  SHOWweapontokenrewardtxt.text=WeaponTokenReward(sweep).ToString();
		  SHOWweapontokenrewardtxt.transform.parent.parent.parent.gameObject.SetActive(true);
		 }
		 if(UnityEngine.Random.value<.03f)
		 {
		  Currencys.AddMistikToken(MistikTokenReward(sweep),"Meta","DungeonReward");
		  SHOWmistiktokenrewardtxt.text=MistikTokenReward(sweep).ToString();
		  SHOWmistiktokenrewardtxt.transform.parent.parent.parent.gameObject.SetActive(true);
		 }
		}
		SoundManager.instance.CashSound(SoundManager._collecting);
		OneCikar(kim);
	}

	private int[] GearSelect(int[] coins, int forced1, int forced2, float chance = 0.25f)
	{
		// Offline recovery candidate; native RVA 0x2202368.
		System.Collections.Generic.List<int> selected=new System.Collections.Generic.List<int>();
		if(forced1>=0 && forced1<coins.Length)selected.Add(coins[forced1]);
		if(forced2>=0 && forced2<coins.Length)selected.Add(coins[forced2]);
		for(int i=0;i<coins.Length;i++)if(i!=forced1 && i!=forced2 && UnityEngine.Random.value<chance)selected.Add(coins[i]);
		return selected.ToArray();
	}

	public void closerewards()
	{
		// Offline recovery candidate; native RVA 0x2201620.
		rewwardShowObj.SetActive(false);
		SoundManager.instance.CashSound(SoundManager._close);
	}

	public void GoDungeon()
	{
		// Offline recovery candidate; native RVA 0x22025c8.
		int key=choosenDungeon==0?Currencys.Dungeon_1_Key:choosenDungeon==1?Currencys.Dungeon_2_Key:Currencys.Dungeon_3_Key;
		if(choosenDungeon>=0 && choosenDungeon<=2 && key==0 && reklamhaklari[choosenDungeon]>=1)
		{
		 // Original RewardAdsManager.ShowRewardBasedVideo(30+choosenDungeon) waits for
		 // an actual ad reward. Offline local scope omits dispatch; no key/entry granted.
		 return;
		}
		SoundManager.instance.CashSound(SoundManager._bell);
		WarController.Dungeondayim=true;
		DungeonCleared=false;
		gecisControl.DungeonGit();
	}

	public void DungeonTamamlandi()
	{
		// Offline recovery candidate; native RVA 0x22028a0.
		if(DungeonCleared)
		{
		 if(choosenDungeon==0)Currencys.SpendDungeon_1_Key(1,"Meta","StartDungeon");
		 if(choosenDungeon==1)Currencys.SpendDungeon_2_Key(1,"Meta","StartDungeon");
		 if(choosenDungeon==2)Currencys.SpendDungeon_3_Key(1,"Meta","StartDungeon");
		 ShowRewards(choosenDungeon,0);
		 GameManager.DungeonLevels[choosenDungeon]=unchecked(GameManager.DungeonLevels[choosenDungeon]+1);
		 ES3.Save<int[]>("DungeonLevels",GameManager.DungeonLevels);
		 SoundManager.instance.RandomizeSfx(SoundManager._collecting);
		 DungeonCleared=false;
		 GunlukGorevler.UpdateTaskProgressK(2,1);
		 ClanTaskLocal.ClanTaskPointEkle(2,1);
		}
		WarController.Dungeondayim=false;
		UpdateData();
		OneCikar(choosenDungeon);
	}

	public void OnEnable()
	{
		// Offline recovery candidate; native RVA 0x2202be0.
		dungeonuiacildi=true;
		UpdateData();
		if(started)CheckReward();
		SoundManager.instance.CashSound(SoundManager._click);
	}

	public void Closedungeonpage()
	{
		// Offline recovery candidate; native RVA 0x22016e0.
		gameObject.SetActive(false);
		GameManager.PageAcildi=false;
		SoundManager.instance.CashSound(SoundManager._close);
	}

	public void OpenDungeon()
	{
		// Offline recovery candidate; native RVA 0x2202cc8.
		OpenInsidePage(0);
	}

	public void InitializeRewardTime()
	{
		// Offline recovery candidate; native RVA 0x220023c.
		if(ES3.KeyExists(LastRewardTimeKey))lastRewardTime=ES3.Load<DateTime>(LastRewardTimeKey);
		else
		{
		 lastRewardTime=DateTime.UtcNow;
		 ES3.Save<DateTime>(LastRewardTimeKey,lastRewardTime);
		 GiveReward();
		}
	}

	private void CheckReward()
	{
		// Offline recovery candidate; native RVA 0x2200300.
		DateTime now=DateTime.UtcNow;
		if(now-lastRewardTime>=rewardInterval){GiveReward();SaveCurrentTime(now);}
	}

	private void GiveReward()
	{
		// Offline recovery candidate; native RVA 0x2202cd0.
		Currencys.AddDungeon_1_Key(unchecked(GameManager.ViPGunlukDungeonKeyArtisi+2),"Meta","DungeonDailyKey");
		Currencys.AddDungeon_2_Key(unchecked(GameManager.ViPGunlukDungeonKeyArtisi+2),"Meta","DungeonDailyKey");
		Currencys.AddDungeon_3_Key(unchecked(GameManager.ViPGunlukDungeonKeyArtisi+2),"Meta","DungeonDailyKey");
		for(int i=0;i<3;i++)reklamhaklari[i]=unchecked(GameManager.ViPGunlukDungeonKeyArtisi+2);
		ES3.Save<int[]>("DungeonReklamHak",reklamhaklari);
		UpdateData();
	}

	private void SaveCurrentTime(DateTime currentTime)
	{
		// Offline recovery candidate; native RVA 0x2202e64.
		lastRewardTime=currentTime;
		ES3.Save<DateTime>(LastRewardTimeKey,currentTime);
	}

	public string GetTimeUntilNextReward(DateTime currentTime)
	{
		// Offline recovery candidate; native RVA 0x2202ec0.
		TimeSpan remaining=rewardInterval-(currentTime-lastRewardTime);
		return "+"+unchecked(GameManager.ViPGunlukDungeonKeyArtisi+2).ToString()+" "+Lang.Get.dungeonkeys+": <sprite=4>"+remaining.ToString(@"hh\:mm\:ss");
	}

	public string GetTimeUntilNextReward()
	{
		// Offline recovery candidate; native RVA 0x2203154.
		return GetTimeUntilNextReward(DateTime.UtcNow);
	}

	private void Update()
	{
		// Offline recovery candidate; native RVA 0x22031b4.
		_dungeonTimerKac.text=GetTimeUntilNextReward(DateTime.UtcNow);
	}
}
