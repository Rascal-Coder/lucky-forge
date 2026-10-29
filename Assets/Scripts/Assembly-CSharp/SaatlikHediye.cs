using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SaatlikHediye : MonoBehaviour
{
	public TextMeshProUGUI[] btnUstuSaat;

	public Button[] rewardButtons;

	public TextMeshProUGUI resetTimerText;

	private TimeSpan[] rewardTimers;

	private TimeSpan resetTime = new TimeSpan(4,0,0);

	public static DateTime lastLoginTime;

	public static float totalSecondsSpentInGame;

	public bool[] collectedOrNot = new bool[7];

	private bool[] startforLog = new bool[7];

	private string[] rewardNames;

	private TimeSpan[] rewardIntervals = new TimeSpan[]{new TimeSpan(0,4,0),new TimeSpan(0,8,0),new TimeSpan(0,12,0),new TimeSpan(0,20,0),new TimeSpan(0,30,0),new TimeSpan(0,50,0),new TimeSpan(1,30,0)};

	public TextMeshProUGUI[] rewardNedir;

	public TextMeshProUGUI[] titles;

	public GameObject infoBottom;

	private void Awake()
	{
	}

	public void Awaker()
	{
        // Original ARM64 0x2033df8.
        rewardTimers=new TimeSpan[rewardIntervals.Length];
        collectedOrNot=ES3.Load<bool[]>("SaatlikHediyeCollectedOrNot",defaultValue:startforLog);
        for(int i=0;i<rewardIntervals.Length;i++){
         TimeSpan remaining=rewardIntervals[i]-TimeSpan.FromSeconds(totalSecondsSpentInGame);
         if(rewardIntervals[i].TotalSeconds>totalSecondsSpentInGame)StartRewardTimer(i,remaining);
        }
	}

	private void OnEnable()
	{
        // Original ARM64 0x2033fe0.
        for(int i=0;i<7;i++)rewardNedir[i].text="<sprite=3>"+(i==6?20:10).ToString();
	}

	private void StartRewardTimer(int index, TimeSpan timeToReward)
	{
        // Original ARM64 0x2033fb0.
        rewardTimers[index]=timeToReward;
	}

	public void ClaimReward(int index)
	{
        // Original ARM64 0x20342b4.
        // Original availability/duplicate protection is Button.interactable in Update.
        // This source callback itself has no time or collected guard.
        rewardButtons[index].interactable=false;btnUstuSaat[index].text=Lang.Get.bitti;
        collectedOrNot[index]=true;ES3.Save<bool[]>("SaatlikHediyeCollectedOrNot",collectedOrNot);
        if(index>=0&&index<7){
         Currencys.AddEnergy(index==6?20:10,"Meta","OnlineReward_"+index+"_Collected");
         BuyukParticle.Playit(BuyukParticle.Energy);
        }
        infoBottom.SetActive(false);
        if(SoundManager.instance!=null)SoundManager.instance.RandomizeSfx(SoundManager._collecting);
        // Original FGAnalytics.NewDesignEvent payload omitted; no resource path omitted.
	}

	private void Update()
	{
        // Original ARM64 0x2034a54.
        for(int i=0;i<rewardIntervals.Length;i++){
         if(rewardTimers[i].TotalSeconds>0){
          rewardTimers[i]=rewardIntervals[i]-TimeSpan.FromSeconds(totalSecondsSpentInGame);
          titles[i].text="<sprite=4>"+string.Format("{0}"+Lang.Get.kisaltmadakika+" {1}"+Lang.Get.kisaltmasaniye,(int)rewardTimers[i].TotalMinutes,rewardTimers[i].Seconds);
          rewardButtons[i].interactable=false;btnUstuSaat[i].text=Lang.Get.waiting;
         }else{
          rewardButtons[i].interactable=!collectedOrNot[i];
          btnUstuSaat[i].text=collectedOrNot[i]?Lang.Get.bitti:Lang.Get.al;
          titles[i].text="<sprite=4>00:00";
         }
        }
        TimeSpan remainingReset=resetTime-(DateTime.UtcNow-lastLoginTime);
        if(remainingReset.TotalSeconds>0){
         string format=Lang.Get.resetin+": {0} "+Lang.Get.saatsaat+" {1} "+Lang.Get.dakikaminute+" {2}"+Lang.Get.kisaltmasaniye;
         resetTimerText.text=string.Format(format,(int)remainingReset.TotalHours,(int)remainingReset.TotalMinutes%60,(int)remainingReset.TotalSeconds%60);
        }else ResetRewards();
	}

	private void ResetRewards()
	{
        // Original ARM64 0x2035288.
        for(int i=0;i<rewardIntervals.Length;i++){rewardButtons[i].interactable=false;btnUstuSaat[i].text=Lang.Get.loading;}
        lastLoginTime=DateTime.UtcNow;ES3.Save<string>("saatlikOdulReset",lastLoginTime.ToString());
        ES3.Save<float>("saatlikOdulSaniyeToplam",0f);totalSecondsSpentInGame=0f;
        for(int i=0;i<rewardIntervals.Length;i++)StartRewardTimer(i,rewardIntervals[i]);
        collectedOrNot=new bool[7];ES3.Save<bool[]>("SaatlikHediyeCollectedOrNot",collectedOrNot);
	}

	public bool IsAnyRewardClaimable()
	{
        // Original ARM64 0x203552c.
        bool[] collected=ES3.Load<bool[]>("SaatlikHediyeCollectedOrNot",defaultValue:new bool[7]);
        float seconds=ES3.Load<float>("saatlikOdulSaniyeToplam",defaultValue:0f);
        TimeSpan[] intervals={new TimeSpan(0,4,0),new TimeSpan(0,8,0),new TimeSpan(0,12,0),new TimeSpan(0,20,0),new TimeSpan(0,30,0),new TimeSpan(0,50,0),new TimeSpan(1,30,0)};
        for(int i=0;i<intervals.Length;i++)if(!collected[i]&&intervals[i].TotalSeconds<=seconds)return true;
        return false;
	}
}
