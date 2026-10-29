using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GunlukHediye : MonoBehaviour
{
	public TextMeshProUGUI _gunluktitle;

	public TextMeshProUGUI _onlinetitle;

	public TextMeshProUGUI _gunluksubtitle;

	public KartAcRenkli _kartacrenkli;

	public int numberOfDays;

	public int currentDay;

	public DateTime lastRewardDate;

	public Button[] _Buttons;

	private bool started;

	public GameObject myinfo;

	public TextMeshProUGUI remainingTimeText;

	public GameObject DailyRewards;

	public GameObject OnlineRewards;

	public kart[] _odulkartlari;

	public GameObject[] insidePages;

	public GameObject[] bottomBtns;

	public Animator gezenAnim;

	public Transform bottombtnlight;

	public TimeSpan rewardInterval;

	public PageReferences _pageRef;

	public void OpenInsidePage(int who)
	{
        // Original ARM64 0x20d2990.
        for(int i=0;i<insidePages.Length;i++){
         insidePages[i].SetActive(i==who);
         if(i==who)bottombtnlight.position=bottomBtns[who].transform.position;
        }
        if(gezenAnim!=null)gezenAnim.Play("Base Layer.karaktergezenanim",0,0f);
        // Original tab analytics omitted. Original scene persistent callback remains.
	}

	private void Start()
	{
	}

	private void OnEnable()
	{
	}

	public void GiveReward()
	{
	}

	public void Get1()
	{
	}

	public void Get2()
	{
	}

	public void Get3()
	{
	}

	public void Get4()
	{
	}

	public void Get5()
	{
	}

	public void Get6()
	{
	}

	public void Get7()
	{
	}

	public void Get8()
	{
	}

	public void Get9()
	{
	}

	public void Get10()
	{
	}

	public void Get11()
	{
	}

	public void Get12()
	{
	}

	public void Get13()
	{
	}

	public void Get14()
	{
	}

	public void Get15()
	{
	}

	public void Get16()
	{
	}

	public void Get17()
	{
	}

	public void Get18()
	{
	}

	public void Get19()
	{
	}

	public void Get20()
	{
	}

	public void Get21()
	{
	}

	public void Get22()
	{
	}

	public void Get23()
	{
	}

	public void Get24()
	{
	}

	public void Get25()
	{
	}

	public void Get26()
	{
	}

	public void Get27()
	{
	}

	public void Get28()
	{
	}

	public void Get29()
	{
	}

	public void Get30()
	{
	}

	private void ClaimEvent(int day)
	{
	}

	public void Closeit()
	{
	}

	public void OpenDaily()
	{
	}

	private void ButtonSettings()
	{
	}
}
