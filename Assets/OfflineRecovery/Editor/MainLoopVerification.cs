using System;using System.Collections.Generic;using System.IO;using System.Reflection;using UnityEditor;using UnityEngine;
namespace LuckyForge.Offline.Editor{
public static class MainLoopVerification{
 [Serializable]public class Result{public bool passed;public int checks;public string testRoot;public string saveFile;public List<string> failures=new List<string>();public List<string> sourceRules=new List<string>();}
 static void Check(Result r,bool ok,string label){r.checks++;if(!ok)r.failures.Add(label);}
 static object Call(object obj,string name,params object[] args)=>obj.GetType().GetMethod(name,BindingFlags.Instance|BindingFlags.NonPublic|BindingFlags.Public).Invoke(obj,args);
 static void Set(object obj,string name,object value)=>obj.GetType().GetField(name,BindingFlags.Instance|BindingFlags.NonPublic|BindingFlags.Public).SetValue(obj,value);
 static T Get<T>(object obj,string name)=>(T)obj.GetType().GetField(name,BindingFlags.Instance|BindingFlags.NonPublic|BindingFlags.Public).GetValue(obj);
 static T Add<T>(Transform p,string name)where T:Component{var g=new GameObject(name);g.transform.SetParent(p,false);return g.AddComponent<T>();}
 static void Reload(){OfflineKeyStore.ResetMemoryForVerification();ES3.CacheFile("medupac.es3",new ES3Settings("medupac.es3",ES3.Location.File));}
 public static Result RunChecks(string suppliedRoot=null){
  var r=new Result{testRoot=Path.GetFullPath(suppliedRoot??Path.Combine(Path.GetTempPath(),"LuckyForgeMainLoopChecks",Guid.NewGuid().ToString("N")))};
  if(EditorApplication.isPlayingOrWillChangePlaymode){r.failures.Add("Requires isolated non-playing Editor process.");return r;}Directory.CreateDirectory(r.testRoot);
  var saved=new Dictionary<FieldInfo,object>();foreach(var type in new[]{typeof(GameManager),typeof(Basarimlar),typeof(SaatlikHediye),typeof(ES3Cloud),typeof(OneTimeOffer),typeof(GooglePlayPassHandler)})foreach(var f in type.GetFields(BindingFlags.Static|BindingFlags.Public|BindingFlags.NonPublic))if(!f.IsLiteral&&!f.IsInitOnly)saved[f]=f.GetValue(null);
  var root=new GameObject("MainLoopVerification");root.SetActive(false);OfflineKeyStore.SetVerificationRoot(r.testRoot);
  try{
   var m=Add<GameManager>(root.transform,"native-main-loop");m.warController=Add<WarController>(root.transform,"battle-state");m._offer=Add<OneTimeOffer>(root.transform,"existing-offline-offer-stub");
   GameManager.GuideDone=false;GameManager.Level=0;GameManager.PageAcildi=false;OneTimeOffer.BuGunStarterAcildi=false;ES3Cloud.OynadigiTumZamanSaniyesi=40;
   GameManager.bilgitimer=123.25f;GameManager.basarimlar=0f;
   float dt=Time.deltaTime;Set(m,"savednew",2f);GameManager.reklamtimer=3f;GameManager.lokasyonClicked=4f;SaatlikHediye.totalSecondsSpentInGame=5f;m.timekazanchesapla=6f;GameManager.inapplookingforCash=true;
   Call(m,"Update");
   Check(r,Get<float>(m,"savednew")== (float)(2f-dt),"positive savednew decrements original scaled delta without clamp");
   Check(r,GameManager.reklamtimer==(float)(3f+dt)&&GameManager.lokasyonClicked==(float)(4f+dt)&&SaatlikHediye.totalSecondsSpentInGame==(float)(5f+dt),"advert/location/hourly timers add one scaled delta");
   Check(r,m.timekazanchesapla==(float)(6f+dt)&&GameManager.bilgitimer==123.25f,"played interval advances while bilgitimer remains entirely untouched");
   Check(r,!GameManager.inapplookingforCash,"original inapp-looking transient clears locally without purchase call");
   Set(m,"savednew",-1f);Call(m,"Update");Check(r,Get<float>(m,"savednew")==-1f,"nonpositive savednew unchanged");
   // Strict thresholds using the actual Editor delta observed by this frame.
   GameManager.basarimlar=(float)(10f-dt);Basarimlar.eklendi=true;Set(m,"saveit",(float)(30f-dt));m.timekazanchesapla=(float)(30f-dt);
   Call(m,"Update");Check(r,GameManager.basarimlar==10f&&Basarimlar.eklendi&&!ES3.KeyExists("BasarilarR"),"exact10 achievement threshold does not save");
   Check(r,Get<float>(m,"saveit")==30f&&!ES3.KeyExists("timesavedOffline"),"exact30 cache threshold does not save");
   Check(r,m.timekazanchesapla==30f&&ES3Cloud.OynadigiTumZamanSaniyesi==40,"exact30 played interval does not increment long");
   Basarimlar.basarilar=new List<BasariGorev>{new BasariGorev(0,5,5,1,100,1,true){currentCount=3}};
   GameManager.basarimlar=11f;Set(m,"saveit",31f);Set(m,"savednew",0f);m.timekazanchesapla=31f;SaatlikHediye.totalSecondsSpentInGame=12.5f;
   DateTime before=DateTime.UtcNow;Call(m,"Update");DateTime after=DateTime.UtcNow;
   Check(r,GameManager.basarimlar==0f&&!Basarimlar.eklendi&&ES3.Load<List<BasariGorev>>("BasarilarR")[0].currentCount==3,"strict>10 invokes actual dirty achievement save and resets timer0");
   Check(r,Get<float>(m,"saveit")==0f&&Get<float>(m,"savednew")==2f,"strict>30 flush calls original cooldown adapter and resets cache timer0");
   Check(r,ES3.Load<string>("OynadigiTumZamanSaniyesi")=="40"&&ES3Cloud.OynadigiTumZamanSaniyesi==41,"cache captures previous long40 before original interval increment1 to41");
   Check(r,ES3.Load<float>("saatlikOdulSaniyeToplam")==12.5f&&SaatlikHediye.totalSecondsSpentInGame==(float)(12.5f+dt),"cache captures hourly time before this frame delta increment");
   DateTime stamp=DateTime.Parse(ES3.Load<string>("timesavedOffline"));Check(r,Math.Abs((stamp-before).TotalSeconds)<3&&Math.Abs((stamp-after).TotalSeconds)<3,"offline timestamp uses current UTC original culture-formatted string");
   Check(r,m.timekazanchesapla==0f&&Get<bool>(m,"ilk30saniye")&&!OneTimeOffer.BuGunStarterAcildi,"first30-second interval marks first-pass flag, resets0 and leaves promotion untouched");
   r.saveFile=OfflineKeyStore.PathFor();Check(r,File.Exists(r.saveFile),"actual periodic flush creates isolated physical save");Reload();
   Check(r,ES3.Load<string>("OynadigiTumZamanSaniyesi")=="40"&&ES3.Load<List<BasariGorev>>("BasarilarR").Count==1,"actual physical reload contains both original mainloop and achievement writes");
   string physical=File.ReadAllText(r.saveFile);ES3.Save<int>("mainloop-cooldown-marker",7);Set(m,"savednew",2f);Set(m,"saveit",31f);Call(m,"Update");
   Check(r,File.ReadAllText(r.saveFile)==physical&&Get<float>(m,"saveit")==0f,"existing cooldown suppresses disk flush but source still resets saveit");
   Set(m,"savednew",0f);Set(m,"saveit",31f);Call(m,"Update");Reload();Check(r,ES3.Load<int>("mainloop-cooldown-marker")==7,"next eligible original periodic flush persists previously cached writes");
   m.warController.savastayim=true;GameManager.basarimlar=11f;Basarimlar.eklendi=true;Set(m,"saveit",31f);Set(m,"savednew",0f);m.timekazanchesapla=31f;long previous=ES3Cloud.OynadigiTumZamanSaniyesi;Call(m,"Update");
   Check(r,GameManager.basarimlar==11f&&Basarimlar.eklendi,"in-battle state freezes achievement timer/save");
   Check(r,Get<float>(m,"saveit")== (float)(31f+dt)&&Get<float>(m,"savednew")==0f,"in-battle state accumulates cache timer and defers disk flush");
   Check(r,ES3Cloud.OynadigiTumZamanSaniyesi==unchecked(previous+1)&&m.timekazanchesapla==0f,"playedtime interval continues during battle");
   m.warController.savastayim=false;Call(m,"Update");Check(r,GameManager.basarimlar==0f&&!Basarimlar.eklendi&&Get<float>(m,"saveit")==0f,"returning home consumes pending achievement/cache save intervals");
   // Preserve source promotion gating with existing non-granting OpenOffer stub.
   GameManager.GuideDone=true;GameManager.Level=5;Set(m,"ilk30saniye",true);Set(m,"starttansonraac",0);m.timekazanchesapla=31f;Call(m,"Update");Check(r,Get<int>(m,"starttansonraac")==0&&!OneTimeOffer.BuGunStarterAcildi,"level<6 preserves original promotion gate");
   GameManager.Level=6;m.timekazanchesapla=31f;Call(m,"Update");Check(r,Get<int>(m,"starttansonraac")==1&&!OneTimeOffer.BuGunStarterAcildi,"eligible second interval increments original counter without opening");
   m.timekazanchesapla=31f;Call(m,"Update");Check(r,Get<int>(m,"starttansonraac")==2&&!OneTimeOffer.BuGunStarterAcildi,"PageAcildi false suppresses promotion while preserving counter");
   GameManager.PageAcildi=true;ES3.Save<bool>("StarterPack",false);m.timekazanchesapla=31f;Call(m,"Update");Check(r,OneTimeOffer.BuGunStarterAcildi&&Get<int>(m,"starttansonraac")==3&&!ES3.Load<bool>("StarterPack"),"existing StarterPack key skips offer but marks original local seen flag, without grant");
   m.timekazanchesapla=31f;Call(m,"Update");Check(r,Get<int>(m,"starttansonraac")==3,"local seen flag suppresses further promotion counter increments");
   OneTimeOffer.BuGunStarterAcildi=false;GameManager.GuideDone=false;Set(m,"starttansonraac",0);m.timekazanchesapla=31f;Call(m,"Update");Check(r,Get<int>(m,"starttansonraac")==0&&!OneTimeOffer.BuGunStarterAcildi,"unfinished guide preserves original promotion gate");
   ES3.DeleteKey("StarterPack");GameManager.GuideDone=true;Set(m,"starttansonraac",1);m.timekazanchesapla=31f;Call(m,"Update");Check(r,OneTimeOffer.BuGunStarterAcildi&&!ES3.KeyExists("StarterPack"),"eligible existing OpenOffer stub grants nothing and creates no purchase key");
   r.sourceRules.Add("Only GameManager.Update restored. Existing SaveCacheToDisk and pause/quit lifecycle are untouched; no bilgitimer write.");r.sourceRules.Add("Time.deltaTime is original scaled time; first long counter increments1 per>30 interval, exactly as native. SDK IsActive/OpenOffer boundary remains existing offline stub.");
  }catch(Exception e){r.failures.Add(e.ToString());}finally{foreach(var kv in saved)kv.Key.SetValue(null,kv.Value);OfflineKeyStore.SetVerificationRoot(null);UnityEngine.Object.DestroyImmediate(root);}
  r.passed=r.failures.Count==0;File.WriteAllText(Path.Combine(r.testRoot,"main-loop-results.json"),JsonUtility.ToJson(r,true));Debug.Log("MainLoopVerification checks="+r.checks+" passed="+r.passed+" root="+r.testRoot);return r;
 }
}}
