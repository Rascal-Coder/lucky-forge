using System;using System.Collections.Generic;using System.IO;using System.Linq;using System.Reflection;using TMPro;using UnityEditor;using UnityEngine;using UnityEngine.UI;
namespace LuckyForge.Offline.Editor{
public static class WaveRewardLifecycleVerification{
 [Serializable]public class Result{public bool playMode;public bool passed;public int checks;public string testRoot;public string saveFile;public string rawCoin;public string rawDataCoin;public string coinBeforeSaveR;public string dataCoinBeforeSaveR;public string parsedCoinR;public string parsedDataCoinR;public string coinAfterReloadR;public string dataCoinAfterReloadR;public string freshCoinBeforeR;public string freshCoinAfterR;public List<string> failures=new List<string>();public List<string> sourceRules=new List<string>();}
 static void Check(Result r,bool ok,string label){r.checks++;if(!ok)r.failures.Add(label);}
 static GameObject Child(Transform parent,string name){var g=new GameObject(name,typeof(RectTransform));g.transform.SetParent(parent,false);return g;}
 static T Add<T>(Transform p,string n)where T:Component=>Child(p,n).AddComponent<T>();
 static object Call(object obj,string name,params object[] args)=>obj.GetType().GetMethod(name,BindingFlags.Instance|BindingFlags.NonPublic|BindingFlags.Public).Invoke(obj,args);
 static void Set(object obj,string name,object value)=>obj.GetType().GetField(name,BindingFlags.Instance|BindingFlags.NonPublic|BindingFlags.Public).SetValue(obj,value);
 static double DataCoin()=>(double)typeof(Currencys).GetField("DataCoin",BindingFlags.Static|BindingFlags.NonPublic).GetValue(null);
 static string RoundTrip(double value)=>value.ToString("R",System.Globalization.CultureInfo.InvariantCulture);
 static void Flush(Currencys driver){
  // The original Coin/Crystal/Energy wrappers schedule timer-based persistence.
  // This synchronous PlayMode fixture advances those original Update branches explicitly before the next frame.
  foreach(string name in new[]{"SaveCoinTimer","SaveCrystalTimer","SaveEnergyTimer"})typeof(Currencys).GetField(name,BindingFlags.Static|BindingFlags.NonPublic).SetValue(null,-1f);
  Call(driver,"Update");
  var disk=new ES3Settings("medupac.es3",ES3.Location.File);ES3.StoreCachedFile("medupac.es3",disk);OfflineKeyStore.ResetMemoryForVerification();ES3.CacheFile("medupac.es3",disk);
 }
 static void Zero(){Currencys.CoinFitle(0);Currencys.CrystalFitle(0);Currencys.MistikTokenFitle(0);Currencys.TalentScrollFitle(0);Currencys.WeaponTokenFitle(0);Currencys.EnergyFitle(0);Currencys.EventDiceFitle(0);}
 static BolumOdulleri Fixture(Transform root){
  var m=Add<BolumOdulleri>(root,"chapter-wave-rewards");m.es3KeyPrefix="WaveOdul_";m.es3BolumKey="BolumOdulReset";
  m.portal=Child(root,"portal").transform;m.cameraHandler=Add<CameraHandler>(root,"map-camera");m.cameraHandler.camera=Add<Camera>(root,"camera");
  m.canvasJobs=Add<CanvasJobs>(root,"canvas");m.canvasJobs.goldyokbasic=Child(root,"not-reached");m.canvasJobs.goldyokbasic.SetActive(false);
  m.collectedUi=InfoPanelFixtureSupport.CreateRewardPopup(root);m.waveRewardBoxes=new List<GameObject>();
  for(int i=0;i<20;i++){
   var box=Child(m.transform,"wave-box"+i);m.waveRewardBoxes.Add(box);
   var holder=Child(box.transform,"button");holder.AddComponent<Button>();holder.AddComponent<TextMeshProUGUI>();
   for(int c=0;c<5;c++)Child(holder.transform,"holder-child"+c);
   var panel=Child(box.transform,"panel");var outer=Child(panel.transform,"outer");var list=Child(outer.transform,"reward-list");Child(panel.transform,"locked");
   foreach(string key in new[]{"coin","crystal","mistik","talent","weapon","energy","enerji","zar","unknown"}){
    var item=Child(list.transform,key);item.AddComponent<TextMeshProUGUI>();var icon=Child(item.transform,"icon");Child(icon.transform,"reach");
   }
   int wave=(i+1)*5;holder.GetComponent<Button>().onClick.AddListener(()=>m.CheckAndGiveWaveRewards(wave));
  }
  HomeWorldFixtureSupport.Setup(m,root);
  return m;
 }
 static Transform Panel(BolumOdulleri m,int i)=>m.waveRewardBoxes[i].transform.GetChild(1);
 static Transform Item(BolumOdulleri m,int i,string key)=>Panel(m,i).GetChild(0).GetChild(0).Find(key);
 static void VerifyNativeOracle(Result r,BolumOdulleri m){
 // GENERATED_BINARY32_ORACLE
Zero();GameManager.Level=0;Call(m,"GiveRewards",new List<WaveRewardGroup>{new WaveRewardGroup{wave=5,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=2}}}},false);
Check(r,Currencys.Coin==180.0d,"binary32 oracle level0 amount2");
Zero();GameManager.Level=0;Call(m,"GiveRewards",new List<WaveRewardGroup>{new WaveRewardGroup{wave=5,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=5}}}},false);
Check(r,Currencys.Coin==450.0000305175781d,"binary32 oracle level0 amount5");
Zero();GameManager.Level=1;Call(m,"GiveRewards",new List<WaveRewardGroup>{new WaveRewardGroup{wave=5,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=1}}}},false);
Check(r,Currencys.Coin==180.0d,"binary32 oracle level1 amount1");
Zero();GameManager.Level=2;Call(m,"GiveRewards",new List<WaveRewardGroup>{new WaveRewardGroup{wave=5,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=7}}}},false);
Check(r,Currencys.Coin==1890.0001220703125d,"binary32 oracle level2 amount7");
Zero();GameManager.Level=7;Call(m,"GiveRewards",new List<WaveRewardGroup>{new WaveRewardGroup{wave=5,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=13}}}},false);
Check(r,Currencys.Coin==9360.0d,"binary32 oracle level7 amount13");
Zero();GameManager.Level=14;Call(m,"GiveRewards",new List<WaveRewardGroup>{new WaveRewardGroup{wave=5,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=50}}}},false);
Check(r,Currencys.Coin==67500.0d,"binary32 oracle level14 amount50");
Zero();GameManager.Level=100;Call(m,"GiveRewards",new List<WaveRewardGroup>{new WaveRewardGroup{wave=5,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=99}}}},false);
Check(r,Currencys.Coin==899910.0625d,"binary32 oracle level100 amount99");
Zero();GameManager.Level=10000;Call(m,"GiveRewards",new List<WaveRewardGroup>{new WaveRewardGroup{wave=5,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=99}}}},false);
Check(r,Currencys.Coin==89108912.0d,"binary32 oracle level10000 amount99");
Zero();GameManager.Level=21474836;Call(m,"GiveRewards",new List<WaveRewardGroup>{new WaveRewardGroup{wave=5,rewards=new List<WaveReward>{new WaveReward{rewardType="coin",amount=100}}}},false);
Check(r,Currencys.Coin==4680.0d,"binary32 oracle level21474836 amount100");
Zero();GameManager.Level=0;var groups0=(List<WaveRewardGroup>)Call(m,"GetWaveRewardGroupsForCurrentLevel",GameManager.Level);Call(m,"GiveRewards",groups0,false);
Check(r,Currencys.Coin==810.0000305175781d&&Currencys.Crystal==0&&Currencys.MistikToken==0&&Currencys.TalentScroll==0&&Currencys.WeaponToken==0&&Currencys.Energy==0&&Currencys.EventDice==0,"full native tablebatch level0 exact Coin and all6 resource totals");
Zero();GameManager.Level=1;var groups1=(List<WaveRewardGroup>)Call(m,"GetWaveRewardGroupsForCurrentLevel",GameManager.Level);Call(m,"GiveRewards",groups1,false);
Check(r,Currencys.Coin==2340.0d&&Currencys.Crystal==0&&Currencys.MistikToken==0&&Currencys.TalentScroll==100&&Currencys.WeaponToken==0&&Currencys.Energy==0&&Currencys.EventDice==0,"full native tablebatch level1 exact Coin and all6 resource totals");
Zero();GameManager.Level=2;var groups2=(List<WaveRewardGroup>)Call(m,"GetWaveRewardGroupsForCurrentLevel",GameManager.Level);Call(m,"GiveRewards",groups2,false);
Check(r,Currencys.Coin==1350.0000610351562d&&Currencys.Crystal==50&&Currencys.MistikToken==0&&Currencys.TalentScroll==50&&Currencys.WeaponToken==100&&Currencys.Energy==0&&Currencys.EventDice==0,"full native tablebatch level2 exact Coin and all6 resource totals");
Zero();GameManager.Level=3;var groups3=(List<WaveRewardGroup>)Call(m,"GetWaveRewardGroupsForCurrentLevel",GameManager.Level);Call(m,"GiveRewards",groups3,false);
Check(r,Currencys.Coin==1800.0d&&Currencys.Crystal==50&&Currencys.MistikToken==0&&Currencys.TalentScroll==100&&Currencys.WeaponToken==150&&Currencys.Energy==0&&Currencys.EventDice==0,"full native tablebatch level3 exact Coin and all6 resource totals");
Zero();GameManager.Level=4;var groups4=(List<WaveRewardGroup>)Call(m,"GetWaveRewardGroupsForCurrentLevel",GameManager.Level);Call(m,"GiveRewards",groups4,false);
Check(r,Currencys.Coin==1800.0001220703125d&&Currencys.Crystal==100&&Currencys.MistikToken==5&&Currencys.TalentScroll==150&&Currencys.WeaponToken==200&&Currencys.Energy==0&&Currencys.EventDice==0,"full native tablebatch level4 exact Coin and all6 resource totals");
Zero();GameManager.Level=5;var groups5=(List<WaveRewardGroup>)Call(m,"GetWaveRewardGroupsForCurrentLevel",GameManager.Level);Call(m,"GiveRewards",groups5,false);
Check(r,Currencys.Coin==8100.0d&&Currencys.Crystal==950&&Currencys.MistikToken==0&&Currencys.TalentScroll==50&&Currencys.WeaponToken==50&&Currencys.Energy==0&&Currencys.EventDice==0,"full native tablebatch level5 exact Coin and all6 resource totals");
Zero();GameManager.Level=6;var groups6=(List<WaveRewardGroup>)Call(m,"GetWaveRewardGroupsForCurrentLevel",GameManager.Level);Call(m,"GiveRewards",groups6,false);
Check(r,Currencys.Coin==7560.0d&&Currencys.Crystal==350&&Currencys.MistikToken==5&&Currencys.TalentScroll==100&&Currencys.WeaponToken==200&&Currencys.Energy==0&&Currencys.EventDice==0,"full native tablebatch level6 exact Coin and all6 resource totals");
Zero();GameManager.Level=7;var groups7=(List<WaveRewardGroup>)Call(m,"GetWaveRewardGroupsForCurrentLevel",GameManager.Level);Call(m,"GiveRewards",groups7,false);
Check(r,Currencys.Coin==10800.000244140625d&&Currencys.Crystal==300&&Currencys.MistikToken==10&&Currencys.TalentScroll==100&&Currencys.WeaponToken==50&&Currencys.Energy==0&&Currencys.EventDice==0,"full native tablebatch level7 exact Coin and all6 resource totals");
Zero();GameManager.Level=8;var groups8=(List<WaveRewardGroup>)Call(m,"GetWaveRewardGroupsForCurrentLevel",GameManager.Level);Call(m,"GiveRewards",groups8,false);
Check(r,Currencys.Coin==64800.0029296875d&&Currencys.Crystal==900&&Currencys.MistikToken==10&&Currencys.TalentScroll==0&&Currencys.WeaponToken==100&&Currencys.Energy==5&&Currencys.EventDice==0,"full native tablebatch level8 exact Coin and all6 resource totals");
Zero();GameManager.Level=9;var groups9=(List<WaveRewardGroup>)Call(m,"GetWaveRewardGroupsForCurrentLevel",GameManager.Level);Call(m,"GiveRewards",groups9,false);
Check(r,Currencys.Coin==17100.000854492188d&&Currencys.Crystal==350&&Currencys.MistikToken==0&&Currencys.TalentScroll==200&&Currencys.WeaponToken==200&&Currencys.Energy==0&&Currencys.EventDice==13,"full native tablebatch level9 exact Coin and all6 resource totals");
Zero();GameManager.Level=10;var groups10=(List<WaveRewardGroup>)Call(m,"GetWaveRewardGroupsForCurrentLevel",GameManager.Level);Call(m,"GiveRewards",groups10,false);
Check(r,Currencys.Coin==72270.00170898438d&&Currencys.Crystal==600&&Currencys.MistikToken==10&&Currencys.TalentScroll==0&&Currencys.WeaponToken==350&&Currencys.Energy==0&&Currencys.EventDice==4,"full native tablebatch level10 exact Coin and all6 resource totals");
Zero();GameManager.Level=11;var groups11=(List<WaveRewardGroup>)Call(m,"GetWaveRewardGroupsForCurrentLevel",GameManager.Level);Call(m,"GiveRewards",groups11,false);
Check(r,Currencys.Coin==49680.0d&&Currencys.Crystal==650&&Currencys.MistikToken==15&&Currencys.TalentScroll==50&&Currencys.WeaponToken==200&&Currencys.Energy==0&&Currencys.EventDice==2,"full native tablebatch level11 exact Coin and all6 resource totals");
Zero();GameManager.Level=12;var groups12=(List<WaveRewardGroup>)Call(m,"GetWaveRewardGroupsForCurrentLevel",GameManager.Level);Call(m,"GiveRewards",groups12,false);
Check(r,Currencys.Coin==65520.0d&&Currencys.Crystal==600&&Currencys.MistikToken==10&&Currencys.TalentScroll==150&&Currencys.WeaponToken==150&&Currencys.Energy==30&&Currencys.EventDice==8,"full native tablebatch level12 exact Coin and all6 resource totals");
Zero();GameManager.Level=13;var groups13=(List<WaveRewardGroup>)Call(m,"GetWaveRewardGroupsForCurrentLevel",GameManager.Level);Call(m,"GiveRewards",groups13,false);
Check(r,Currencys.Coin==120960.0029296875d&&Currencys.Crystal==110&&Currencys.MistikToken==15&&Currencys.TalentScroll==250&&Currencys.WeaponToken==200&&Currencys.Energy==0&&Currencys.EventDice==0,"full native tablebatch level13 exact Coin and all6 resource totals");
Zero();GameManager.Level=14;var groups14=(List<WaveRewardGroup>)Call(m,"GetWaveRewardGroupsForCurrentLevel",GameManager.Level);Call(m,"GiveRewards",groups14,false);
Check(r,Currencys.Coin==129600.0029296875d&&Currencys.Crystal==110&&Currencys.MistikToken==15&&Currencys.TalentScroll==250&&Currencys.WeaponToken==200&&Currencys.Energy==0&&Currencys.EventDice==0,"full native tablebatch level14 exact Coin and all6 resource totals");
Zero();GameManager.Level=15;var groups15=(List<WaveRewardGroup>)Call(m,"GetWaveRewardGroupsForCurrentLevel",GameManager.Level);Call(m,"GiveRewards",groups15,false);
Check(r,Currencys.Coin==197280.0068359375d&&Currencys.Crystal==90&&Currencys.MistikToken==15&&Currencys.TalentScroll==100&&Currencys.WeaponToken==300&&Currencys.Energy==0&&Currencys.EventDice==0,"full native tablebatch level15 exact Coin and all6 resource totals");
Zero();GameManager.Level=16;var groups16=(List<WaveRewardGroup>)Call(m,"GetWaveRewardGroupsForCurrentLevel",GameManager.Level);Call(m,"GiveRewards",groups16,false);
Check(r,Currencys.Coin==120870.00048828125d&&Currencys.Crystal==110&&Currencys.MistikToken==15&&Currencys.TalentScroll==0&&Currencys.WeaponToken==50&&Currencys.Energy==20&&Currencys.EventDice==15,"full native tablebatch level16 exact Coin and all6 resource totals");
Zero();GameManager.Level=17;var groups17=(List<WaveRewardGroup>)Call(m,"GetWaveRewardGroupsForCurrentLevel",GameManager.Level);Call(m,"GiveRewards",groups17,false);
Check(r,Currencys.Coin==207360.01171875d&&Currencys.Crystal==110&&Currencys.MistikToken==15&&Currencys.TalentScroll==200&&Currencys.WeaponToken==200&&Currencys.Energy==20&&Currencys.EventDice==0,"full native tablebatch level17 exact Coin and all6 resource totals");
Zero();GameManager.Level=18;var groups18=(List<WaveRewardGroup>)Call(m,"GetWaveRewardGroupsForCurrentLevel",GameManager.Level);Call(m,"GiveRewards",groups18,false);
Check(r,Currencys.Coin==116280.005859375d&&Currencys.Crystal==70&&Currencys.MistikToken==30&&Currencys.TalentScroll==200&&Currencys.WeaponToken==100&&Currencys.Energy==0&&Currencys.EventDice==11,"full native tablebatch level18 exact Coin and all6 resource totals");
Zero();GameManager.Level=19;var groups19=(List<WaveRewardGroup>)Call(m,"GetWaveRewardGroupsForCurrentLevel",GameManager.Level);Call(m,"GiveRewards",groups19,false);
Check(r,Currencys.Coin==172800.00756835938d&&Currencys.Crystal==110&&Currencys.MistikToken==15&&Currencys.TalentScroll==250&&Currencys.WeaponToken==200&&Currencys.Energy==0&&Currencys.EventDice==0,"full native tablebatch level19 exact Coin and all6 resource totals");
Zero();GameManager.Level=20;var groups20=(List<WaveRewardGroup>)Call(m,"GetWaveRewardGroupsForCurrentLevel",GameManager.Level);Call(m,"GiveRewards",groups20,false);
Check(r,Currencys.Coin==258930.0048828125d&&Currencys.Crystal==90&&Currencys.MistikToken==15&&Currencys.TalentScroll==100&&Currencys.WeaponToken==300&&Currencys.Energy==0&&Currencys.EventDice==0,"full native tablebatch level20 exact Coin and all6 resource totals");
Zero();GameManager.Level=21;var groups21=(List<WaveRewardGroup>)Call(m,"GetWaveRewardGroupsForCurrentLevel",GameManager.Level);Call(m,"GiveRewards",groups21,false);
Check(r,Currencys.Coin==156420.00170898438d&&Currencys.Crystal==110&&Currencys.MistikToken==15&&Currencys.TalentScroll==0&&Currencys.WeaponToken==50&&Currencys.Energy==20&&Currencys.EventDice==15,"full native tablebatch level21 exact Coin and all6 resource totals");
Zero();GameManager.Level=22;var groups22=(List<WaveRewardGroup>)Call(m,"GetWaveRewardGroupsForCurrentLevel",GameManager.Level);Call(m,"GiveRewards",groups22,false);
Check(r,Currencys.Coin==264960.00439453125d&&Currencys.Crystal==110&&Currencys.MistikToken==15&&Currencys.TalentScroll==200&&Currencys.WeaponToken==200&&Currencys.Energy==20&&Currencys.EventDice==0,"full native tablebatch level22 exact Coin and all6 resource totals");
Zero();GameManager.Level=23;var groups23=(List<WaveRewardGroup>)Call(m,"GetWaveRewardGroupsForCurrentLevel",GameManager.Level);Call(m,"GiveRewards",groups23,false);
Check(r,Currencys.Coin==146880.00244140625d&&Currencys.Crystal==70&&Currencys.MistikToken==30&&Currencys.TalentScroll==200&&Currencys.WeaponToken==100&&Currencys.Energy==0&&Currencys.EventDice==11,"full native tablebatch level23 exact Coin and all6 resource totals");
Zero();GameManager.Level=24;var groups24=(List<WaveRewardGroup>)Call(m,"GetWaveRewardGroupsForCurrentLevel",GameManager.Level);Call(m,"GiveRewards",groups24,false);
Check(r,Currencys.Coin==216000.00390625d&&Currencys.Crystal==110&&Currencys.MistikToken==15&&Currencys.TalentScroll==250&&Currencys.WeaponToken==200&&Currencys.Energy==0&&Currencys.EventDice==0,"full native tablebatch level24 exact Coin and all6 resource totals");
m.character=Child(m.transform,"character-position-check").transform;m.character.localPosition=new Vector3(1f,2f,3f);
m.bestSurvive=0;m.UpdateCharacterPosition();Check(r,m.character.localPosition.x==1f&&m.character.localPosition.y==2f&&m.character.localPosition.z==-23.0f,"original character local position wave0");
m.bestSurvive=5;m.UpdateCharacterPosition();Check(r,m.character.localPosition.x==1f&&m.character.localPosition.y==2f&&m.character.localPosition.z==10.0f,"original character local position wave5");
m.bestSurvive=6;m.UpdateCharacterPosition();Check(r,m.character.localPosition.x==1f&&m.character.localPosition.y==2f&&m.character.localPosition.z==30.0f,"original character local position wave6");
m.bestSurvive=10;m.UpdateCharacterPosition();Check(r,m.character.localPosition.x==1f&&m.character.localPosition.y==2f&&m.character.localPosition.z==50.0f,"original character local position wave10");
m.bestSurvive=15;m.UpdateCharacterPosition();Check(r,m.character.localPosition.x==1f&&m.character.localPosition.y==2f&&m.character.localPosition.z==85.94999694824219f,"original character local position wave15");
m.bestSurvive=20;m.UpdateCharacterPosition();Check(r,m.character.localPosition.x==1f&&m.character.localPosition.y==2f&&m.character.localPosition.z==126.0f,"original character local position wave20");
m.bestSurvive=25;m.UpdateCharacterPosition();Check(r,m.character.localPosition.x==1f&&m.character.localPosition.y==2f&&m.character.localPosition.z==165.0f,"original character local position wave25");
m.bestSurvive=30;m.UpdateCharacterPosition();Check(r,m.character.localPosition.x==1f&&m.character.localPosition.y==2f&&m.character.localPosition.z==203.10000610351562f,"original character local position wave30");
m.bestSurvive=35;m.UpdateCharacterPosition();Check(r,m.character.localPosition.x==1f&&m.character.localPosition.y==2f&&m.character.localPosition.z==241.14999389648438f,"original character local position wave35");
m.bestSurvive=40;m.UpdateCharacterPosition();Check(r,m.character.localPosition.x==1f&&m.character.localPosition.y==2f&&m.character.localPosition.z==279.5999755859375f,"original character local position wave40");
m.bestSurvive=45;m.UpdateCharacterPosition();Check(r,m.character.localPosition.x==1f&&m.character.localPosition.y==2f&&m.character.localPosition.z==318.6000061035156f,"original character local position wave45");
m.bestSurvive=50;m.UpdateCharacterPosition();Check(r,m.character.localPosition.x==1f&&m.character.localPosition.y==2f&&m.character.localPosition.z==357.0f,"original character local position wave50");
m.bestSurvive=55;m.UpdateCharacterPosition();Check(r,m.character.localPosition.x==1f&&m.character.localPosition.y==2f&&m.character.localPosition.z==396.54998779296875f,"original character local position wave55");
m.bestSurvive=60;m.UpdateCharacterPosition();Check(r,m.character.localPosition.x==1f&&m.character.localPosition.y==2f&&m.character.localPosition.z==435.0f,"original character local position wave60");
m.bestSurvive=65;m.UpdateCharacterPosition();Check(r,m.character.localPosition.x==1f&&m.character.localPosition.y==2f&&m.character.localPosition.z==472.54998779296875f,"original character local position wave65");
m.bestSurvive=70;m.UpdateCharacterPosition();Check(r,m.character.localPosition.x==1f&&m.character.localPosition.y==2f&&m.character.localPosition.z==511.0f,"original character local position wave70");
m.bestSurvive=75;m.UpdateCharacterPosition();Check(r,m.character.localPosition.x==1f&&m.character.localPosition.y==2f&&m.character.localPosition.z==549.75f,"original character local position wave75");
m.bestSurvive=80;m.UpdateCharacterPosition();Check(r,m.character.localPosition.x==1f&&m.character.localPosition.y==2f&&m.character.localPosition.z==588.0f,"original character local position wave80");
m.bestSurvive=81;m.UpdateCharacterPosition();Check(r,m.character.localPosition.x==1f&&m.character.localPosition.y==2f&&m.character.localPosition.z==599.3190307617188f,"original character local position wave81");
m.bestSurvive=100;m.UpdateCharacterPosition();Check(r,m.character.localPosition.x==1f&&m.character.localPosition.y==2f&&m.character.localPosition.z==739.9000244140625f,"original character local position wave100");
GameManager.Level=0;m.UpdateMaxZForCurrentLevel();Check(r,m.cameraHandler.maxZ==-125.5f&&m.portal.position.z==148.8000030517578f,"native level0 camera maxZ and portal position independent binary32 oracle");
 }
 public static Result RunChecks(string suppliedRoot=null){
  var r=new Result{testRoot=Path.GetFullPath(suppliedRoot??Path.Combine(Path.GetTempPath(),"LuckyForgeWaveRewardChecks",Guid.NewGuid().ToString("N")))};
  r.playMode=Application.isPlaying;if(!r.playMode){r.failures.Add("Requires isolated real PlayMode; use VisualFixChecks.RunWaveBatch or RunIntegrationBatch.");return r;}Directory.CreateDirectory(r.testRoot);
  var saved=new Dictionary<FieldInfo,object>();foreach(var type in new[]{typeof(Currencys),typeof(GameManager),typeof(Basarimlar),typeof(GunlukGorevler)})foreach(var f in type.GetFields(BindingFlags.Static|BindingFlags.Public|BindingFlags.NonPublic))if(!f.IsLiteral&&!f.IsInitOnly)saved[f]=f.GetValue(null);
  var oldSound=SoundManager.instance;var root=new GameObject("WaveRewardLifecycleVerification");root.SetActive(false);OfflineKeyStore.SetVerificationRoot(r.testRoot);
  try{
   SoundManager.instance=null;GameManager.NewUserTapNation=true;GameManager.Level=0;GameManager.BestSurvive=0;
   // Exact mandatory first-install string keys from original LoadingPage.SetData.
   ES3.Save<string>("Coin","5");ES3.Save<string>("DataCoin","10");
   // Other wave currencies have zero-fallback original LoadStart methods. Explicit
   // zero keys make this isolated fixture valid before exercising scheduled saves.
   foreach(string key in new[]{"Crystal","DataCrystal","Energy","DataEnergy","TalentScroll","DataTalentScroll","MistikToken","DataMistikToken","WeaponToken","DataWeaponToken","EventDice","DataEventDice"})ES3.Save<int>(key,0);
   var currencyDriver=Add<Currencys>(root.transform,"original-deferred-currency-save-driver");
   Basarimlar.basarilar=new List<BasariGorev>();GunlukGorevler.tasks=new List<GunlukGorev>();Zero();
   var m=Fixture(root.transform);Call(m,"OnEnable");Check(r,!m.portal.gameObject.activeSelf,"source initial portal gate level>4 before Start");Call(m,"Start");
   Check(r,m.manualLevelRewards.Count==18&&m.manualLevelRewards.Sum(t=>t.Count)==226&&m.manualLevelRewards.Sum(t=>t.Sum(g=>g.rewards.Count))==248,"all18 native tables226 wave groups248 rewards recovered");
   Check(r,m.currentLevel==0&&m.bestSurvive==0&&m.waveRewardBoxes.Take(2).All(g=>g.activeSelf)&&m.waveRewardBoxes.Skip(2).All(g=>!g.activeSelf),"level0 original2 reward groups active,18 extra boxes hidden");
   Check(r,m.waveRewardBoxes[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text=="5"&&m.waveRewardBoxes[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text=="10","actual UI wave labels5/10");
   Check(r,Item(m,0,"coin").gameObject.activeSelf&&!Item(m,0,"crystal").gameObject.activeSelf&&Panel(m,0).GetChild(1).gameObject.activeSelf,"reward icon type filtering and below-wave lock");
   m.CheckAndGiveWaveRewards(5);Check(r,Currencys.Coin==0&&!ES3.KeyExists("WaveOdul_0_5")&&m.canvasJobs.goldyokbasic.activeSelf,"unreached wave refuses reward and shows source warning");
   GameManager.BestSurvive=10;m.bestSurvive=10;m.cameraHandler.draggingInfo=true;m.CheckAndGiveWaveRewards(10);Check(r,Currencys.Coin==0&&!ES3.KeyExists("WaveOdul_0_10"),"camera drag rejects physical UI click callback");m.cameraHandler.draggingInfo=false;
   m.UpdateWaveRewardUI();Check(r,!Panel(m,0).GetChild(1).gameObject.activeSelf&&Item(m,0,"coin").GetChild(0).GetChild(0).gameObject.activeSelf,"reached wave unlock indicator and reward reach indicator");
   m.waveRewardBoxes[1].transform.GetChild(0).GetComponent<Button>().onClick.Invoke();
   Check(r,Currencys.Coin==810.000030517578125d,"native level0 batch cumulative180+630.000030517578125 exact binary32 oracle");
   Check(r,ES3.Load<bool>("WaveOdul_0_5")&&ES3.Load<bool>("WaveOdul_0_10")&&!m.waveRewardBoxes[0].transform.GetChild(0).GetComponent<Button>().interactable&&!Panel(m,1).gameObject.activeSelf,"claim writes both original keys and disables both corresponding UI buttons");
   m.CheckAndGiveWaveRewards(10);Check(r,Currencys.Coin==810.000030517578125d,"duplicate batch awards nothing");
   Zero();m.es3KeyPrefix="separate_";m.CheckAndGiveWaveRewards(5);m.CheckAndGiveWaveRewards(10);Check(r,Currencys.Coin==630.000030517578125d,"source separate claims differ from batch by exactly180Coin");
   Zero();m.es3KeyPrefix="false-key_";ES3.Save<bool>("false-key_0_5",false);m.CheckAndGiveWaveRewards(5);Check(r,Currencys.Coin==0&&!ES3.Load<bool>("false-key_0_5"),"KeyExists false value still permanently counts claimed");
   m.es3KeyPrefix="WaveOdul_";Currencys.CoinFitle(810.000030517578125d);
   double originalCoin=Currencys.Coin,originalDataCoin=DataCoin();
   r.coinBeforeSaveR=RoundTrip(originalCoin);r.dataCoinBeforeSaveR=RoundTrip(originalDataCoin);
   // The original save uses culture-default Double.ToString(), not the R format.
   // Persisted expectations must follow that original string contract exactly.
   string expectedRawCoin=originalCoin.ToString(),expectedRawDataCoin=originalDataCoin.ToString();
   Flush(currencyDriver);r.rawCoin=ES3.Load<string>("Coin");r.rawDataCoin=ES3.Load<string>("DataCoin");
   double parsedCoin=double.Parse(r.rawCoin),parsedDataCoin=double.Parse(r.rawDataCoin);
   r.parsedCoinR=RoundTrip(parsedCoin);r.parsedDataCoinR=RoundTrip(parsedDataCoin);
   typeof(Currencys).GetField("<Coin>k__BackingField",BindingFlags.Static|BindingFlags.NonPublic).SetValue(null,0d);Currencys.LoadStartCoin();
   r.coinAfterReloadR=RoundTrip(Currencys.Coin);r.dataCoinAfterReloadR=RoundTrip(DataCoin());
   Check(r,r.rawCoin==expectedRawCoin&&r.rawDataCoin==expectedRawDataCoin&&Currencys.Coin==parsedCoin&&DataCoin()==parsedDataCoin&&ES3.Load<bool>("WaveOdul_0_5")&&ES3.Load<bool>("WaveOdul_0_10"),"physical store reload obeys original ToString/Parse contract and preserves both claim keys");
   r.freshCoinBeforeR=RoundTrip(Currencys.Coin);var m2=Fixture(root.transform);Call(m2,"Start");m2.bestSurvive=10;m2.CheckAndGiveWaveRewards(10);r.freshCoinAfterR=RoundTrip(Currencys.Coin);Check(r,Currencys.Coin==parsedCoin&&DataCoin()==parsedDataCoin&&r.freshCoinAfterR==r.freshCoinBeforeR&&!Panel(m2,0).gameObject.activeSelf&&!Panel(m2,1).gameObject.activeSelf,"fresh manager cannot regrant physically saved rewards");
   VerifyNativeOracle(r,m);
   // Keep the existing world alive: native OnEnable first moves the camera, then
   // BolumuYerlestir schedules old chunk destruction under real PlayMode.
   Zero();GameManager.Level=1;GameManager.BestSurvive=0;m.es3KeyPrefix="previous_";m.levelalindi=true;Call(m,"OnEnable");
   Check(r,Currencys.Coin==1620.00006103515625d&&ES3.KeyExists("previous_0_5")&&ES3.KeyExists("previous_0_10"),"previouschapter0 settlement uses current level1 multiplier and retains chapter0 keys");
   Check(r,!m.levelalindi&&m.bestSurvive==0&&!m.portal.gameObject.activeSelf,"source auto settlement resets flag/best UI without changing actual current level");
   double before=Currencys.Coin;Call(m,"OnEnable");Check(r,Currencys.Coin==before,"second OnEnable no completion flag grants no resources");
   GameManager.Level=2;m.es3KeyPrefix="previous-one_";ES3.Save<bool>("previous-one_1_5",false);Call(m,"EskiBolumOdulleri",100);Check(r,ES3.KeyExists("previous-one_1_20")&&!ES3.Load<bool>("previous-one_1_5"),"previous chapter claim skips existing false key and marks all remaining source groups");Call(m,"ResetWaveRewards");Check(r,!ES3.KeyExists("previous-one_1_5")&&!ES3.KeyExists("previous-one_1_20")&&ES3.KeyExists("previous_0_5"),"source cleanup deletes previouschapter>=1 keys only");
   GameManager.Level=5;Call(m,"OnEnable");Check(r,m.portal.gameObject.activeSelf,"source portal first activates level5");
   r.saveFile=OfflineKeyStore.PathFor();Flush(currencyDriver);Check(r,File.Exists(r.saveFile),"isolated physical wave reward store exists");
   r.sourceRules.Add("40 persistent original callbacks remain. KeyExists drives claim once per existing key; original previouschapter cleanup is preserved.");
   r.sourceRules.Add("Independent Python binary32 oracle and fixed exact expected doubles; cumulativeCoin behavior preserved. Layout/character positioning and popup animation outside this fixture.");
  }catch(Exception e){r.failures.Add(e.ToString());}finally{InfoPanelFixtureSupport.Dispose(root.transform);foreach(var kv in saved)kv.Key.SetValue(null,kv.Value);SoundManager.instance=oldSound;OfflineKeyStore.SetVerificationRoot(null);UnityEngine.Object.DestroyImmediate(root);}
  r.passed=r.failures.Count==0;File.WriteAllText(Path.Combine(r.testRoot,"wave-reward-results.json"),JsonUtility.ToJson(r,true));Debug.Log("WaveRewardLifecycleVerification checks="+r.checks+" passed="+r.passed+" root="+r.testRoot);return r;
 }
}}
