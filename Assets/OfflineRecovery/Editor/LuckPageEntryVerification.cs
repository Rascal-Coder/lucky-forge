using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
public static class LuckPageEntryVerification
{
    [Serializable]public sealed class Result{public bool passed;public int checks;public List<string> failures=new List<string>();}
    static void Check(Result r,bool ok,string label){r.checks++;if(!ok)r.failures.Add(label);}
    public static Result RunChecks()
    {
        var r=new Result();bool oldGuide=GameManager.GuideDone,oldStop=WarController.StopGame;float oldScale=Time.timeScale;var oldSound=SoundManager.instance;var root=new GameObject("LuckPageEntryVerification");root.SetActive(false);var page=new GameObject("OriginalLuckySpinPage");var info=new GameObject("OriginalSlotInfo");
        try{
            var war=root.AddComponent<WarController>();var slot=root.AddComponent<SlotMachine>();var sound=root.AddComponent<SoundManager>();SoundManager.instance=sound;war.slotMachine=slot;slot.slotinfo=info;war.luckpage=page;typeof(WarController).GetProperty("token").SetValue(war,7,null);typeof(WarController).GetProperty("Silver").SetValue(war,1234f,null);Time.timeScale=.37f;WarController.StopGame=true;
            GameManager.GuideDone=false;war.pageAcik=false;page.SetActive(false);info.SetActive(true);war.openCloseLuckPage();Check(r,page.activeInHierarchy&&war.pageAcik&&!info.activeSelf,"unfinished guide opens original page, sets pageAcik and hides slot info");
            info.SetActive(true);war.openCloseLuckPage();Check(r,!page.activeSelf&&!war.pageAcik&&!info.activeSelf,"same original toggle closes an already-open page through CloseLuckPage");
            war.pageAcik=true;info.SetActive(true);war.CloseLuckPage();Check(r,war.pageAcik&&info.activeSelf,"closing an already-inactive page has no side effects");
            GameManager.GuideDone=true;war.pageAcik=false;war.openCloseLuckPage();Check(r,page.activeSelf&&!war.pageAcik&&!info.activeSelf,"completed guide opens page without changing pageAcik");
            war.pageAcik=true;war.CloseLuckPage();Check(r,!page.activeSelf&&war.pageAcik,"completed guide close preserves existing pageAcik state");
            GameManager.GuideDone=false;page.SetActive(true);war.pageAcik=true;war.slotMachine=null;war.CloseLuckPage();Check(r,!page.activeSelf&&!war.pageAcik,"native close permits missing slotMachine reference");
            war.slotMachine=slot;slot.slotinfo=null;page.SetActive(true);war.pageAcik=true;war.CloseLuckPage();Check(r,!page.activeSelf&&!war.pageAcik,"native close permits missing slotinfo reference");
            war.luckpage=null;war.pageAcik=true;war.CloseLuckPage();Check(r,war.pageAcik,"native close permits missing lucky page with no extra flag changes");
            war.luckpage=page;page.transform.SetParent(root.transform);page.SetActive(true);war.pageAcik=true;war.CloseLuckPage();Check(r,page.activeSelf&&war.pageAcik,"native activeInHierarchy guard preserves child of inactive parent");
            Check(r,war.token==7&&war.Silver==1234,"panel entry/exit grants or spends no tokens or silver");Check(r,Mathf.Abs(Time.timeScale-.37f)<.00001f,"original entry/exit does not change timescale");Check(r,WarController.StopGame,"original entry/exit does not overwrite tutorial StopGame");
        }catch(Exception e){r.failures.Add(e.ToString());}
        finally{GameManager.GuideDone=oldGuide;WarController.StopGame=oldStop;Time.timeScale=oldScale;SoundManager.instance=oldSound;if(page)UnityEngine.Object.DestroyImmediate(page);UnityEngine.Object.DestroyImmediate(info);UnityEngine.Object.DestroyImmediate(root);}
        r.passed=r.failures.Count==0;var folder=Path.Combine(Directory.GetParent(Application.dataPath).FullName,"Verification");Directory.CreateDirectory(folder);File.WriteAllText(Path.Combine(folder,"luck-page-entry.json"),JsonUtility.ToJson(r,true));return r;
    }
    public static void RunBatch(){var r=RunChecks();Debug.Log(JsonUtility.ToJson(r));EditorApplication.Exit(r.passed?0:1);}
}
