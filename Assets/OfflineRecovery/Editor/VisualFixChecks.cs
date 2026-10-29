using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace LuckyForge.Offline.Editor
{
    // Domain reloads on entering/exiting PlayMode discard static fields. The real
    // PlayMode result and continuation stage therefore live in SessionState.
    [InitializeOnLoad]
    public static class VisualFixChecks
    {
        const string Key="LuckyForge.WavePlayModeAggregate";
        [Serializable] sealed class DriverReport
        {
            public string phase;
            public bool passed;
            public List<string> failures=new List<string>();
        }
        static string Folder=>Path.Combine(Directory.GetParent(Application.dataPath).FullName,"Verification");
        static VisualFixChecks(){EditorApplication.playModeStateChanged+=PlayState;}
        public static void RunBatch(){OfflineIntegrationVerification.RunChecksBatch();}
        public static void RunWaveBatch(){Begin(true);}
        public static void RunIntegrationBatch(){Begin(false);}
        static void Begin(bool waveOnly)
        {
            if(EditorApplication.isPlayingOrWillChangePlaymode)throw new InvalidOperationException("Wave aggregate driver requires an isolated non-playing Editor process.");
            Directory.CreateDirectory(Folder);
            SessionState.SetBool(Key+".waveOnly",waveOnly);
            SessionState.SetString(Key+".actions",Environment.GetEnvironmentVariable("LUCKYFORGE_RECOVERY_PROBE_ACTIONS")??"");
            SessionState.SetString(Key+".root",Path.Combine(Folder,"WaveRewardTests",Guid.NewGuid().ToString("N")));
            SessionState.SetString(Key+".result","");
            SessionState.SetString(Key+".phase","await-enter-play");
            // No Loading/Sahne/SDK scene participates in these synchronous unit checks.
            EditorSceneManager.NewScene(NewSceneSetup.EmptyScene,NewSceneMode.Single);
            EditorApplication.EnterPlaymode();
        }
        static void PlayState(PlayModeStateChange state)
        {
            string phase=SessionState.GetString(Key+".phase","");
            if(state==PlayModeStateChange.EnteredPlayMode&&phase=="await-enter-play")EditorApplication.delayCall+=RunWaveInPlay;
            if(state==PlayModeStateChange.EnteredEditMode&&phase=="await-exit-play")EditorApplication.delayCall+=RunEditContinuation;
        }
        static void RunWaveInPlay()
        {
            SessionState.SetString(Key+".phase","wave-running");
            var errors=new List<string>();
            Application.LogCallback listener=(message,stack,type)=>{if(type==LogType.Error||type==LogType.Exception||type==LogType.Assert)errors.Add(type+": "+message+"\n"+stack);};
            try
            {
                if(!Application.isPlaying)throw new InvalidOperationException("EnteredPlayMode continuation is not actually playing.");
                WaveRewardLifecycleVerification.Result wave;
                Application.logMessageReceived+=listener;
                try{wave=WaveRewardLifecycleVerification.RunChecks(SessionState.GetString(Key+".root",""));}
                finally{Application.logMessageReceived-=listener;}
                if(wave==null)throw new InvalidOperationException("Original Wave.RunChecks returned no result.");
                wave.failures.AddRange(errors);wave.passed=wave.failures.Count==0;
                string json=JsonUtility.ToJson(wave,true);
                SessionState.SetString(Key+".result",json);
                File.WriteAllText(Path.Combine(Folder,"wave-reward-playmode.json"),json);
                File.WriteAllText(Path.Combine(wave.testRoot,"wave-reward-results.json"),json);
                // Preserve even a failure across exit; the EditMode aggregate receives
                // this exact result and never executes Wave.RunChecks a second time.
                SessionState.SetString(Key+".phase","await-exit-play");
                EditorApplication.ExitPlaymode();
            }
            catch(Exception e){Application.logMessageReceived-=listener;Fail("wave-running",e);}
        }
        static void RunEditContinuation()
        {
            SessionState.SetString(Key+".phase","edit-continuation");
            try
            {
                if(EditorApplication.isPlayingOrWillChangePlaymode)throw new InvalidOperationException("Edit continuation still has an active PlayMode transition.");
                string json=SessionState.GetString(Key+".result","");
                if(string.IsNullOrEmpty(json))throw new InvalidOperationException("Missing persisted actual Wave PlayMode result.");
                var wave=JsonUtility.FromJson<WaveRewardLifecycleVerification.Result>(json);
                if(wave==null||!wave.playMode)throw new InvalidOperationException("Persisted Wave result did not originate in PlayMode.");
                Environment.SetEnvironmentVariable("LUCKYFORGE_RECOVERY_PROBE_ACTIONS",SessionState.GetString(Key+".actions",""));
                bool only=SessionState.GetBool(Key+".waveOnly",false);
                SessionState.SetString(Key+".phase","");
                if(only){EditorApplication.Exit(wave.passed?0:1);return;}
                var home=HomeWorldVerification.RunChecks();
                File.WriteAllText(Path.Combine(Folder,"home-world.json"),JsonUtility.ToJson(home,true));
                OfflineIntegrationVerification.RunWithWaveResult(wave,home);
            }
            catch(Exception e){Fail("edit-continuation",e);}
        }
        static void Fail(string phase,Exception exception)
        {
            SessionState.SetString(Key+".phase","");
            var report=new DriverReport{phase=phase,passed=false};report.failures.Add(exception.ToString());
            Directory.CreateDirectory(Folder);File.WriteAllText(Path.Combine(Folder,"wave-playmode-driver.json"),JsonUtility.ToJson(report,true));
            Debug.LogError("Wave PlayMode aggregate driver failed: "+exception);EditorApplication.Exit(1);
        }
    }
}
