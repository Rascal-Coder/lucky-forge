using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Basarimlar : MonoBehaviour
{
	public GameObject basariPrefab;

	public Transform basariParent;

	public int visibleCount = 30;

	public CurrencyCollectedUi collectedUi;

	public static List<BasariGorev> basarilar = new List<BasariGorev>();

	private static List<BasariGorevUI> basariUIs = new List<BasariGorevUI>();

	private bool loaded;

	public static GameObject gorevtamamlandiObj;

	public GameObject gorevtamamlandiObjPublic;

	public static bool eklendi;

	private void LoadBasarilar()
	{
        // Original ARM64 recovery 0x21af65c.
        if(ES3.KeyExists("BasarilarR"))basarilar=ES3.Load<List<BasariGorev>>("BasarilarR");else InitializeBasarilar();
	}

	public void OyunBaslayinca()
	{
        // Original ARM64 recovery 0x21b0d2c.
        if(loaded){basariUIs.Clear();basarilar.Clear();}
        gorevtamamlandiObj=gorevtamamlandiObjPublic;LoadBasarilar();InitializeUI();loaded=true;
	}

	private void InitializeBasarilar()
	{
        // Original ARM64 recovery 0x21af718.
        basarilar=new List<BasariGorev>{
        new BasariGorev(0,5,5,1,100,1,false),
        new BasariGorev(1,3,3,0,10,1,false),
        new BasariGorev(2,1,1,1,100,1,false),
        new BasariGorev(3,3,3,0,10,1,false),
        new BasariGorev(4,1,1,1,150,1,false),
        new BasariGorev(5,2,2,1,100,1,false),
        new BasariGorev(6,3,3,1,100,1,false),
        new BasariGorev(7,2,2,0,10,1,false),
        new BasariGorev(8,2,2,1,100,1,false),
        new BasariGorev(9,20,20,1,100,1,false),
        new BasariGorev(10,5,5,1,100,1,false),
        new BasariGorev(11,5,5,1,100,1,false),
        new BasariGorev(12,1,1,0,10,1,false),
        new BasariGorev(13,5,5,1,100,1,false),
        new BasariGorev(14,3,3,1,100,1,false),
        new BasariGorev(15,5,5,1,100,1,false),
        new BasariGorev(16,1,1,1,100,1,false),
        new BasariGorev(17,50,50,0,10,1,false),
        new BasariGorev(18,1,1,1,100,1,false),
        new BasariGorev(19,1,1,1,150,1,false),
        new BasariGorev(20,7,7,1,100,1,false),
        new BasariGorev(21,8,8,1,100,1,false),
        new BasariGorev(22,1,1,1,150,1,false),
        new BasariGorev(23,3,3,1,100,1,false),
        new BasariGorev(24,1,1,0,10,1,false),
        new BasariGorev(25,1,1,0,10,1,false),
        new BasariGorev(26,3,3,1,100,1,false),
        new BasariGorev(27,2,2,1,100,1,false),
        new BasariGorev(28,1,1,1,100,1,false),
        new BasariGorev(29,3,3,0,10,1,false),
        new BasariGorev(30,2,2,1,250,1,false),
        new BasariGorev(31,2,2,1,100,1,false)
        };
        ES3.Save<List<BasariGorev>>("BasarilarR",basarilar);
	}

	private void InitializeUI()
	{
        // Original ARM64 recovery 0x21b0e48.
        foreach(var gorev in basarilar.Take(basarilar.Count)){GameObject clone=Instantiate(basariPrefab,basariParent);var row=clone.GetComponent<BasariGorevUI>();clone.SetActive(true);row.Initialize(gorev,this);basariUIs.Add(row);}
        siralamaYap();
	}

	private void siralamaYap()
	{
        // Original ARM64 recovery 0x21b1320.
        // Original limit is literal10, independent of serialized visibleCount.
        // Native selectors 0x21b2164: current>=max; 0x21b2184: single precision ratio.
        var visible=basarilar.Take(10).OrderByDescending(t=>t.currentCount>=t.maxValue).ThenByDescending(t=>(float)t.currentCount/(float)t.maxValue).ToList();
        for(int i=0;i<basarilar.Count;i++){var current=basarilar[i];var row=basariUIs.Find(t=>t.gorev==current);if(row==null)continue;if(visible.Contains(current)){row.transform.SetSiblingIndex(visible.IndexOf(current));row.gameObject.SetActive(true);current.ilk10da=true;}else{row.gameObject.SetActive(false);current.ilk10da=false;}}
	}

	public void CollectReward(BasariGorev gorev, BasariGorevUI ui)
	{
        // Original ARM64 recovery 0x21af29c.
        if(gorev==null || ui==null || !gorev.isCompleted || gorev.isCollected)return;
        double coin=0d;int crystal=0;
        if(gorev.OdulType==0){crystal=gorev.expReward;Currencys.AddCrystal(crystal,"Meta","AchivementCollect");BuyukParticle.Playit(BuyukParticle.Crystal_Particle);}
        else if(gorev.OdulType==1){coin=gorev.expReward;Currencys.AddCoin(coin,"Meta","AchivementCollect");BuyukParticle.Playit(BuyukParticle.Para_Particle);}
        gorev.isCompleted=false;gorev.isCollected=true;
        gorev.KacKereYapildi=unchecked(gorev.KacKereYapildi+1);
        int nextMax=unchecked(gorev.StartMaxValue*gorev.KacKereYapildi);
        if(gorev.OdulType==1)gorev.expReward=(int)((1f+(float)gorev.KacKereYapildi*0.2f)*(float)gorev.expReward);
        gorev.currentCount=0;gorev.maxValue=nextMax;
        basarilar.Remove(gorev);basarilar.Add(gorev);gorev.isCollected=false;
        collectedUi.GiveRewardUI(coin,0,0,crystal,0,0,0,0,false);
        ui.transform.SetSiblingIndex(basarilar.Count);
        ES3.Save<List<BasariGorev>>("BasarilarR",basarilar);siralamaYap();UpdateAllTaskUIs();
	}

	private static void UpdateAllTaskUIs()
	{
        // Original ARM64 recovery 0x21b17cc.
        if(basariUIs==null)return;foreach(var row in basariUIs)if(row!=null)row.UpdateUI();
	}

	public void UpdateUI()
	{
        // Original ARM64 recovery 0x21b198c.
        if(basariUIs==null || basarilar==null)return;
        int count=Mathf.Min(basariUIs.Count,basarilar.Count);
        for(int i=0;i<count;i++){if(basariUIs[i]!=null && basarilar[i]!=null){basariUIs[i].gorev=basarilar[i];basariUIs[i].UpdateUI();}}
	}

	public static void UpdateBasarimlarT(int type, int increment)
	{
        // Original ARM64 recovery 0x21b1bac.
        if(basarilar.Count==0)return;
        eklendi=true;
        var gorev=basarilar.Find(t=>t.GorevType==type);
        if(!gorev.ilk10da || gorev.isCompleted)return;
        gorev.currentCount=unchecked(gorev.currentCount+increment);
        if(gorev.currentCount>=gorev.maxValue){gorev.isCompleted=true;if(basarilar.IndexOf(gorev)<basarilar.Count && GameManager.Level>=3){if(GunlukGorevler._infoCloneAnasayfa!=null)GunlukGorevler._infoCloneAnasayfa.SetActive(true);GunlukGorevler.basariminfo=true;}if(gorevtamamlandiObj!=null && GameManager.Level>=3)gorevtamamlandiObj.SetActive(true);}
	}

	public static void SaveBasarimlar()
	{
        // Original ARM64 recovery 0x21b1ed8.
        if(!eklendi)return;ES3.Save<List<BasariGorev>>("BasarilarR",basarilar);eklendi=false;
	}

	private void OnEnable()
	{
        // Original ARM64 recovery 0x21b1f8c.
        if(loaded){UpdateAllTaskUIs();siralamaYap();}
	}
}
