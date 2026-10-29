using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResearchManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CStart_003Ed__30 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ResearchManager _003C_003E4__this;

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
		public _003CStart_003Ed__30(int _003C_003E1__state)
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

	public Slider[] researchSliders;

	public TextMeshProUGUI[] timeRemainingTexts;

	public TextMeshProUGUI[] researchNameTexts;

	public GameObject[] researchTables;

	public long[] researchDurations;

	public long[] researchEndTimes;

	public bool[] isResearchActive;

	public int[] currentResearchIDs;

	public bool[] labsatinalinmis;

	public int[] labfiyatlar;

	public TextMeshProUGUI[] _fiyat;

	public Transform ReSearchitems;

	public GameObject[] _ON;

	public GameObject[] _OFF;

	public GameObject[] _Purchase;

	public TextMeshProUGUI[] _arastirmayok;

	public TextMeshProUGUI[] _finishnow;

	public ResearchitemUi[] _arastirilan;

	public TextMeshProUGUI[] _kactan;

	public TextMeshProUGUI[] _labpurchase;

	public TextMeshProUGUI[] _labtitles;

	public TaskManager _taskManager;

	public GameObject ResearchsPage;

	public int acilanTable;

	public bool triggerforpage;

	public GameObject researchpage;

	public GameObject arasitirmatamamlandiinfo;

	public TextMeshProUGUI arastirmatamamlanditext;

	public int KristalFiyati(int tableIndex)
	{
        // Original ARM64 recovery 0x202d368.
        if(PlayerData.researchSaveData.ArastirmaCenterLevel_Level==0)return 1;
        return Mathf.Clamp((int)(GetRemainingTimeInMinutes(tableIndex)*2f),3,10000);
	}

	public float GetRemainingTimeInMinutes(int tableIndex)
	{
        // Original ARM64 recovery 0x202d480.
        return (float)System.Math.Max(unchecked(researchEndTimes[tableIndex]-TimeManager.Instance.GetCurrentUTCTime()),0L)/60f;
	}

	[IteratorStateMachine(typeof(_003CStart_003Ed__30))]
	private IEnumerator Start()
	{
        // Original ARM64 recovery 0x202ea5c.
        arastirmatamamlanditext.text=Lang.Get.arastirmatamamlandi;
        yield return new WaitForSeconds(1f);
        for(int i=0;i<ReSearchitems.childCount;i++)ReSearchitems.GetChild(i).GetComponent<ResearchitemUi>().LoadStart();
        for(int i=0;i<_arastirmayok.Length;i++)_arastirmayok[i].text=Lang.Get.yenibirarastirma;
        for(int i=0;i<_finishnow.Length;i++){_finishnow[i].text=Lang.Get.finishnow;_labtitles[i].text=Lang.Get.labaratuar+". "+i.ToString();}
        for(int i=0;i<_labpurchase.Length;i++)_labpurchase[i].text=Lang.Get.openlab+" <sprite=1>"+labfiyatlar[i].ToString();
        if(ES3.KeyExists("Labsatinalinmis"))labsatinalinmis=ES3.Load<bool[]>("Labsatinalinmis");else ES3.Save<bool[]>("Labsatinalinmis",labsatinalinmis);
        LoadResearch();
	}

	private void Update()
	{
        // Original ARM64 recovery 0x202d5b4.
        for(int i=0;i<researchTables.Length;i++)if(isResearchActive[i])
        {long now=TimeManager.Instance.GetCurrentUTCTime();if(now<researchEndTimes[i])UpdateResearchProgress(i,now);else CompleteResearch(i);}
        if(!triggerforpage)return;
        for(int i=0;i<researchTables.Length;i++)
        {
         if(labsatinalinmis[i])
         {
          if(isResearchActive[i])
          {
           _fiyat[i].text="<sprite=1>"+KristalFiyati(i).ToString();_ON[i].SetActive(true);_OFF[i].SetActive(false);_Purchase[i].SetActive(false);
           if(triggerforpage){TextUpdate(i);triggerforpage=false;}
          }
          else{_ON[i].SetActive(false);_OFF[i].SetActive(true);_Purchase[i].SetActive(false);}
         }
         else{_ON[i].SetActive(false);_OFF[i].SetActive(false);_Purchase[i].SetActive(true);if(i!=0)researchTables[i].gameObject.SetActive(labsatinalinmis[i-1]);}
        }
	}

	private void TextUpdate(int tableIndex)
	{
        // Original ARM64 recovery 0x202dc24.
        researchNameTexts[tableIndex].text=_arastirilan[tableIndex]._title.text;_kactan[tableIndex].text=_arastirilan[tableIndex].duzhaliforresearch;
        researchDurations[tableIndex]=(long)unchecked(_arastirilan[tableIndex].arastirmaDakikaKac()*60);researchSliders[tableIndex].maxValue=(float)researchDurations[tableIndex];
        _fiyat[tableIndex].text="<sprite=1>"+KristalFiyati(tableIndex).ToString();
	}

	public void StartResearch(int tableIndex, int researchID, long duration)
	{
        // Original ARM64 recovery 0x202ca60.
        if(isResearchActive[tableIndex])return;
        currentResearchIDs[tableIndex]=researchID;researchDurations[tableIndex]=unchecked(duration*60L);
        researchEndTimes[tableIndex]=unchecked(TimeManager.Instance.GetCurrentUTCTime()+researchDurations[tableIndex]);researchSliders[tableIndex].maxValue=(float)researchDurations[tableIndex];
        isResearchActive[tableIndex]=true;_arastirilan[tableIndex]=ReSearchitems.GetChild(researchID).GetComponent<ResearchitemUi>();
        SaveResearch();TextUpdate(tableIndex);UpdateTableInfos();
	}

	public void UpdateTableInfos()
	{
        // Original ARM64 recovery 0x202df94.
        for(int i=0;i<isResearchActive.Length;i++){_ON[i].SetActive(isResearchActive[i]&&labsatinalinmis[i]);_OFF[i].SetActive(!isResearchActive[i]&&labsatinalinmis[i]);_Purchase[i].SetActive(!labsatinalinmis[i]);}
	}

	private void UpdateResearchProgress(int tableIndex, long currentTime)
	{
        // Original ARM64 recovery 0x202db44.
        long remaining=unchecked(researchEndTimes[tableIndex]-currentTime);timeRemainingTexts[tableIndex].text=FormatTime((float)remaining);researchSliders[tableIndex].value=(float)unchecked(researchDurations[tableIndex]-remaining);
	}

	private void CompleteResearch(int tableIndex)
	{
        // Original ARM64 recovery 0x202d9b4.
        isResearchActive[tableIndex]=false;researchSliders[tableIndex].value=researchSliders[tableIndex].maxValue;
        GiveReward(currentResearchIDs[tableIndex],tableIndex);ClanTaskLocal.ClanTaskPointEkle(6,1);
        ES3.DeleteKey("researchEndTime"+tableIndex.ToString());ES3.DeleteKey("currentResearchID"+tableIndex.ToString());arasitirmatamamlandiinfo.SetActive(true);UpdateTableInfos();
	}

	private void SaveResearch()
	{
        // Original ARM64 recovery 0x202de40.
        for(int i=0;i<researchTables.Length;i++){ES3.Save<long>("researchEndTime"+i.ToString(),researchEndTimes[i]);ES3.Save<int>("currentResearchID"+i.ToString(),currentResearchIDs[i]);}
	}

	public bool CheckResearchBosmu()
	{
        // Original ARM64 recovery 0x202e3a4.
        for(int i=0;i<researchTables.Length;i++)if(labsatinalinmis[i]&&!isResearchActive[i])return true;return false;
	}

	private void LoadResearch()
	{
        // Original ARM64 recovery 0x202e430.
        for(int i=0;i<researchTables.Length;i++)
        {
         if(!ES3.KeyExists("researchEndTime"+i.ToString())||!ES3.KeyExists("currentResearchID"+i.ToString()))continue;
         researchEndTimes[i]=ES3.Load<long>("researchEndTime"+i.ToString());currentResearchIDs[i]=ES3.Load<int>("currentResearchID"+i.ToString());isResearchActive[i]=true;
         if(currentResearchIDs[i]<0)continue;
         _arastirilan[i]=ReSearchitems.GetChild(currentResearchIDs[i]).GetComponent<ResearchitemUi>();researchDurations[i]=(long)unchecked(_arastirilan[i].arastirmaDakikaKac()*60);researchSliders[i].maxValue=(float)researchDurations[i];TextUpdate(i);
        }
        UpdateTableInfos();
	}

	public bool Checkresearchvarmi(int researchNum)
	{
        // Original ARM64 recovery 0x202c9fc.
        for(int i=0;i<currentResearchIDs.Length;i++)if(currentResearchIDs[i]==researchNum)return true;return false;
	}

	private void GiveReward(int researchID, int tableIndex)
	{
        // Original ARM64 recovery 0x202e2d8.
        for(int i=0;i<ReSearchitems.childCount;i++)ReSearchitems.GetChild(i).GetComponent<ResearchitemUi>().ReSearchDone(researchID);currentResearchIDs[tableIndex]=-1;
	}

	public void HemenSonlandirKristalile(int tableIndex)
	{
        // Original ARM64 recovery 0x202e75c.
        if(Currencys.Crystal<KristalFiyati(tableIndex))return;
        Currencys.SpendCrystal(KristalFiyati(tableIndex),"Meta","ResearchSonlandir");CompleteResearch(tableIndex);
	}

	public void StopResearch(int tableIndex)
	{
        // Original ARM64 recovery 0x202ce18.
        isResearchActive[tableIndex]=false;ES3.DeleteKey("researchEndTime"+tableIndex.ToString());currentResearchIDs[tableIndex]=-1;ES3.DeleteKey("currentResearchID"+tableIndex.ToString());UpdateTableInfos();
	}

	private string FormatTime(float seconds)
	{
        // Original ARM64 recovery 0x202e10c.
        System.TimeSpan time=System.TimeSpan.FromSeconds((double)seconds);
        return time.TotalMinutes<60d?string.Format("{0:D2}:{1:D2}",time.Minutes,time.Seconds):string.Format("{0:D2}:{1:D2}:{2:D2}",time.Hours,time.Minutes,time.Seconds);
	}

	public void OpenResearchs(int tablenum)
	{
        // Original ARM64 recovery 0x202e880.
        if(labsatinalinmis[tablenum]){acilanTable=tablenum;ResearchsPage.SetActive(true);return;}
        if(Currencys.Crystal>labfiyatlar[tablenum]){Currencys.SpendCrystal(labfiyatlar[tablenum],"Meta","NewResearchTab");labsatinalinmis[tablenum]=true;ES3.Save<bool[]>("Labsatinalinmis",labsatinalinmis);triggerforpage=true;}
	}

	public void CloseResearchs()
	{
        // Original ARM64 recovery 0x202cc78.
        ResearchsPage.SetActive(false);
	}

	public void OpenResearchPage(bool nedir)
	{
        // Original ARM64 recovery 0x202ea2c.
        triggerforpage=nedir;researchpage.SetActive(nedir);
	}
}
