using System.Linq;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GunlukGorevler : MonoBehaviour
{
	public GameObject taskPrefab;

	public Transform taskListParent;

	public TextMeshProUGUI resetTimeText;

	public TextMeshProUGUI missiontitle;

	private DateTime nextResetTime;

	public static List<GunlukGorev> tasks;

	private static List<GunlukGorevTekUi> taskUIs = new List<GunlukGorevTekUi>();

	private static bool loaded;

	public GameObject _infoAnasayfa;

	public RewardAdsManager rewardAdsManager;

	public static GameObject _infoCloneAnasayfa;

	public int TotalYapilanDailyTask;

	public bool[] TotalHaftalikOdulToplandi = new bool[4];

	public Slider topslider;

	public TextMeshProUGUI _TotalHaftalikSayi;

	public Button[] topOdulBtns;

	public PassGame passGame;

	public GameManager gameManager;

	public CurrencyCollectedUi collectedUi;

	public Basarimlar basarimlar;

	public static GameObject gorevtamamlandiObj;

	public GameObject gorevtamamlandiObjPublic;

	[Header("Btns")]
	public TextMeshProUGUI[] altbtnstexts;

	public GameObject[] altinfos;

	public Transform altchooser;

	public GameObject[] insidePages;

	public RectTransform[] rects;

	public static bool basariminfo;

	public static int KacinciGun;

	public void OpenInsidePage(int who)
	{
        // Original ARM64 recovery 0x1f78bdc.
        for (int i=0;i<insidePages.Length;i++) {
            insidePages[i].SetActive(i==who);
            if(i==who){rects[who].anchoredPosition=new Vector2(rects[who].anchoredPosition.x,0f);altchooser.position=altbtnstexts[who].transform.position;}
        }
        if(who==0 || who==1) altinfos[who].SetActive(false);
        if(SoundManager.instance!=null)SoundManager.instance.CashSound(SoundManager._click);
	}

	private void Start()
	{
        // Original ARM64 recovery 0x1f78dfc.
        altbtnstexts[0].text=Lang.Get.missionsTab;
        altbtnstexts[1].text=Lang.Get.challengesTab;
	}

	private void OnEnable()
	{
        // Original ARM64 recovery 0x1f78eec.
        UpdateAllTaskUIs();
        if(loaded){SaveTasks();siralamaYap();}
        if(_infoCloneAnasayfa!=null && _infoCloneAnasayfa.activeInHierarchy)altinfos[0].SetActive(true);
        if(basariminfo)altinfos[1].SetActive(true);
        OpenInsidePage(0);
	}

	public bool CheckTasksIfo()
	{
        // Original ARM64 recovery 0x1f795e4.
        bool result=false;
        foreach(var task in tasks)if(task.isCompleted && !task.isCollected)result=true;
        return result;
	}

	public void Closeit()
	{
        // Original ARM64 recovery 0x1f79758.
        passGame.GorevlerdenCikildi();
        if(SoundManager.instance!=null)SoundManager.instance.RandomizeSfx(SoundManager._close);
        GameManager.lokasyonClicked=0;GameManager.PageAcildi=false;
        gameObject.SetActive(false);
	}

	public void OpenPage()
	{
        // Original ARM64 recovery 0x1f7991c.
        gameObject.SetActive(true);
        GameManager.PageAcildi=true;
        // Offline: original FGAnalytics DailyQuests/FeatureIcon event omitted.
	}

	public void OyunBaslayinca()
	{
        // Original ARM64 recovery 0x1f79a94.
        if(loaded){taskUIs.Clear();tasks.Clear();}
        TotalYapilanDailyTask=ES3.Load<int>("TotalYapilanDailyTask",defaultValue:0);
        if(ES3.KeyExists("TotalHaftalikOdulToplandi"))TotalHaftalikOdulToplandi=ES3.Load<bool[]>("TotalHaftalikOdulToplandi");
        gorevtamamlandiObj=gorevtamamlandiObjPublic;
        _infoCloneAnasayfa=_infoAnasayfa;
        LoadTasks();LoadNextResetTime();InitializeTaskUI();
        missiontitle.text=Lang.Get.gunlukGorevTitle;loaded=true;
	}

	public void OyunBaslayincaKontrol2()
	{
        // Original ARM64 recovery 0x1f7a178.
        if(DateTime.Now>=nextResetTime){ResetTasks();SetNextResetTime();}
	}

	private void Update()
	{
        // Original ARM64 recovery 0x1f7a52c.
        UpdateResetTimeText();_TotalHaftalikSayi.text=TotalYapilanDailyTask.ToString();topslider.value=TotalYapilanDailyTask;
        topOdulBtns[0].interactable=TotalYapilanDailyTask>=25 && !TotalHaftalikOdulToplandi[0];
        topOdulBtns[1].interactable=TotalYapilanDailyTask>=60 && !TotalHaftalikOdulToplandi[1];
        topOdulBtns[2].interactable=TotalYapilanDailyTask>=100 && !TotalHaftalikOdulToplandi[2];
        topOdulBtns[3].interactable=TotalYapilanDailyTask>=140 && !TotalHaftalikOdulToplandi[3];
	}

	public void TopOdulTopla(int sira)
	{
        // Original ARM64 recovery 0x1f7aacc.
        // Original threshold gates are the four buttons in Update; preserve handler rules.
        switch(sira){
        case 0:if(!TotalHaftalikOdulToplandi[0]){Currencys.AddCrystal(200,"Meta","DailyQuestTopReward");TotalHaftalikOdulToplandi[0]=true;BuyukParticle.Playit(BuyukParticle.Crystal_Particle);}break;
        case 1:if(!TotalHaftalikOdulToplandi[1]){Currencys.AddCrystal(300,"Meta","DailyQuestTopReward");TotalHaftalikOdulToplandi[1]=true;BuyukParticle.Playit(BuyukParticle.Crystal_Particle);}break;
        case 2:if(!TotalHaftalikOdulToplandi[2]){Currencys.AddCrystal(400,"Meta","DailyQuestTopReward");TotalHaftalikOdulToplandi[2]=true;BuyukParticle.Playit(BuyukParticle.Crystal_Particle);}break;
        case 3:if(!TotalHaftalikOdulToplandi[3]){Currencys.AddMistikToken(50,"Meta","DailyQuestTopReward");BuyukParticle.Playit(BuyukParticle.MistikToken);for(int i=0;i<4;i++)TotalHaftalikOdulToplandi[i]=false;TotalYapilanDailyTask=0;ES3.Save<int>("TotalYapilanDailyTask",0);}break;
        }
        ES3.Save<bool[]>("TotalHaftalikOdulToplandi",TotalHaftalikOdulToplandi);
	}

	private void InitializeTaskUI()
	{
        // Original ARM64 recovery 0x1f79e38.
        foreach(var task in tasks){var row=Instantiate(taskPrefab,taskListParent).GetComponent<GunlukGorevTekUi>();row.gameObject.SetActive(true);row.transform.localScale=Vector3.one;row.Initialize(task,this);taskUIs.Add(row);}
        UpdateTaskProgressK(0,1);siralamaYap();
	}

	private void siralamaYap()
	{
        // Original ARM64 recovery 0x1f79240.
        // Original selector helpers: 0x1f7d000, 0x1f7d028, reference-match 0x1f7d03c.
        var sorted=tasks.OrderBy(t=>t.isCompleted?(t.isCollected?2:0):1).ThenBy(t=>t.GorevType).ToList();
        for(int i=0;i<sorted.Count;i++){var current=sorted[i];var ui=taskUIs.Find(row=>row.task==current);if(ui!=null)ui.transform.SetSiblingIndex(i);}
	}

	private void SetNextResetTime()
	{
        // Original ARM64 recovery 0x1f7a478.
        nextResetTime=DateTime.Now.AddHours(24d);
        ES3.Save<DateTime>("nextResetTimeGunlukGorev",nextResetTime);
	}

	private void LoadNextResetTime()
	{
        // Original ARM64 recovery 0x1f79db4.
        if(ES3.KeyExists("nextResetTimeGunlukGorev"))nextResetTime=ES3.Load<DateTime>("nextResetTimeGunlukGorev");else SetNextResetTime();
	}

	private void UpdateResetTimeText()
	{
        // Original ARM64 recovery 0x1f7a6f0.
        var remaining=nextResetTime-DateTime.Now;
        if(remaining<=TimeSpan.Zero){ResetTasks();SetNextResetTime();return;}
        resetTimeText.text=Lang.Get.refreshin+string.Format(": <sprite=4>{0:D2}{1} {2:D2}{3} {4:D2}{5}",remaining.Hours,Lang.Get.kisaltmasaat,remaining.Minutes,Lang.Get.kisaltmadakika,remaining.Seconds,Lang.Get.kisaltmasaniye);
	}

	private void ResetTasks()
	{
        // Original ARM64 recovery 0x1f7a1f4.
        if(tasks==null){Debug.LogError("ResetTasks ERROR: tasks list is NULL!");return;}
        foreach(var task in tasks){if(task==null){Debug.LogError("ResetTasks WARNING: A task in tasks list is NULL!");continue;}task.currentCount=0;task.isCompleted=false;task.isCollected=false;}
        SaveTasks();KacinciGun=unchecked(KacinciGun+1);ES3.Save<int>("GorevKacinciGun",KacinciGun);
        UpdateAllTaskUIs();UpdateTaskProgressK(0,1);
	}

	private static void UpdateAllTaskUIs()
	{
        // Original ARM64 recovery 0x1f79064.
        foreach(var row in taskUIs)row.UpdateUI();
	}

	private void LoadTasks()
	{
        // Original ARM64 recovery 0x1f79ce4.
        if(ES3.KeyExists("GunlukGorevlerB")){tasks=ES3.Load<List<GunlukGorev>>("GunlukGorevlerB");if(tasks!=null)return;}
        InitializeTasks();
	}

	private void InitializeTasks()
	{
        // Original ARM64 recovery 0x1f7ba68.
        tasks=new List<GunlukGorev>{
        new GunlukGorev(0,1,4,unchecked(400+400*GameManager.Level),false),
        new GunlukGorev(1,1000,1,50,false),
        new GunlukGorev(2,9,0,50,false),
        new GunlukGorev(3,15,2,300,false),
        new GunlukGorev(4,5,4,unchecked(500+500*GameManager.Level),false),
        new GunlukGorev(5,2,0,50,false),
        new GunlukGorev(6,2,3,5,false),
        new GunlukGorev(7,3,4,unchecked(500+500*GameManager.Level),false),
        new GunlukGorev(8,40,0,30,false),
        new GunlukGorev(9,10,1,50,false),
        new GunlukGorev(10,1,2,200,false),
        new GunlukGorev(11,5,3,5,false),
        new GunlukGorev(12,5,0,30,false),
        new GunlukGorev(13,5,3,30,false),
        new GunlukGorev(14,5,0,30,false),
        new GunlukGorev(15,1,3,50,false),
        new GunlukGorev(16,1000,4,unchecked(500+500*GameManager.Level),false),
        new GunlukGorev(17,1,1,100,false),
        new GunlukGorev(18,100,1,100,false),
        new GunlukGorev(19,3,0,30,false)
        };
        SaveTasks();
	}

	public static void SaveTasks()
	{
        // Original ARM64 recovery 0x1f791b8.
        ES3.Save<List<GunlukGorev>>("GunlukGorevlerB",tasks);
	}

	public void CollectReward(GunlukGorev task)
	{
        // Original ARM64 recovery 0x1f7c710.
        if(!task.isCompleted || task.isCollected)return;
        double coin=0;int weapon=0,mistik=0,crystal=0,talent=0;
        switch(task.OdulType){
        case 0:crystal=task.expReward;Currencys.AddCrystal(crystal,"Meta","DailyQuestReward");BuyukParticle.Playit(BuyukParticle.Crystal_Particle);break;
        case 1:weapon=task.expReward;Currencys.AddWeaponToken(weapon,"Meta","DailyQuestReward");BuyukParticle.Playit(BuyukParticle.WeaponToken);break;
        case 2:talent=task.expReward;Currencys.AddTalentScroll(talent,"Meta","DailyQuestReward");BuyukParticle.Playit(BuyukParticle.Talent);break;
        case 3:mistik=task.expReward;Currencys.AddMistikToken(mistik,"Meta","DailyQuestReward");BuyukParticle.Playit(BuyukParticle.MistikToken);break;
        case 4:coin=task.expReward;Currencys.AddCoin(coin,"Meta","DailyQuestReward");BuyukParticle.Playit(BuyukParticle.Para_Particle);break;
        }
        TotalYapilanDailyTask=unchecked(TotalYapilanDailyTask+1);ES3.Save<int>("TotalYapilanDailyTask",TotalYapilanDailyTask);
        if(SoundManager.instance!=null)SoundManager.instance.RandomizeSfx(SoundManager._collecting);
        Basarimlar.UpdateBasarimlarT(5,1);task.isCollected=true;SaveTasks();UpdateAllTaskUIs();
        if(_infoCloneAnasayfa!=null)_infoCloneAnasayfa.SetActive(false);
        passGame.AddExp(5);collectedUi.GiveRewardUI(coin,weapon,mistik,crystal,0,talent,5,0,false);BuyukParticle.Playit(BuyukParticle.Gamepasscoin);
        // Offline: original FGAnalytics DailyQuests claim event omitted.
	}

	public static void UpdateTaskProgressK(int type, int increment)
	{
        // Original ARM64 recovery 0x1f7aed4.
        if(tasks==null || tasks.Count==0)return;
        var task=tasks.Find(t=>t.GorevType==type);
        if(task==null || task.isCompleted)return;
        task.currentCount=unchecked(task.currentCount+increment);
        if(task.currentCount>=task.maxValue){task.isCompleted=true;if(_infoCloneAnasayfa!=null && GameManager.Level>=3)_infoCloneAnasayfa.SetActive(true);if(gorevtamamlandiObj!=null && GameManager.Level>=3)gorevtamamlandiObj.SetActive(true);}
	}
}
