using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResearchitemUi : MonoBehaviour
{
	public bool ArastirmaCenterLevel;

	public bool GameSpeed;

	public bool AttackSpeed;

	public bool Health;

	public bool Attack;

	public bool CoinBonusEveryWave;

	public bool CoinBonusEvery50kills;

	public bool GoldBonusEveryWave;

	public bool GoldBonusEvery100kills;

	public bool CoinBonusafterBossKilled;

	public bool GoldBonusafterBossKilled;

	public bool Range;

	public bool LighningOrbAttack;

	public bool FireOrbAttack;

	public bool IceOrbAttack;

	public bool PoisonOrbAttack;

	public bool BlastOrbAttack;

	public bool SteelOrbAttack;

	public Button _upgBtn;

	public ResearchManager _researchManager;

	public TextMeshProUGUI _title;

	public TextMeshProUGUI _subtitle;

	public TextMeshProUGUI _lvl;

	public TextMeshProUGUI _dakika;

	public TextMeshProUGUI _fiyat;

	public TextMeshProUGUI _cancel;

	public GameObject _researchYapiliyor;

	public GameObject _levelreq;

	public TextMeshProUGUI _levelreqtext;

	public GameObject arastiriliyor;

	public string duzhaliforresearch;

	public bool artimlimi;

	private int mynum;

	public int lvl;

	private float deger;

	public float artiskac;

	private int MaxUpgSayisi;

	private float savetime;

	private bool saved;

	[Header("Ayar")]
	public int BaslangicLvlReq;

	public int LvlReqArtis;

	public int[] DakikaArtis;

	public double[] ellefiyat;

	public int LevelRequired()
	{
        // Original ARM64 recovery 0x202ace4.
        return unchecked(BaslangicLvlReq+LvlReqArtis*lvl);
	}

	public double fiyat()
	{
        // Original ARM64 recovery 0x202acf4.
        return lvl<ellefiyat.Length?ellefiyat[lvl]:ellefiyat[ellefiyat.Length-1]+ellefiyat[0]*MeduPow.Pow(1.5d,lvl);
	}

	public int arastirmaDakikaKac()
	{
        // Original ARM64 recovery 0x202ad68.
        return Mathf.Clamp(DakikaArtis[Mathf.Clamp(lvl,0,DakikaArtis.Length-1)]/GameManager.ResearchSpeedUp,1,100000);
	}

	public string FormatTime(float setMinutes)
	{
        // Original ARM64 recovery 0x202ae1c.
        if(setMinutes<60f)return string.Format("<sprite=4>{0:D2}:{1:D2}",Mathf.FloorToInt(setMinutes),Mathf.FloorToInt((setMinutes-Mathf.Floor(setMinutes))*60f))+Lang.Get.kisaltmadakika;
        return string.Format("<sprite=4>{0:D2}:{1:D2}",Mathf.FloorToInt(setMinutes/60f),Mathf.FloorToInt(setMinutes%60f))+Lang.Get.kisaltmasaat;
	}

	public void LoadStart()
	{
        // Original ARM64 recovery 0x202b130.
        mynum=transform.GetSiblingIndex();_cancel.text=Lang.Get.iptal;
        if(ArastirmaCenterLevel){lvl=PlayerData.researchSaveData.ArastirmaCenterLevel_Level;artiskac=PlayerData.researchDatas.ArastirmaCenterLevel_ArtisKac;MaxUpgSayisi=1000;}
        if(GameSpeed){lvl=PlayerData.researchSaveData.GameSpeed_Level;artiskac=PlayerData.researchDatas.GameSpeed_ArtisKac;MaxUpgSayisi=7;}
        if(AttackSpeed){lvl=PlayerData.researchSaveData.AttackSpeed_Level;artiskac=PlayerData.researchDatas.AttackSpeed_ArtisKac;MaxUpgSayisi=50;}
        if(Health){lvl=PlayerData.researchSaveData.Health_Level;artiskac=PlayerData.researchDatas.Health_ArtisKac;MaxUpgSayisi=300;}
        if(Attack){lvl=PlayerData.researchSaveData.Attack_Level;artiskac=PlayerData.researchDatas.Attack_ArtisKac;MaxUpgSayisi=150;}
        if(CoinBonusEveryWave){lvl=PlayerData.researchSaveData.SilverBonusEveryWave_Level;artiskac=PlayerData.researchDatas.SilverBonusEveryWave_ArtisKac;MaxUpgSayisi=100;}
        if(CoinBonusEvery50kills){lvl=PlayerData.researchSaveData.SilverBonusEvery50kills_Level;artiskac=PlayerData.researchDatas.SilverBonusEvery50kills_ArtisKac;MaxUpgSayisi=100;}
        if(GoldBonusEveryWave){lvl=PlayerData.researchSaveData.GoldBonusEveryWave_Level;artiskac=PlayerData.researchDatas.GoldBonusEveryWave_ArtisKac;MaxUpgSayisi=100;}
        if(GoldBonusEvery100kills){lvl=PlayerData.researchSaveData.GoldBonusEvery100kills_Level;artiskac=PlayerData.researchDatas.GoldBonusEvery100kills_ArtisKac;MaxUpgSayisi=100;}
        if(CoinBonusafterBossKilled){lvl=PlayerData.researchSaveData.SilverBonusafterBossKilled_Level;artiskac=PlayerData.researchDatas.SilverBonusafterBossKilled_ArtisKac;MaxUpgSayisi=100;}
        if(GoldBonusafterBossKilled){lvl=PlayerData.researchSaveData.GoldBonusafterBossKilled_Level;artiskac=PlayerData.researchDatas.GoldBonusafterBossKilled_ArtisKac;MaxUpgSayisi=100;}
        if(Range){lvl=PlayerData.researchSaveData.Range_Level;artiskac=PlayerData.researchDatas.Range_ArtisKac;MaxUpgSayisi=100;}
        if(LighningOrbAttack){lvl=PlayerData.researchSaveData.LighningOrbAttack_Level;artiskac=PlayerData.researchDatas.LighningOrbAttack_ArtisKac;MaxUpgSayisi=200;}
        if(FireOrbAttack){lvl=PlayerData.researchSaveData.FireOrbAttack_Level;artiskac=PlayerData.researchDatas.FireOrbAttack_ArtisKac;MaxUpgSayisi=200;}
        if(IceOrbAttack){lvl=PlayerData.researchSaveData.IceOrbAttack_Level;artiskac=PlayerData.researchDatas.IceOrbAttack_ArtisKac;MaxUpgSayisi=200;}
        if(PoisonOrbAttack){lvl=PlayerData.researchSaveData.PoisonOrbAttack_Level;artiskac=PlayerData.researchDatas.PoisonOrbAttack_ArtisKac;MaxUpgSayisi=200;}
        if(BlastOrbAttack){lvl=PlayerData.researchSaveData.BlastOrbAttack_Level;artiskac=PlayerData.researchDatas.BlastOrbAttack_ArtisKac;MaxUpgSayisi=200;}
        if(SteelOrbAttack){lvl=PlayerData.researchSaveData.SteelOrbAttack_Level;artiskac=PlayerData.researchDatas.SteelOrbAttack_ArtisKac;MaxUpgSayisi=200;}
        Titles();UpdatedData();if(_researchManager.isResearchActive[_researchManager.acilanTable])_researchManager.triggerforpage=true;
	}

	private void Start()
	{
	}

	private void Titles()
	{
        // Original ARM64 recovery 0x202b74c.
        if(ArastirmaCenterLevel)_title.text=Lang.Get.ResearchName7;
        if(GameSpeed)_title.text=Lang.Get.ResearchName8;
        if(LighningOrbAttack)_title.text=Lang.Get.ResearchName1;
        if(FireOrbAttack)_title.text=Lang.Get.ResearchName2;
        if(IceOrbAttack)_title.text=Lang.Get.ResearchName3;
        if(PoisonOrbAttack)_title.text=Lang.Get.ResearchName4;
        if(BlastOrbAttack)_title.text=Lang.Get.ResearchName5;
        if(SteelOrbAttack)_title.text=Lang.Get.ResearchName6;
	}

	private void UpdatedData()
	{
        // Original ARM64 recovery 0x202ba38.
        if(ArastirmaCenterLevel)duzhaliforresearch=((int)(artiskac*(float)lvl)).ToString()+" � <color=#8BFFD2>"+((int)(artiskac*(float)unchecked(lvl+1))).ToString()+"</color>";
        else if(artimlimi)duzhaliforresearch="+"+(artiskac*(float)lvl).ToString("F2")+" � <color=#8BFFD2>+"+(artiskac*(float)unchecked(lvl+1)).ToString("F2")+"</color>";
        else duzhaliforresearch="x"+(artiskac*(float)lvl+1f).ToString("F2")+" � <color=#8BFFD2>x"+(artiskac*(float)unchecked(lvl+1)+1f).ToString("F2")+"</color>";
        _subtitle.text=duzhaliforresearch;_lvl.text=Lang.Get.lv+lvl.ToString();
        if(lvl<MaxUpgSayisi)_dakika.text=FormatTime((float)arastirmaDakikaKac());else{_dakika.text="MAX";_upgBtn.interactable=false;}
        _fiyat.text="<sprite=0>"+ShortScaleString.parseDouble(fiyat(),1,1000000d,false);
	}

	public void ReSearchDone(int num)
	{
        // Original ARM64 recovery 0x202c2bc.
        if(lvl>=MaxUpgSayisi||mynum!=num)return;lvl=unchecked(lvl+1);
        if(ArastirmaCenterLevel)PlayerData.researchSaveData.ArastirmaCenterLevel_Level=lvl;
        if(GameSpeed)PlayerData.researchSaveData.GameSpeed_Level=lvl;
        if(AttackSpeed)PlayerData.researchSaveData.AttackSpeed_Level=lvl;
        if(Health)PlayerData.researchSaveData.Health_Level=lvl;
        if(Attack)PlayerData.researchSaveData.Attack_Level=lvl;
        if(CoinBonusEveryWave)PlayerData.researchSaveData.SilverBonusEveryWave_Level=lvl;
        if(CoinBonusEvery50kills)PlayerData.researchSaveData.SilverBonusEvery50kills_Level=lvl;
        if(GoldBonusEveryWave)PlayerData.researchSaveData.GoldBonusEveryWave_Level=lvl;
        if(GoldBonusEvery100kills)PlayerData.researchSaveData.GoldBonusEvery100kills_Level=lvl;
        if(CoinBonusafterBossKilled)PlayerData.researchSaveData.SilverBonusafterBossKilled_Level=lvl;
        if(GoldBonusafterBossKilled)PlayerData.researchSaveData.GoldBonusafterBossKilled_Level=lvl;
        if(Range)PlayerData.researchSaveData.Range_Level=lvl;
        if(LighningOrbAttack)PlayerData.researchSaveData.LighningOrbAttack_Level=lvl;
        if(FireOrbAttack)PlayerData.researchSaveData.FireOrbAttack_Level=lvl;
        if(IceOrbAttack)PlayerData.researchSaveData.IceOrbAttack_Level=lvl;
        if(PoisonOrbAttack)PlayerData.researchSaveData.PoisonOrbAttack_Level=lvl;
        if(BlastOrbAttack)PlayerData.researchSaveData.BlastOrbAttack_Level=lvl;
        if(SteelOrbAttack)PlayerData.researchSaveData.SteelOrbAttack_Level=lvl;
        UpdatedData();Saveit();if(SoundManager.instance!=null)SoundManager.instance.RandomizeSfx(SoundManager._coin2);
	}

	public void StartResearch()
	{
        // Original ARM64 recovery 0x202c808.
        if(!_researchManager.isResearchActive[_researchManager.acilanTable]&&!_researchManager.Checkresearchvarmi(mynum)&&Currencys.Coin>fiyat())
        {Currencys.SpendCoin(fiyat(),"Meta","StartResearch");_researchManager.StartResearch(_researchManager.acilanTable,mynum,(long)arastirmaDakikaKac());_researchManager.CloseResearchs();}
        if(SoundManager.instance!=null)SoundManager.instance.RandomizeSfx(SoundManager._bell2);
	}

	public void CancelResearch()
	{
        // Original ARM64 recovery 0x202cc94.
        if(_researchManager.isResearchActive[_researchManager.acilanTable]&&_researchManager.currentResearchIDs[_researchManager.acilanTable]==mynum)
        {Currencys.AddCoin(fiyat(),"Meta","CancelResearch");_researchManager.StopResearch(_researchManager.acilanTable);}
        if(SoundManager.instance!=null)SoundManager.instance.RandomizeSfx(SoundManager._balikgone);
	}

	private void Update()
	{
        // Original ARM64 recovery 0x202cf1c.
        bool selectedActive=_researchManager.isResearchActive[_researchManager.acilanTable]&&_researchManager.currentResearchIDs[_researchManager.acilanTable]==mynum;
        _researchYapiliyor.SetActive(selectedActive);
        _upgBtn.interactable=!selectedActive&&lvl<MaxUpgSayisi&&PlayerData.researchSaveData.ArastirmaCenterLevel_Level>=LevelRequired()&&!_researchManager.Checkresearchvarmi(mynum)&&!_researchManager.isResearchActive[_researchManager.acilanTable]&&Currencys.Coin>fiyat();
        arastiriliyor.SetActive(_researchManager.Checkresearchvarmi(mynum));
        if(mynum==0)return;
        bool required=PlayerData.researchSaveData.ArastirmaCenterLevel_Level<LevelRequired();_levelreq.SetActive(required);
        if(required)_levelreqtext.text=Lang.Get.ResearchName7+" "+Lang.Get.lv+LevelRequired().ToString()+" "+Lang.Get.required;
	}

	private void Saveit()
	{
        // Original ARM64 recovery 0x202c7a4.
        PlayerData.researchDatas.SaveResearch();
	}
}
