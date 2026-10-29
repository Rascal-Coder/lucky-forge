using System;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
[InitializeOnLoad]
public static class EnergyRightsButtonsVerification
{
    const string Pending="LuckyForge.VerifyOriginalEnergyButtons";
    [Serializable]public sealed class Result{public bool passed;public int checks;public bool playMode;public string profile;public string route="real source Button serialized-component copies; target/renderer remap only; synthetic pointerClick, not physical input";public List<string> sourcePaths=new List<string>();public List<string> failures=new List<string>();}
    static Result result;
    static EnergyRightsButtonsVerification(){EditorApplication.playModeStateChanged+=OnPlayState;}
    static void Check(bool ok,string label){result.checks++;if(!ok)result.failures.Add(label);}
    static string PathOf(Transform t){string s=t.name;for(t=t.parent;t;t=t.parent)s=t.name+"/"+s;return s;}
    static Button CopyButton(Scene scene,string path,string method,UnityEngine.Object target,Transform parent,string name)
    {
        Button source=null;foreach(var b in Resources.FindObjectsOfTypeAll<Button>())if(b&&b.gameObject.scene==scene&&PathOf(b.transform)==path){source=b;break;}
        if(!source||source.onClick.GetPersistentEventCount()!=1||source.onClick.GetPersistentMethodName(0)!=method||source.onClick.GetPersistentTarget(0).GetType()!=target.GetType()||source.onClick.GetPersistentListenerState(0)!=UnityEngine.Events.UnityEventCallState.RuntimeOnly)throw new InvalidOperationException("Original callback differs: "+path);
        var go=new GameObject(name,typeof(RectTransform),typeof(CanvasRenderer),typeof(Image),typeof(Button));go.transform.SetParent(parent,false);go.SetActive(false);var button=go.GetComponent<Button>();EditorUtility.CopySerialized(source,button);button.targetGraphic=go.GetComponent<Image>();
        var so=new SerializedObject(button);so.FindProperty("m_OnClick.m_PersistentCalls.m_Calls").GetArrayElementAtIndex(0).FindPropertyRelative("m_Target").objectReferenceValue=target;so.ApplyModifiedPropertiesWithoutUndo();go.SetActive(true);return button;
    }
    public static void RunBatch()
    {
        var empty=EditorSceneManager.NewScene(NewSceneSetup.EmptyScene,NewSceneMode.Single);var original=EditorSceneManager.OpenScene("Assets/Scenes/Sahne.unity",OpenSceneMode.Additive);var root=new GameObject("OriginalEnergyButtonFixture");root.SetActive(false);SceneManager.MoveGameObjectToScene(root,empty);
        try{
            var energy=EnergyRightsFixtureData.Build(root,"OriginalEnergyPanel");EnergyRightsFixtureData.Child(root,"InactiveSound",false).AddComponent<SoundManager>();var transition=EnergyRightsFixtureData.Child(root,"InactiveTransition",false).AddComponent<GecisControl>();transition.enerji=energy;root.AddComponent<EventSystem>();
            CopyButton(original,"Canvases/BottomCanvas/SafeArea/YukariBolge/ParaKristalSTAT/energy","OpenClose",energy,root.transform,"OriginalTopEnergyButton");
            CopyButton(original,"Canvases/TopCanvasJobs/TopCanvas/Energy/Close (1)","OpenClose",energy,energy.transform,"OriginalEnergyCloseButton");
            CopyButton(original,"Canvases/TopCanvasJobs/TopCanvas/Energy/bilgiback (4)","CrystalHarcandi",energy,energy.transform,"OriginalCrystalPurchaseButton");
            Button battleSource=null;foreach(var b in Resources.FindObjectsOfTypeAll<Button>())if(b&&b.gameObject.scene==original&&b.onClick.GetPersistentEventCount()==1&&b.onClick.GetPersistentMethodName(0)=="SavasaGitSiege"&&b.onClick.GetPersistentTarget(0)is GecisControl){battleSource=b;break;}if(!battleSource)throw new InvalidOperationException("Original battle-start callback missing.");
            var battlePath=PathOf(battleSource.transform);CopyButton(original,battlePath,"SavasaGitSiege",transition,root.transform,"OriginalInsufficientEnergyBattleButton");SessionState.SetString(Pending+".battlePath",battlePath);
            SessionState.SetString(Pending+".profile",Path.Combine(Directory.GetParent(Application.dataPath).FullName,"Verification","EnergyButtonTests",Guid.NewGuid().ToString("N")));SessionState.SetBool(Pending,true);
        }finally{EditorSceneManager.CloseScene(original,true);}
        EditorApplication.EnterPlaymode();
    }
    static void OnPlayState(PlayModeStateChange state){if(state==PlayModeStateChange.EnteredPlayMode&&SessionState.GetBool(Pending,false))EditorApplication.delayCall+=Run;}
    static Button Button(GameObject owner,string name){foreach(var b in owner.GetComponentsInChildren<Button>(true))if(b.name==name)return b;throw new InvalidOperationException("Prepared button missing: "+name);}
    static void Click(Button b){if(!b.isActiveAndEnabled||!b.IsInteractable()||!ExecuteEvents.Execute(b.gameObject,new PointerEventData(EventSystem.current){button=PointerEventData.InputButton.Left,eligibleForClick=true,clickCount=1},ExecuteEvents.pointerClickHandler))throw new InvalidOperationException("Original button is not normally clickable: "+b.name);}
    static void Run()
    {
        SessionState.SetBool(Pending,false);result=new Result{playMode=Application.isPlaying,profile=SessionState.GetString(Pending+".profile","")};result.sourcePaths.Add("Canvases/BottomCanvas/SafeArea/YukariBolge/ParaKristalSTAT/energy");result.sourcePaths.Add("Canvases/TopCanvasJobs/TopCanvas/Energy/Close (1)");result.sourcePaths.Add("Canvases/TopCanvasJobs/TopCanvas/Energy/bilgiback (4)");result.sourcePaths.Add(SessionState.GetString(Pending+".battlePath",""));
        try{
            OfflineKeyStore.SetVerificationRoot(result.profile);Time.timeScale=1;GameManager.Language=0;GameManager.EliteON=false;if(PlayerData.clanPerksDatam==null)PlayerData.clanPerksDatam=new PlayerData.ClanPerksData();
            EnergyRightsCanvas c=null;foreach(var item in Resources.FindObjectsOfTypeAll<EnergyRightsCanvas>())if(item&&item.gameObject.scene.IsValid()&&item.name=="OriginalEnergyPanel"){c=item;break;}if(!c)throw new InvalidOperationException("Prepared Energy panel missing.");var root=c.transform.parent.gameObject;SoundManager.instance=root.GetComponentInChildren<SoundManager>(true);BuyukParticle.Energy=EnergyRightsFixtureData.Child(root,"OwnedParticle",false).AddComponent<ParticleSystem>();
            ES3.Save<int>("CrystalEnergyRemaining",4);ES3.Save<DateTime>("CrystalEnergyResetTime",DateTime.UtcNow);ES3.Save<int>("AdEnergyRemaining",2);ES3.Save<DateTime>("AdEnergyResetTime",DateTime.UtcNow);Currencys.CrystalFitle(500);Currencys.EnergyFitle(0);root.SetActive(true);
            var open=Button(root,"OriginalTopEnergyButton");var close=Button(root,"OriginalEnergyCloseButton");var purchase=Button(root,"OriginalCrystalPurchaseButton");var battle=Button(root,"OriginalInsufficientEnergyBattleButton");
            Check(Application.isPlaying,"original RuntimeOnly callbacks execute in real PlayMode");Check(open.onClick.GetPersistentTarget(0)==c&&open.onClick.GetPersistentMethodName(0)=="OpenClose"&&purchase.onClick.GetPersistentTarget(0)==c&&purchase.onClick.GetPersistentMethodName(0)=="CrystalHarcandi","real source persistent methods/targets retained with isolated references");
            Click(battle);Check(c.gameObject.activeInHierarchy&&Currencys.Energy==0&&Currencys.Crystal==500,"actual battle-start callback opens energy dialog when below5 without charging");Check(c.claimEnergy.text==Lang.Get.GetEnergy&&(int)EnergyRightsFixtureData.Get(c,"crystalRemaining")==4,"native Awake/OnEnable initialize the opened dialog");Click(close);Check(!c.gameObject.activeSelf,"actual close-button callback closes dialog");Click(open);Check(c.gameObject.activeInHierarchy&&purchase.IsInteractable(),"actual top Energy callback opens normally clickable purchase option");
            Click(purchase);Check(Currencys.Crystal==400&&Currencys.Energy==30&&(int)EnergyRightsFixtureData.Get(c,"crystalRemaining")==3,"actual original purchase button pays100 for30");var first=(DateTime)EnergyRightsFixtureData.Get(c,"crystalResetTime");Click(purchase);Click(purchase);Click(purchase);Check(Currencys.Crystal==100&&Currencys.Energy==120&&(int)EnergyRightsFixtureData.Get(c,"crystalRemaining")==0,"four real original button events preserve quota4 and allow paid energy above natural cap");Click(purchase);Check(Currencys.Crystal==100&&Currencys.Energy==120&&purchase.IsInteractable(),"fifth clickable original button event is rejected by handler quota guard, not new UI hardening");Click(close);Click(open);Check((int)EnergyRightsFixtureData.Get(c,"crystalRemaining")==0&&(DateTime)EnergyRightsFixtureData.Get(c,"crystalResetTime")==first,"normal close/reopen does not reset consumed quota or window");Click(close);
            EnergyRightsFixtureData.FlushEnergy(SoundManager.instance.gameObject);OfflineKeyStore.ResetMemoryForVerification();EnergyRightsFixtureData.SetCrystal(0,0);EnergyRightsFixtureData.SetEnergy(0,0);Currencys.LoadStartCrystal();Currencys.LoadStartEnergy();var restarted=EnergyRightsFixtureData.Build(root,"RestartedEnergyPanel");restarted.gameObject.SetActive(true);Check(Currencys.Crystal==100&&Currencys.Energy==120&&(int)EnergyRightsFixtureData.Get(restarted,"crystalRemaining")==0&&(DateTime)EnergyRightsFixtureData.Get(restarted,"crystalResetTime")==first,"fresh component Awake and disk reread preserve paid balances and exhausted window");Check((int)EnergyRightsFixtureData.Get(restarted,"adRemaining")==2&&ES3.Load<int>("AdEnergyRemaining")==2,"original ad quota remains unconsumed; no ad callback invoked");
        }catch(Exception e){result.failures.Add(e.ToString());}
        result.passed=result.failures.Count==0;var folder=Path.Combine(Directory.GetParent(Application.dataPath).FullName,"Verification");Directory.CreateDirectory(folder);File.WriteAllText(Path.Combine(folder,"energy-rights-buttons.json"),JsonUtility.ToJson(result,true));Debug.Log(JsonUtility.ToJson(result));EditorApplication.Exit(result.passed?0:1);
    }
}
