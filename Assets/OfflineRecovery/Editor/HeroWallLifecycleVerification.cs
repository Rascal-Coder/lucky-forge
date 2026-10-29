using System;using System.Collections.Generic;using System.IO;using System.Reflection;using TMPro;using UnityEditor;using UnityEngine;using UnityEngine.UI;
namespace LuckyForge.Offline.Editor {
public static class HeroWallLifecycleVerification {
 [Serializable] public class Result{public bool passed;public int checks;public string testRoot;public string saveFile;public List<string> failures=new List<string>();}
 static void Check(Result r,bool value,string label){r.checks++;if(!value)r.failures.Add(label);}
 static GameObject Child(Transform parent,string name){var g=new GameObject(name,typeof(RectTransform));g.SetActive(false);g.transform.SetParent(parent,false);return g;}
 static T Add<T>(Transform parent,string name)where T:Component=>Child(parent,name).AddComponent<T>();
 static void Call(object obj,string name)=>obj.GetType().GetMethod(name,BindingFlags.Instance|BindingFlags.Public|BindingFlags.NonPublic).Invoke(obj,null);
 static void Fill(MonoBehaviour obj){foreach(var f in obj.GetType().GetFields(BindingFlags.Instance|BindingFlags.Public)){if(f.FieldType==typeof(TextMeshProUGUI))f.SetValue(obj,Add<TextMeshProUGUI>(obj.transform,f.Name));else if(f.FieldType==typeof(Button))f.SetValue(obj,Add<Button>(obj.transform,f.Name));else if(f.FieldType==typeof(Image))f.SetValue(obj,Add<Image>(obj.transform,f.Name));else if(f.FieldType==typeof(Slider))f.SetValue(obj,Add<Slider>(obj.transform,f.Name));else if(f.FieldType==typeof(Transform))f.SetValue(obj,Child(obj.transform,f.Name).transform);}}
 static void Stars(Transform parent){for(int i=0;i<7;i++)Child(Child(parent,"star"+i).transform,"lit");}
 static Image[] Images(Transform parent){var arr=new Image[10];for(int i=0;i<10;i++)arr[i]=Add<Image>(parent,"part"+i);return arr;}
 static void Flush(){var disk=new ES3Settings("medupac.es3",ES3.Location.File);ES3.StoreCachedFile("medupac.es3",disk);OfflineKeyStore.ResetMemoryForVerification();ES3.CacheFile("medupac.es3",disk);}
 static void NativeFactory(HeroController c,HeroCharacterPage hp,WallPage wp){
 c.mainHeroes=new MainHero[6];c.Walls=new Wall[8];
// Original level1 component 91407
var h0=Add<MainHero>(c.transform,"MainHero0");c.mainHeroes[0]=h0;h0.heroController=c;h0.heroCharacterPage=hp;h0.iconSet=new Sprite[6];
h0.HeroNum=0;
h0.HeroName="Arion";
h0.SatinAlimCrystalFiyati=0;
h0.SetGold=new double[]{20000.0d,100000.0d,300000.0d,800000.0d,1400000.0d,2000000.0d,2500000.0d,3000000.0d};
h0.SetHeroStone=new int[]{50,100,250,500,1000,1500,2500,3000};
h0.YuzdeDurum=new int[]{0,10,20,30,40,50,60,70,70};
// Original level1 component 93995
var h1=Add<MainHero>(c.transform,"MainHero1");c.mainHeroes[1]=h1;h1.heroController=c;h1.heroCharacterPage=hp;h1.iconSet=new Sprite[6];
h1.HeroNum=1;
h1.HeroName="Kael";
h1.SatinAlimCrystalFiyati=8000;
h1.SetGold=new double[]{20000.0d,100000.0d,300000.0d,800000.0d,1400000.0d,2000000.0d,2500000.0d,3000000.0d};
h1.SetHeroStone=new int[]{50,100,250,500,1000,1500,2500,3000};
h1.YuzdeDurum=new int[]{0,10,14,18,22,26,30,34,34};
// Original level1 component 91872
var h2=Add<MainHero>(c.transform,"MainHero2");c.mainHeroes[2]=h2;h2.heroController=c;h2.heroCharacterPage=hp;h2.iconSet=new Sprite[6];
h2.HeroNum=2;
h2.HeroName="Draven";
h2.SatinAlimCrystalFiyati=7000;
h2.SetGold=new double[]{20000.0d,100000.0d,300000.0d,800000.0d,1400000.0d,2000000.0d,2500000.0d,3000000.0d};
h2.SetHeroStone=new int[]{50,100,250,500,1000,1500,2500,3000};
h2.YuzdeDurum=new int[]{0,5,8,11,14,17,20,25,25};
// Original level1 component 88717
var h3=Add<MainHero>(c.transform,"MainHero3");c.mainHeroes[3]=h3;h3.heroController=c;h3.heroCharacterPage=hp;h3.iconSet=new Sprite[6];
h3.HeroNum=3;
h3.HeroName="Thoren";
h3.SatinAlimCrystalFiyati=4000;
h3.SetGold=new double[]{20000.0d,100000.0d,300000.0d,800000.0d,1400000.0d,2000000.0d,2500000.0d,3000000.0d};
h3.SetHeroStone=new int[]{50,100,250,500,1000,1500,2500,3000};
h3.YuzdeDurum=new int[]{0,5,9,13,17,21,25,30,30};
// Original level1 component 86955
var h4=Add<MainHero>(c.transform,"MainHero4");c.mainHeroes[4]=h4;h4.heroController=c;h4.heroCharacterPage=hp;h4.iconSet=new Sprite[6];
h4.HeroNum=4;
h4.HeroName="Silas";
h4.SatinAlimCrystalFiyati=8000;
h4.SetGold=new double[]{20000.0d,100000.0d,300000.0d,800000.0d,1400000.0d,2000000.0d,2500000.0d,3000000.0d};
h4.SetHeroStone=new int[]{50,100,250,500,1000,1500,2500,3000};
h4.YuzdeDurum=new int[]{0,30,40,50,60,70,80,90,90};
// Original level1 component 85200
var h5=Add<MainHero>(c.transform,"MainHero5");c.mainHeroes[5]=h5;h5.heroController=c;h5.heroCharacterPage=hp;h5.iconSet=new Sprite[6];
h5.HeroNum=5;
h5.HeroName="Korrin";
h5.SatinAlimCrystalFiyati=4000;
h5.SetGold=new double[]{20000.0d,100000.0d,300000.0d,800000.0d,1400000.0d,2000000.0d,2500000.0d,3000000.0d};
h5.SetHeroStone=new int[]{50,100,250,500,1000,1500,2500,3000};
h5.YuzdeDurum=new int[]{0,10,20,30,40,50,60,70,70};
// Original level1 component 95318
var w0=Add<Wall>(c.transform,"Wall0");c.Walls[0]=w0;w0.heroController=c;w0.wallPage=wp;
w0.WallName="Timberwall";
w0.Num=0;
w0.StartLevel=1;
w0.MaxLevel=7;
w0.BaslangicExp=0;
w0.DegerSonu="%";
w0.BonusLevel=new int[]{0,10,20,30,40,50,60,70,80};
w0.SetWallStone=new int[]{50,100,250,700,1200,2000,3500,5000};
// Original level1 component 94147
var w1=Add<Wall>(c.transform,"Wall1");c.Walls[1]=w1;w1.heroController=c;w1.wallPage=wp;
w1.WallName="Hayguard";
w1.Num=1;
w1.StartLevel=0;
w1.MaxLevel=7;
w1.BaslangicExp=0;
w1.DegerSonu="%";
w1.BonusLevel=new int[]{0,4,8,12,16,20,24,28,32};
w1.SetWallStone=new int[]{50,100,250,700,1200,2000,3500,5000};
// Original level1 component 86592
var w2=Add<Wall>(c.transform,"Wall2");c.Walls[2]=w2;w2.heroController=c;w2.wallPage=wp;
w2.WallName="Frostveil";
w2.Num=2;
w2.StartLevel=0;
w2.MaxLevel=7;
w2.BaslangicExp=0;
w2.DegerSonu="s";
w2.BonusLevel=new int[]{0,2,3,4,5,6,7,8,9};
w2.SetWallStone=new int[]{50,100,250,700,1200,2000,3500,5000};
// Original level1 component 89173
var w3=Add<Wall>(c.transform,"Wall3");c.Walls[3]=w3;w3.heroController=c;w3.wallPage=wp;
w3.WallName="Mossgolem";
w3.Num=3;
w3.StartLevel=0;
w3.MaxLevel=7;
w3.BaslangicExp=0;
w3.DegerSonu="%";
w3.BonusLevel=new int[]{0,20,24,28,32,36,40,44,50};
w3.SetWallStone=new int[]{50,100,250,700,1200,2000,3500,5000};
// Original level1 component 94039
var w4=Add<Wall>(c.transform,"Wall4");c.Walls[4]=w4;w4.heroController=c;w4.wallPage=wp;
w4.WallName="Thornspire";
w4.Num=4;
w4.StartLevel=0;
w4.MaxLevel=7;
w4.BaslangicExp=0;
w4.DegerSonu="%";
w4.BonusLevel=new int[]{0,10,13,16,19,21,24,27,30};
w4.SetWallStone=new int[]{50,100,250,700,1200,2000,3500,5000};
// Original level1 component 89328
var w5=Add<Wall>(c.transform,"Wall5");c.Walls[5]=w5;w5.heroController=c;w5.wallPage=wp;
w5.WallName="Duskrune";
w5.Num=5;
w5.StartLevel=0;
w5.MaxLevel=7;
w5.BaslangicExp=0;
w5.DegerSonu="%";
w5.BonusLevel=new int[]{0,10,20,30,40,50,60,70,80};
w5.SetWallStone=new int[]{50,100,250,700,1200,2000,3500,5000};
// Original level1 component 95048
var w6=Add<Wall>(c.transform,"Wall6");c.Walls[6]=w6;w6.heroController=c;w6.wallPage=wp;
w6.WallName="Stormbrick";
w6.Num=6;
w6.StartLevel=0;
w6.MaxLevel=7;
w6.BaslangicExp=0;
w6.DegerSonu="";
w6.BonusLevel=new int[]{0,1,2,3,4,5,6,7,8};
w6.SetWallStone=new int[]{50,100,250,700,1200,2000,3500,5000};
// Original level1 component 92772
var w7=Add<Wall>(c.transform,"Wall7");c.Walls[7]=w7;w7.heroController=c;w7.wallPage=wp;
w7.WallName="Verdantstun";
w7.Num=7;
w7.StartLevel=0;
w7.MaxLevel=7;
w7.BaslangicExp=0;
w7.DegerSonu="%";
w7.BonusLevel=new int[]{0,5,10,15,20,25,30,35,40};
w7.SetWallStone=new int[]{50,100,250,700,1200,2000,3500,5000};
}

 public static Result RunChecks(string suppliedRoot=null){
 var r=new Result{testRoot=Path.GetFullPath(suppliedRoot??Path.Combine(Path.GetTempPath(),"LuckyForgeHeroWallChecks",Guid.NewGuid().ToString("N")))};
 if(EditorApplication.isPlayingOrWillChangePlaymode){r.failures.Add("Requires isolated non-playing Editor process.");return r;}Directory.CreateDirectory(r.testRoot);
 var saved=new Dictionary<FieldInfo,object>();foreach(var type in new[]{typeof(Currencys),typeof(GameManager),typeof(Lang)})foreach(var f in type.GetFields(BindingFlags.Static|BindingFlags.Public|BindingFlags.NonPublic))if(!f.IsLiteral&&!f.IsInitOnly)saved[f]=f.GetValue(null);
 var oldWall=PlayerData.mainWallEffect;var oldSound=SoundManager.instance;var root=new GameObject("HeroWallLifecycleVerification");root.SetActive(false);
 OfflineKeyStore.SetVerificationRoot(r.testRoot);
 try{
 GameManager.Language=0;GameManager.NewUserTapNation=true;Lang.currentLang=null;SoundManager.instance=null;PlayerData.mainWallEffect=new PlayerData.WallEffect();
 var controller=Add<HeroController>(root.transform,"HeroController");controller.canvasJobs=Add<CanvasJobs>(root.transform,"Canvas");
 var heroUi=Add<HeroCharacterPage>(root.transform,"HeroUi");Fill(heroUi);Stars(heroUi.stars);heroUi.characterSet=Images(heroUi.transform);heroUi.heroController=controller;
 var inventory=Add<InventoryGearUI>(root.transform,"InventoryCharacter");inventory.characterSet=Images(inventory.transform);inventory.heroController=controller;heroUi.inventoryGearUI=inventory;
 var wallUi=Add<WallPage>(root.transform,"WallUi");Fill(wallUi);Stars(wallUi.stars);wallUi.heroController=controller;wallUi.inventoryGearUI=inventory;
 controller.castleinwallparent=Child(root.transform,"homewalls").transform;controller.battleinwallparent=Child(root.transform,"battlewalls").transform;
 for(int i=0;i<8;i++){Child(wallUi.characterSet,"wallpreview"+i);Child(controller.castleinwallparent,"homewall"+i);Child(controller.battleinwallparent,"battlewall"+i);}
 NativeFactory(controller,heroUi,wallUi);
 foreach(var hero in controller.mainHeroes)Call(hero,"Start");foreach(var wall in controller.Walls)wall.LoadData();
 controller.MainHeroNum=0;controller.currentMainHero=controller.mainHeroes[0];controller.currentMainWall=0;
 Check(r,controller.mainHeroes[0].Level==1&&controller.mainHeroes[1].Level==0,"native first hero owned, other hero locked");Check(r,controller.Walls[0].Level==1&&controller.Walls[1].Level==0,"native first wall owned, other wall locked");
 Call(heroUi,"OnEnable");Check(r,heroUi.headname.text=="Arion"&&!heroUi.usebtn.gameObject.activeSelf&&heroUi.upgradebtn.gameObject.activeSelf,"initial current hero UI and button state");
 heroUi.SetHero(1);var h=controller.mainHeroes[1];Check(r,heroUi.headname.text=="Kael"&&heroUi.satinalimbtn.gameObject.activeSelf&&!heroUi.upgradebtn.gameObject.activeSelf&&!heroUi.usebtn.gameObject.activeSelf,"locked hero original name and purchase UI");Check(r,heroUi.satinalimfiyati.text=="<sprite=1>8000","original serialized crystal unlock cost");
 heroUi.Use();Check(r,controller.MainHeroNum==0&&controller.currentMainHero==controller.mainHeroes[0],"locked hero cannot be selected");
 Currencys.CrystalFitle(7999);heroUi.SatinAl();Check(r,h.Level==0&&Currencys.Crystal==7999&&!ES3.KeyExists("MainHeroLevel1"),"one crystal short unlock preserves level and balance");
 Currencys.CrystalFitle(8000);heroUi.SatinAl();Check(r,h.Level==1&&Currencys.Crystal==0&&ES3.Load<int>("MainHeroLevel1")==1,"exact original cost unlock and persisted level");Check(r,heroUi.usebtn.gameObject.activeSelf&&heroUi.upgradebtn.gameObject.activeSelf&&!heroUi.satinalimbtn.gameObject.activeSelf,"purchased hero UI refresh");Check(r,controller.MainHeroNum==0,"purchase does not silently select");
 heroUi.Use();Check(r,controller.MainHeroNum==1&&controller.currentMainHero==h&&ES3.Load<int>("MainHeroNum")==1&&!heroUi.usebtn.gameObject.activeSelf&&inventory.character_degisti,"actual Use selects saves and refreshes");
 Check(r,heroUi.coinfiyat.text=="<sprite=0>"+ShortScaleString.parseDouble(100000d,1,1000000d,false)&&heroUi.herostonefiyat.text=="<sprite=9>100","original level1 costs 100000 Coin +100 HeroStone");
 Currencys.CoinFitle(99999d);Currencys.HeroStoneFitle(100);heroUi.Upgrade();Check(r,h.Level==1&&Currencys.Coin==99999d&&Currencys.HeroStone==100,"one coin short upgrade cannot debit");
 Currencys.CoinFitle(100000d);Currencys.HeroStoneFitle(99);heroUi.Upgrade();Check(r,h.Level==1&&Currencys.Coin==100000d&&Currencys.HeroStone==99,"one HeroStone short upgrade cannot debit");
 Currencys.HeroStoneFitle(100);heroUi.Upgrade();Check(r,h.Level==2&&Currencys.Coin==0d&&Currencys.HeroStone==0&&ES3.Load<int>("MainHeroLevel1")==2,"exact two-resource debit and level2 save");Check(r,heroUi.solstar.text=="2"&&heroUi.suankiyuzde.text==h.Yuzde().ToString()+"%"&&heroUi.characterskillsub.text==h.heroSkillSubtitle(),"upgrade refreshes displayed stat, stars and original skill text");
 Flush();h.Level=0;Call(h,"Start");controller.MainHeroNum=ES3.Load<int>("MainHeroNum");controller.currentMainHero=controller.mainHeroes[controller.MainHeroNum];Check(r,h.Level==2&&controller.currentMainHero==h,"hero level and selection survive actual file reload");Currencys.LoadStartCoin();Currencys.LoadStartHeroStone();Currencys.LoadStartCrystal();Check(r,Currencys.Coin==0d&&Currencys.HeroStone==0&&Currencys.Crystal==0,"actual currency mirrors retain debits after file reload");
 Call(wallUi,"OnEnable");Check(r,wallUi.headname.text==controller.Walls[0].WallName&&!wallUi.usebtn.gameObject.activeSelf,"initial wall UI bound to selected wall");
 wallUi.SetHero(1);var w=controller.Walls[1];Check(r,wallUi.eventileeldeedilirobj.gameObject.activeSelf&&!wallUi.usebtn.gameObject.activeSelf&&!wallUi.upgradebtn.gameObject.activeSelf,"locked wall retains original event/card acquisition UI");wallUi.Use();Check(r,controller.currentMainWall==0,"locked wall cannot select");
 int balance=Currencys.WallToken;w.AddKartExp(1);Check(r,w.Level==1&&w.LevelExp==1&&Currencys.WallToken==balance&&ES3.Load<int>("WallLevel1")==1&&ES3.Load<int>("WallExp1")==1,"one actual acquired card unlocks original wall and saves without resource grant");
 wallUi.SetHero(1);Check(r,wallUi.usebtn.gameObject.activeSelf&&wallUi.upgradebtn.gameObject.activeSelf&&!wallUi.eventileeldeedilirobj.gameObject.activeSelf&&wallUi.sliderexp.maxValue==2f&&wallUi.sliderexp.value==1f,"unlocked wall progress and button refresh");wallUi.Use();Check(r,controller.currentMainWall==1&&ES3.Load<int>("currentMainWall")==1&&inventory.wall_degisti,"wall selection and save");Check(r,controller.castleinwallparent.GetChild(1).gameObject.activeSelf&&!controller.castleinwallparent.GetChild(0).gameObject.activeSelf&&controller.battleinwallparent.GetChild(1).gameObject.activeSelf,"actual home and battle wall visuals selected");
 Currencys.WallTokenFitle(100);wallUi.Upgrade();Check(r,w.Level==1&&w.LevelExp==1&&Currencys.WallToken==100,"missing wall card exp cannot spend tokens");w.AddKartExp(1);Currencys.WallTokenFitle(99);wallUi.Upgrade();Check(r,w.Level==1&&w.LevelExp==2&&Currencys.WallToken==99,"one wall token short cannot spend card exp");
 Currencys.WallTokenFitle(100);wallUi.Upgrade();Check(r,w.Level==2&&w.LevelExp==0&&Currencys.WallToken==0&&ES3.Load<int>("WallLevel1")==2&&ES3.Load<int>("WallExp1")==0,"native wall upgrade spends100 tokens and2 cards, saves both");Check(r,wallUi.solstar.text=="2"&&wallUi.suankiyuzde.text==w.Bonus().ToString()+w.DegerSonu&&wallUi.wallstone.text=="0","wall upgrade UI stat and currency refresh");
 controller.WallBonusAyarla();Check(r,PlayerData.mainWallEffect.SpinFiyatiDusur==w.Bonus()&&PlayerData.mainWallEffect.KaleHpArttir==0,"selected upgraded wall actual combat bonus mapping");
 Flush();w.Level=0;w.LevelExp=0;w.LoadData();controller.currentMainWall=ES3.Load<int>("currentMainWall");controller.LoadWalls();Currencys.LoadStartWallToken();Check(r,w.Level==2&&w.LevelExp==0&&controller.currentMainWall==1&&Currencys.WallToken==0,"wall stats selection and debit survive actual file reload");
 h.Level=7;heroUi.SetHero(1);Check(r,!heroUi.upgradebtn.interactable&&heroUi.starup.text=="MAX","native hero cap UI7");w.Level=7;wallUi.SetHero(1);Check(r,!wallUi.upgradebtn.interactable&&wallUi.starup.text=="MAX","native wall cap UI7");
 r.saveFile=OfflineKeyStore.PathFor();Check(r,File.Exists(r.saveFile),"physical isolated ES3 file exists");
 }catch(Exception e){r.failures.Add(e.ToString());}finally{foreach(var entry in saved)entry.Key.SetValue(null,entry.Value);PlayerData.mainWallEffect=oldWall;SoundManager.instance=oldSound;OfflineKeyStore.SetVerificationRoot(null);UnityEngine.Object.DestroyImmediate(root);}
 r.passed=r.failures.Count==0;File.WriteAllText(Path.Combine(r.testRoot,"hero-wall-results.json"),JsonUtility.ToJson(r,true));Debug.Log("HeroWallLifecycleVerification checks="+r.checks+" passed="+r.passed+" root="+r.testRoot);return r;
 }
}
}
