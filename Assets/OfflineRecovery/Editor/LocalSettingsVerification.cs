using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
public static class LocalSettingsVerification
{
    [Serializable] public sealed class Result { public bool passed; public int checks; public List<string> failures=new List<string>(); }
    static void Check(Result r,bool ok,string label){r.checks++;if(!ok)r.failures.Add(label);}
    static GameObject Child(GameObject root,string name){var go=new GameObject(name);go.transform.SetParent(root.transform);return go;}
    static Transform Tick(GameObject root,string name){var go=Child(root,name);Child(go,"OriginalTick");return go.transform;}
    static void Invoke(MenuGeneralSettings menu,string method){typeof(MenuGeneralSettings).GetMethod(method,BindingFlags.Instance|BindingFlags.NonPublic).Invoke(menu,null);}
    public static Result RunChecks()
    {
        var r=new Result();var root=new GameObject("LocalSettingsVerification");root.SetActive(false);
        var audio=new GameObject("LocalSettingsTestAudio");
        var old=new Dictionary<FieldInfo,object>();
        foreach(var f in typeof(MenuGeneralSettings).GetFields(BindingFlags.Static|BindingFlags.Public)) old[f]=f.GetValue(null);
        var oldSound=SoundManager.instance;int oldLanguage=GameManager.Language,oldRate=Application.targetFrameRate,oldQuality=QualitySettings.GetQualityLevel();bool oldPage=GameManager.PageAcildi;
        var oldLang=Lang.currentLang;var oldRandom=UnityEngine.Random.state;
        var rootField=typeof(OfflineKeyStore).GetField("verificationRoot",BindingFlags.Static|BindingFlags.NonPublic);
        string oldRoot=(string)rootField.GetValue(null);
        AudioClip silence=null;
        try
        {
            OfflineKeyStore.SetVerificationRoot(Path.Combine(Directory.GetParent(Application.dataPath).FullName,"Verification","SettingsTests",Guid.NewGuid().ToString("N")));
            var menuObject=Child(root,"SettingsPanel");var menu=menuObject.AddComponent<MenuGeneralSettings>();menu._gm=root.AddComponent<GameManager>();
            var sound=root.AddComponent<SoundManager>();SoundManager.instance=sound;
            silence=AudioClip.Create("SettingsTestSilent",4410,1,44100,false);
            sound.efxSource=audio.AddComponent<AudioSource>();sound.CashSource=audio.AddComponent<AudioSource>();sound.musicSource=audio.AddComponent<AudioSource>();
            sound.efxSource.clip=silence;sound.CashSource.clip=silence;sound.musicSource.clip=silence;
            foreach(var f in typeof(MenuGeneralSettings).GetFields(BindingFlags.Instance|BindingFlags.Public))
            {
                if(f.FieldType==typeof(Text)){var go=new GameObject(f.Name,typeof(RectTransform),typeof(CanvasRenderer),typeof(Text));go.transform.SetParent(root.transform);f.SetValue(menu,go.GetComponent<Text>());}
                else if(f.FieldType==typeof(TextMeshProUGUI)){var go=new GameObject(f.Name,typeof(RectTransform),typeof(CanvasRenderer),typeof(TextMeshProUGUI));go.transform.SetParent(root.transform);f.SetValue(menu,go.GetComponent<TextMeshProUGUI>());}
            }
            menu._joinandget=new TextMeshProUGUI[2];for(int i=0;i<2;i++){var go=new GameObject("JoinLabel"+i,typeof(RectTransform),typeof(CanvasRenderer),typeof(TextMeshProUGUI));go.transform.SetParent(root.transform);menu._joinandget[i]=go.GetComponent<TextMeshProUGUI>();}
            menu.optimizationCheck=Child(root,"OptimizationCheck");menu._highobj=Child(root,"QualityHigh");menu._lowobj=Child(root,"QualityLow");menu._cloudacik=Child(root,"SavedCloudOn");menu._cloudkapali=Child(root,"SavedCloudOff");menu.instaodul=Child(root,"SocialRewardA");menu.discordodul=Child(root,"SocialRewardB");
            menu._seslerObj=Tick(root,"Sound");menu._muzikObj=Tick(root,"Music");menu._titresimObj=Tick(root,"Vibration");menu._bildirimlerObj=Tick(root,"Notifications");
            GameManager.Language=0;MenuGeneralSettings.FPS=89;MenuGeneralSettings.CloseTextObjects=true;MenuGeneralSettings.Optimization=false;MenuGeneralSettings.EfektOnOf=false;MenuGeneralSettings.MuzikOnOf=true;MenuGeneralSettings.TitresimOnOf=false;MenuGeneralSettings.BildirimOnOf=true;
            ES3.Save<bool>("discordodul",false);ES3.Save<bool>("instaodul",false);
            Invoke(menu,"OnEnable");Check(r,menu._gm.saveit==31f,"original OnEnable schedules saveit31");
            Invoke(menu,"Start");
            Check(r,menu._title.text==Lang.Get.Menutitle&&menu._Ayarlartitle.text==Lang.Get.ayarlarbulut&&menu._Dillertitle.text==Lang.Get.diller,"original localized title labels");
            Check(r,menu._kalite.text==Lang.Get.quality&&menu._medium.text==Lang.Get.low&&menu._high.text==Lang.Get.high&&menu._joinandget[0].text==Lang.Get.joinandget50&&menu._joinandget[1].text==Lang.Get.joinandget50,"quality and existing join labels localized");
            Check(r,menu._fpskac.text=="FPS 89"&&MenuGeneralSettings.FPS==89,"Start displays current FPS without replacing it");
            Check(r,menu._seslerObj.GetChild(0).gameObject.activeSelf&&!menu._muzikObj.GetChild(0).gameObject.activeSelf&&menu._titresimObj.GetChild(0).gameObject.activeSelf&&!menu._bildirimlerObj.GetChild(0).gameObject.activeSelf,"original inverse OFF-flag ticks");
            Check(r,!menu._cloudacik.activeSelf&&menu._cloudkapali.activeSelf&&menu._highobj.activeSelf&&!menu._lowobj.activeSelf&&menu.optimizationCheck.activeSelf,"local saved cloud/quality/text displays");
            Check(r,!menu.instaodul.activeSelf&&!menu.discordodul.activeSelf,"social reward UI uses key presence even for stored false");
            ES3.Save<bool>("Cloudacilmis",true);Invoke(menu,"Start");Check(r,menu._cloudacik.activeSelf&&!menu._cloudkapali.activeSelf,"read-only saved cloud flag initializes existing indicator");
            menu.OpenCloseTexts();Check(r,!MenuGeneralSettings.CloseTextObjects&&!menu.optimizationCheck.activeSelf&&!ES3.Load<bool>("CloseTextObjects"),"text visibility toggle saves false");
            menu.OpenCloseTexts();Check(r,MenuGeneralSettings.CloseTextObjects&&menu.optimizationCheck.activeSelf&&ES3.Load<bool>("CloseTextObjects"),"text visibility toggle saves true");
            menu.TitresimAc();Check(r,MenuGeneralSettings.TitresimOnOf&&!menu._titresimObj.GetChild(0).gameObject.activeSelf&&ES3.Load<bool>("TitresimOnOf"),"vibration OFF persists and clears tick");
            menu.TitresimAc();Check(r,!MenuGeneralSettings.TitresimOnOf&&menu._titresimObj.GetChild(0).gameObject.activeSelf&&!ES3.Load<bool>("TitresimOnOf"),"vibration ON persists and restores tick");
            menu.EfektAc();Check(r,MenuGeneralSettings.EfektOnOf&&!menu._seslerObj.GetChild(0).gameObject.activeSelf&&ES3.Load<bool>("EfektOnOf"),"effects OFF persists and clears tick");
            menu.EfektAc();Check(r,!MenuGeneralSettings.EfektOnOf&&menu._seslerObj.GetChild(0).gameObject.activeSelf&&!ES3.Load<bool>("EfektOnOf"),"effects ON persists and restores tick");
            menu.MuzikAc();Check(r,!MenuGeneralSettings.MuzikOnOf&&menu._muzikObj.GetChild(0).gameObject.activeSelf&&!ES3.Load<bool>("MuzikOnOf"),"music ON persists and restores tick");
            menu.MuzikAc();Check(r,MenuGeneralSettings.MuzikOnOf&&!menu._muzikObj.GetChild(0).gameObject.activeSelf&&ES3.Load<bool>("MuzikOnOf"),"music OFF persists and clears tick");
            MenuGeneralSettings.FPS=60;menu.fpsdegistir();Check(r,MenuGeneralSettings.FPS==120&&Application.targetFrameRate==120&&menu._fpskac.text=="FPS 120"&&ES3.Load<int>("FPS")==120,"FPS60 becomes120 and persists");
            menu.fpsdegistir();Check(r,MenuGeneralSettings.FPS==30&&Application.targetFrameRate==30&&ES3.Load<int>("FPS")==30,"FPS120 becomes30");
            menu.fpsdegistir();Check(r,MenuGeneralSettings.FPS==60&&Application.targetFrameRate==60&&ES3.Load<int>("FPS")==60,"FPS30 becomes60");
            MenuGeneralSettings.FPS=73;menu.fpsdegistir();Check(r,MenuGeneralSettings.FPS==60,"native fallback FPS becomes60");
            Application.targetFrameRate=61;for(int i=0;i<10;i++)menu.setfps(47);Check(r,Application.targetFrameRate==61,"hidden setfps first10 calls leave target unchanged");
            menu.setfps(47);Check(r,Application.targetFrameRate==47&&MenuGeneralSettings.FPS==60&&ES3.Load<int>("FPS")==60,"hidden eleventh call changes target only without persisting FPS");
            menu.LowHighQuality();Check(r,MenuGeneralSettings.Optimization&&menu._lowobj.activeSelf&&!menu._highobj.activeSelf&&QualitySettings.GetQualityLevel()==0&&ES3.Load<bool>("Optimization"),"optimization true selects original low quality0");
            menu.LowHighQuality();Check(r,!MenuGeneralSettings.Optimization&&!menu._lowobj.activeSelf&&menu._highobj.activeSelf&&QualitySettings.GetQualityLevel()==1&&!ES3.Load<bool>("Optimization"),"optimization false selects original high quality1");
            ES3.StoreCachedFile("medupac.es3",new ES3Settings("medupac.es3",ES3.Location.File));OfflineKeyStore.ResetMemoryForVerification();
            Check(r,ES3.Load<bool>("MuzikOnOf")&&!ES3.Load<bool>("EfektOnOf")&&!ES3.Load<bool>("TitresimOnOf")&&ES3.Load<int>("FPS")==60&&!ES3.Load<bool>("Optimization")&&ES3.Load<bool>("CloseTextObjects"),"all local settings survive explicit flush and memory reset");
            GameManager.PageAcildi=true;menu.Closepage();Check(r,!GameManager.PageAcildi&&!menuObject.activeSelf,"Closepage clears global page flag and closes original object");
        }
        catch(Exception e){r.failures.Add(e.ToString());}
        finally
        {
            foreach(var row in old)row.Key.SetValue(null,row.Value);GameManager.Language=oldLanguage;GameManager.PageAcildi=oldPage;Lang.currentLang=oldLang;SoundManager.instance=oldSound;Application.targetFrameRate=oldRate;QualitySettings.SetQualityLevel(oldQuality);UnityEngine.Random.state=oldRandom;OfflineKeyStore.SetVerificationRoot(oldRoot);
            UnityEngine.Object.DestroyImmediate(root);UnityEngine.Object.DestroyImmediate(audio);if(silence)UnityEngine.Object.DestroyImmediate(silence);
        }
        r.passed=r.failures.Count==0;var folder=Path.Combine(Directory.GetParent(Application.dataPath).FullName,"Verification");Directory.CreateDirectory(folder);File.WriteAllText(Path.Combine(folder,"local-settings.json"),JsonUtility.ToJson(r,true));return r;
    }
    public static void RunBatch(){var r=RunChecks();Debug.Log(JsonUtility.ToJson(r));EditorApplication.Exit(r.passed?0:1);}
}
