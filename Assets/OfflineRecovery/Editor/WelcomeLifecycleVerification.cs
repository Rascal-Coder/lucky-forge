using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[InitializeOnLoad]
public static class WelcomeLifecycleVerification
{
    const string Pending="LuckyForge.VerifyWelcomeLifecycle";
    const string CloneName="OriginalWelcomeLifecycleVerification";
    [Serializable]public sealed class Result{public bool passed;public int checks;public bool playMode;public float serializedTimer,activationTimer,activationReal,initialTimer,initialReal,expectedRemaining,closedReal;public List<string> failures=new List<string>();}
    static Result result;
    static FalseDestroyLater target;
    static float beforeScale;
    static Dictionary<Graphic,bool> raycastFlags;
    static bool observedBeforeExpiry;
    static bool baselineObserved;
    static WelcomeLifecycleVerification(){EditorApplication.playModeStateChanged+=OnPlayState;}
    static void Check(Result r,bool ok,string label){r.checks++;if(!ok)r.failures.Add(label);}
    static void Invoke(FalseDestroyLater t,string method){typeof(FalseDestroyLater).GetMethod(method,BindingFlags.Instance|BindingFlags.NonPublic).Invoke(t,null);}
    static Result Finish(Result r){r.passed=r.failures.Count==0;var folder=Path.Combine(Directory.GetParent(Application.dataPath).FullName,"Verification");Directory.CreateDirectory(folder);File.WriteAllText(Path.Combine(folder,"welcome-lifecycle.json"),JsonUtility.ToJson(r,true));return r;}

    // Immediate original branch checks; no real profile, scene edits or pool initialization.
    public static Result RunChecks()
    {
        var r=new Result{playMode=Application.isPlaying};var parent=new GameObject("LifetimeBranchOwner");parent.SetActive(false);var go=new GameObject("LifetimeBranchChild");go.transform.SetParent(parent.transform);var t=go.AddComponent<FalseDestroyLater>();float oldInfo=GameManager.bilgitimer;
        try{
            t.timer=4f;t.second=9f;t.falseit=true;t.Unscaled=true;Invoke(t,"OnEnable");Check(r,t.timer==4f,"original OnEnable preserves existing lifetime timer");
            t.bilgivertimeresetle=true;GameManager.bilgitimer=8;Invoke(t,"OnEnable");Check(r,GameManager.bilgitimer==0&&t.timer==4,"original info reset affects global info timer only");t.bilgivertimeresetle=false;
            t.ikincikereBeniGorme=true;Invoke(t,"OnEnable");Check(r,go.activeSelf,"first guarded enable remains active");Invoke(t,"OnEnable");Check(r,!go.activeSelf,"second guarded enable hides original object");go.SetActive(true);Invoke(t,"OnEnable");Check(r,go.activeSelf,"second-enable counter resets after hiding");t.ikincikereBeniGorme=false;
            GameManager.bilgitimer=.5f;t.timer=3;t.Hemen();Check(r,t.timer==3,"original Hemen uses strict global timer>.5 guard");GameManager.bilgitimer=.50001f;t.Hemen();Check(r,t.timer==10&&go.activeSelf,"eligible Hemen accelerates timer without immediate close");
            go.SetActive(false);t.timer=t.second;t.parentidafalseet=false;Invoke(t,"Update");Check(r,t.timer==9,"expiry is strict greater-than, not >=");
            go.SetActive(true);t.timer=9.01f;Invoke(t,"Update");Check(r,!go.activeSelf&&t.timer==0,"falseit expiry hides and resets timer");
            t.falseit=false;t.timer=9.01f;Invoke(t,"Update");Check(r,t.timer==9.01f,"non-falseit expiry does not reset timer");
            t.falseit=true;t.parentidafalseet=true;parent.SetActive(true);go.SetActive(false);t.timer=9.01f;Invoke(t,"Update");Check(r,!parent.activeSelf&&t.timer==0,"original parent-close branch hides parent too");
            t.parentidafalseet=false;t.transformToParent=true;go.SetActive(true);Invoke(t,"Start");Check(r,!go.activeSelf,"original reparentable Start caches parent and initially hides");var other=new GameObject("TemporaryOtherOwner");go.transform.SetParent(other.transform);t.timer=10;Invoke(t,"Update");Check(r,go.transform.parent==parent.transform&&t.timer==0,"original falseit expiry restores cached parent");UnityEngine.Object.DestroyImmediate(other);
        }catch(Exception e){r.failures.Add(e.ToString());}
        finally{GameManager.bilgitimer=oldInfo;UnityEngine.Object.DestroyImmediate(parent);}
        return Finish(r);
    }

    // Standalone real 9-second PlayMode test of an unmodified clone of the original scene object.
    public static void RunBatch()
    {
        var r=RunChecks();if(!r.passed){Debug.Log(JsonUtility.ToJson(r));EditorApplication.Exit(1);return;}
        SessionState.SetInt(Pending+".branchChecks",r.checks);
        var empty=EditorSceneManager.NewScene(NewSceneSetup.EmptyScene,NewSceneMode.Single);
        var original=EditorSceneManager.OpenScene("Assets/Scenes/Sahne.unity",OpenSceneMode.Additive);
        FalseDestroyLater source=null;foreach(var component in Resources.FindObjectsOfTypeAll<FalseDestroyLater>())if(component&&component.gameObject.scene==original&&component.gameObject.name=="welcomeguide"){source=component;break;}
        if(!source)throw new InvalidOperationException("Original welcomeguide lifetime component missing.");
        SessionState.SetFloat(Pending+".serializedTimer",source.timer);
        var clone=UnityEngine.Object.Instantiate(source.gameObject);clone.name=CloneName;clone.SetActive(false);SceneManager.MoveGameObjectToScene(clone,empty);EditorSceneManager.CloseScene(original,true);
        SessionState.SetBool(Pending,true);EditorApplication.EnterPlaymode();
    }
    static void OnPlayState(PlayModeStateChange state){if(state==PlayModeStateChange.EnteredPlayMode&&SessionState.GetBool(Pending,false))EditorApplication.delayCall+=BeginRealCheck;}
    static void BeginRealCheck()
    {
        SessionState.SetBool(Pending,false);result=new Result{playMode=Application.isPlaying,checks=SessionState.GetInt(Pending+".branchChecks",0),serializedTimer=SessionState.GetFloat(Pending+".serializedTimer",float.NaN)};
        baselineObserved=false;observedBeforeExpiry=false;
        foreach(var t in Resources.FindObjectsOfTypeAll<FalseDestroyLater>())if(t&&t.gameObject.scene.IsValid()&&t.gameObject.name==CloneName){target=t;break;}
        Check(result,target&&target.second==9f&&target.falseit&&target.Unscaled&&!target.destroy&&!target.parentidafalseet&&!target.transformToParent&&!target.pooling,"original welcome serialized9-second unscaled self-hide configuration");
        if(!target){Complete();return;}
        raycastFlags=new Dictionary<Graphic,bool>();foreach(var graphic in target.GetComponentsInChildren<Graphic>(true))raycastFlags.Add(graphic,graphic.raycastTarget);
        Check(result,raycastFlags.Count>0,"real original welcome Graphic hierarchy retained");beforeScale=Time.timeScale;Time.timeScale=0;
        GameManager.bilgitimer=0f;result.activationTimer=target.timer;result.activationReal=Time.realtimeSinceStartup;target.gameObject.SetActive(true);
        Check(result,target.gameObject.activeInHierarchy,"original welcome activates before expiry");EditorApplication.update+=Poll;
    }
    static void Poll()
    {
        try{
            float elapsed=Time.realtimeSinceStartup-result.activationReal;
            if(!target){result.failures.Add("Original welcome unexpectedly destroyed.");Complete();return;}
            // The activation can occur midway through a long Editor frame. Native Update
            // counts that frame's entire unscaledDeltaTime. Start a measured baseline
            // after observing its first real increment; never normalize/reset its timer.
            if(!baselineObserved&&target.gameObject.activeSelf&&target.timer>result.activationTimer){result.initialTimer=target.timer;result.initialReal=Time.realtimeSinceStartup;result.expectedRemaining=Mathf.Max(0,target.second-result.initialTimer);baselineObserved=true;}
            if(!observedBeforeExpiry&&baselineObserved&&target.gameObject.activeSelf&&target.timer>=target.second-1f){Check(result,target.timer<=target.second,"welcome remains active before original lifetime deadline at timeScale0");observedBeforeExpiry=true;}
            if(!target.gameObject.activeSelf){result.closedReal=Time.realtimeSinceStartup;float remainingElapsed=result.closedReal-result.initialReal;Check(result,baselineObserved&&observedBeforeExpiry&&Mathf.Abs(remainingElapsed-result.expectedRemaining)<=.5f&&elapsed<12f,"actual unscaled Update hides original welcome after measured second-minus-initialTimer remaining lifetime while paused");Check(result,target.timer==0f&&Time.timeScale==0,"native expiry resets lifetime timer without resuming scaled gameplay");bool unchanged=true,allInactive=true;foreach(var row in raycastFlags){unchanged&=row.Key&&row.Key.raycastTarget==row.Value;allInactive&=row.Key&&!row.Key.gameObject.activeInHierarchy;}Check(result,unchanged&&allInactive,"original raycast flags unchanged; hidden welcome hierarchy stops intercepting input");Complete();return;}
            if(elapsed>12f){result.failures.Add("Original welcome did not hide after12 realtime seconds.");Complete();}
        }catch(Exception e){result.failures.Add(e.ToString());Complete();}
    }
    static void Complete(){EditorApplication.update-=Poll;Time.timeScale=beforeScale;var r=Finish(result);Debug.Log(JsonUtility.ToJson(r));EditorApplication.Exit(r.passed?0:1);}
}
