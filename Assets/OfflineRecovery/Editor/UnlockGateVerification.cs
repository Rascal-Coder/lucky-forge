using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

namespace LuckyForge.Offline.Editor
{
    public static class UnlockGateVerification
    {
        [Serializable] public sealed class Result {public bool passed;public int checks;public List<string> failures=new List<string>();}
        static void Check(Result r,bool ok,string label){r.checks++;if(!ok)r.failures.Add(label);}
        public static Result RunChecks()
        {
            var r=new Result();var root=new GameObject("UnlockGateVerification");root.SetActive(false);
            bool newUser=GameManager.NewUserTapNation;int level=GameManager.Level;int minutes=AnalyticsTimeEvent.totalMinutes;
            string folder=Path.Combine(Path.GetTempPath(),"LuckyForgeUnlockChecks",Guid.NewGuid().ToString("N"));OfflineKeyStore.SetVerificationRoot(folder);
            try
            {
                var buttonObject=new GameObject("LockedButton",typeof(RectTransform),typeof(CanvasRenderer),typeof(Image),typeof(Button),typeof(CanvasGroup));buttonObject.transform.SetParent(root.transform);
                var lockObject=new GameObject("Lock");lockObject.transform.SetParent(root.transform);
                var infoObject=new GameObject("Info");infoObject.transform.SetParent(root.transform);
                var normal=new GameObject("Feature");normal.transform.SetParent(root.transform);
                var gate=root.AddComponent<KademeliAcilimLevel>();
                var pair=new KademeliAcilimLevel.ButtonLevelPairer {obje=buttonObject,requiredLevel=5,butonlu=true,varsaBtn=buttonObject.GetComponent<Button>(),lockvarsa=lockObject,infovarsa=infoObject,canvasgroupvarsa=buttonObject.GetComponent<CanvasGroup>()};
                gate.buttonsWithLevels=new List<KademeliAcilimLevel.ButtonLevelPairer>{pair,new KademeliAcilimLevel.ButtonLevelPairer {obje=normal,requiredLevel=5}};
                GameManager.NewUserTapNation=true;GameManager.Level=4;gate.OnPlayerLevelUp();
                Check(r,!pair.varsaBtn.interactable && lockObject.activeSelf && !infoObject.activeSelf,"below-level button keeps native lock/info behavior");
                Check(r,Mathf.Abs(pair.canvasgroupvarsa.alpha-0.7f)<0.000001f,"native disabled alpha0.7");
                Check(r,!normal.activeSelf,"below-level ordinary object hidden");
                GameManager.Level=5;gate.OnPlayerLevelUp();
                Check(r,pair.varsaBtn.interactable && !lockObject.activeSelf && infoObject.activeSelf,"exact required level unlocks button");
                Check(r,pair.canvasgroupvarsa.alpha==1f && normal.activeSelf,"unlocked opacity and ordinary feature visibility");
                GameManager.NewUserTapNation=false;gate.OnPlayerLevelUp();Check(r,!gate.enabled,"old-user branch disables level gate");
                var old=root.AddComponent<KademeliAcilim>();
                var timed=new GameObject("TimedFeature");timed.transform.SetParent(root.transform);
                old.buttonsWithLevels=new List<KademeliAcilim.ButtonLevelPair>{new KademeliAcilim.ButtonLevelPair{obje=timed,requiredLevel=5}};
                AnalyticsTimeEvent.totalMinutes=4;old.OnPlayerLevelUp();Check(r,!timed.activeSelf,"old-user minute gate below threshold");
                AnalyticsTimeEvent.totalMinutes=5;old.OnPlayerLevelUp();Check(r,timed.activeSelf,"old-user minute gate at threshold");
                timed.SetActive(false);AnalyticsTimeEvent.totalMinutes=5000;old.OnPlayerLevelUp();Check(r,!timed.activeSelf,"native >4999 fast-exit retained");
                GameManager.NewUserTapNation=true;old.OnPlayerLevelUp();Check(r,!old.enabled,"new-user branch disables old-time gate");
                var clock=root.AddComponent<AnalyticsTimeEvent>();
                AnalyticsTimeEvent.totalMinutes=7;
                typeof(AnalyticsTimeEvent).GetField("elapsedTime",BindingFlags.Instance|BindingFlags.NonPublic).SetValue(clock,180f);
                typeof(AnalyticsTimeEvent).GetMethod("Update",BindingFlags.Instance|BindingFlags.NonPublic).Invoke(clock,null);
                Check(r,AnalyticsTimeEvent.GetTotalMinutes()==8,"native clock increments once per update, not catch-up loop");
                Check(r,ES3.Load<int>("totalPlayTimeMinutes",-1)==8,"native minute save key uses actual adapter");
            }
            catch(Exception ex){r.failures.Add(ex.ToString());}
            finally{GameManager.NewUserTapNation=newUser;GameManager.Level=level;AnalyticsTimeEvent.totalMinutes=minutes;UnityEngine.Object.DestroyImmediate(root);OfflineKeyStore.SetVerificationRoot(null);}
            r.passed=r.failures.Count==0;
            string path=Path.Combine(Directory.GetParent(Application.dataPath).FullName,"Verification","unlock-gates.json");Directory.CreateDirectory(Path.GetDirectoryName(path));File.WriteAllText(path,JsonUtility.ToJson(r,true));return r;
        }
    }
}
