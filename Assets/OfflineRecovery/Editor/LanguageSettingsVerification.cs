using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

// Separate batch process: the original language action intentionally reloads Loading.
[InitializeOnLoad]
public static class LanguageSettingsVerification
{
    const string Pending="LuckyForge.VerifyLocalLanguageReload";
    [Serializable]public sealed class Result{public bool passed;public int checks;public bool playMode;public string verificationRoot,loadedScene;public List<string> failures=new List<string>();}
    static Result result;static float started;
    static LanguageSettingsVerification(){EditorApplication.playModeStateChanged+=OnPlayState;}
    static void Check(bool ok,string label){result.checks++;if(!ok)result.failures.Add(label);}
    public static void RunBatch(){SessionState.SetBool(Pending,true);EditorSceneManager.NewScene(NewSceneSetup.EmptyScene,NewSceneMode.Single);EditorApplication.EnterPlaymode();}
    static void OnPlayState(PlayModeStateChange state){if(state==PlayModeStateChange.EnteredPlayMode&&SessionState.GetBool(Pending,false))EditorApplication.delayCall+=Begin;}
    static void Begin()
    {
        SessionState.SetBool(Pending,false);result=new Result{playMode=Application.isPlaying};started=Time.realtimeSinceStartup;
        try{
            Check(Application.isPlaying,"original asynchronous language reload runs in real PlayMode");
            result.verificationRoot=Path.Combine(Directory.GetParent(Application.dataPath).FullName,"Verification","LanguageSettingsTests",Guid.NewGuid().ToString("N"));OfflineKeyStore.SetVerificationRoot(result.verificationRoot);
            var go=new GameObject("OriginalLanguageSettingsAction");go.SetActive(false);var menu=go.AddComponent<MenuGeneralSettings>();
            GameManager.Language=0;SceneManager.sceneLoaded+=OnLoaded;EditorApplication.update+=Watchdog;
            menu.DilDegistir(3);
            Check(GameManager.Language==3,"original action applies chosen language index");
            var settings=new ES3Settings("medupac.es3",ES3.Location.File);
            Check(File.Exists(OfflineKeyStore.PathFor("medupac.es3",settings)),"original File settings flush language to isolated disk immediately");
            OfflineKeyStore.ResetMemoryForVerification();Check(ES3.Load<int>("Language",settings)==3,"selected language survives disk reread before scene reload");
        }catch(Exception e){result.failures.Add(e.ToString());Complete();}
    }
    static void OnLoaded(Scene scene,LoadSceneMode mode)
    {
        if(result==null)return;result.loadedScene=scene.name;
        Check(scene.name=="Loading"&&scene.path=="Assets/Scenes/Loading.unity","actual original Loading scene finishes loading");
        Check(GameManager.Language==3&&ES3.Load<int>("Language",new ES3Settings("medupac.es3",ES3.Location.File))==3,"language remains applied and persisted when original Loading scene is entered");Complete();
    }
    static void Watchdog(){if(result!=null&&Time.realtimeSinceStartup-started>20){result.failures.Add("Original Loading scene did not load within20 realtime seconds.");Complete();}}
    static void Complete()
    {
        SceneManager.sceneLoaded-=OnLoaded;EditorApplication.update-=Watchdog;result.passed=result.failures.Count==0;var folder=Path.Combine(Directory.GetParent(Application.dataPath).FullName,"Verification");Directory.CreateDirectory(folder);File.WriteAllText(Path.Combine(folder,"language-settings.json"),JsonUtility.ToJson(result,true));Debug.Log(JsonUtility.ToJson(result));
        // Keep the isolated root through process shutdown: Loading must never see a real profile.
        EditorApplication.Exit(result.passed?0:1);
    }
}
