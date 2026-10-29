using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using TMPro;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public static class TaskLockVerification
{
    [Serializable]public sealed class Result{public bool passed;public int checks;public string source="actual Sahne Talent-tab LockedforTask configuration cloned for isolation; no asset edits";public List<string> failures=new List<string>();}
    static void Check(Result r,bool ok,string label){r.checks++;if(!ok)r.failures.Add(label);}
    static GameObject Child(GameObject owner,string name,bool active=true){var g=new GameObject(name);g.transform.SetParent(owner.transform);g.SetActive(active);return g;}
    static TextMeshProUGUI Label(GameObject owner,string name){var g=new GameObject(name,typeof(RectTransform),typeof(CanvasRenderer),typeof(TextMeshProUGUI));g.transform.SetParent(owner.transform);return g.GetComponent<TextMeshProUGUI>();}
    static void Enable(LockedforTask target){typeof(LockedforTask).GetMethod("OnEnable",BindingFlags.Instance|BindingFlags.NonPublic).Invoke(target,null);}
    static string PathOf(Transform t){string path=t.name;for(t=t.parent;t;t=t.parent)path=t.name+"/"+path;return path;}
    public static Result RunChecks()
    {
        var r=new Result();var root=new GameObject("TaskLockVerification");root.SetActive(false);var oldScene=SceneManager.GetActiveScene();var original=SceneManager.GetSceneByPath("Assets/Scenes/Sahne.unity");bool closeOriginal=!original.IsValid()||!original.isLoaded;
        int oldLevel=GameManager.Level,oldTime=AnalyticsTimeEvent.totalMinutes,oldLanguage=GameManager.Language,oldTask=Lang.TaskKacLazim;bool oldNew=GameManager.NewUserTapNation;float oldTimer=GameManager.bilgitimer;var oldArray=YeniButonAcildi.bulundu;var oldLang=Lang.currentLang;var oldSound=SoundManager.instance;var oldRandom=UnityEngine.Random.state;var rootField=typeof(OfflineKeyStore).GetField("verificationRoot",BindingFlags.Static|BindingFlags.NonPublic);string oldRoot=(string)rootField.GetValue(null);
        try{
            OfflineKeyStore.SetVerificationRoot(Path.Combine(Directory.GetParent(Application.dataPath).FullName,"Verification","TaskLockTests",Guid.NewGuid().ToString("N")));GameManager.Language=0;SoundManager.instance=root.AddComponent<SoundManager>();
            if(closeOriginal)original=EditorSceneManager.OpenScene("Assets/Scenes/Sahne.unity",OpenSceneMode.Additive);
            LockedforTask source=null;foreach(var l in Resources.FindObjectsOfTypeAll<LockedforTask>())if(l&&l.gameObject.scene==original&&PathOf(l.transform)=="Canvases/BottomCanvas/SafeArea/bottombtns/bottombtn (1)/LockedforTask (5)"){source=l;break;}
            Check(r,source&&source.LockedKac==3&&source.yenisistem&&source.VarsaKim==0,"actual original Talent lock has LockedKac3, new-system flag and silent notification index0");if(!source)throw new InvalidOperationException("Actual Talent lock configuration missing.");
            var tab=UnityEngine.Object.Instantiate(source.transform.parent.gameObject,root.transform,false);var target=tab.GetComponentInChildren<LockedforTask>(true);Check(r,target&&target.LockedKac==source.LockedKac&&target._kimiLockluyor&&target._kimiLockluyor.transform.IsChildOf(tab.transform)&&target.varsaimgkapat&&target.varsaimgkapat.transform.IsChildOf(tab.transform),"real clone preserves original main-button and image references within the tab");
            var notifyObject=Child(root,"IsolatedOriginalNotification",false);var notify=notifyObject.AddComponent<YeniButonAcildi>();notify._taskkaccompleted=Label(notifyObject,"Completed");notify._taptopcontinue=Label(notifyObject,"Tap");notify._bilgitext=Label(notifyObject,"Info");target._yeniAcildi=notify;
            var jobs=root.AddComponent<CanvasJobs>();jobs._taskKacLazim=Child(root,"LevelRequirementInfo",false);jobs._taskkacLazimText=Label(jobs._taskKacLazim,"Requirement");target._canvasJobs=jobs;
            var flags=new Dictionary<Graphic,bool>();foreach(var graphic in tab.GetComponentsInChildren<Graphic>(true))flags[graphic]=graphic.raycastTarget;
            bool clickedBinding=false;foreach(var b in target.GetComponentsInChildren<Button>(true))for(int i=0;i<b.onClick.GetPersistentEventCount();i++)if(b.onClick.GetPersistentTarget(i)==target&&b.onClick.GetPersistentMethodName(i)=="Clicked"&&b.onClick.GetPersistentListenerState(i)==UnityEngine.Events.UnityEventCallState.RuntimeOnly)clickedBinding=true;Check(r,clickedBinding,"actual lock-layer button retains its original RuntimeOnly Clicked target");
            GameManager.NewUserTapNation=true;GameManager.Level=1;AnalyticsTimeEvent.totalMinutes=5000;target.gameObject.SetActive(true);Enable(target);Check(r,target.gameObject.activeSelf&&!target._kimiLockluyor.interactable&&!target.varsaimgkapat.enabled,"new-system Level1 stays locked even at5000 old-system minutes");
            GameManager.Level=2;Enable(target);Check(r,!target.gameObject.activeSelf&&target._kimiLockluyor.interactable&&target.varsaimgkapat.enabled,"actual Level2 boundary unlocks LockedKac3 through native minus1 rule");Check(r,!notifyObject.activeSelf&&!ES3.KeyExists("BilgiBulundu"),"actual Talent VarsaKim0 creates no new notification overlay or save");
            bool unchanged=true;foreach(var flag in flags)unchanged&=flag.Key&&flag.Key.raycastTarget==flag.Value;Check(r,unchanged,"all actual tab Graphic raycastTarget flags remain unchanged");
            GameManager.Level=1;target.gameObject.SetActive(true);Enable(target);Check(r,target.gameObject.activeSelf&&!target._kimiLockluyor.interactable,"original OnEnable can restore locked presentation below threshold");
            GameManager.NewUserTapNation=false;AnalyticsTimeEvent.totalMinutes=0;Enable(target);Check(r,!target.gameObject.activeSelf&&target._kimiLockluyor.interactable,"old-user branch bypasses this new-system lock at zero played minutes");
            target.yenisistem=false;GameManager.Level=0;AnalyticsTimeEvent.totalMinutes=6000;target.gameObject.SetActive(true);Enable(target);Check(r,target.gameObject.activeSelf&&!target._kimiLockluyor.interactable,"ordinary old lock still obeys level threshold, independent of played minutes");target.yenisistem=true;GameManager.NewUserTapNation=true;
            var extra=Child(root,"OptionalExtra",true);target._varsaExtraObjesiAcilsin=extra;GameManager.Level=1;Enable(target);Check(r,!extra.activeSelf,"original OnEnable hides optional extra while locked");GameManager.Level=2;Enable(target);Check(r,extra.activeSelf&&!target.gameObject.activeSelf,"original unlock activates optional extra and hides its lock object");
            GameManager.Level=1;target.Clicked();Check(r,Lang.TaskKacLazim==3&&jobs._taskKacLazim.activeSelf,"original locked click displays exact serialized requirement3");jobs._taskKacLazim.SetActive(false);GameManager.Level=4;target.Clicked();Check(r,!jobs._taskKacLazim.activeSelf,"native Clicked strict Level>LockedKac guard suppresses stale hint");
            var nullable=Child(root,"NullOptionalReferences").AddComponent<LockedforTask>();nullable.LockedKac=3;nullable._yeniAcildi=notify;GameManager.Level=2;nullable.OpenLock();Check(r,!nullable.gameObject.activeSelf,"native optional button/image/extra null checks retained");
            Check(r,oldArray!=null&&oldArray.Length==30,"original notification static initializer has30 entries");YeniButonAcildi.bulundu=null;notify.Bulundu(0,4);Check(r,!notifyObject.activeSelf,"native kim0 short-circuits even before notification-array access");YeniButonAcildi.bulundu=new int[30];
            typeof(YeniButonAcildi).GetMethod("Start",BindingFlags.Instance|BindingFlags.NonPublic).Invoke(notify,null);Check(r,notify._taptopcontinue.text==Lang.Get.taptocontinue,"original notification Start localizes tap hint");
            GameManager.bilgitimer=8;notify.Bulundu(1,4);Check(r,notifyObject.activeSelf&&GameManager.bilgitimer==0&&YeniButonAcildi.bulundu[1]==1&&notify._taskkaccompleted.text==Lang.Get.task+" 4 "+Lang.Get.tamamlandi,"first original nonzero discovery displays exact text and records index");
            ES3.StoreCachedFile("medupac.es3",new ES3Settings("medupac.es3",ES3.Location.File));OfflineKeyStore.ResetMemoryForVerification();Check(r,ES3.Load<int[]>("BilgiBulundu")[1]==1,"original discovery flags survive flush and disk reread");
            GameManager.bilgitimer=1;notify.Closeit();Check(r,notifyObject.activeSelf,"native notification close uses strict external timer>1 guard");GameManager.bilgitimer=1.0001f;notify.Closeit();Check(r,!notifyObject.activeSelf&&GameManager.bilgitimer==0,"eligible native notification close hides and resets info timer");notify.Bulundu(1,5);Check(r,!notifyObject.activeSelf&&YeniButonAcildi.bulundu[1]==1,"previous discovery is not shown again");
            bool bounds=false;try{notify.Bulundu(30,4);}catch(IndexOutOfRangeException){bounds=true;}Check(r,bounds,"original notification bounds behavior is not silently normalized");
        }catch(Exception e){r.failures.Add(e.ToString());}
        finally{GameManager.Level=oldLevel;GameManager.Language=oldLanguage;GameManager.NewUserTapNation=oldNew;GameManager.bilgitimer=oldTimer;AnalyticsTimeEvent.totalMinutes=oldTime;Lang.TaskKacLazim=oldTask;Lang.currentLang=oldLang;YeniButonAcildi.bulundu=oldArray;SoundManager.instance=oldSound;UnityEngine.Random.state=oldRandom;OfflineKeyStore.SetVerificationRoot(oldRoot);UnityEngine.Object.DestroyImmediate(root);if(closeOriginal&&original.IsValid()&&original.isLoaded)EditorSceneManager.CloseScene(original,true);if(oldScene.IsValid()&&oldScene.isLoaded)SceneManager.SetActiveScene(oldScene);}
        r.passed=r.failures.Count==0;var folder=Path.Combine(Directory.GetParent(Application.dataPath).FullName,"Verification");Directory.CreateDirectory(folder);File.WriteAllText(Path.Combine(folder,"task-locks.json"),JsonUtility.ToJson(r,true));return r;
    }
    public static void RunBatch(){var r=RunChecks();Debug.Log(JsonUtility.ToJson(r));EditorApplication.Exit(r.passed?0:1);}
}
