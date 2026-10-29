using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using TMPro;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[InitializeOnLoad]
public static class PageMenuButtonVerification
{
    const string Pending="LuckyForge.VerifyOriginalPageMenuButtons";
    const string Owner="OriginalPageMenuRouteOwner";
    [Serializable]public sealed class Result{public bool passed;public int checks;public bool playMode;public string route="original-scene-button-serialized-callbacks; target-only remap into isolated fixture; synthetic pointerClick, not physical input";public string profile;public float activationReal,detachReal;public List<string> failures=new List<string>();}
    static Result result;static PageReferences p;static Button open,close;static MenuGeneralSettings menu;static Transform[] canvases;static Vector3[] world;static int phase,lastFrame;static float started;
    static PageMenuButtonVerification(){EditorApplication.playModeStateChanged+=OnPlayState;}
    static void Check(bool ok,string label){result.checks++;if(!ok)result.failures.Add(label);}
    static GameObject Child(GameObject root,string name,bool active=true){var go=new GameObject(name);go.transform.SetParent(root.transform);go.SetActive(active);return go;}
    static TextMeshProUGUI Label(GameObject root,string name){var go=new GameObject(name,typeof(RectTransform),typeof(CanvasRenderer),typeof(TextMeshProUGUI));go.transform.SetParent(root.transform);return go.GetComponent<TextMeshProUGUI>();}
    static GameObject FindPath(Scene scene,string path){var parts=path.Split('/');foreach(var root in scene.GetRootGameObjects()){if(root.name!=parts[0])continue;var t=root.transform;for(int i=1;i<parts.Length&&t;i++)t=t.Find(parts[i]);return t?t.gameObject:null;}return null;}
    static Button CloneOriginalButton(Scene original,string path,string method,Transform parent,PageReferences isolatedTarget,string name)
    {
        var source=FindPath(original,path);if(!source)throw new InvalidOperationException("Original button missing: "+path);var originalButton=source.GetComponent<Button>();if(!originalButton||originalButton.onClick.GetPersistentEventCount()!=1||originalButton.onClick.GetPersistentMethodName(0)!=method||!(originalButton.onClick.GetPersistentTarget(0)is PageReferences)||originalButton.onClick.GetPersistentListenerState(0)!=UnityEngine.Events.UnityEventCallState.RuntimeOnly)throw new InvalidOperationException("Original runtime-only PageReferences callback differs: "+path);
        var clone=UnityEngine.Object.Instantiate(source,parent,false);clone.name=name;var button=clone.GetComponent<Button>();var so=new SerializedObject(button);var calls=so.FindProperty("m_OnClick.m_PersistentCalls.m_Calls");if(calls.arraySize!=1)throw new InvalidOperationException("Original callback count changed during clone.");
        // Preserve the real method, mode, arguments and RuntimeOnly state. Only replace the
        // original-scene target reference with the same-type isolated object before unloading.
        calls.GetArrayElementAtIndex(0).FindPropertyRelative("m_Target").objectReferenceValue=isolatedTarget;so.ApplyModifiedPropertiesWithoutUndo();return button;
    }
    static MenuGeneralSettings CreateSettings(GameObject menuObject,GameManager gm)
    {
        var component=menuObject.AddComponent<MenuGeneralSettings>();component._gm=gm;
        foreach(var f in typeof(MenuGeneralSettings).GetFields(BindingFlags.Instance|BindingFlags.Public)){
            if(f.FieldType==typeof(Text)){var go=new GameObject(f.Name,typeof(RectTransform),typeof(CanvasRenderer),typeof(Text));go.transform.SetParent(menuObject.transform);f.SetValue(component,go.GetComponent<Text>());}
            else if(f.FieldType==typeof(TextMeshProUGUI))f.SetValue(component,Label(menuObject,f.Name));
        }
        component._joinandget=new[]{Label(menuObject,"Join0"),Label(menuObject,"Join1")};component.optimizationCheck=Child(menuObject,"OptimizationCheck");component._highobj=Child(menuObject,"QualityHigh");component._lowobj=Child(menuObject,"QualityLow");component._cloudacik=Child(menuObject,"SavedCloudOn");component._cloudkapali=Child(menuObject,"SavedCloudOff");component.instaodul=Child(menuObject,"SocialA");component.discordodul=Child(menuObject,"SocialB");
        foreach(var name in new[]{"_seslerObj","_muzikObj","_titresimObj","_bildirimlerObj"}){var go=Child(menuObject,name);Child(go,"OriginalTick");typeof(MenuGeneralSettings).GetField(name).SetValue(component,go.transform);}return component;
    }
    public static void RunBatch()
    {
        var empty=EditorSceneManager.NewScene(NewSceneSetup.EmptyScene,NewSceneMode.Single);var original=EditorSceneManager.OpenScene("Assets/Scenes/Sahne.unity",OpenSceneMode.Additive);var fixture=new GameObject("OriginalMenuRouteFixture");SceneManager.MoveGameObjectToScene(fixture,empty);
        try{
            var owner=Child(fixture,Owner,false);p=owner.AddComponent<PageReferences>();var groups=new GameObject[3];for(int i=0;i<3;i++)groups[i]=Child(owner,"OriginalCanvasGroup"+i);p.Menu=Child(groups[0],"OriginalMenuPanel",false);p.Karts=Child(groups[0],"Karts",false);p.ChestArea=Child(groups[0],"Chest",false);p.KaynakYok=Child(groups[2],"ResourceInfo",false);p._starterpackicon=Child(groups[0],"ExistingOfferIcon");p._MainCamera=Child(fixture,"IsolatedCamera").AddComponent<Camera>();p._MainCulling=5;p._TamSayfaCulling=32;
            p._kaynaksubtitle=Label(groups[2],"ResourceTitle");p._kaynakbtnustu=Label(groups[2],"ResourceButton");p._guncellemelazimtext=new Text[2];for(int i=0;i<2;i++){var go=new GameObject("UpdateText"+i,typeof(RectTransform),typeof(CanvasRenderer),typeof(Text));go.transform.SetParent(groups[2].transform);p._guncellemelazimtext[i]=go.GetComponent<Text>();}
            var gm=Child(fixture,"InactiveGameManager",false).AddComponent<GameManager>();CreateSettings(p.Menu,gm);Child(fixture,"InactiveSound",false).AddComponent<SoundManager>();fixture.AddComponent<EventSystem>();
            CloneOriginalButton(original,"Canvases/BottomCanvas/SafeArea/YukariBolge/menu","PageAc_Menu",groups[1].transform,p,"OriginalHomeSettingsButton");CloneOriginalButton(original,"Canvases/GenelCanvas/SafeArea/Menu/Menu/Close","A_PageKapat",p.Menu.transform,p,"OriginalSettingsCloseButton");
            SessionState.SetString(Pending+".profile",Path.Combine(Directory.GetParent(Application.dataPath).FullName,"Verification","PageMenuButtonTests",Guid.NewGuid().ToString("N")));SessionState.SetBool(Pending,true);
        }finally{EditorSceneManager.CloseScene(original,true);}
        EditorApplication.EnterPlaymode();
    }
    static void OnPlayState(PlayModeStateChange state){if(state==PlayModeStateChange.EnteredPlayMode&&SessionState.GetBool(Pending,false))EditorApplication.delayCall+=Begin;}
    static void Begin()
    {
        SessionState.SetBool(Pending,false);result=new Result{playMode=Application.isPlaying,profile=SessionState.GetString(Pending+".profile","")};started=Time.realtimeSinceStartup;phase=0;lastFrame=-1;
        try{
            OfflineKeyStore.SetVerificationRoot(result.profile);Time.timeScale=1f;GameManager.Language=0;GameManager.PerformansMode=false;GameManager.PageAcildi=false;GameManager.TamPageAcildi=false;GecisControl.savastayim=false;MenuGeneralSettings.FPS=60;PageReferences.tamsayfa=true;
            foreach(var c in Resources.FindObjectsOfTypeAll<PageReferences>())if(c&&c.gameObject.scene.IsValid()&&c.name==Owner){p=c;break;}if(!p)throw new InvalidOperationException("Prepared isolated PageReferences lost.");
            menu=p.Menu.GetComponent<MenuGeneralSettings>();SoundManager.instance=p.transform.parent.GetComponentInChildren<SoundManager>(true);open=p.transform.GetChild(1).Find("OriginalHomeSettingsButton").GetComponent<Button>();close=p.Menu.transform.Find("OriginalSettingsCloseButton").GetComponent<Button>();canvases=new[]{p.transform.GetChild(0),p.transform.GetChild(1),p.transform.GetChild(2)};world=new[]{canvases[0].position,canvases[1].position,canvases[2].position};
            Check(Application.isPlaying,"original serialized RuntimeOnly button callbacks execute in real PlayMode");Check(open.onClick.GetPersistentTarget(0)==p&&open.onClick.GetPersistentMethodName(0)=="PageAc_Menu"&&close.onClick.GetPersistentTarget(0)==p&&close.onClick.GetPersistentMethodName(0)=="A_PageKapat","actual source button callbacks preserved with target-only fixture remap");
            result.activationReal=Time.realtimeSinceStartup;p.gameObject.SetActive(true);EditorApplication.update+=Poll;
        }catch(Exception e){result.failures.Add(e.ToString());Complete();}
    }
    static void PointerClick(Button b){if(!ExecuteEvents.Execute(b.gameObject,new PointerEventData(EventSystem.current){button=PointerEventData.InputButton.Left,clickCount=1,eligibleForClick=true},ExecuteEvents.pointerClickHandler))throw new InvalidOperationException("Original Button did not handle pointerClick.");}
    static void Poll()
    {
        if(Time.frameCount==lastFrame)return;lastFrame=Time.frameCount;
        try{
            if(Time.realtimeSinceStartup-started>10){result.failures.Add("Original serialized menu route or native Canvas coroutine timed out.");Complete();return;}
            if(phase==0){if(PageReferences.tamsayfa)return;Check(!p.Menu.activeInHierarchy&&p.transform.childCount==3,"native startup begins with menu hidden and3 grouped canvases");Check(p._kaynaksubtitle.text==Lang.Get.kaynakyoktitle&&p._kaynakbtnustu.text==Lang.Get.kaynakyokbtn&&p._guncellemelazimtext[0].text==Lang.Get.guncellemetitle&&p._guncellemelazimtext[1].text==Lang.Get.guncellemesubtitle,"real original PageReferences.Start initializes local labels");PointerClick(open);Check(GameManager.PageAcildi&&p.Menu.activeInHierarchy&&menu._gm.saveit==31,"original homepage button event reaches PageReferences and actual settings OnEnable");phase=1;return;}
            if(phase==1){Check(menu._title.text==Lang.Get.Menutitle&&menu._fpskac.text=="FPS 60","opened settings runs its restored native Start through lifecycle");GameManager.lokasyonClicked=8;p._MainCamera.cullingMask=99;PointerClick(close);Check(!GameManager.PageAcildi&&!p.Menu.activeInHierarchy&&GameManager.lokasyonClicked==0&&p._MainCamera.cullingMask==5,"original close button event reaches local close/camera/global-state cleanup");phase=2;return;}
            if(phase==2&&p.transform.childCount==0){result.detachReal=Time.realtimeSinceStartup;bool preserved=true;for(int i=0;i<3;i++)preserved&=canvases[i]&&canvases[i].parent==null&&canvases[i].position==world[i];Check(preserved,"actual native2-second coroutine detaches all three groups without changing world positions");Check(result.detachReal-result.activationReal>=1.5f&&result.detachReal-result.activationReal<6f,"real native Canvas detach happens after scaled2-second wait");Check(!GameManager.PageAcildi&&!p.Menu.activeInHierarchy,"native hierarchy detach does not reopen closed settings");Complete();return;}
        }catch(Exception e){result.failures.Add(e.ToString());Complete();}
    }
    static void Complete(){EditorApplication.update-=Poll;result.passed=result.failures.Count==0;var folder=Path.Combine(Directory.GetParent(Application.dataPath).FullName,"Verification");Directory.CreateDirectory(folder);File.WriteAllText(Path.Combine(folder,"page-menu-buttons.json"),JsonUtility.ToJson(result,true));Debug.Log(JsonUtility.ToJson(result));EditorApplication.Exit(result.passed?0:1);}
}
