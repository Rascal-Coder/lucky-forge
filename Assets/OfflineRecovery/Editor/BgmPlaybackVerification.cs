using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

[InitializeOnLoad]
public static class BgmPlaybackVerification
{
    const string Pending="LuckyForge.BgmPlaybackVerification";
    [Serializable] public sealed class Observation
    {
        public string stage,clip,assetPath,loadState,mixer;
        public bool playing,enabled,active,mute,loop,listenerPause;
        public int firstSample,lastSample,distinctSamples,samples,frequency,channels;
        public float volume,pitch,spatialBlend,listenerVolume,outputPeak,pcmPeak;
        public double firstDsp,lastDsp;
    }
    [Serializable] public sealed class Result
    {
        public bool passed,playMode;
        public int checks;
        public string profile,route="Original Loading.Start coroutine (stop before LoadSceneAsync), original War.OnEnable BGM branch, original settings toggle, original GecisControl.SavasaBittiSiege coroutine; no substituted clip/source.";
        public List<string> failures=new List<string>();
        public List<Observation> observations=new List<Observation>();
    }
    static Result r;static SoundManager sm;static WarController war;static GecisControl home;static MenuGeneralSettings settings;static LoadingPage loading;
    static int phase,lastFrame,lastSample;static float started,stageAt;static Observation observation;static bool loadingDone;
    static BgmPlaybackVerification(){EditorApplication.playModeStateChanged+=PlayState;}
    static GameObject Child(GameObject root,string name,bool active=true){var g=new GameObject(name);g.transform.SetParent(root.transform);g.SetActive(active);return g;}
    static void Check(bool ok,string message){r.checks++;if(!ok)r.failures.Add(message);}
    public static void RunBatch()
    {
        var empty=EditorSceneManager.NewScene(NewSceneSetup.EmptyScene,NewSceneMode.Single);
        var original=EditorSceneManager.OpenScene("Assets/Scenes/Loading.unity",OpenSceneMode.Additive);
        var fixture=new GameObject("BgmPlaybackFixture");SceneManager.MoveGameObjectToScene(fixture,empty);
        try {
            SoundManager source=null;foreach(var root in original.GetRootGameObjects())foreach(var c in root.GetComponentsInChildren<SoundManager>(true))source=c;
            if(!source)throw new InvalidOperationException("Original Loading SoundManager missing.");
            var holder=Child(fixture,"OriginalAudioHolder",false);
            var clone=UnityEngine.Object.Instantiate(source.gameObject,holder.transform,false);clone.name="OriginalBgmSoundManager";
            var controller=Child(fixture,"DisabledWar",false).AddComponent<WarController>();controller.enabled=false;
            var transition=Child(fixture,"DisabledHomeRoute",false).AddComponent<GecisControl>();transition.enabled=false;
            transition.GenelCanvases=Array.Empty<GameObject>();transition.MapParent=Child(fixture,"Map").transform;Child(transition.MapParent.gameObject,"OriginalMapSlot");transition.eliteObjects=Child(fixture,"Elite");transition.gecisanim=Child(fixture,"TransitionVisual");transition.castleArea=Child(fixture,"Castle");
            var menu=Child(fixture,"DisabledSettings",false).AddComponent<MenuGeneralSettings>();menu.enabled=false;menu._muzikObj=Child(menu.gameObject,"OriginalMusicToggle").transform;Child(menu._muzikObj.gameObject,"Tick");
            var loader=Child(fixture,"ManualOriginalLoading",false).AddComponent<LoadingPage>();loader.enabled=false;
            Child(fixture,"FixtureListener").AddComponent<AudioListener>();
            SessionState.SetString(Pending+".profile",Path.Combine(Directory.GetParent(Application.dataPath).FullName,"Verification","BgmPlaybackTests",Guid.NewGuid().ToString("N")));
            SessionState.SetBool(Pending,true);
        } finally {EditorSceneManager.CloseScene(original,true);}
        EditorApplication.EnterPlaymode();
    }
    static void PlayState(PlayModeStateChange s){if(s==PlayModeStateChange.EnteredPlayMode&&SessionState.GetBool(Pending,false))EditorApplication.delayCall+=Begin;}
    static void Begin()
    {
        SessionState.SetBool(Pending,false);r=new Result{playMode=Application.isPlaying,profile=SessionState.GetString(Pending+".profile","")};started=Time.realtimeSinceStartup;lastFrame=-1;phase=0;loadingDone=false;
        try {
            OfflineKeyStore.SetVerificationRoot(r.profile);Time.timeScale=1;Basarimlar.eklendi=false;GameManager.EliteON=false;WarController.Dungeondayim=false;
            var root=GameObject.Find("BgmPlaybackFixture");sm=root.GetComponentInChildren<SoundManager>(true);war=root.GetComponentInChildren<WarController>(true);home=root.GetComponentInChildren<GecisControl>(true);settings=root.GetComponentInChildren<MenuGeneralSettings>(true);loading=root.GetComponentInChildren<LoadingPage>(true);
            SoundManager.instance=null;root.transform.Find("OriginalAudioHolder").gameObject.SetActive(true);
            Check(SoundManager.instance==sm,"real original SoundManager.Awake initialized singleton");
            Check(sm.musicSource&&sm.musicSource.gameObject==sm.gameObject&&sm.musicSource.loop&&!sm.musicSource.mute&&!sm.musicSource.playOnAwake&&Mathf.Abs(sm.musicSource.volume-.3f)<.0001f&&sm.musicSource.spatialBlend==0&&sm.musicSource.outputAudioMixerGroup==null,"original level0 music AudioSource settings preserved: volume.3, looping,2D, direct output, no PlayOnAwake");
            Check(SoundManager._muzik&&SoundManager._lobby&&SoundManager._muzik==Resources.Load<AudioClip>("Music/music")&&SoundManager._lobby==Resources.Load<AudioClip>("Music/musiclobby"),"real Awake resolves original64-path BGM identities");
            Check(AssetDatabase.GetAssetPath(SoundManager._muzik)=="Assets/Resources/music/music.ogg"&&AssetDatabase.GetAssetPath(SoundManager._lobby)=="Assets/Resources/music/musiclobby.ogg","original imported OGG identities retained");
            Check(SoundManager._muzik.samples==3305088&&SoundManager._lobby.samples==3103488&&SoundManager._muzik.frequency==48000&&SoundManager._lobby.frequency==48000,"OGG imported lengths match original client sample frames");
            Check(!AudioListener.pause&&AudioListener.volume>0,"fixture listener is audible; no forced listener/mixer override");
            home.gameObject.SetActive(true);home.StartCoroutine(LoadingUntilLobby());EditorApplication.update+=Poll;
        } catch(Exception e){r.failures.Add(e.ToString());Complete();}
    }
    static IEnumerator LoadingUntilLobby()
    {
        var e=(IEnumerator)typeof(LoadingPage).GetMethod("Start",BindingFlags.NonPublic|BindingFlags.Instance).Invoke(loading,null);
        while(e.MoveNext()){
            // Stop at the native lobby callback, before yielding its following1.5s wait.
            // This avoids replacing the isolated harness with the real Sahne scene.
            if(sm.musicSource.clip==SoundManager._lobby){loadingDone=true;yield break;}
            yield return e.Current;
        }
        throw new InvalidOperationException("Original Loading.Start reached scene-load without selecting original lobby music.");
    }
    static void WarEnable(){typeof(WarController).GetMethod("OnEnable",BindingFlags.NonPublic|BindingFlags.Instance).Invoke(war,null);}
    static void StartObserve(string stage)
    {
        var s=sm.musicSource;var c=s.clip;observation=new Observation{stage=stage,clip=c?c.name:"",assetPath=c?AssetDatabase.GetAssetPath(c):"",loadState=c?c.loadState.ToString():"null",mixer=s.outputAudioMixerGroup?s.outputAudioMixerGroup.name:"null",playing=s.isPlaying,enabled=s.enabled,active=s.gameObject.activeInHierarchy,mute=s.mute,loop=s.loop,listenerPause=AudioListener.pause,firstSample=s.timeSamples,lastSample=s.timeSamples,samples=c?c.samples:0,frequency=c?c.frequency:0,channels=c?c.channels:0,volume=s.volume,pitch=s.pitch,spatialBlend=s.spatialBlend,listenerVolume=AudioListener.volume,firstDsp=AudioSettings.dspTime};lastSample=s.timeSamples;stageAt=Time.realtimeSinceStartup;
    }
    static void Sample()
    {
        var s=sm.musicSource;int now=s.timeSamples;if(now!=lastSample)observation.distinctSamples++;lastSample=now;observation.lastSample=now;observation.lastDsp=AudioSettings.dspTime;observation.playing&=s.isPlaying;
        var output=new float[2048];s.GetOutputData(output,0);foreach(var v in output)observation.outputPeak=Mathf.Max(observation.outputPeak,Mathf.Abs(v));
    }
    static void FinishObserve()
    {
        var c=sm.musicSource.clip;var pcm=new float[4096];bool read=c&&c.GetData(pcm,Math.Min(24000,Math.Max(0,c.samples-4096)));if(read)foreach(var v in pcm)observation.pcmPeak=Mathf.Max(observation.pcmPeak,Mathf.Abs(v));
        Check(observation.playing&&observation.distinctSamples>=2&&observation.lastSample>observation.firstSample,"actual "+observation.stage+" AudioSource.timeSamples advances while playing");
        Check(observation.lastDsp-observation.firstDsp>.25,"actual "+observation.stage+" audio DSP clock advances (no null/headless audio PASS)");
        Check(observation.outputPeak>.00001f,"actual "+observation.stage+" source output contains nonzero samples");
        Check(read&&observation.pcmPeak>.00001f,"actual "+observation.stage+" original imported clip decodes nonzero PCM");r.observations.Add(observation);
    }
    static void Poll()
    {
        if(Time.frameCount==lastFrame)return;lastFrame=Time.frameCount;
        try {
            if(Time.realtimeSinceStartup-started>45){r.failures.Add("BGM lifecycle/sample verification timed out; no playback claimed.");Complete();return;}
            if(phase==0){if(!loadingDone||!sm.musicSource.isPlaying)return;Check(!GameManager.GuideDone&&!MenuGeneralSettings.MuzikOnOf&&sm.musicSource.clip==SoundManager._lobby,"original first-launch Loading.Start selects lobby with native music-enabled default");StartObserve("first-lobby");phase=1;return;}
            if(phase==1){Sample();if(Time.realtimeSinceStartup-stageAt<1.2f)return;FinishObserve();WarEnable();Check(sm.musicSource.clip==SoundManager._lobby&&sm.musicSource.isPlaying,"GuideDone=false leaves existing lobby track untouched");sm.stopBackgroundMusic();GameManager.GuideDone=true;WarEnable();Check(sm.musicSource.clip==SoundManager._muzik,"GuideDone=true original OnEnable selects battle track");phase=10;return;}
            if(phase==10){if(!sm.musicSource.isPlaying)return;StartObserve("battle");phase=2;return;}
            if(phase==2){Sample();if(Time.realtimeSinceStartup-stageAt<1.2f)return;FinishObserve();settings.MuzikAc();Check(MenuGeneralSettings.MuzikOnOf&&!sm.musicSource.isPlaying&&sm.musicSource.clip==SoundManager._muzik,"actual music preference toggle saves disabled state and stops original battle source");WarEnable();Check(sm.musicSource.clip==SoundManager._muzik&&!sm.musicSource.isPlaying,"music-off preference prevents original OnEnable playback");settings.MuzikAc();Check(!MenuGeneralSettings.MuzikOnOf&&sm.musicSource.clip==SoundManager._muzik,"actual toggle re-enables same original battle clip");Time.timeScale=0;StartObserve("battle-timescale-paused");phase=3;return;}
            if(phase==3){Sample();if(Time.realtimeSinceStartup-stageAt<1.2f)return;FinishObserve();Time.timeScale=1;home.SavasaBittiSiege();Check(!sm.musicSource.isPlaying,"actual original return-home coroutine first stops battle music");stageAt=Time.realtimeSinceStartup;phase=4;return;}
            if(phase==4){if(sm.musicSource.clip!=SoundManager._lobby||!sm.musicSource.isPlaying)return;Check(Time.realtimeSinceStartup-stageAt>=.8f,"actual return-home lobby switch follows original1-second wait");StartObserve("return-home-lobby");phase=5;return;}
            if(phase==5){Sample();if(Time.realtimeSinceStartup-stageAt<1.2f)return;FinishObserve();Complete();}
        } catch(Exception e){r.failures.Add(e.ToString());Complete();}
    }
    static void Complete()
    {
        EditorApplication.update-=Poll;Time.timeScale=1;if(r==null)r=new Result();r.passed=r.failures.Count==0;var folder=Path.Combine(Directory.GetParent(Application.dataPath).FullName,"Verification");Directory.CreateDirectory(folder);File.WriteAllText(Path.Combine(folder,"bgm-playback.json"),JsonUtility.ToJson(r,true));Debug.Log(JsonUtility.ToJson(r));EditorApplication.Exit(r.passed?0:1);
    }
}
