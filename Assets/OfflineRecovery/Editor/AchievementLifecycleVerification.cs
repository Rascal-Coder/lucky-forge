using System;using System.Collections.Generic;using System.IO;using System.Linq;using System.Reflection;using TMPro;using UnityEditor;using UnityEngine;using UnityEngine.UI;
namespace LuckyForge.Offline.Editor{
public static class AchievementLifecycleVerification{
 [Serializable]public class Result{public bool passed;public int checks;public string testRoot;public string saveFile;public List<string> failures=new List<string>();public List<string> sourceRules=new List<string>();}
 static void Check(Result r,bool ok,string label){r.checks++;if(!ok)r.failures.Add(label);}
 static GameObject Child(Transform parent,string name){var g=new GameObject(name,typeof(RectTransform));g.SetActive(false);g.transform.SetParent(parent,false);return g;}
 static T Add<T>(Transform parent,string name)where T:Component=>Child(parent,name).AddComponent<T>();
 static object Call(object obj,string name,params object[] args)=>obj.GetType().GetMethod(name,BindingFlags.Instance|BindingFlags.NonPublic|BindingFlags.Public).Invoke(obj,args);
 static void ResetAchievementStatics(){Basarimlar.basarilar=new List<BasariGorev>();Basarimlar.eklendi=false;typeof(Basarimlar).GetField("basariUIs",BindingFlags.Static|BindingFlags.NonPublic).SetValue(null,new List<BasariGorevUI>());}
 static BasariGorevUI Row(Transform root){var row=Add<BasariGorevUI>(root,"achievement-template");row.titleText=Add<TextMeshProUGUI>(row.transform,"title");row.expRewardText=Add<TextMeshProUGUI>(row.transform,"reward");row.progressText=Add<TextMeshProUGUI>(row.transform,"progress");row.progressSlider=Add<Slider>(row.transform,"slider");row.collectButton=Add<Button>(row.transform,"claim");row._collecttext=Add<TextMeshProUGUI>(row.transform,"claim-text");row._check=Child(row.transform,"collected");row.siyahlik=Child(row.transform,"shade");row._rewardIcons=Child(row.transform,"reward-icons").transform;for(int i=0;i<2;i++)Child(row._rewardIcons,"icon"+i);return row;}
 static Basarimlar Fixture(Transform root,out GunlukGorevler tabs){var m=Add<Basarimlar>(root,"shared-task-page");m.basariPrefab=Row(root).gameObject;m.basariParent=Child(m.transform,"achievement-list").transform;m.visibleCount=10;m.collectedUi=InfoPanelFixtureSupport.CreateRewardPopup(root);m.gorevtamamlandiObjPublic=Child(root,"achievement-completed-indicator");tabs=m.gameObject.AddComponent<GunlukGorevler>();tabs.insidePages=new[]{Child(m.transform,"daily-list"),m.basariParent.gameObject};tabs.rects=tabs.insidePages.Select(g=>(RectTransform)g.transform).ToArray();tabs.altbtnstexts=new[]{Add<TextMeshProUGUI>(root,"daily-tab"),Add<TextMeshProUGUI>(root,"achievement-tab")};tabs.altinfos=new[]{Child(root,"daily-tab-info"),Child(root,"achievement-tab-info")};tabs.altchooser=Child(root,"tab-selector").transform;return m;}
 static BasariGorevUI Find(Basarimlar m,int type)=>m.basariParent.GetComponentsInChildren<BasariGorevUI>(true).Single(row=>row.gorev.GorevType==type);
 static void Flush(){var disk=new ES3Settings("medupac.es3",ES3.Location.File);ES3.StoreCachedFile("medupac.es3",disk);OfflineKeyStore.ResetMemoryForVerification();ES3.CacheFile("medupac.es3",disk);}
 static void VerifyChiefTitles(Result r){
 // NATIVE_CHIEF_CHECKS
GameManager.Language=0;Check(r,Lang.Get.missionStr2=="Defeat the " + Lang.Get.chefnameStr0 + " chief","LangEN.missionStr2 exact native chief/literal Unicode composition");
GameManager.Language=0;Check(r,Lang.Get.missionStr12=="Defeat the " + Lang.Get.chefnameStr1 + " chief","LangEN.missionStr12 exact native chief/literal Unicode composition");
GameManager.Language=0;Check(r,Lang.Get.missionStr16=="Defeat the " + Lang.Get.chefnameStr2 + " chief","LangEN.missionStr16 exact native chief/literal Unicode composition");
GameManager.Language=0;Check(r,Lang.Get.missionStr19=="Defeat the " + Lang.Get.chefnameStr3 + " chief","LangEN.missionStr19 exact native chief/literal Unicode composition");
GameManager.Language=0;Check(r,Lang.Get.missionStr22=="Defeat the " + Lang.Get.chefnameStr4 + " chief","LangEN.missionStr22 exact native chief/literal Unicode composition");
GameManager.Language=0;Check(r,Lang.Get.missionStr24=="Defeat the " + Lang.Get.chefnameStr5 + " chief","LangEN.missionStr24 exact native chief/literal Unicode composition");
GameManager.Language=0;Check(r,Lang.Get.missionStr25=="Defeat the " + Lang.Get.chefnameStr6 + " chief","LangEN.missionStr25 exact native chief/literal Unicode composition");
GameManager.Language=0;Check(r,Lang.Get.missionStr28=="Defeat the " + Lang.Get.chefnameStr7 + " chief","LangEN.missionStr28 exact native chief/literal Unicode composition");
GameManager.Language=2;Check(r,Lang.Get.missionStr2=="Derrota al jefe " + Lang.Get.chefnameStr0,"LangES.missionStr2 exact native chief/literal Unicode composition");
GameManager.Language=2;Check(r,Lang.Get.missionStr12=="Derrota al jefe " + Lang.Get.chefnameStr1,"LangES.missionStr12 exact native chief/literal Unicode composition");
GameManager.Language=2;Check(r,Lang.Get.missionStr16=="Derrota al jefe " + Lang.Get.chefnameStr2,"LangES.missionStr16 exact native chief/literal Unicode composition");
GameManager.Language=2;Check(r,Lang.Get.missionStr19=="Derrota al jefe " + Lang.Get.chefnameStr3,"LangES.missionStr19 exact native chief/literal Unicode composition");
GameManager.Language=2;Check(r,Lang.Get.missionStr22=="Derrota al jefe " + Lang.Get.chefnameStr4,"LangES.missionStr22 exact native chief/literal Unicode composition");
GameManager.Language=2;Check(r,Lang.Get.missionStr24=="Derrota al jefe " + Lang.Get.chefnameStr5,"LangES.missionStr24 exact native chief/literal Unicode composition");
GameManager.Language=2;Check(r,Lang.Get.missionStr25=="Derrota al jefe " + Lang.Get.chefnameStr6,"LangES.missionStr25 exact native chief/literal Unicode composition");
GameManager.Language=2;Check(r,Lang.Get.missionStr28=="Derrota al jefe " + Lang.Get.chefnameStr7,"LangES.missionStr28 exact native chief/literal Unicode composition");
GameManager.Language=3;Check(r,Lang.Get.missionStr2=="Derrote o chefe " + Lang.Get.chefnameStr0,"LangPR.missionStr2 exact native chief/literal Unicode composition");
GameManager.Language=3;Check(r,Lang.Get.missionStr12=="Derrote o chefe " + Lang.Get.chefnameStr1,"LangPR.missionStr12 exact native chief/literal Unicode composition");
GameManager.Language=3;Check(r,Lang.Get.missionStr16=="Derrote o chefe " + Lang.Get.chefnameStr2,"LangPR.missionStr16 exact native chief/literal Unicode composition");
GameManager.Language=3;Check(r,Lang.Get.missionStr19=="Derrote o chefe " + Lang.Get.chefnameStr3,"LangPR.missionStr19 exact native chief/literal Unicode composition");
GameManager.Language=3;Check(r,Lang.Get.missionStr22=="Derrote o chefe " + Lang.Get.chefnameStr4,"LangPR.missionStr22 exact native chief/literal Unicode composition");
GameManager.Language=3;Check(r,Lang.Get.missionStr24=="Derrote o chefe " + Lang.Get.chefnameStr5,"LangPR.missionStr24 exact native chief/literal Unicode composition");
GameManager.Language=3;Check(r,Lang.Get.missionStr25=="Derrote o chefe " + Lang.Get.chefnameStr6,"LangPR.missionStr25 exact native chief/literal Unicode composition");
GameManager.Language=3;Check(r,Lang.Get.missionStr28=="Derrote o chefe " + Lang.Get.chefnameStr7,"LangPR.missionStr28 exact native chief/literal Unicode composition");
GameManager.Language=1;Check(r,Lang.Get.missionStr2==Lang.Get.chefnameStr0 + " 치프를 물리치세요","LangKR.missionStr2 exact native chief/literal Unicode composition");
GameManager.Language=1;Check(r,Lang.Get.missionStr12==Lang.Get.chefnameStr1 + " 치프를 물리치세요","LangKR.missionStr12 exact native chief/literal Unicode composition");
GameManager.Language=1;Check(r,Lang.Get.missionStr16==Lang.Get.chefnameStr2 + " 치프를 물리치세요","LangKR.missionStr16 exact native chief/literal Unicode composition");
GameManager.Language=1;Check(r,Lang.Get.missionStr19==Lang.Get.chefnameStr3 + " 치프를 물리치세요","LangKR.missionStr19 exact native chief/literal Unicode composition");
GameManager.Language=1;Check(r,Lang.Get.missionStr22==Lang.Get.chefnameStr4 + " 치프를 물리치세요","LangKR.missionStr22 exact native chief/literal Unicode composition");
GameManager.Language=1;Check(r,Lang.Get.missionStr24==Lang.Get.chefnameStr5 + " 치프를 물리치세요","LangKR.missionStr24 exact native chief/literal Unicode composition");
GameManager.Language=1;Check(r,Lang.Get.missionStr25==Lang.Get.chefnameStr6 + " 치프를 물리치세요","LangKR.missionStr25 exact native chief/literal Unicode composition");
GameManager.Language=1;Check(r,Lang.Get.missionStr28==Lang.Get.chefnameStr7 + " 치프를 물리치세요","LangKR.missionStr28 exact native chief/literal Unicode composition");
GameManager.Language=5;Check(r,Lang.Get.missionStr2=="Besiege den Chef " + Lang.Get.chefnameStr0,"LangGR.missionStr2 exact native chief/literal Unicode composition");
GameManager.Language=5;Check(r,Lang.Get.missionStr12=="Besiege den Chef " + Lang.Get.chefnameStr1,"LangGR.missionStr12 exact native chief/literal Unicode composition");
GameManager.Language=5;Check(r,Lang.Get.missionStr16=="Besiege den Chef " + Lang.Get.chefnameStr2,"LangGR.missionStr16 exact native chief/literal Unicode composition");
GameManager.Language=5;Check(r,Lang.Get.missionStr19=="Besiege den Chef " + Lang.Get.chefnameStr3,"LangGR.missionStr19 exact native chief/literal Unicode composition");
GameManager.Language=5;Check(r,Lang.Get.missionStr22=="Besiege den Chef " + Lang.Get.chefnameStr4,"LangGR.missionStr22 exact native chief/literal Unicode composition");
GameManager.Language=5;Check(r,Lang.Get.missionStr24=="Besiege den Chef " + Lang.Get.chefnameStr5,"LangGR.missionStr24 exact native chief/literal Unicode composition");
GameManager.Language=5;Check(r,Lang.Get.missionStr25=="Besiege den Chef " + Lang.Get.chefnameStr6,"LangGR.missionStr25 exact native chief/literal Unicode composition");
GameManager.Language=5;Check(r,Lang.Get.missionStr28=="Besiege den Chef " + Lang.Get.chefnameStr7,"LangGR.missionStr28 exact native chief/literal Unicode composition");
GameManager.Language=4;Check(r,Lang.Get.missionStr2==Lang.Get.chefnameStr0 + "チーフを倒す","LangJP.missionStr2 exact native chief/literal Unicode composition");
GameManager.Language=4;Check(r,Lang.Get.missionStr12==Lang.Get.chefnameStr1 + "チーフを倒す","LangJP.missionStr12 exact native chief/literal Unicode composition");
GameManager.Language=4;Check(r,Lang.Get.missionStr16==Lang.Get.chefnameStr2 + "チーフを倒す","LangJP.missionStr16 exact native chief/literal Unicode composition");
GameManager.Language=4;Check(r,Lang.Get.missionStr19==Lang.Get.chefnameStr3 + "チーフを倒す","LangJP.missionStr19 exact native chief/literal Unicode composition");
GameManager.Language=4;Check(r,Lang.Get.missionStr22==Lang.Get.chefnameStr4 + "チーフを倒す","LangJP.missionStr22 exact native chief/literal Unicode composition");
GameManager.Language=4;Check(r,Lang.Get.missionStr24==Lang.Get.chefnameStr5 + "チーフを倒す","LangJP.missionStr24 exact native chief/literal Unicode composition");
GameManager.Language=4;Check(r,Lang.Get.missionStr25==Lang.Get.chefnameStr6 + "チーフを倒す","LangJP.missionStr25 exact native chief/literal Unicode composition");
GameManager.Language=4;Check(r,Lang.Get.missionStr28==Lang.Get.chefnameStr7 + "チーフを倒す","LangJP.missionStr28 exact native chief/literal Unicode composition");
GameManager.Language=6;Check(r,Lang.Get.missionStr2=="Победите вождя " + Lang.Get.chefnameStr0,"LangRU.missionStr2 exact native chief/literal Unicode composition");
GameManager.Language=6;Check(r,Lang.Get.missionStr12=="Победите вождя " + Lang.Get.chefnameStr1,"LangRU.missionStr12 exact native chief/literal Unicode composition");
GameManager.Language=6;Check(r,Lang.Get.missionStr16=="Победите вождя " + Lang.Get.chefnameStr2,"LangRU.missionStr16 exact native chief/literal Unicode composition");
GameManager.Language=6;Check(r,Lang.Get.missionStr19=="Победите вождя " + Lang.Get.chefnameStr3,"LangRU.missionStr19 exact native chief/literal Unicode composition");
GameManager.Language=6;Check(r,Lang.Get.missionStr22=="Победите вождя " + Lang.Get.chefnameStr4,"LangRU.missionStr22 exact native chief/literal Unicode composition");
GameManager.Language=6;Check(r,Lang.Get.missionStr24=="Победите вождя " + Lang.Get.chefnameStr5,"LangRU.missionStr24 exact native chief/literal Unicode composition");
GameManager.Language=6;Check(r,Lang.Get.missionStr25=="Победите вождя " + Lang.Get.chefnameStr6,"LangRU.missionStr25 exact native chief/literal Unicode composition");
GameManager.Language=6;Check(r,Lang.Get.missionStr28=="Победите вождя " + Lang.Get.chefnameStr7,"LangRU.missionStr28 exact native chief/literal Unicode composition");
 }
 public static Result RunChecks(string suppliedRoot=null){
 var r=new Result{testRoot=Path.GetFullPath(suppliedRoot??Path.Combine(Path.GetTempPath(),"LuckyForgeAchievementChecks",Guid.NewGuid().ToString("N")))};
 if(EditorApplication.isPlayingOrWillChangePlaymode){r.failures.Add("Requires isolated non-playing Editor process.");return r;}Directory.CreateDirectory(r.testRoot);
 var saved=new Dictionary<FieldInfo,object>();foreach(var type in new[]{typeof(Currencys),typeof(GameManager),typeof(Lang),typeof(Basarimlar),typeof(GunlukGorevler)})foreach(var f in type.GetFields(BindingFlags.Static|BindingFlags.Public|BindingFlags.NonPublic))if(!f.IsLiteral&&!f.IsInitOnly)saved[f]=f.GetValue(null);
 var oldSound=SoundManager.instance;var root=new GameObject("AchievementLifecycleVerification");root.SetActive(false);OfflineKeyStore.SetVerificationRoot(r.testRoot);
 try{
 GameManager.Language=0;GameManager.NewUserTapNation=true;Lang.currentLang=null;GameManager.Level=0;SoundManager.instance=null;ResetAchievementStatics();GunlukGorevler.basariminfo=false;GunlukGorevler._infoCloneAnasayfa=Child(root.transform,"home-task-info");Currencys.CoinFitle(0);Currencys.CrystalFitle(0);
 Basarimlar.UpdateBasarimlarT(0,1);Check(r,!Basarimlar.eklendi&&Basarimlar.basarilar.Count==0,"original empty static list ignores pre-initialization progress");
 GunlukGorevler tabs;var m=Fixture(root.transform,out tabs);m.OyunBaslayinca();
 Check(r,Basarimlar.basarilar.Count==32&&m.basariParent.childCount==32,"32 exact original achievement records instantiate32 bound rows");
 Check(r,Basarimlar.basarilar.Select(g=>g.GorevType).SequenceEqual(Enumerable.Range(0,32))&&Basarimlar.basarilar.All(g=>g.KacKereYapildi==1&&g.StartMaxValue==g.maxValue&&!g.isCompleted&&!g.isCollected),"original initial order tier1 baseline and flags");
 Check(r,Basarimlar.basarilar[0].maxValue==5&&Basarimlar.basarilar[0].expReward==100&&Basarimlar.basarilar[1].maxValue==3&&Basarimlar.basarilar[1].expReward==10&&Basarimlar.basarilar[30].expReward==250,"native first-spin100Coin epic3/10Crystal and type30/250Coin balance");
 Check(r,Basarimlar.basarilar.Count(g=>g.ilk10da)==10&&Basarimlar.basarilar.Take(10).All(g=>g.ilk10da)&&!Basarimlar.basarilar[10].ilk10da,"only original first10 eligible tasks accrue progress");
 Check(r,m.basariParent.GetComponentsInChildren<BasariGorevUI>(true).Count(row=>row.gameObject.activeSelf)==10,"native rows beyond first10 hidden");
 Check(r,Find(m,2).titleText.text=="Defeat the Cursed Pharaoh chief."&&Find(m,0).titleText.text==Lang.Get.missionStr0+".","chief dependency and mission dispatch produce exact original full English title");
 tabs.OpenInsidePage(1);Check(r,tabs.insidePages[1].activeSelf&&!tabs.insidePages[0].activeSelf&&!tabs.altinfos[1].activeSelf,"existing daily-page achievement tab reaches actual list without rewriting Daily module");
 m.visibleCount=1;Call(m,"siralamaYap");Check(r,Basarimlar.basarilar.Count(g=>g.ilk10da)==10,"source algorithm uses literal10 independent of visibleCount field");m.visibleCount=10;
 var g0=Basarimlar.basarilar.Single(g=>g.GorevType==0);var row0=Find(m,0);row0.collectButton.onClick.Invoke();Check(r,Currencys.Coin==0&&g0.KacKereYapildi==1,"bound runtime claim listener cannot grant unfinished tier");
 Basarimlar.UpdateBasarimlarT(31,500);Check(r,Basarimlar.basarilar.Single(g=>g.GorevType==31).currentCount==0&&Basarimlar.eklendi,"hidden task progress ignored while original dirty flag is set");Basarimlar.SaveBasarimlar();Check(r,!Basarimlar.eklendi&&ES3.Load<List<BasariGorev>>("BasarilarR").Count==32,"dirty-controlled typed save clears dirty flag");
 Basarimlar.UpdateBasarimlarT(0,4);Call(m,"OnEnable");Check(r,g0.currentCount==4&&!g0.isCompleted&&!row0.collectButton.interactable&&row0.progressText.text=="4 / 5","below threshold progress refreshes native row without reward");
 Basarimlar.UpdateBasarimlarT(0,3);Check(r,g0.currentCount==7&&g0.isCompleted&&!m.gorevtamamlandiObjPublic.activeSelf&&!GunlukGorevler._infoCloneAnasayfa.activeSelf,"original overshoot completes once and suppresses level0 indicators");Basarimlar.UpdateBasarimlarT(0,100);Check(r,g0.currentCount==7,"completed tier cannot keep accumulating progress");
 Call(m,"OnEnable");Check(r,row0.collectButton.interactable&&row0.transform.GetSiblingIndex()==0&&row0._collecttext.text==Lang.Get.topla,"opening page prioritizes claimable row and enables claim label");
 int staleListenerCalls=0;row0.collectButton.onClick.AddListener(()=>staleListenerCalls++);row0.Initialize(g0,m);row0.collectButton.onClick.Invoke();
 Check(r,staleListenerCalls==0&&Currencys.Coin==100,"native Initialize removes old runtime listeners and one actual button event grants100Coin");
 Check(r,g0.KacKereYapildi==2&&g0.maxValue==10&&g0.currentCount==0&&!g0.isCompleted&&!g0.isCollected&&g0.expReward==140,"first claim exact tier2 goal10 reset and float-grown140Coin next reward");
 Check(r,Basarimlar.basarilar.Last()==g0&&!g0.ilk10da&&!row0.gameObject.activeSelf&&Basarimlar.basarilar.Single(g=>g.GorevType==10).ilk10da,"claimed achievement rotates to end and next original item becomes eligible");
 row0.collectButton.onClick.Invoke();Check(r,Currencys.Coin==100&&g0.KacKereYapildi==2,"duplicate same-tier claim cannot grant again");
 Check(r,ES3.Load<List<BasariGorev>>("BasarilarR").Last().GorevType==0&&ES3.Load<List<BasariGorev>>("BasarilarR").Last().maxValue==10,"claim immediately persists original list rotation and next tier");
 Basarimlar.UpdateBasarimlarT(0,10);Check(r,g0.currentCount==0&&!g0.isCompleted,"rotated-out next tier cannot accumulate before re-entering first10");
 GameManager.Level=3;var g1=Basarimlar.basarilar.Single(g=>g.GorevType==1);Basarimlar.UpdateBasarimlarT(1,3);Call(m,"OnEnable");Check(r,g1.isCompleted&&GunlukGorevler.basariminfo&&GunlukGorevler._infoCloneAnasayfa.activeSelf&&m.gorevtamamlandiObjPublic.activeSelf,"level3 completion flags shared home/task indicators");Find(m,1).collectButton.onClick.Invoke();Check(r,Currencys.Crystal==10&&g1.KacKereYapildi==2&&g1.maxValue==6&&g1.expReward==10,"Crystal tier reward stays10 while target doubles3to6");
 var beforeOrder=Basarimlar.basarilar.Select(g=>g.GorevType).ToArray();var g2=Basarimlar.basarilar.Single(g=>g.GorevType==2);m.CollectReward(g2,null);Check(r,beforeOrder.SequenceEqual(Basarimlar.basarilar.Select(g=>g.GorevType))&&Currencys.Coin==100,"null UI cannot authorize achievement claim");
 int rotations=0;while(!g0.ilk10da&&rotations<32){var task=Basarimlar.basarilar.First();if(!task.isCompleted)Basarimlar.UpdateBasarimlarT(task.GorevType,task.maxValue);Find(m,task.GorevType).collectButton.onClick.Invoke();rotations++;}
 Check(r,g0.ilk10da&&g0.KacKereYapildi==2,"original queue rotation eventually reactivates next spin tier without free progress");
 Basarimlar.UpdateBasarimlarT(0,10);Find(m,0).collectButton.onClick.Invoke();Check(r,g0.KacKereYapildi==3&&g0.maxValue==15&&g0.expReward==224&&g0.currentCount==0,"second spin tier grows140to224Coin and target15 by actual float rule");
 var first=Basarimlar.basarilar[0];Basarimlar.UpdateBasarimlarT(first.GorevType,1);Check(r,Basarimlar.eklendi,"actual eligible progress marks persistence dirty");Basarimlar.SaveBasarimlar();Flush();var disk=ES3.Load<List<BasariGorev>>("BasarilarR");var disk0=disk.Single(g=>g.GorevType==0);Check(r,disk.Count==32&&disk0.KacKereYapildi==3&&disk0.maxValue==15&&disk0.expReward==224&&!disk0.isCompleted,"actual disk preserves typed32 records, grown tiers/rewards and completion flags");Check(r,disk.Select(g=>g.GorevType).SequenceEqual(Basarimlar.basarilar.Select(g=>g.GorevType))&&disk[0].currentCount==first.currentCount,"actual disk preserves queue order and pending progress");
 double coinBeforeReload=Currencys.Coin;int crystalBeforeReload=Currencys.Crystal;ResetAchievementStatics();GunlukGorevler tabs2;var m2=Fixture(root.transform,out tabs2);m2.OyunBaslayinca();Check(r,Basarimlar.basarilar.Single(g=>g.GorevType==0).KacKereYapildi==3&&Basarimlar.basarilar.Take(10).All(g=>g.ilk10da)&&Basarimlar.basarilar.Skip(10).All(g=>!g.ilk10da),"fresh manager reload rebuilds UI eligibility from preserved actual queue");Check(r,Currencys.Coin==coinBeforeReload&&Currencys.Crystal==crystalBeforeReload,"loading saved achievement state grants no automatic resources");
 Call(m2,"OnEnable");m2.UpdateUI();Check(r,m2.basariParent.GetComponentsInChildren<BasariGorevUI>(true).All(row=>row.titleText.text.Length>1),"all32 reloaded localized UI rows remain bound and populated");
 VerifyChiefTitles(r);GameManager.Language=0;Check(r,Lang.chefnameStr(-1)==Lang.Get.chefnameStrDefault&&Lang.chefnameStr(8)==Lang.Get.chefnameStrDefault,"native chief dispatch defaults preserve out-of-range behavior");
 r.saveFile=OfflineKeyStore.PathFor();Check(r,File.Exists(r.saveFile),"isolated actual physical achievement save exists");r.sourceRules.Add("Only first10 count progress. Claim resets this tier, rotates it to end, grows target and (Coin only) reward; duplicate current tier rejected.");r.sourceRules.Add("Popup rendering and unrelated acquisition/payment/online handlers outside fixture; no blanket progress grants or historic backfill.");
 }catch(Exception e){r.failures.Add(e.ToString());}finally{InfoPanelFixtureSupport.Dispose(root.transform);foreach(var kv in saved)kv.Key.SetValue(null,kv.Value);SoundManager.instance=oldSound;OfflineKeyStore.SetVerificationRoot(null);UnityEngine.Object.DestroyImmediate(root);}
 r.passed=r.failures.Count==0;File.WriteAllText(Path.Combine(r.testRoot,"achievement-results.json"),JsonUtility.ToJson(r,true));Debug.Log("AchievementLifecycleVerification checks="+r.checks+" passed="+r.passed+" root="+r.testRoot);return r;
 }
}
}
