using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using TMPro;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

namespace LuckyForge.Offline.Editor
{
    [InitializeOnLoad]
    public static class DungeonLifecycleVerification
    {
        [Serializable] public sealed class Result
        {public bool passed;public int checks;public string testRoot;public List<string> failures=new List<string>();public List<string> observations=new List<string>();public List<string> limitations=new List<string>();}
        [Serializable] sealed class TextBinding{public string field;public int index,component;}
        [Serializable] sealed class Node{public int id,active;public string name;public TextBinding text;public Node[] children;}
        [Serializable] sealed class SceneData{public Node[] trees;}
        const string OriginalRows=@"{""trees"":[{""id"":449,""name"":""unit"",""active"":1,""transform_id"":58256,""text"":null,""children"":[{""id"":10397,""name"":""scale"",""active"":1,""transform_id"":66905,""text"":null,""children"":[{""id"":18774,""name"":""coin"",""active"":1,""transform_id"":72596,""text"":null,""children"":[{""id"":25211,""name"":""odulicon"",""active"":1,""transform_id"":76794,""text"":null,""children"":[]},{""id"":22847,""name"":""text"",""active"":1,""transform_id"":77177,""text"":{""field"":""SHOWcoinrewardtxt"",""index"":0,""component"":83111},""children"":[]}]}]}]},{""id"":1873,""name"":""unit (1)"",""active"":1,""transform_id"":59497,""text"":null,""children"":[{""id"":1631,""name"":""scale (1)"",""active"":1,""transform_id"":59291,""text"":null,""children"":[{""id"":15599,""name"":""talentscroll"",""active"":1,""transform_id"":77855,""text"":null,""children"":[{""id"":18877,""name"":""odulicon"",""active"":1,""transform_id"":74226,""text"":null,""children"":[]},{""id"":19351,""name"":""text"",""active"":1,""transform_id"":73296,""text"":{""field"":""SHOWtalentrewardtxt"",""index"":0,""component"":83353},""children"":[]}]}]}]},{""id"":1373,""name"":""unit (3)"",""active"":1,""transform_id"":59060,""text"":null,""children"":[{""id"":7077,""name"":""scale (3)"",""active"":1,""transform_id"":64024,""text"":null,""children"":[{""id"":14130,""name"":""weaponToken"",""active"":1,""transform_id"":74555,""text"":null,""children"":[{""id"":14825,""name"":""odulicon"",""active"":1,""transform_id"":77539,""text"":null,""children"":[]},{""id"":18725,""name"":""text"",""active"":1,""transform_id"":76824,""text"":{""field"":""SHOWweapontokenrewardtxt"",""index"":0,""component"":83073},""children"":[]}]}]}]},{""id"":11184,""name"":""unit (10)"",""active"":1,""transform_id"":67594,""text"":null,""children"":[{""id"":11708,""name"":""scale (3)"",""active"":1,""transform_id"":68055,""text"":null,""children"":[{""id"":15644,""name"":""herostone"",""active"":1,""transform_id"":77869,""text"":null,""children"":[{""id"":18923,""name"":""odulicon"",""active"":1,""transform_id"":74240,""text"":null,""children"":[]},{""id"":19334,""name"":""text"",""active"":1,""transform_id"":73281,""text"":{""field"":""SHOWherostonerewardtxt"",""index"":0,""component"":83339},""children"":[]}]}]}]},{""id"":4784,""name"":""unit (11)"",""active"":1,""transform_id"":62033,""text"":null,""children"":[{""id"":2465,""name"":""scale (3)"",""active"":1,""transform_id"":60003,""text"":null,""children"":[{""id"":15592,""name"":""crystal"",""active"":1,""transform_id"":77862,""text"":null,""children"":[{""id"":18869,""name"":""odulicon"",""active"":1,""transform_id"":74231,""text"":null,""children"":[]},{""id"":19342,""name"":""text"",""active"":1,""transform_id"":73288,""text"":{""field"":""SHOWcrystalrewardtxt"",""index"":0,""component"":83362},""children"":[]}]}]}]},{""id"":6169,""name"":""unit (12)"",""active"":1,""transform_id"":63246,""text"":null,""children"":[{""id"":8473,""name"":""scale (3)"",""active"":1,""transform_id"":65239,""text"":null,""children"":[{""id"":18765,""name"":""energy"",""active"":1,""transform_id"":72589,""text"":null,""children"":[{""id"":25221,""name"":""odulicon"",""active"":1,""transform_id"":76798,""text"":null,""children"":[]},{""id"":22853,""name"":""text"",""active"":1,""transform_id"":77169,""text"":{""field"":""SHOWenergyrewardtxt"",""index"":0,""component"":83116},""children"":[]}]}]}]},{""id"":5661,""name"":""unit (13)"",""active"":1,""transform_id"":62798,""text"":null,""children"":[{""id"":7175,""name"":""scale (3)"",""active"":1,""transform_id"":64113,""text"":null,""children"":[{""id"":14698,""name"":""mistikcoin"",""active"":1,""transform_id"":69949,""text"":null,""children"":[{""id"":18320,""name"":""odulicon"",""active"":1,""transform_id"":69679,""text"":null,""children"":[]},{""id"":23815,""name"":""text"",""active"":1,""transform_id"":78093,""text"":{""field"":""SHOWmistiktokenrewardtxt"",""index"":0,""component"":84708},""children"":[]}]}]}]},{""id"":8707,""name"":""unit (4)"",""active"":1,""transform_id"":65445,""text"":null,""children"":[{""id"":2474,""name"":""scale (3)"",""active"":1,""transform_id"":60012,""text"":null,""children"":[{""id"":24081,""name"":""gearKafa"",""active"":1,""transform_id"":78911,""text"":null,""children"":[{""id"":19586,""name"":""odulicon"",""active"":1,""transform_id"":77988,""text"":null,""children"":[]},{""id"":15123,""name"":""text"",""active"":1,""transform_id"":77182,""text"":{""field"":""SHOWgearscrollrewardtxt"",""index"":0,""component"":84962},""children"":[]}]}]}]},{""id"":9125,""name"":""unit (5)"",""active"":1,""transform_id"":65805,""text"":null,""children"":[{""id"":12574,""name"":""scale (3)"",""active"":1,""transform_id"":68789,""text"":null,""children"":[{""id"":16458,""name"":""gearGogus"",""active"":1,""transform_id"":78292,""text"":null,""children"":[{""id"":22725,""name"":""odulicon"",""active"":1,""transform_id"":79665,""text"":null,""children"":[]},{""id"":19664,""name"":""text"",""active"":1,""transform_id"":76701,""text"":{""field"":""SHOWgearscrollrewardtxt"",""index"":1,""component"":83413},""children"":[]}]}]}]},{""id"":819,""name"":""unit (6)"",""active"":1,""transform_id"":58584,""text"":null,""children"":[{""id"":5679,""name"":""scale (3)"",""active"":1,""transform_id"":62811,""text"":null,""children"":[{""id"":21903,""name"":""gearDonluk"",""active"":1,""transform_id"":76198,""text"":null,""children"":[{""id"":23727,""name"":""odulicon"",""active"":1,""transform_id"":74583,""text"":null,""children"":[]},{""id"":21525,""name"":""text"",""active"":1,""transform_id"":76772,""text"":{""field"":""SHOWgearscrollrewardtxt"",""index"":2,""component"":83387},""children"":[]}]}]}]},{""id"":5463,""name"":""unit (7)"",""active"":1,""transform_id"":62629,""text"":null,""children"":[{""id"":10999,""name"":""scale (3)"",""active"":1,""transform_id"":67432,""text"":null,""children"":[{""id"":24889,""name"":""gearAyakkabi"",""active"":1,""transform_id"":72291,""text"":null,""children"":[{""id"":20686,""name"":""odulicon"",""active"":1,""transform_id"":79671,""text"":null,""children"":[]},{""id"":23977,""name"":""text"",""active"":1,""transform_id"":72168,""text"":{""field"":""SHOWgearscrollrewardtxt"",""index"":3,""component"":83635},""children"":[]}]}]}]},{""id"":6019,""name"":""unit (8)"",""active"":1,""transform_id"":63107,""text"":null,""children"":[{""id"":5501,""name"":""scale (3)"",""active"":1,""transform_id"":62663,""text"":null,""children"":[{""id"":14175,""name"":""gearYuzuk"",""active"":1,""transform_id"":76811,""text"":null,""children"":[{""id"":18856,""name"":""odulicon"",""active"":1,""transform_id"":71712,""text"":null,""children"":[]},{""id"":16358,""name"":""text"",""active"":1,""transform_id"":72691,""text"":{""field"":""SHOWgearscrollrewardtxt"",""index"":4,""component"":84643},""children"":[]}]}]}]},{""id"":2951,""name"":""unit (9)"",""active"":1,""transform_id"":60427,""text"":null,""children"":[{""id"":6613,""name"":""scale (3)"",""active"":1,""transform_id"":63630,""text"":null,""children"":[{""id"":20676,""name"":""gearKolye"",""active"":1,""transform_id"":75536,""text"":null,""children"":[{""id"":13527,""name"":""odulicon"",""active"":1,""transform_id"":72639,""text"":null,""children"":[]},{""id"":22815,""name"":""text"",""active"":1,""transform_id"":72295,""text"":{""field"":""SHOWgearscrollrewardtxt"",""index"":5,""component"":83295},""children"":[]}]}]}]}]}";
        const BindingFlags B=BindingFlags.Instance|BindingFlags.Public|BindingFlags.NonPublic;
        const string Intent="LuckyForge.Dungeon.Batch";
        static Fixture live;static double started;
        static DungeonLifecycleVerification(){EditorApplication.playModeStateChanged+=Mode;}
        static void Check(Result r,bool value,string message){r.checks++;if(!value)r.failures.Add(message);}
        static object Call(object o,string name,params object[] args)
        {return o.GetType().GetMethod(name,B).Invoke(o,args);}
        static void Set(object o,string name,object value){o.GetType().GetField(name,B).SetValue(o,value);}
        static T Get<T>(object o,string name){return (T)o.GetType().GetField(name,B).GetValue(o);}
        static GameObject Child(Transform p,string n){var g=new GameObject(n,typeof(RectTransform));g.transform.SetParent(p,false);return g;}
        static T Add<T>(Transform p,string n)where T:Component{return Child(p,n).AddComponent<T>();}
        static void Wire(object obj,Transform p)
        {
            foreach(var f in obj.GetType().GetFields(BindingFlags.Instance|BindingFlags.Public))
            {
                if(f.FieldType==typeof(GameObject))f.SetValue(obj,Child(p,f.Name));
                else if(f.FieldType==typeof(TextMeshProUGUI))f.SetValue(obj,Add<TextMeshProUGUI>(p,f.Name));
                else if(f.FieldType==typeof(Button))f.SetValue(obj,Add<Button>(p,f.Name));
                else if(f.FieldType==typeof(Slider))f.SetValue(obj,Add<Slider>(p,f.Name));
                else if(f.FieldType==typeof(Image))f.SetValue(obj,Add<Image>(p,f.Name));
                else if(f.FieldType==typeof(Transform))f.SetValue(obj,Child(p,f.Name).transform);
            }
        }
        static TextMeshProUGUI[] Texts(Transform root,string name,int count)
        {var a=new TextMeshProUGUI[count];for(int i=0;i<count;i++)a[i]=Add<TextMeshProUGUI>(root,name+i);return a;}
        static GameObject[] Objects(Transform root,string name,int count)
        {var a=new GameObject[count];for(int i=0;i<count;i++)a[i]=Child(root,name+i);return a;}
        static GameObject FromNode(Node n,Transform root,DungeonUi ui)
        {
            var go=Child(root,n.name);
            if(n.text!=null && !string.IsNullOrEmpty(n.text.field))
            {
                var text=go.AddComponent<TextMeshProUGUI>();var f=typeof(DungeonUi).GetField(n.text.field);
                if(f.FieldType.IsArray)((TextMeshProUGUI[])f.GetValue(ui))[n.text.index]=text;else f.SetValue(ui,text);
            }
            foreach(var child in n.children??new Node[0])FromNode(child,go.transform,ui);
            go.SetActive(n.active!=0);return go;
        }
        sealed class Fixture:IDisposable
        {
            public Result result;public GameObject root;public DungeonUi ui;public WarController war;public GecisControl gecis;
            public SoundManager sound;public Dictionary<FieldInfo,object> statics=new Dictionary<FieldInfo,object>();
            public string oldRoot;public UnityEngine.Random.State random;public float timeScale;
            public Fixture()
            {
                result=new Result{testRoot=Path.Combine(Path.GetTempPath(),"LuckyForgeDungeonChecks",Guid.NewGuid().ToString("N"))};Directory.CreateDirectory(result.testRoot);
                foreach(var t in new[]{typeof(Currencys),typeof(GameManager),typeof(PlayerData),typeof(DungeonUi),typeof(WarController),typeof(GecisControl),typeof(SoundManager),typeof(Lang),typeof(Basarimlar),typeof(GunlukGorevler),typeof(AnalyticsTimeEvent)})
                    foreach(var f in t.GetFields(BindingFlags.Static|BindingFlags.Public|BindingFlags.NonPublic))if(!f.IsLiteral&&!f.IsInitOnly)statics[f]=f.GetValue(null);
                foreach(var f in typeof(PlayerData).GetFields(BindingFlags.Static|BindingFlags.Public))
                    if(f.FieldType.GetConstructor(Type.EmptyTypes)!=null)f.SetValue(null,Activator.CreateInstance(f.FieldType));
                oldRoot=(string)typeof(OfflineKeyStore).GetField("verificationRoot",BindingFlags.Static|BindingFlags.NonPublic).GetValue(null);OfflineKeyStore.SetVerificationRoot(result.testRoot);
                random=UnityEngine.Random.state;timeScale=Time.timeScale;
                root=new GameObject("DungeonLifecycleVerification");root.SetActive(false);
                GameManager.Language=0;GameManager.Level=6;GameManager.TimeScale=1;GameManager.DungeonLevels=new int[3];GameManager.ViPGunlukDungeonKeyArtisi=0;
                WarController.Dungeondayim=false;WarController.DailyWardayim=false;WarController.GuildRaiddeyim=false;WarController.StopGame=false;
                GecisControl.savastayim=false;Lang.currentLang=null;Basarimlar.basarilar=new List<BasariGorev>();GunlukGorevler.tasks=new List<GunlukGorev>();
                sound=Add<SoundManager>(root.transform,"ActualSoundManager");sound.enabled=false;SoundManager.instance=sound;
                ui=Add<DungeonUi>(root.transform,"DungeonUi");ui.enabled=false;Wire(ui,ui.transform);
                ui.insidePages=Objects(ui.transform,"InsidePage",2);ui.bottomBtns=Objects(ui.transform,"BottomButton",2);ui.bottominfos=Objects(ui.transform,"BottomInfo",2);
                ui.bottombtntexts=Texts(ui.transform,"BottomText",2);ui.dungeonnames=Texts(ui.transform,"Name",3);ui.dungeonlevels=Texts(ui.transform,"Level",3);ui.dungeonkeys=Texts(ui.transform,"Key",3);
                ui.rewardnediryazi=Texts(ui.transform,"RewardDescription",3);ui.chancesLefttxt=Texts(ui.transform,"Chances",3);ui.rewardleveltxt=Texts(ui.transform,"RewardLevel",3);
                ui.onecikandungeonicon=Objects(ui.transform,"DungeonIcon",3);ui.SHOWgearscrollrewardtxt=new TextMeshProUGUI[6];
                var rows=JsonUtility.FromJson<SceneData>(OriginalRows).trees;ui.ShowAllRewards=new GameObject[rows.Length];
                for(int i=0;i<rows.Length;i++)ui.ShowAllRewards[i]=FromNode(rows[i],ui.rewwardShowObj.transform,ui);
                war=Add<WarController>(root.transform,"WarController");war.enabled=false;Wire(war,war.transform);ui.warController=war;war.dungeonUi=ui;
                war.DungeonWinObjectsUI=Objects(war.transform,"DungeonWin",2);war.DungeonLoseObjectsUI=Objects(war.transform,"DungeonLose",2);
                war.mysticUI=Add<MistikInGameUI>(root.transform,"MistikInGameUI");war.mysticUI.enabled=false;war.mysticUI.warController=war;
                gecis=Add<GecisControl>(root.transform,"GecisControl");gecis.enabled=false;Wire(gecis,gecis.transform);ui.gecisControl=gecis;war.gecisControl=gecis;gecis.warController=war;gecis.dungeonUi=ui;
                gecis.gecisyapiliyor=true; // Core fixture deliberately tests busy guard; no EditMode coroutine request.
                Currencys.CoinFitle(0);Currencys.CrystalFitle(0);Currencys.TalentScrollFitle(0);Currencys.HeroStoneFitle(0);Currencys.WeaponTokenFitle(0);Currencys.MistikTokenFitle(0);Currencys.EnergyFitle(0);
                Currencys.Dungeon_1_KeyFitle(0);Currencys.Dungeon_2_KeyFitle(0);Currencys.Dungeon_3_KeyFitle(0);Currencys.GearScroll=new int[6];
                var integrity=typeof(Currencys).GetField("DataGearScroll",BindingFlags.Static|BindingFlags.NonPublic);if(integrity!=null)integrity.SetValue(null,new int[6]);
                ui.onecikanobj.SetActive(false);ui.rewwardShowObj.SetActive(false);ui.sweepedobj.SetActive(false);
            }
            public void BattleDependencies()
            {
                var hero=Add<HeroController>(root.transform,"HeroController");hero.enabled=false;hero.HeroCommanders=new List<Commander>();war.heroController=hero;
                hero.currentMainHero=Add<MainHero>(root.transform,"MainHero");hero.currentMainHero.enabled=false;hero.currentMainHero.iconSet=new Sprite[6];
                war.charParcalar=new SpriteRenderer[10];for(int i=0;i<10;i++)war.charParcalar[i]=Add<SpriteRenderer>(root.transform,"CharacterPart"+i);
                Set(war,"chefSummonButton",Child(war.transform,"ChefSummonButton")); // Actual private serialized dependency used by ClearData.
                war.TotalUiDamages=new double[20];war.DungeonHpSetsArtan=new long[]{30,60,120,200,300,500,700,900,1500,2000};war.dungeonMaps=Objects(war.transform,"DungeonMap",3);
                war.slotMachine=Add<SlotMachine>(root.transform,"SlotMachine");war.slotMachine.enabled=false;
                war.slotMachine.commanderSpawner=Add<CommanderSpawner>(root.transform,"CommanderSpawner");war.slotMachine.commanderSpawner.enabled=false;
                war.slotMachine.commanderSpawner.inventorySlots=new List<InventorySlot>();war.slotMachine.commanderSpawner.activeCommanders=new List<Commander>();
                war.craftandsell=Add<CraftAndSell>(root.transform,"CraftAndSell");war.craftandsell.enabled=false;war.craftandsell.warController=war;
                war._skillSecimPage=Add<RogueLikeSkillSec>(root.transform,"RogueLikeSkillSec");war._skillSecimPage.enabled=false;
                war.mysticUI.heroController=hero;war.mysticUI.MysticListContent=Child(war.mysticUI.transform,"MysticList").transform;
                gecis.GenelCanvases=new GameObject[0];gecis.cameraHandler=Add<CameraHandler>(root.transform,"CameraHandler");gecis.cameraHandler.enabled=false;gecis.cameraHandler.camera=gecis.cameraHandler.gameObject.AddComponent<Camera>();gecis.cameraHandler.camera.enabled=false;
                gecis.gecisyapiliyor=false;GameManager.DungeonLevels=new int[3];DungeonUi.choosenDungeon=0;DungeonUi.DungeonCleared=false;WarController.Dungeondayim=false;
            }
            public void Dispose()
            {
                if(war!=null)war.StopAllCoroutines();if(gecis!=null)gecis.StopAllCoroutines();
                if(root!=null)UnityEngine.Object.DestroyImmediate(root);if(sound!=null)UnityEngine.Object.DestroyImmediate(sound.gameObject);
                foreach(var f in statics)f.Key.SetValue(null,f.Value);UnityEngine.Random.state=random;Time.timeScale=timeScale;OfflineKeyStore.SetVerificationRoot(oldRoot);
            }
        }
        static void Flush(){var s=new ES3Settings("medupac.es3",ES3.Location.File);ES3.StoreCachedFile("medupac.es3",s);OfflineKeyStore.ResetMemoryForVerification();ES3.CacheFile("medupac.es3",s);}
        static void Write(Result r){r.passed=r.failures.Count==0;File.WriteAllText(Path.Combine(r.testRoot,"dungeon-results.json"),JsonUtility.ToJson(r,true));Debug.Log("Dungeon checks="+r.checks+" passed="+r.passed+" result="+r.testRoot);}
        static void Core(Fixture f)
        {
            var r=f.result;var ui=f.ui;var w=f.war;
            Check(r,ui.ShowAllRewards.Length==13&&Array.TrueForAll(ui.SHOWgearscrollrewardtxt,t=>t!=null),"Independent original13reward rows and13text bindings resolve");
            ui.InitializeRewardTime();Check(r,Currencys.Dungeon_1_Key==2&&Currencys.Dungeon_2_Key==2&&Currencys.Dungeon_3_Key==2,"Original first initialization grants exactly2 keys of each type");
            Check(r,ES3.KeyExists("dungeonKeyTimer")&&ES3.Load<int[]>("DungeonReklamHak")[0]==2,"Original UTC timer and ad-quota keys saved without simulating an ad");
            ui.InitializeRewardTime();Check(r,Currencys.Dungeon_1_Key==2,"Repeated initialization reloads timestamp without another grant");
            Call(ui,"Start");Check(r,Currencys.Dungeon_1_Key==2&&ui.titledungeons.text==Lang.Get.Dungeon,"Actual Start localizes UI and does not duplicate initial keys");
            var stamp=DateTime.UtcNow.AddHours(-13);Call(ui,"SaveCurrentTime",stamp);Call(ui,"CheckReward");
            Check(r,Currencys.Dungeon_1_Key==4&&Currencys.Dungeon_2_Key==4&&Currencys.Dungeon_3_Key==4,"Original elapsed12hour refresh adds one2-key batch, not per missed interval");
            Call(ui,"CheckReward");Check(r,Currencys.Dungeon_1_Key==4,"Same-time refresh does not grant a second batch");
            var clock=new DateTime(2026,1,1,0,0,0,DateTimeKind.Utc);Set(ui,"lastRewardTime",clock);
            Check(r,ui.GetTimeUntilNextReward(clock.AddHours(6)).EndsWith("06:00:00"),"Original12hour countdown formats remaining6hours");
            for(int i=0;i<3;i++){ui.OneCikar(i);Check(r,DungeonUi.choosenDungeon==i&&WarController.DungeonLevel==0&&ui.challangebtn.interactable&&!ui.sweepbtn.gameObject.activeSelf,"Original dungeon detail/key and level0 sweep gate"+i);}
            GameManager.DungeonLevels=new[]{10,10,10};
            Check(r,ui.CoinReward(0)==1500&&ui.TalentReward(0)==70&&ui.WeaponTokenReward(0)==30&&ui.CrystalReward(0)==30,"Original level10 reward formulas");
            Check(r,ui.HeroStoneReward(0)==5&&ui.MistikTokenReward(0)==5&&ui.EnergyReward(0)==10,"Original fixed rewards at fortune0");
            PlayerData.dailyFortune.DungeonDrops=.5f;Check(r,ui.CoinReward(0)==750&&ui.TalentReward(0)==35&&ui.HeroStoneReward(0)==2&&ui.EnergyReward(0)==5,"Positive fractional original fortune multiplier is not clamped up");PlayerData.dailyFortune.DungeonDrops=0;
            GameManager.DungeonLevels=new[]{1000,1000,1000};Check(r,ui.CoinReward(0)==80500&&ui.TalentReward(0)==330&&ui.WeaponTokenReward(0)==110&&ui.CrystalReward(0)==160,"Original independent reward caps");
            GameManager.DungeonLevels=new int[3];bool randomOkay=true;
            for(int i=0;i<100;i++){UnityEngine.Random.InitState(i);var s=UnityEngine.Random.state;float roll=UnityEngine.Random.Range(1f,20f);int expected=(int)roll+30;UnityEngine.Random.state=s;randomOkay&=ui.GearScrollReward(0)==expected;}
            Check(r,randomOkay,"100 seeded real Unity gear amount rolls match original range/truncation");
            Currencys.Dungeon_1_KeyFitle(0);ui.reklamhaklari[0]=0;ui.OneCikar(0);Check(r,!ui.challangebtn.interactable&&!ui.sweepbtn.interactable,"Original zero keys and zero ad quota disable visible challenge/sweep");
            ui.reklamhaklari[0]=1;ui.OneCikar(0);WarController.Dungeondayim=false;ui.GoDungeon();Check(r,!WarController.Dungeondayim&&Currencys.Dungeon_1_Key==0,"Unavailable offline ad branch grants neither key nor entry");
            Currencys.Dungeon_1_KeyFitle(2);ui.OneCikar(0);ui.GoDungeon();Check(r,WarController.Dungeondayim&&Currencys.Dungeon_1_Key==2&&!DungeonUi.DungeonCleared,"Original keyed entry sets mode without charging at entry; busy real Gecis guard isolates core fixture");
            w.DungeonSonlandir(false);Check(r,!DungeonUi.DungeonCleared&&w.pageAcik&&Time.timeScale==0&&!Get<bool>(w,"WaveBitti"),"Actual loss result flags and pause");
            w.DungeonTamamlandi();Check(r,Currencys.Dungeon_1_Key==2&&GameManager.DungeonLevels[0]==0&&!WarController.Dungeondayim&&Time.timeScale==1,"Actual loss return does not charge or advance");
            // Exact first gear dungeon win: same independent seeded Unity stream as native.
            ui.OneCikar(0);UnityEngine.Random.InitState(123);var state=UnityEngine.Random.state;
            int f1=UnityEngine.Random.Range(0,3),f2=UnityEngine.Random.Range(3,5);var indices=new List<int>{f1,f2};
            for(int i=0;i<6;i++)if(i!=f1&&i!=f2&&UnityEngine.Random.value<.25f)indices.Add(i);
            int[] expectedGears=new int[6];foreach(int i in indices)expectedGears[i]=(int)UnityEngine.Random.Range(1f,20f)+30;
            UnityEngine.Random.state=state;WarController.Dungeondayim=true;w.DungeonSonlandir(true);w.DungeonTamamlandi();
            Check(r,Currencys.Dungeon_1_Key==1&&GameManager.DungeonLevels[0]==1&&!DungeonUi.DungeonCleared,"Actual victory return charges1 key and advances selected dungeon once");
            for(int i=0;i<6;i++)Check(r,Currencys.GearScroll[i]==expectedGears[i],"Original forced-two plus25percent gear selection/amount"+i);
            ui.DungeonTamamlandi();Check(r,Currencys.Dungeon_1_Key==1&&GameManager.DungeonLevels[0]==1,"Original cleared flag blocks duplicate result reward/progression");
            ui.OneCikar(1);WarController.Dungeondayim=true;DungeonUi.DungeonCleared=true;int oldEnergy=Currencys.Energy,oldCrystal=Currencys.Crystal;ui.DungeonTamamlandi();
            Check(r,Currencys.Energy==oldEnergy+10&&Currencys.Crystal==oldCrystal+10&&Currencys.Dungeon_2_Key==3&&GameManager.DungeonLevels[1]==1,"Second dungeon grants exact energy/crystal and charges its own key");
            ui.OneCikar(2);UnityEngine.Random.InitState(224);state=UnityEngine.Random.state;bool talent=UnityEngine.Random.value<.7f,hero=UnityEngine.Random.value<.1f,weapon=UnityEngine.Random.value<.4f,mystic=UnityEngine.Random.value<.03f;
            UnityEngine.Random.state=state;WarController.Dungeondayim=true;DungeonUi.DungeonCleared=true;ui.DungeonTamamlandi();
            Check(r,Currencys.Coin==500&&Currencys.TalentScroll==(talent?30:0)&&Currencys.HeroStone==(hero?5:0)&&Currencys.WeaponToken==(weapon?10:0)&&Currencys.MistikToken==(mystic?5:0),"Third dungeon independent original70/10/40/3percent reward rolls");
            Check(r,Currencys.Dungeon_3_Key==3&&GameManager.DungeonLevels[2]==1,"Third dungeon selected-key debit/progression");
            Flush();Check(r,ES3.Load<int[]>("DungeonLevels")[0]==1&&ES3.Load<int[]>("DungeonLevels")[1]==1&&ES3.Load<int[]>("DungeonLevels")[2]==1&&ES3.Load<int>("Dungeon_1_Key")==1,"Actual ES3 disk flush/reload retains completion and key debit");
            var gateObject=Child(f.root.transform,"OriginalGateTarget1488");var timeGate=Add<KademeliAcilim>(f.root.transform,"KademeliAcilim");timeGate.enabled=false;timeGate.buttonsWithLevels=new List<KademeliAcilim.ButtonLevelPair>{new KademeliAcilim.ButtonLevelPair{obje=gateObject,requiredLevel=20,butonlu=false}};
            GameManager.NewUserTapNation=false;AnalyticsTimeEvent.totalMinutes=19;timeGate.OnPlayerLevelUp();Check(r,!gateObject.activeSelf,"Actual legacy20minute gate stays closed at19minutes");AnalyticsTimeEvent.totalMinutes=20;timeGate.OnPlayerLevelUp();Check(r,gateObject.activeSelf,"Actual legacy20minute gate opens at20minutes");
            var levelGate=Add<KademeliAcilimLevel>(f.root.transform,"KademeliAcilimLevel");levelGate.enabled=false;levelGate.buttonsWithLevels=new List<KademeliAcilimLevel.ButtonLevelPairer>{new KademeliAcilimLevel.ButtonLevelPairer{obje=gateObject,requiredLevel=6,butonlu=false}};
            GameManager.NewUserTapNation=true;GameManager.Level=5;levelGate.OnPlayerLevelUp();Check(r,!gateObject.activeSelf,"Actual new-user level6 gate stays closed at5");GameManager.Level=6;levelGate.OnPlayerLevelUp();Check(r,gateObject.activeSelf,"Actual new-user level6 gate opens at6");
            r.observations.Add("Actual restored DungeonUi/War result/ES3/Unity Random and original unlock classes. Funds/progression/time in this isolated fixture are explicit test inputs, not user-save grants.");
        }
        public static Result RunChecks()
        {
            if(EditorApplication.isPlayingOrWillChangePlaymode)throw new InvalidOperationException("Dedicated non-playing Editor required.");
            using(var f=new Fixture()){try{Core(f);}catch(Exception e){f.result.failures.Add(e.ToString());}f.result.limitations.Add("Core tests result/fees/rewards/storage and real unlock methods; real Gecis busy guard avoids EditMode coroutines. Does not prove actual scene button or20wave battle.");Write(f.result);return f.result;}
        }
        public static void RunBatch()
        {if(EditorApplication.isPlayingOrWillChangePlaymode)throw new InvalidOperationException("Dedicated fresh Editor process required.");SessionState.SetBool(Intent,true);EditorSceneManager.NewScene(NewSceneSetup.EmptyScene,NewSceneMode.Single);EditorApplication.EnterPlaymode();}
        static void Mode(PlayModeStateChange mode)
        {
            if(!SessionState.GetBool(Intent,false))return;
            if(mode==PlayModeStateChange.EnteredPlayMode)EditorApplication.delayCall+=StartLive;
            if(mode==PlayModeStateChange.EnteredEditMode){int exit=SessionState.GetInt(Intent+".exit",1);SessionState.EraseBool(Intent);EditorApplication.Exit(exit);}
        }
        static void StartLive()
        {
            try{live=new Fixture();Core(live);live.BattleDependencies();live.root.SetActive(true);live.ui.GoDungeon();started=EditorApplication.timeSinceStartup;EditorApplication.update+=Tick;}
            catch(Exception e){Fail(e);}
        }
        static void Tick()
        {
            try
            {
                if(live==null)return;if(EditorApplication.timeSinceStartup-started>15)throw new TimeoutException("Actual dungeon transition/init");
                if(live.gecis.gecisyapiliyor)return;
                var f=live;var w=f.war;var r=f.result;
                Check(r,GecisControl.savastayim&&WarController.Dungeondayim&&Get<int>(w,"TotalWaves")==20&&w.MaxEnemyCount==12,"Actual GoDungeon→Gecis1s coroutine→War.GoDungeon initializes20waves/12enemy cap");
                Check(r,w.CastleHp==500&&w.MaxCastleHealth==500&&w.Silver==200&&Get<float>(w,"SilverData")==400,"Actual ClearData and native200silver initialize castle and balance");
                Check(r,w.enemiesbonushp==30&&w.enemiesbonushpARTAN==30&&w.currentWaveIndex==0,"Original selected dungeon0 health math and starting wave");
                Check(r,w.DungeonSavasAlaniParent.activeSelf&&!w.BolumSavasAlaniParent.activeSelf&&!w.DailyWarSavasAlaniParent.activeSelf&&!w.GuildRaidSavasAlaniParent.activeSelf,"Actual transition picks only original Dungeon arena");
                Check(r,!f.gecis.cameraHandler.camera.orthographic&&f.gecis.cameraHandler.transform.position.z==-255&&f.gecis.castleinbattle.activeSelf,"Actual transition preserves original battle camera/castle activation");
                Check(r,Currencys.Dungeon_1_Key==1,"Actual entry still preserves previously saved1key; no entry debit");
                r.limitations.Add("PlayMode additionally runs actual1second Gecis transition and War.ClearData/GoDungeon; stops scheduled wave coroutine during cleanup before spawning. No20wave combat completion or physical UI drive claimed.");
                Finish();
            }
            catch(Exception e){Fail(e);}
        }
        static void Fail(Exception e){if(live!=null)live.result.failures.Add(e.ToString());else Debug.LogException(e);Finish();}
        static void Finish(){EditorApplication.update-=Tick;bool yes=false;if(live!=null){Write(live.result);yes=live.result.passed;live.Dispose();live=null;}SessionState.SetInt(Intent+".exit",yes?0:1);EditorApplication.ExitPlaymode();}
    }
}
