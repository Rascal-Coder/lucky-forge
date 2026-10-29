using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PassGame : MonoBehaviour
{
	public enum Rewards
	{
		kristal = 0,
		mystictoken = 1,
		dungeonkey1 = 2,
		dungeonkey2 = 3,
		dungeonkey3 = 4,
		talent = 5,
		herostone = 6,
		weapontoken = 7
	}

	[Serializable]
	public class Reward
	{
		public Rewards rewardType;

		public int amount;

		[HideInInspector]
		public bool isCollected;
	}

	public static int GamePassSavedCycle;

	private bool started;

	public TextMeshProUGUI _battlepass;

	public TextMeshProUGUI _headtitle;

	public TextMeshProUGUI _lvlhalloween;

	public TextMeshProUGUI _subtitles;

	public Slider _sliderdigged;

	public TextMeshProUGUI _kalandakika;

	public TextMeshProUGUI _sliderustukacakac;

	public TextMeshProUGUI endsin;

	public TextMeshProUGUI _halloweenpass;

	public TextMeshProUGUI _hallowenpasssub;

	public TextMeshProUGUI _halloweenfiyat;

	public TextMeshProUGUI _free;

	public TextMeshProUGUI _premium;

	public TextMeshProUGUI _getpremium;

	public TextMeshProUGUI _topbtnrewards;

	public TextMeshProUGUI _topbtnmissions;

	public List<Reward> freeRewards;

	public List<Reward> premiumRewards;

	public List<Reward> premiumRewards2;

	public TextMeshProUGUI _info;

	public GameObject _infoobj;

	public GameObject _buypage;

	public GameObject _infogenel;

	public List<PassTekliReward> freeRewardsUi;

	public List<PassTekliReward> premiumRewardsUi;

	public GameObject _bottomgetpremium;

	public GameObject _freeuitek;

	public GameObject _premiumuitek;

	public GameObject _numortatek;

	public Transform rewardsContainer_free;

	public Transform rewardsContainer_premium;

	public Transform numortaContainer;

	public Sprite[] _icons;

	public TextMeshProUGUI _buytorchtitle;

	public TextMeshProUGUI _buytorchkac;

	public TextMeshProUGUI _no;

	public TextMeshProUGUI _buytorchfiyat;

	public int torchkackerealindi;

	public GameObject _torchpage;

	public GameObject _yeterlikristalyokpage;

	public TextMeshProUGUI _yeterlikristalyoktext;

	public KartAcRenkli _kartAcTekli;

	public GameObject[] pages;

	public Button[] _topbtns;

	public GameObject _topRewardsinfo;

	public CanvasJobs canvasJobs;

	public TextMeshProUGUI[] _olympiainfos;

	public TextMeshProUGUI _kacxvalue;

	public infoIcons _infoIcons;

	public RectTransform rect;

	public static int Level;

	public static int Exp;

	public int toplanmasayisi;

	private int[] MaxExps = new int[]{10,10,10,10,15,15,15,15,15,15,15,15,20,20,20,20,20,20,20,20,20,25,25,25,25,25,25,25,25,25,25,25,30,30,30,30,35,35,35,35,40,50};

	private int maxLevel = 30;

	private Rewards rewardType;

	private DateTime eventStartTimeUTC = new DateTime(2024,11,1,0,0,0,DateTimeKind.Utc);

	private TimeSpan eventCycleDuration = TimeSpan.FromDays(14d);

	public int Torchfiyat()
	{
		return 0;
	}

	public void AddExp(int KacExp)
	{
        // Original ARM64 recovery 0x1f7ccf4.
        if(Level>=maxLevel)return;
        Exp=unchecked(Exp+KacExp);
        while(Exp>=MaxExps[Level-1]){Exp-=MaxExps[Level-1];Level++;if(Level>=maxLevel)break;}
        if(Level>=maxLevel){Level=maxLevel;Exp=0;}
        CheckAll();ES3.Save<int>("PassLevel",Level);ES3.Save<int>("PassExp",Exp);
	}

	public void OpenPage(int kim)
	{
	}

	public void LoadPass()
	{
	}

	public void OpeninfoGenel(bool acik)
	{
	}

	public int GetCurrentCycleCount()
	{
		return 0;
	}

	public DateTime GetCurrentCycleStart()
	{
		return default;
	}

	public DateTime GetNextResetTime()
	{
		return default;
	}

	public void ResetEventRewards()
	{
	}

	private void UpdateCountdownUI()
	{
	}

	public void infover(string msj)
	{
	}

	private void OnEnable()
	{
	}

	private void Update()
	{
	}

	public void OpenBuyPage()
	{
	}

	public void BuyPass()
	{
	}

	public void OpenBuyTorch()
	{
	}

	public void BuyTorch()
	{
	}

	private void Saat()
	{
	}

	private void UpdateRewardUI()
	{
	}

	private void UpdateSingleRewardUI(Reward reward, int rewardLevel, Transform parent2, GameObject uis, bool premium, int num)
	{
	}

	private void TryGppPremiumUnlock()
	{
	}

	public void RefreshPremiumState()
	{
	}

	private void CheckAll()
	{
	}

	private void CheckStatus(Reward reward, int rewardLevel, Transform parent2, GameObject uis, PassTekliReward rewardkim, bool premium)
	{
	}

	private void CollectReward(Reward reward, int rewardLevel, bool premium)
	{
	}

	private void SaveRewards()
	{
	}

	private void LoadRewards()
	{
	}

	private void RewardTypes(Reward reward)
	{
	}

	public void Close()
	{
	}

	public void OpenEvent()
	{
	}

	public void GorevlerdenCikildi()
	{
	}

	private void OnApplicationFocus(bool hasFocus)
	{
	}
}
