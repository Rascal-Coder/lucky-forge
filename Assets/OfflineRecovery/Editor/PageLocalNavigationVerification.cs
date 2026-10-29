using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEditor;
using UnityEngine;
public static class PageLocalNavigationVerification
{
    [Serializable]public sealed class Result{public bool passed;public int checks;public List<string> failures=new List<string>();}
    static void Check(Result r,bool ok,string label){r.checks++;if(!ok)r.failures.Add(label);}
    static GameObject Child(GameObject root,string name,bool active=false){var go=new GameObject(name);go.transform.SetParent(root.transform);go.SetActive(active);return go;}
    static object Invoke(PageReferences p,string name){return typeof(PageReferences).GetMethod(name,BindingFlags.Instance|BindingFlags.NonPublic).Invoke(p,null);}
    public static Result RunChecks()
    {
        var r=new Result();var root=new GameObject("OriginalPageNavigationBranches");root.SetActive(false);var p=root.AddComponent<PageReferences>();var oldSound=SoundManager.instance;bool oldPerf=GameManager.PerformansMode,oldBattle=GecisControl.savastayim,oldPage=GameManager.PageAcildi,oldFull=GameManager.TamPageAcildi;float oldClick=GameManager.lokasyonClicked,oldInfo=GameManager.bilgitimer;var oldRandom=UnityEngine.Random.state;
        var eventField=typeof(PageReferences).GetField("m_OnPageOpenedOrAreaClicked",BindingFlags.Static|BindingFlags.NonPublic);var oldEvent=eventField.GetValue(null);eventField.SetValue(null,null);
        var detached=new List<GameObject>();GameObject hierarchy=null;
        try{
            SoundManager.instance=root.AddComponent<SoundManager>();p.Menu=Child(root,"Menu");p.ChestArea=Child(root,"Chest");p.Karts=Child(root,"Karts");p.Shop=Child(root,"UntouchedShop",true);p.EventsPage=Child(root,"UntouchedEvents",true);p.KaynakYok=Child(root,"ResourceInfo");p._MainCamera=Child(root,"Camera").AddComponent<Camera>();p._MainCulling=5;p._TamSayfaCulling=32;
            GameManager.PageAcildi=false;GameManager.lokasyonClicked=7;GameManager.bilgitimer=4;
            p.PageAc_Menu();Check(r,p.Menu.activeSelf&&GameManager.PageAcildi,"original outer menu handler opens menu and marks page open");
            p.Menu.SetActive(false);p.PageAc_Menu();Check(r,!p.Menu.activeSelf&&GameManager.PageAcildi,"existing-page guard skips reactivation while preserving original open flag");
            p.Menu.SetActive(true);p.ChestArea.SetActive(true);p.Karts.SetActive(true);p._MainCamera.cullingMask=123;p.A_PageKapat();Check(r,!p.Menu.activeSelf&&!p.ChestArea.activeSelf&&!p.Karts.activeSelf&&!GameManager.PageAcildi,"original close hides exactly three local pages and clears open flag");Check(r,p.Shop.activeSelf&&p.EventsPage.activeSelf,"original close does not add unrelated Shop/Event behavior");Check(r,p._MainCamera.cullingMask==5&&GameManager.lokasyonClicked==0&&GameManager.bilgitimer==4,"close restores original Main mask and click timer without altering bilgitimer");
            int count=0;PageReferences.PageOrAreaEventHandler a=()=>count++,b=()=>count+=10;PageReferences.OnPageOpenedOrAreaClicked+=a;PageReferences.OnPageOpenedOrAreaClicked+=b;GameManager.PerformansMode=false;GecisControl.savastayim=false;GameManager.PageAcildi=false;GameManager.TamPageAcildi=true;
            Invoke(p,"Update");Check(r,count==11&&p._MainCamera.cullingMask==5,"original Update invokes combined listeners and uses Main when no page");
            GameManager.PageAcildi=true;GameManager.TamPageAcildi=false;p._MainCamera.cullingMask=0;Invoke(p,"Update");Check(r,count==22&&p._MainCamera.cullingMask==5,"non-full page retains Main culling");
            GameManager.TamPageAcildi=true;Invoke(p,"Update");Check(r,count==33&&p._MainCamera.cullingMask==32,"open full page selects original Full mask");
            GameManager.PerformansMode=true;p._MainCamera.cullingMask=99;Invoke(p,"Update");Check(r,count==44&&p._MainCamera.cullingMask==99,"performance guard preserves mask but event still invokes first");
            GameManager.PerformansMode=false;GecisControl.savastayim=true;p._MainCamera.cullingMask=77;Invoke(p,"Update");Check(r,count==55&&p._MainCamera.cullingMask==77,"battle guard preserves mask but event still invokes first");
            PageReferences.OnPageOpenedOrAreaClicked-=b;Invoke(p,"Update");Check(r,count==56,"native event remove preserves the remaining listener");PageReferences.OnPageOpenedOrAreaClicked-=a;Invoke(p,"Update");Check(r,count==56,"all listeners can be removed without late invocation");
            p.GoMainCulling();Check(r,p._MainCamera.cullingMask==5,"original GoMainCulling wrapper");p._MainCamera.cullingMask=42;p.CullingMainle();Check(r,p._MainCamera.cullingMask==5,"original CullingMainle wrapper");
            p.KaynakAc();Check(r,p.KaynakYok.activeSelf,"resource-info overlay opens through original local handler");var sourceFlag=typeof(PageReferences).GetField("kaynakpage",BindingFlags.Instance|BindingFlags.NonPublic);sourceFlag.SetValue(p,true);p.KaynakKapat();Check(r,!p.KaynakYok.activeSelf&&!(bool)sourceFlag.GetValue(p),"resource-info close clears its original flag");
            hierarchy=new GameObject("OriginalThreeCanvasDetach");hierarchy.SetActive(false);var hp=hierarchy.AddComponent<PageReferences>();var world=new List<Vector3>();for(int i=0;i<3;i++){var go=Child(hierarchy,"Canvas"+i);go.transform.position=new Vector3(i+12,9-i,-5);detached.Add(go);world.Add(go.transform.position);}
            var coroutine=(IEnumerator)Invoke(hp,"unchild");bool first=coroutine.MoveNext();var seconds=typeof(WaitForSeconds).GetField("m_Seconds",BindingFlags.NonPublic|BindingFlags.Instance);Check(r,first&&coroutine.Current is WaitForSeconds&&seconds!=null&&(float)seconds.GetValue(coroutine.Current)==2f&&hierarchy.transform.childCount==3,"original unchild first yields exactly2 scaled seconds before any detach");
            bool second=coroutine.MoveNext();bool correct=!second&&hierarchy.transform.childCount==0;for(int i=0;i<3;i++)correct&=detached[i].transform.parent==null&&detached[i].transform.position==world[i];Check(r,correct,"native child2 then1 then0 detach preserves all three world positions");
            Check(r,GameManager.bilgitimer==4,"no restored PageReferences method invents a global info timer increment");
        }catch(Exception e){r.failures.Add(e.ToString());}
        finally{eventField.SetValue(null,oldEvent);SoundManager.instance=oldSound;GameManager.PerformansMode=oldPerf;GecisControl.savastayim=oldBattle;GameManager.PageAcildi=oldPage;GameManager.TamPageAcildi=oldFull;GameManager.lokasyonClicked=oldClick;GameManager.bilgitimer=oldInfo;UnityEngine.Random.state=oldRandom;UnityEngine.Object.DestroyImmediate(root);foreach(var go in detached)if(go)UnityEngine.Object.DestroyImmediate(go);if(hierarchy)UnityEngine.Object.DestroyImmediate(hierarchy);}
        r.passed=r.failures.Count==0;var folder=Path.Combine(Directory.GetParent(Application.dataPath).FullName,"Verification");Directory.CreateDirectory(folder);File.WriteAllText(Path.Combine(folder,"page-local-navigation.json"),JsonUtility.ToJson(r,true));return r;
    }
    public static void RunBatch(){var r=RunChecks();Debug.Log(JsonUtility.ToJson(r));EditorApplication.Exit(r.passed?0:1);}
}
