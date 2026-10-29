using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CAnimateDPSChange_003Ed__124 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public float duration;

		public long addedDPS;

		public GameManager _003C_003E4__this;

		public long from;

		public long to;

		private float _003CelapsedTime_003E5__2;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CAnimateDPSChange_003Ed__124(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003Cscanit_003Ed__108 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public GameManager _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003Cscanit_003Ed__108(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	public static string Playername = string.Empty;

	public static bool MerdivenEventAktif;

	public static bool tabletor1920;

	public static string UserUniqueid = string.Empty;

	public static string UserOnlineUniqueid = string.Empty;

	public static bool NameSettedOnCBS;

	public static int Language;

	public static int BulunduguBolum;

	public static bool GuideDone;

	public static int GuidePhaseTamamlandi;

	public static int GorevTaskTamamlanan;

	public static int[] DungeonLevels = new int[3];

	public static int inapp_Boost_satisGelirX;

	public static int inapp_Boost_talent2x;

	public static bool PremiumPassMevcut;

	public static float TimeScale = 1f;

	public static int MaxGearSize = 1000;

	public static bool BottomPageOpened;

	public static float lokasyonClicked;

	public static string KaziWeeklySaveid = "Weekly";

	public static string suankisurum;

	public static bool PerformansMode;

	public static bool NewUserTapNation;

	public static int MusteriSayisi;

	public static int BankadaBirikenCrystal;

	public static bool PageAcildi;

	public static bool TamPageAcildi;

	public static string Bolumismi;

	public static int DailyTalentIncomeTotal;

	public static int DailyCrystalIncomeTotal;

	public static float UnlockedTimeScale;

	public static bool ArmyUnitsHits2X;

	public static int SilverCoinIncomePurchased;

	public static int NoAdsGameSpeed;

	public static int ExtraGameSpeed;

	public static int AlinanExtraSpeedHour;

	public static float offlinepacksaat;

	public static float offlinepackkazanc;

	public static float extracashtimer;

	public float timers;

	public static float time30sec;

	public static int ViPGunlukDungeonKeyArtisi;

	public static bool ViPSinirsizidle;

	public static float MilestoneGoldBonus;

	public static int ResearchSpeedUp;

	public static float KazancBooster;

	public static float CookieKazanc;

	public static float SpeedBooster;

	public static bool loadingfirst;

	public float timekazanchesapla;

	private bool ilk30saniye;

	public GameObject _Loading;

	public static bool agegectim;

	public static bool loading;

	public static bool inapplookingforCash;

	public static bool guidecamera;

	public DailyLoginEvent _loginevent7;

	public GunlukHediye _gunlukhediye;

	public SaatlikHediye _saatlikhediye;

	public OneTimeOffer _offer;

	public CanvasJobs canvasJobs;

	public GunlukWars _gunlukWars;

	public NewOfflineRewards offlineRewards;

	public WarController warController;

	public static int LevelExp;

	public static int Level;

	public static int EliteLevel;

	public static int Rated;

	public static bool EliteON;

	private int old_bonustoplamiforinfo;

	public static int WeeklyLeaderboardCoin;

	public static int cColorCode;

	private DateTime MerdivenlastResetDate;

	public static string _merdivenkalanzaman;

	public TextMeshProUGUI _homemerdivenbtntimer;

	public DungeonUi _dungeonTimericin;

	public GameObject _GuideManager;

	public static float basarimlar;

	public static float bilgitimer;

	public static bool oyunbasladi;

	public PassGame passGame;

	private static bool saveExp;

	private static bool saveLevel;

	private static float timersaveExp;

	private static bool infolevelup;

	public bool gunlukhediyegoster;

	public bool gunlukhediyegoster2;

	public KademeliAcilim _kademeliAcilim;

	public GunlukGorevler gunlukGorevler;

	public Basarimlar basarimlarPage;

	public DailySpin dailySpin;

	public static int BestSurvive;

	public static int BestSurviveElites;

	public GoldUpgradeitem[] goldUpgradeitem;

	public AnaSayfaEnemyAyarlaryici anaSayfaEnemy;

	public PoolObject poolObject;

	public static float reklamtimer;

	public static bool[] SatinalinanUpgrades = new bool[40];

	public ClanTaskLocal clanTaskLocal;

	public LockedforTask[] _lockedfortasks;

	private int starttansonraac;

	public float saveit;

	public TextMeshProUGUI _dpstop;

	public GameObject _topdps;

	public FalseDestroyLater _topdpsfalser;

	public Animator _topdpsanim;

	private long _previousDPS;

	public string _newDPSIndicator;

	private string dpsdurum;

	private float savednew;

	public static int LevelExpMax()
	{
        // Offline recovery from native 0x221120c. Missing-reference guards are intentional.
        return unchecked(Level*105);
	}

	public static void LevelExpArttir(int kacx = 1)
	{
        // Offline recovery from native 0x221126c. Missing-reference guards are intentional.
        LevelExp=unchecked(LevelExp+kacx);
        while(LevelExp>=LevelExpMax())
        {
         LevelExp=unchecked(LevelExp-LevelExpMax());
         Level=unchecked(Level+1);
         infolevelup=true;
         // Native GppEntitlements.ApplyGamePass call intentionally omitted offline.
        }
        saveExp=true;saveLevel=true;timersaveExp=0;
        // Offline integration: native only raises save flags. Store the exact LoadingPage
        // keys here so progression persists before the remaining deferred UI saver is restored.
        ES3.Save<int>("SeviyeDeneyimPuani",LevelExp);
        ES3.Save<int>("Seviye",Level);
	}

	private void UpgradeVerileriCek()
	{
	}

	public static void LeaderCoinEkle(int kac)
	{
        // Offline recovery from native 0x2211394. Missing-reference guards are intentional.
        WeeklyLeaderboardCoin=unchecked(WeeklyLeaderboardCoin+kac);
        cColorCode=unchecked(cColorCode+kac*2);
        if(LeaderBoard.Weeklysavechanging)return;
        ES3.Save<int>(KaziWeeklySaveid,WeeklyLeaderboardCoin);
        ES3.Save<int>(KaziWeeklySaveid+"ColorCode",cColorCode);
	}

	private void Awake()
	{
		// Native RVA0x22114a0.
		loading = true;
		Screen.sleepTimeout = -1;
		Screen.fullScreen = true;
	}

	private void Start()
	{
		MenuGeneralSettings.FPS = ES3.Load<int>("FPS", 60);
        Application.targetFrameRate = MenuGeneralSettings.FPS;
        lokasyonClicked = 2f; inapplookingforCash = false; guidecamera = false;
        if (_Loading != null) _Loading.SetActive(GuideDone);
        MerdivenEventAktif = true; PageAcildi = false;
        StartCoroutine(scanit());
        if (_saatlikhediye != null) _saatlikhediye.Awaker();
        MerdivenStarter();
        QualitySettings.SetQualityLevel(MenuGeneralSettings.Optimization ? 0 : 1);
        if (_dungeonTimericin != null) _dungeonTimericin.InitializeRewardTime();
        OpenLockForTasks();
	}

	public void OpenLockForTasks()
	{
	}

	public void GunlukHediyeler()
	{
	}
	private IEnumerator scanit()
	{
        // Original state-machine RVA0x2212da0; only fixed local waits.
        yield return new WaitForSeconds(0.2f);
        if (gunlukGorevler != null) gunlukGorevler.OyunBaslayinca();
        if (basarimlarPage != null) basarimlarPage.OyunBaslayinca();
        yield return new WaitForSeconds(0.2f);
        loading = false; timekazanchesapla = 29f;
        GunlukHediyeler();
        if (dailySpin != null) dailySpin.OyunBaslayinca();
        if (passGame != null) passGame.LoadPass();
        if (poolObject != null) poolObject.ActivatePool();
        yield return new WaitForSeconds(0.3f);
        if (gunlukGorevler != null) gunlukGorevler.OyunBaslayincaKontrol2();
        if (anaSayfaEnemy != null) anaSayfaEnemy.SetUp(BestSurvive);
        if (offlineRewards != null) offlineRewards.LoadData();
        if (passGame != null) passGame.ResetEventRewards();
        oyunbasladi = true;
        yield return new WaitForSeconds(0.3f);
        if (_gunlukWars != null) _gunlukWars.OyunBaslayincaCek();
        yield return new WaitForSeconds(0.5f);
        if (_Loading != null) _Loading.SetActive(false);
        reklamtimer = 200f;
        // Starter-pack purchase popup branch is deliberately omitted in offline mode.
	}

	private void Update()
	{

        // Original ARM64 0x2211efc, full1160-byte method. Original f32 timer steps.
        if(savednew>0f)savednew=(float)(savednew-Time.deltaTime);
        reklamtimer=(float)(reklamtimer+Time.deltaTime);
        if(!warController.savastayim){
            basarimlar=(float)(basarimlar+Time.deltaTime);
            if(basarimlar>10f){Basarimlar.SaveBasarimlar();basarimlar=0f;}
        }
        lokasyonClicked=(float)(lokasyonClicked+Time.deltaTime);
        saveit=(float)(saveit+Time.deltaTime);
        if(saveit>30f&&!warController.savastayim){
            ES3.Save<string>("OynadigiTumZamanSaniyesi",ES3Cloud.OynadigiTumZamanSaniyesi.ToString());
            ES3.Save<string>("timesavedOffline",DateTime.UtcNow.ToString());
            ES3.Save<float>("saatlikOdulSaniyeToplam",SaatlikHediye.totalSecondsSpentInGame);
            SaveCacheToDisk();saveit=0f;
        }
        SaatlikHediye.totalSecondsSpentInGame=(float)(SaatlikHediye.totalSecondsSpentInGame+Time.deltaTime);
        if(inapplookingforCash)inapplookingforCash=false;
        timekazanchesapla=(float)(timekazanchesapla+Time.deltaTime);
        if(timekazanchesapla>30f){
            // Original long++ once per30-second interval, despite the Seconds field name.
            ES3Cloud.OynadigiTumZamanSaniyesi=unchecked(ES3Cloud.OynadigiTumZamanSaniyesi+1L);
            if(ilk30saniye&&!OneTimeOffer.BuGunStarterAcildi&&GuideDone&&Level>=6){
                starttansonraac=unchecked(starttansonraac+1);
                if(starttansonraac>=2&&PageAcildi){
                    if(!ES3.KeyExists("StarterPack")&&!GooglePlayPassHandler.IsActive)_offer.OpenOffer();
                    OneTimeOffer.BuGunStarterAcildi=true;
                }
            }
            timekazanchesapla=0f;ilk30saniye=true;
        }
	}

	private void MerdivenStarter()
	{
	}

	private void CheckAndReset()
	{
	}

	public void ResetAllSaves()
	{
	}

	public long CalculateTotalDPS()
	{
		return 0L;
	}

	public void ShowDPS()
	{
	}

	[IteratorStateMachine(typeof(_003CAnimateDPSChange_003Ed__124))]
	private IEnumerator AnimateDPSChange(long from, long to, long addedDPS, float duration)
	{
		return null;
	}

	private void OnApplicationPause(bool pause)
	{
		// Offline integration: lifecycle flush is never suppressed by an unrestored Update timer.
		if (pause) { savednew = 0f; SaveCacheToDisk(); }
	}

	private void OnApplicationQuit()
	{
		// Offline integration: always flush the final local state.
		savednew = 0f; SaveCacheToDisk();
	}

	private void SaveCacheToDisk()
	{
        // Native RVA0x2212384; keep explicit cache flush route.
        if (savednew > 0f) return;
        savednew = 2f;
        ES3.StoreCachedFile("medupac.es3", new ES3Settings("medupac.es3", ES3.Location.File));
	}
}
