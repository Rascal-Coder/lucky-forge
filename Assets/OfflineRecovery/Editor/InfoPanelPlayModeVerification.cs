using System;using System.Collections.Generic;using System.IO;using System.Linq;using System.Reflection;using TMPro;using UnityEditor;using UnityEditor.SceneManagement;using UnityEngine;using UnityEngine.SceneManagement;
namespace LuckyForge.Offline.Editor {
[InitializeOnLoad] public static class InfoPanelPlayModeVerification {
 const string Key="LuckyForgeRecovery.InfoPanelPlayModeRoot";
 [Serializable] public class Result{public bool passed;public int checks;public int totalOriginalAnimatorCount;public string testRoot;public string sourcePath="Canvases/TopCanvasJobs/TopCanvas/CurrencyCollected";public List<string> failures=new List<string>();public List<string> controllers=new List<string>();public List<string> runtimeErrors=new List<string>();public string note="Actual original CurrencyCollectedUi clone contains17 Animators (root+8unit+8canvastekliobj). Expected controllers select only the8 native-controlled third ancestors of the8 TMP amount fields. All17 original components stay untouched. Source StartCoroutine/WaitForSeconds/Update used; no manually advanced enumerator. Does not assert physical mouse input or full campaign.";}
 static Result result;static CurrencyCollectedUi popup;static Animator[] animators;static int phase;static float phaseStarted;static double deadline;static bool finishing;
 static InfoPanelPlayModeVerification(){if(string.IsNullOrEmpty(SessionState.GetString(Key,"")))return;Subscribe();}
 static string Root=>SessionState.GetString(Key,"");
 static void Subscribe(){EditorApplication.update-=Tick;EditorApplication.update+=Tick;EditorApplication.playModeStateChanged-=OnMode;EditorApplication.playModeStateChanged+=OnMode;Application.logMessageReceived-=OnLog;Application.logMessageReceived+=OnLog;deadline=EditorApplication.timeSinceStartup+60;}
 static void Check(bool ok,string s){result.checks++;if(!ok)result.failures.Add(s);}
 static void OnLog(string condition,string stack,LogType type){if(result!=null&&(type==LogType.Error||type==LogType.Exception||type==LogType.Assert))result.runtimeErrors.Add(condition+"\n"+stack);}
 public static void RunBatch(){
  if(EditorApplication.isPlayingOrWillChangePlaymode)throw new InvalidOperationException("Requires fresh non-playing Editor process");
  string root=Path.Combine(Path.GetTempPath(),"LuckyForgeInfoPanelPlayModeChecks",Guid.NewGuid().ToString("N"));Directory.CreateDirectory(root);SessionState.SetString(Key,root);
  result=new Result{testRoot=root};
  var original=EditorSceneManager.OpenScene("Assets/Scenes/Sahne.unity",OpenSceneMode.Single);
  Transform source=original.GetRootGameObjects().Select(g=>g.transform).Single(t=>t.name=="Canvases").Find("TopCanvasJobs/TopCanvas/CurrencyCollected");
  if(source==null||source.GetComponent<CurrencyCollectedUi>()==null)throw new InvalidOperationException("Exact original popup hierarchy missing");
  var harness=EditorSceneManager.NewScene(NewSceneSetup.EmptyScene,NewSceneMode.Additive);
  var cloned=UnityEngine.Object.Instantiate(source.gameObject);cloned.name="OriginalCurrencyCollectedUi_PlayModeClone";cloned.SetActive(false);SceneManager.MoveGameObjectToScene(cloned,harness);
  var canvas=new GameObject("isolated-original-popup-canvas",typeof(RectTransform),typeof(Canvas));SceneManager.MoveGameObjectToScene(canvas,harness);canvas.GetComponent<Canvas>().renderMode=RenderMode.ScreenSpaceOverlay;cloned.transform.SetParent(canvas.transform,false);
  var sgo=new GameObject("isolated-disabled-SoundManager");sgo.SetActive(false);SceneManager.MoveGameObjectToScene(sgo,harness);var sound=sgo.AddComponent<SoundManager>();sound.enabled=false;
  // Remains disabled; the test assigns singleton explicitly after domain reload.
  result.totalOriginalAnimatorCount=cloned.GetComponentsInChildren<Animator>(true).Length;
  foreach(var a in Texts(cloned.GetComponent<CurrencyCollectedUi>()).Select(t=>t.transform.parent.parent.parent.GetComponent<Animator>()))result.controllers.Add(AssetDatabase.GetAssetPath(a.runtimeAnimatorController));
  File.WriteAllText(Path.Combine(root,"setup.json"),JsonUtility.ToJson(result,true));
  EditorSceneManager.CloseScene(original,true);SceneManager.SetActiveScene(harness);
  string folder="Assets/OfflineRecovery/Generated";Directory.CreateDirectory(folder);EditorSceneManager.SaveScene(harness,folder+"/InfoPanelPlayModeHarness.unity");
  Subscribe();EditorApplication.isPlaying=true;
 }
 static TextMeshProUGUI[] Texts()=>Texts(popup);
 static TextMeshProUGUI[] Texts(CurrencyCollectedUi p)=>new[]{p.coinT,p.weaponT,p.mistikT,p.crystalT,p.EnerjiT,p.talentT,p.passstarT,p.zarT};
 static void OnMode(PlayModeStateChange state){if(state!=PlayModeStateChange.EnteredEditMode||string.IsNullOrEmpty(Root))return;EditorApplication.delayCall+=Exit;}
 static void Tick(){
  if(string.IsNullOrEmpty(Root))return;
  if(EditorApplication.timeSinceStartup>deadline){if(result==null)result=new Result{testRoot=Root};result.failures.Add("Actual PlayMode source coroutine timed out");Finish();return;}
  if(!EditorApplication.isPlaying||EditorApplication.isPaused||finishing)return;
  try{
   if(phase==0){
    result=JsonUtility.FromJson<Result>(File.ReadAllText(Path.Combine(Root,"setup.json")));Time.timeScale=1f;
    OfflineKeyStore.SetVerificationRoot(Path.Combine(Root,"Profile"));GameManager.Language=0;Lang.currentLang=null;
    popup=UnityEngine.Object.FindObjectsByType<CurrencyCollectedUi>(FindObjectsInactive.Include,FindObjectsSortMode.None).Single();
    SoundManager.instance=UnityEngine.Object.FindObjectsByType<SoundManager>(FindObjectsInactive.Include,FindObjectsSortMode.None).Single();
    animators=Texts().Select(t=>t.transform.parent.parent.parent.GetComponent<Animator>()).ToArray();
    Check(animators.Length==8&&animators.All(a=>a!=null&&a.runtimeAnimatorController!=null)&&result.controllers.Count==8&&result.controllers.All(s=>!string.IsNullOrEmpty(s))&&animators.Select(a=>AssetDatabase.GetAssetPath(a.runtimeAnimatorController)).SequenceEqual(result.controllers)&&result.totalOriginalAnimatorCount==17&&popup.GetComponentsInChildren<Animator>(true).Length==17,"all8 exact native-controlled original Animator references/controllers survived source clone; all17 original Animators retained");
    Check(Texts().All(t=>t!=null)&&popup.obtained!=null,"all9 original serialized TMP references bound");
    popup.GiveRewardUI(1234,2,3,4,5,6,7,8,true);phaseStarted=Time.time;
    Check(popup.gameObject.activeSelf&&Texts().All(t=>t.transform.parent.parent.parent.gameObject.activeSelf),"real source GiveRewardUI shows all8 positive original reward rows");
    Check(Texts().Select(t=>t.text).SequenceEqual(new[]{"1,234","2","3","4","5","6","7","8"}),"real source8 amounts formatted without changing resources");
    Check(popup.obtained.text==Lang.Get.lv+GameManager.Level.ToString()+" "+Lang.Get.Rewards+"!","original chapter reward obtained header");
    Check(animators[0].enabled&&animators.Skip(1).All(a=>!a.enabled),"real StartCoroutine immediately enables first row then yields0.3s");
    popup.CloseRewardUi();Check(popup.gameObject.activeSelf,"actual immediate original close blocked by OnEnable0.2s cooldown");phase=1;
   }else if(phase==1&&Time.time-phaseStarted>=0.36f){
    Check(animators[0].enabled&&animators[1].enabled,"real WaitForSeconds resumed source coroutine and enabled second row");phase=2;
   }else if(phase==2&&Time.time-phaseStarted>=2.8f){
    Check(animators.All(a=>a.enabled),"actual source coroutine naturally enabled all8 original Animators");
    popup.CloseRewardUi();Check(!popup.gameObject.activeSelf&&animators.All(a=>!a.enabled),"actual Update cooldown completion allows close and disables all8 original Animators");
    popup.GiveRewardUI(0,2,0,4,0,6,0,8,false);phaseStarted=Time.time;
    Check(Texts().Select(t=>t.transform.parent.parent.parent.gameObject.activeSelf).SequenceEqual(new[]{false,true,false,true,false,true,false,true}),"source mixed payout hides exactly zero-valued rows");
    Check(popup.obtained.text==Lang.Get.obtained&&animators[1].enabled&&animators.Where((a,i)=>i!=1).All(a=>!a.enabled),"normal obtained header and coroutine skips first absent row without artificial delay");phase=3;
   }else if(phase==3&&Time.time-phaseStarted>=1.6f){
    Check(animators.Select(a=>a.enabled).SequenceEqual(new[]{false,true,false,true,false,true,false,true}),"actual source scheduler enables only4 requested mixed rows");
    popup.CloseRewardUi();Check(!popup.gameObject.activeSelf&&animators.All(a=>!a.enabled),"mixed source popup closes and disables all8 Animators");
    Check(Currencys.Coin==0&&Currencys.Crystal==0&&Currencys.Energy==0,"presentation-only calls do not grant resources");
    Check(!Directory.Exists(Path.Combine(Root,"Profile"))||Directory.GetFiles(Path.Combine(Root,"Profile"),"*.offline.json").Length==0,"presentation-only chain writes no physical resource store");Finish();
   }
  }catch(Exception e){if(result==null)result=new Result{testRoot=Root};result.failures.Add(e.ToString());Finish();}
 }
 static void Finish(){if(finishing)return;finishing=true;result.passed=result.failures.Count==0&&result.runtimeErrors.Count==0;File.WriteAllText(Path.Combine(Root,"info-panel-playmode-results.json"),JsonUtility.ToJson(result,true));Debug.Log("InfoPanelPlayMode checks="+result.checks+" passed="+result.passed+" root="+Root);if(EditorApplication.isPlayingOrWillChangePlaymode)EditorApplication.isPlaying=false;else Exit();}
 static void Exit(){if(string.IsNullOrEmpty(Root))return;string p=Path.Combine(Root,"info-panel-playmode-results.json");if(!File.Exists(p))return;var r=JsonUtility.FromJson<Result>(File.ReadAllText(p));SessionState.EraseString(Key);EditorApplication.Exit(r.passed?0:1);}
}
}
