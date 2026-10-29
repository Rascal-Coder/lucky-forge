using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

// Run in a separate Unity invocation after EnergyRightsButtonsVerification.RunBatch.
[InitializeOnLoad]
public static class EnergyRightsRestartVerification
{
    const string Pending="LuckyForge.VerifyEnergyProcessRestart";
    [Serializable]public sealed class Result{public bool passed;public int checks;public bool playMode;public string profile;public List<string> failures=new List<string>();}
    static Result result;
    static EnergyRightsRestartVerification(){EditorApplication.playModeStateChanged+=OnPlayState;}
    static void Check(bool ok,string label){result.checks++;if(!ok)result.failures.Add(label);}
    public static void RunBatch(){SessionState.SetBool(Pending,true);EditorSceneManager.NewScene(NewSceneSetup.EmptyScene,NewSceneMode.Single);EditorApplication.EnterPlaymode();}
    static void OnPlayState(PlayModeStateChange state){if(state==PlayModeStateChange.EnteredPlayMode&&SessionState.GetBool(Pending,false))EditorApplication.delayCall+=Run;}
    static void Run()
    {
        SessionState.SetBool(Pending,false);result=new Result{playMode=Application.isPlaying};
        try{
            var project=Directory.GetParent(Application.dataPath).FullName;var prior=JsonUtility.FromJson<EnergyRightsButtonsVerification.Result>(File.ReadAllText(Path.Combine(project,"Verification","energy-rights-buttons.json")));Check(prior!=null&&prior.passed,"previous original-button process completed successfully");if(prior==null||!prior.passed)throw new InvalidOperationException("Run the original-button fixture successfully first.");
            string allowed=Path.GetFullPath(Path.Combine(project,"Verification","EnergyButtonTests"))+Path.DirectorySeparatorChar;result.profile=Path.GetFullPath(prior.profile);if(!result.profile.StartsWith(allowed,StringComparison.OrdinalIgnoreCase))throw new InvalidOperationException("Restart fixture only accepts its own EnergyButtonTests profile.");
            Check(Application.isPlaying&&Currencys.Crystal==0&&Currencys.Energy==0,"fresh isolated process starts with default static balances before reading test save");
            OfflineKeyStore.SetVerificationRoot(result.profile);GameManager.Language=0;Currencys.LoadStartCrystal();Currencys.LoadStartEnergy();Check(Currencys.Crystal==100&&Currencys.Energy==120,"separate process restores original paid balances from disk");
            var root=new GameObject("EnergySeparateProcessFixture");root.SetActive(false);SoundManager.instance=EnergyRightsFixtureData.Child(root,"InactiveSound",false).AddComponent<SoundManager>();var c=EnergyRightsFixtureData.Build(root,"EnergyRestoredOnRestart");var now=DateTime.UtcNow;var reset=ES3.Load<DateTime>("CrystalEnergyResetTime");Check(now-reset<TimeSpan.FromHours(24),"persisted original purchase window has not expired during this restart test");
            root.SetActive(true);c.gameObject.SetActive(true);Check((int)EnergyRightsFixtureData.Get(c,"crystalRemaining")==0&&(DateTime)EnergyRightsFixtureData.Get(c,"crystalResetTime")==reset,"fresh-process real Awake/OnEnable retain exhausted original window");Check((int)EnergyRightsFixtureData.Get(c,"adRemaining")==2&&Currencys.Crystal==100&&Currencys.Energy==120,"restart does not grant energy, replenish crystal uses or consume ads");
        }catch(Exception e){result.failures.Add(e.ToString());}
        result.passed=result.failures.Count==0;var folder=Path.Combine(Directory.GetParent(Application.dataPath).FullName,"Verification");Directory.CreateDirectory(folder);File.WriteAllText(Path.Combine(folder,"energy-rights-restart.json"),JsonUtility.ToJson(result,true));Debug.Log(JsonUtility.ToJson(result));EditorApplication.Exit(result.passed?0:1);
    }
}
