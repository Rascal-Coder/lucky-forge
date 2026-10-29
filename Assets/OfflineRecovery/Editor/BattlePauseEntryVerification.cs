using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
public static class BattlePauseEntryVerification
{
    [Serializable]public sealed class Result{public bool passed;public int checks;public List<string> failures=new List<string>();}
    static void Check(Result r,bool ok,string label){r.checks++;if(!ok)r.failures.Add(label);}
    public static Result RunChecks()
    {
        var r=new Result();float oldScale=Time.timeScale,oldConfigured=GameManager.TimeScale;bool oldStop=WarController.StopGame,oldGuide=GameManager.GuideDone;var oldSound=SoundManager.instance;var owner=new GameObject("BattlePauseEntryVerification");owner.SetActive(false);var menu=new GameObject("OriginalBattleMenu");
        try{
            var war=owner.AddComponent<WarController>();war.TotalUiDamages=Array.Empty<double>();var sound=owner.AddComponent<SoundManager>();SoundManager.instance=sound;war.menuPage=menu;war.menu_weaponcontent=new GameObject("DamageContent").transform;war.menu_weaponcontent.SetParent(owner.transform);typeof(WarController).GetProperty("token").SetValue(war,9,null);typeof(WarController).GetProperty("Silver").SetValue(war,4321f,null);
            GameManager.TimeScale=2.5f;GameManager.GuideDone=false;WarController.StopGame=false;Time.timeScale=1.25f;menu.SetActive(false);war.pageAcik=false;war.OpenMenu();Check(r,menu.activeSelf&&war.pageAcik&&Time.timeScale==0,"original pause opens menu, sets pageAcik and stops scaled time");
            war.OpenMenu();Check(r,menu.activeSelf&&war.pageAcik&&Time.timeScale==0,"repeated original OpenMenu remains open and does not toggle");Check(r,!WarController.StopGame,"pause does not set tutorial StopGame");
            war.ContineuToFight();Check(r,!menu.activeSelf&&!war.pageAcik&&Mathf.Abs(Time.timeScale-2.5f)<.00001f,"continue restores configured2.5x and closes menu");Check(r,!WarController.StopGame,"continue does not overwrite StopGame=false");
            GameManager.TimeScale=1.75f;Time.timeScale=.3f;war.pageAcik=true;war.ContineuToFight();Check(r,!menu.activeSelf&&!war.pageAcik&&Mathf.Abs(Time.timeScale-1.75f)<.00001f,"continue has no inactive-menu guard and restores current configured speed");
            GameManager.GuideDone=true;WarController.StopGame=true;war.OpenMenu();Check(r,menu.activeSelf&&war.pageAcik&&Time.timeScale==0&&WarController.StopGame,"pause still opens during StopGame=true without changing guide state");war.ContineuToFight();Check(r,!menu.activeSelf&&!war.pageAcik&&Mathf.Abs(Time.timeScale-1.75f)<.00001f&&WarController.StopGame&&GameManager.GuideDone,"continue preserves tutorial stop flag and completed-guide state");
            Check(r,war.token==9&&war.Silver==4321,"pause and continue neither spend nor grant token/silver");
        }catch(Exception e){r.failures.Add(e.ToString());}
        finally{Time.timeScale=oldScale;GameManager.TimeScale=oldConfigured;WarController.StopGame=oldStop;GameManager.GuideDone=oldGuide;SoundManager.instance=oldSound;UnityEngine.Object.DestroyImmediate(menu);UnityEngine.Object.DestroyImmediate(owner);}
        r.passed=r.failures.Count==0;var folder=Path.Combine(Directory.GetParent(Application.dataPath).FullName,"Verification");Directory.CreateDirectory(folder);File.WriteAllText(Path.Combine(folder,"battle-pause-entry.json"),JsonUtility.ToJson(r,true));return r;
    }
    public static void RunBatch(){var r=RunChecks();Debug.Log(JsonUtility.ToJson(r));EditorApplication.Exit(r.passed?0:1);}
}
