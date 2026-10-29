using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasJobs : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003Clatestart_003Ed__82 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public CanvasJobs _003C_003E4__this;

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
		public _003Clatestart_003Ed__82(int _003C_003E1__state)
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

	public TextMeshProUGUI _para;

	public TextMeshProUGUI _crystal;

	public TextMeshProUGUI _dps;

	public TextMeshProUGUI _energy;

	public TextMeshProUGUI _energyTimer;

	public infoCurrencyShow infoCurrency;

	private int upgtoplami;

	private double oldpara = -1d;

	private int oldcrystal = -1;

	private int oldreklamkupon = -1;

	public Animator _crystaliconanim;

	private int oldchestsayisi;

	public static Transform _infoParaParent;

	public static Animator _paratopcashanim;

	public GameObject goldyokbasic;

	public TextMeshProUGUI golyokbasictxt;

	public GameObject goldyokinfo;

	public TextMeshProUGUI goldyoktxt;

	public TextMeshProUGUI gettxt;

	public ShopUi shopui;

	public BottomPages bottomPages;

	public Button passbtn;

	public TMP_InputField _inputname;

	public LeaderBoard _leaders;

	public RateEnabler rateEnabler;

	[Header("TopStageCastle")]
	public TextMeshProUGUI siegeName;

	public TextMeshProUGUI siegeLevel;

	public TextMeshProUGUI bestsurvive;

	public TextMeshProUGUI bestsurviveKac;

	public WarController warController;

	public TextMeshProUGUI energySpend;

	public TextMeshProUGUI normalMode;

	public TextMeshProUGUI eliteMode;

	public GameObject eliteChooser;

	public Animator eliteAnim;

	[Header("AnaSayfaTexts")]
	public TextMeshProUGUI dailygorevler;

	public TextMeshProUGUI gamespass;

	public TextMeshProUGUI merdivenevent;

	public TextMeshProUGUI spinevent;

	public TextMeshProUGUI income2x;

	public TextMeshProUGUI leaderboardtxt;

	public TextMeshProUGUI sevendayevent;

	public TextMeshProUGUI dailyrewards;

	public TextMeshProUGUI starterpack;

	public TextMeshProUGUI piggybank;

	public TextMeshProUGUI startit;

	public TextMeshProUGUI dungeontxt;

	public TextMeshProUGUI dailywarstxt;

	public TextMeshProUGUI noadstxt;

	public TextMeshProUGUI researchtxt;

	public TextMeshProUGUI totalgoldbonusestxt;

	public TextMeshProUGUI totalgoldbonuskac;

	public TextMeshProUGUI battletxt;

	public TextMeshProUGUI guild;

	public TextMeshProUGUI idlerewards;

	public TextMeshProUGUI eventname;

	public TextMeshProUGUI dailywar;

	public TextMeshProUGUI dailyfortune;

	private string[] Bolgeisimleri = new string[]{"Ardent","Brinor","Caelum","Drovak","Elyria","Ferros","Gallia","Helion","Ionia","Jorvik","Kaelis","Lythor","Myrion","Nyxus","Orenda","Pyros","Quorra","Riven","Solara","Thalos","Umbria","Vesper","Wyvern","Xandor","Ymir","Zephra","Aloria","Brevan","Crestol","Drakos","Etrium","Faelan","Graxia","Hesper","Ionis","Jandra","Korune","Lirien","Morael","Navori","Othran","Pyrion","Quinol","Rhosta","Sylmar","Tyros","Uldor","Valmar","Wyndel","Xypher","Yalara","Zorath","Avion","Brathol","Cindor","Delara","Elaris","Fendril","Gromar","Haleth","Ikora","Jerith","Kordel","Leosia","Merion","Norvik","Olisar","Perion","Questor","Rivora","Seraph","Talmar","Ulthos","Veldor","Wynora","Xandria","Ysolde","Zephos","Arkon","Belmar","Cyrena","Dorian","Elowen","Forwen","Gralor","Hybris","Illara","Joreth","Kethor","Lyrion","Morven","Nyther","Orluna","Polara","Quillon","Rymora","Sephir","Torven","Urenis","Vireth"};

	public TextMeshProUGUI fortunetracktimer;

	public SquareGachaSystem squareGachaSystem;

	public GameObject noadsshow;

	public TextMeshProUGUI forgeyoktitle;

	public TextMeshProUGUI forgeyoksubtitle;

	public TextMeshProUGUI forgeyokgo;

	public TextMeshProUGUI gorevtamamlandi;

	[Header("Energy")]
	public int energyPerInterval = 5;

	public float regenIntervalSeconds = 300f;

	private DateTime lastRegenTime;

	private float regenTimer;

	private const string LastRegenKey = "LastEnergyRegenTime";

	[Header("PassHome")]
	public TextMeshProUGUI passtitle;

	public TextMeshProUGUI passlvl;

	public TextMeshProUGUI passexp;

	public TextMeshProUGUI passtime;

	public Slider passslider;

	public PassGame passgame;

	[SerializeField]
	private float smoothTime = 3f;

	private float _currentExpValue;

	public GameObject _taskKacLazim;

	public TextMeshProUGUI _taskkacLazimText;

	public FalseDestroyLater _falserTask;

	public Animator _taskKacLazimAnimator;

	public void UpdateStageInfos()
	{
        // Original ARM64 recovery 0x21cd400.
        if(GameManager.EliteON)
        {
         siegeName.text=Lang.Get.Elite+" "+Lang.Get.bolgesi+" #"+unchecked(GameManager.EliteLevel+1).ToString();
         warController.bolgename.text=Lang.Get.Elite+" #"+unchecked(GameManager.EliteLevel+1).ToString();
         bestsurvive.text=Lang.Get.BestSurvive+" "+GameManager.BestSurviveElites.ToString()+"/"+warController.MaxWaveCountLevels[Mathf.Clamp(GameManager.EliteLevel,0,10)].ToString();
        }
        else
        {
         int region=GameManager.Level%100;
         siegeName.text=Bolgeisimleri[region]+" "+Lang.Get.bolgesi;
         siegeLevel.text=Lang.Get.lv+unchecked(GameManager.Level+1).ToString();
         warController.bolgename.text=Bolgeisimleri[region]+" "+Lang.Get.lv+unchecked(GameManager.Level+1).ToString();
         bestsurvive.text=Lang.Get.bestsurvive;
         bestsurviveKac.text=GameManager.BestSurvive.ToString();
        }
	}

	private void OnEnable()
	{
        // Offline adaptation: rating/ad-free entitlement/offer calls omitted.
        // Original local countdown stays wired if this dependency is restored.
        if (squareGachaSystem != null && fortunetracktimer != null)
        {
            string countdown=squareGachaSystem.UpdateCountdownString();
            if (countdown != null) fortunetracktimer.text=countdown;
        }
        if (noadsshow != null) noadsshow.SetActive(false);
	}

	private void Start()
	{
        // RVA0x21cdba8 direct localization stores; skip unresolved Lang.Get.
        var language=Lang.Get;
        if (language != null)
        {
            if (gorevtamamlandi != null) gorevtamamlandi.text=language.gorevtamamlandi;
            if (forgeyoktitle != null) forgeyoktitle.text=language.forgeyoktitle;
            if (forgeyoksubtitle != null) forgeyoksubtitle.text=language.forgeyoksubtitle;
            if (forgeyokgo != null) forgeyokgo.text=language.forgeyokgo;
            if (dailywar != null) dailywar.text=language.dailywars;
            if (dailygorevler != null) dailygorevler.text=language.dailygorevler;
            if (gamespass != null) gamespass.text=language.gamespass;
            if (merdivenevent != null) merdivenevent.text=language.merdivenevent;
            if (spinevent != null) spinevent.text=language.spinevent;
            if (income2x != null) income2x.text=language.income2x;
            if (leaderboardtxt != null) leaderboardtxt.text=language.leaderboardtxt;
            if (sevendayevent != null) sevendayevent.text=language.sevendayevent;
            if (dailyrewards != null) dailyrewards.text=language.dailyrewards;
            if (starterpack != null) starterpack.text=language.starterpack;
            if (piggybank != null) piggybank.text=language.piggybank;
            if (startit != null) startit.text=language.startit;
            if (dungeontxt != null) dungeontxt.text=language.dungeontxt;
            if (dailywarstxt != null) dailywarstxt.text=language.dailywars;
            if (noadstxt != null) noadstxt.text=language.noadspack;
            if (researchtxt != null) researchtxt.text=language.Research;
            if (totalgoldbonusestxt != null) totalgoldbonusestxt.text=language.totalgoldbonuses;
            if (guild != null) guild.text=language.guild;
            if (dailyfortune != null) dailyfortune.text=language.DailyFortune;
            if (idlerewards != null) idlerewards.text=language.IdleRewardsTitle;
            if (eventname != null) eventname.text=language.pathOfEmeralds;
            if (normalMode != null) normalMode.text=language.Normal;
            if (eliteMode != null) eliteMode.text=language.Elite;
            if (passtitle != null) passtitle.text=language.gamespass;
            if (goldyoktxt != null) goldyoktxt.text=language.goldyoktxt;
            if (gettxt != null) gettxt.text=language.eldeet;
        }
        if (battletxt != null) battletxt.text="<sprite=3>5";
        StartCoroutine(latestart());
        EnergyStart(); // Existing body remains a stub until separately restored.
        if (GameManager.NameSettedOnCBS && _inputname != null) _inputname.interactable=false;
        GoNormalElite();
	}

	public void GetPassData(int passexpT, int passmaxT, string passtimeT)
	{
        // RVA0x21ce93c; no invented progression calculation.
        if (passexp != null) passexp.text="<sprite=12>"+passexpT+"/"+passmaxT;
        if (passslider != null) { passslider.maxValue=passmaxT; passslider.value=passexpT; }
        if (passtime != null) passtime.text=passtimeT;
        if (passlvl != null) passlvl.text=PassGame.Level.ToString();
	}

	public void GoNormalElite()
	{
        // RVA0x21ce784 is visual feedback only; it does not toggle EliteON.
        TextMeshProUGUI selected=GameManager.EliteON ? eliteMode : normalMode;
        TextMeshProUGUI other=GameManager.EliteON ? normalMode : eliteMode;
        if (eliteChooser != null && selected != null) eliteChooser.transform.localPosition = new Vector3(selected.transform.localPosition.x,0,0);
        // Original passes Color(255,255,255,255), not normalized Color.white.
        if (selected != null) selected.color = new Color(255,255,255,255);
        if (other != null) other.color = new Color(175,255,255,255);
        if (eliteAnim != null) eliteAnim.Play("Base Layer.elitenormalchooser",0,0);
	}
	private IEnumerator latestart()
	{
        // MoveNext0x21d0b64: reads local nickname field only, no CBS call.
        yield return new WaitForSeconds(0.5f);
        if (_inputname != null && _leaders != null) _inputname.text=_leaders.playerNickname;
        UpdateStageInfos(); // Separately unresolved native method.
        GameManager.MilestoneGoldBonus=1f+GameManager.Level*0.1f;
	}

	public void UpdateName()
	{
        // RVA0x21ceacc updates local field + ES3; no network call in this method.
        if (GameManager.NameSettedOnCBS || _inputname == null || _leaders == null) return;
        _leaders.playerNickname=_inputname.text;
        ES3.Save<string>("playerNickname",_leaders.playerNickname);
	}

	private void EnergyStart()
	{
        // Native0x21ce40c: first install defaults to now, not a full-energy grant.
        lastRegenTime=ES3.Load<System.DateTime>("LastEnergyRegenTime",defaultValue:System.DateTime.UtcNow);
        double elapsed=(System.DateTime.UtcNow-lastRegenTime).TotalSeconds;
        int intervals=Mathf.FloorToInt((float)(elapsed/regenIntervalSeconds));
        int amount=System.Math.Min(unchecked(intervals*energyPerInterval),Currencys.MaxEnergy());
        if (amount>0)
        {
            if (Currencys.Energy<Currencys.MaxEnergy())
            {
                Currencys.AddEnergy(amount,"Meta","Login");
                if (Currencys.Energy>Currencys.MaxEnergy()) Currencys.EnergyFitle(Currencys.MaxEnergy());
            }
            lastRegenTime=lastRegenTime.AddSeconds((double)(intervals*regenIntervalSeconds));
            ES3.Save<System.DateTime>("LastEnergyRegenTime",lastRegenTime);
        }
        regenTimer=(float)(System.DateTime.UtcNow-lastRegenTime).TotalSeconds;
	}

	private void Update()
	{
        // Native0x21ceb94: one interval per frame, using scaled Time.deltaTime.
        regenTimer+=Time.deltaTime;
        if (regenTimer>=regenIntervalSeconds)
        {
            if (Currencys.Energy<Currencys.MaxEnergy())
            {
                Currencys.AddEnergy(energyPerInterval,"Meta","Every_8_Minutes");
                if (Currencys.Energy>Currencys.MaxEnergy()) Currencys.EnergyFitle(Currencys.MaxEnergy());
            }
            lastRegenTime=System.DateTime.UtcNow;
            ES3.Save<System.DateTime>("LastEnergyRegenTime",lastRegenTime);
            regenTimer-=regenIntervalSeconds;
        }
        // Native dereferences warController; null guard supports recovered scenes.
        if (warController==null || !warController.savastayim)
        {
            if (_energy!=null) _energy.text="<color=#00FFFD>"+Currencys.Energy+"</color>/"+Currencys.MaxEnergy();
            if (energySpend!=null) energySpend.text=GameManager.EliteON ? "<sprite=3>7" : "<sprite=3>5";
        }
        if (_energyTimer!=null)
        {
            bool belowCap=Currencys.Energy<Currencys.MaxEnergy();
            _energyTimer.gameObject.SetActive(belowCap);
            if (belowCap)
            {
                float remaining=Mathf.Max(0,regenIntervalSeconds-regenTimer);
                int minutes=Mathf.FloorToInt(remaining/60f);
                int seconds=Mathf.FloorToInt(remaining%60f);
                _energyTimer.text=string.Format("{0:00}:{1:00}",minutes,seconds);
            }
        }
        if (oldpara!=Currencys.Coin)
        {
            if (_para!=null) _para.text=ShortScaleString.parseDouble(Currencys.Coin,1,1000000.0,true);
            oldpara=Currencys.Coin;
        }
        if (oldcrystal!=Currencys.Crystal)
        {
            if (_crystal!=null) _crystal.text=Currencys.Crystal.ToString();
            if (_crystaliconanim!=null) _crystaliconanim.Play("Base Layer.topiconanim",0,0);
            oldcrystal=Currencys.Crystal;
        }
	}

	public void OpenKacLvlLazim(int kaclazim, bool florabagli)
	{
        // RVA0x21cf370: florabagli is unused in original code.
        Lang.TaskKacLazim=kaclazim;
        if (_taskkacLazimText != null && Lang.Get != null) _taskkacLazimText.text=Lang.Get.taskkactamamlamalisin;
        if (_taskKacLazim != null) _taskKacLazim.SetActive(true);
        if (_falserTask != null) _falserTask.timer=0;
        if (_taskKacLazimAnimator != null) _taskKacLazimAnimator.Play("Base Layer.Kilitbilgiver",0,0);
	}

	public void GoGold()
	{
        // RVA0x21cf470: native tutorial completion gate retained.
        if (goldyokinfo != null) goldyokinfo.SetActive(false);
        if (GameManager.GuideDone)
        {
            if (bottomPages != null) bottomPages.OpenPage(0);
            if (shopui != null) shopui.OpenPageinapp(2);
        }
	}

	public void CloseNotGold()
	{
        if (goldyokinfo != null) goldyokinfo.SetActive(false); // RVA0x21cf514
	}

	public void OpenGoldYok(int durum)
	{
        // RVA0x21cf530: exact switch to Lang virtual properties.
        if (golyokbasictxt != null && Lang.Get != null)
        {
            switch(durum)
            {
                case 0: golyokbasictxt.text=Lang.Get.NotEnoughGold; break;
                case 1: golyokbasictxt.text=Lang.Get.NotEnoughGearScroll; break;
                case 2: golyokbasictxt.text=Lang.Get.NotEnoughTalentScroll; break;
                case 3: golyokbasictxt.text=Lang.Get.NotEnoughWeaponToken; break;
                case 4: golyokbasictxt.text=Lang.Get.NotEnoughCrystals; break;
                case 5: golyokbasictxt.text=Lang.Get.gearfull; break;
                case 6: golyokbasictxt.text=Lang.Get.golyokbasictxt; break;
                default: golyokbasictxt.text=Lang.Get.NotEnoughResources; break;
            }
        }
        if (goldyokbasic != null) goldyokbasic.SetActive(true);
        if (SoundManager.instance != null) SoundManager.instance.CashSound(SoundManager._catch);
	}
}
