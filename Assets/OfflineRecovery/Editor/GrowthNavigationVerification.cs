using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
public static class GrowthNavigationVerification
{
    [Serializable]public sealed class Result{public bool passed;public int checks;public List<string> failures=new List<string>();}
    static void Check(Result r,bool ok,string label){r.checks++;if(!ok)r.failures.Add(label);}
    static GameObject Go(GameObject root,string name,bool active=true){var go=new GameObject(name);go.SetActive(active);go.transform.SetParent(root.transform);return go;}
    static TextMeshProUGUI Label(GameObject root,string name){var go=new GameObject(name,typeof(RectTransform),typeof(CanvasRenderer),typeof(TextMeshProUGUI));go.transform.SetParent(root.transform);return go.GetComponent<TextMeshProUGUI>();}
    static void Invoke(object target,string name){target.GetType().GetMethod(name,BindingFlags.Instance|BindingFlags.NonPublic).Invoke(target,null);}
    static void SetCurrency(string name,object value){typeof(Currencys).GetProperty(name).SetValue(null,value,null);}
    public static Result RunChecks()
    {
        var r=new Result();var root=new GameObject("GrowthNavigationVerification");bool oldLock=GuideJustGear.LockGearClick,oldPage=GameManager.PageAcildi;var oldSound=SoundManager.instance;int oldLanguage=GameManager.Language;var oldLang=Lang.currentLang;var oldRandom=UnityEngine.Random.state;
        var oldCurrencies=new Dictionary<string,object>();foreach(var name in new[]{"Crystal","Coin","HeroStone","TalentScroll","Dungeon_1_Key","Dungeon_2_Key","Dungeon_3_Key","MistikToken","WeaponToken","PetFood","WallToken"})oldCurrencies[name]=typeof(Currencys).GetProperty(name).GetValue(null,null);var oldScroll=Currencys.GearScroll;
        Texture2D texture=null;Sprite sprite=null;
        try{
            var soundObject=Go(root,"InactiveSound",false);SoundManager.instance=soundObject.AddComponent<SoundManager>();GameManager.Language=0;GameManager.PageAcildi=true;GuideJustGear.LockGearClick=false;
            var epObject=Go(root,"OriginalEquipmentPage",false);var ep=epObject.AddComponent<EquipmentPageParent>();ep.heroes=Label(epObject,"Heroes");ep.wall=Label(epObject,"Walls");ep.pet=Label(epObject,"Pets");ep.insidePages=new GameObject[3];ep.bottomBtns=new GameObject[3];for(int i=0;i<3;i++){ep.insidePages[i]=Go(epObject,"Inside"+i,false);ep.bottomBtns[i]=Go(epObject,"Button"+i);ep.bottomBtns[i].transform.position=new Vector3(30+i*7,-12+i,4);}
            ep.bottombtnlight=Go(epObject,"Highlight").transform;Invoke(ep,"Start");Check(r,ep.heroes.text==Lang.Get.Heroes&&ep.wall.text==Lang.Get.Walls_new&&ep.pet.text==Lang.Get.pets,"original equipment navigation labels");
            ep.OpenInsidePage(1);Check(r,epObject.activeSelf&&!ep.insidePages[0].activeSelf&&ep.insidePages[1].activeSelf&&!ep.insidePages[2].activeSelf,"equipment opens exactly selected original page");Check(r,ep.bottombtnlight.position==ep.bottomBtns[1].transform.position,"selection highlight uses original button world position");
            GuideJustGear.LockGearClick=true;ep.OpenInsidePage(2);Check(r,ep.insidePages[1].activeSelf&&!ep.insidePages[2].activeSelf,"original gear tutorial lock prevents tab navigation");GuideJustGear.LockGearClick=false;
            var highlight=ep.bottombtnlight.position;ep.OpenInsidePage(-1);Check(r,epObject.activeSelf&&!ep.insidePages[0].activeSelf&&!ep.insidePages[1].activeSelf&&!ep.insidePages[2].activeSelf&&ep.bottombtnlight.position==highlight,"native unmatched negative selection opens parent with all tabs hidden");ep.Close();Check(r,!epObject.activeSelf&&GameManager.PageAcildi,"equipment Close only hides its own page");
            var invObject=Go(root,"OriginalInventoryPage",false);var inv=invObject.AddComponent<inventoryPage>();inv.inventorytitle=Label(invObject,"InventoryTitle");inv.coins=new TextMeshProUGUI[17];for(int i=0;i<17;i++){var row=Go(invObject,"ResourceRow"+i,false);var holder=Go(row,"Holder");inv.coins[i]=Label(holder,"Amount");}
            SetCurrency("Crystal",0);SetCurrency("Coin",1000001d);SetCurrency("HeroStone",2);SetCurrency("TalentScroll",-4);SetCurrency("Dungeon_1_Key",5);SetCurrency("Dungeon_2_Key",0);SetCurrency("Dungeon_3_Key",7);SetCurrency("MistikToken",8);SetCurrency("WeaponToken",9);SetCurrency("PetFood",0);SetCurrency("WallToken",17);Currencys.GearScroll=new[]{11,12,13,14,15,16};
            Invoke(inv,"OnEnable");Check(r,inv.inventorytitle.text==Lang.Get.inventory,"inventory OnEnable localizes and refreshes rows");
            var expected=new[]{"0","1 M","2","-4","5","0","7","8","9","11","12","13","14","16","15","0","17"};for(int i=0;i<expected.Length;i++)Check(r,inv.coins[i].text==expected[i],"original inventory resource/format index"+i);
            Check(r,!inv.coins[0].transform.parent.parent.gameObject.activeSelf&&inv.coins[1].transform.parent.parent.gameObject.activeSelf&&!inv.coins[3].transform.parent.parent.gameObject.activeSelf&&!inv.coins[5].transform.parent.parent.gameObject.activeSelf&&!inv.coins[15].transform.parent.parent.gameObject.activeSelf,"inventory hides nonpositive resource rows while preserving original text");
            inv.OpenCloseInventory();Check(r,invObject.activeInHierarchy,"inventory original toggle opens");inv.OpenCloseInventory();Check(r,!invObject.activeSelf,"inventory original toggle closes");GuideJustGear.LockGearClick=true;inv.OpenCloseInventory();Check(r,!invObject.activeSelf,"inventory tutorial lock prevents opening");GuideJustGear.LockGearClick=false;
            Check(r,Currencys.Coin==1000001d&&Currencys.TalentScroll==-4&&Currencys.GearScroll[4]==15&&Currencys.GearScroll[5]==16,"navigation does not mutate resource values or material order");
            var cmObject=Go(root,"CollectionDisplayBackend",false);var cm=cmObject.AddComponent<CollectiblesManager>();cm.allCollectibles=new List<CollectibleItem>{new CollectibleItem(0,"HP",12){ID=37,StatName="HP",Value=12,Collected=true},new CollectibleItem(1,"BowAttackArtisi",7){ID=49,StatName="BowAttackArtisi",Value=7,Collected=false}};
            texture=new Texture2D(2,2);sprite=Sprite.Create(texture,new Rect(0,0,2,2),Vector2.zero);cm.collectiblesicons=new[]{sprite,sprite};
            var cuObject=Go(root,"OriginalCollectionsPage",false);var cu=cuObject.AddComponent<CollectiblesUi>();cu.collectiblesManager=cm;cu.title=Label(cuObject,"Title");cu.content=Go(cuObject,"Content").transform;
            for(int i=0;i<2;i++){var row=Go(cu.content.gameObject,"OriginalRow"+i,false);var frame=Go(row,"IconFrame");var icon=new GameObject("OriginalIcon",typeof(RectTransform),typeof(CanvasRenderer),typeof(Image));icon.transform.SetParent(frame.transform);Label(row,"OriginalName");Label(row,"OriginalStat");}
            Invoke(cu,"Start");Invoke(cu,"OnEnable");Check(r,cu.title.text==Lang.Get.Collections_new,"collection page localizes title");Check(r,cu.content.GetChild(0).gameObject.activeSelf&&!cu.content.GetChild(1).gameObject.activeSelf,"only existing Collected=true row is shown");
            Check(r,cu.content.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>().sprite==sprite&&cu.content.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text=="Vortexa"&&cu.content.GetChild(0).GetChild(2).GetComponent<TextMeshProUGUI>().text==Lang.Get.HP_Title+" 12%","collection display uses original list index, sprite and stat formatting");
            Check(r,cm.Names(0)=="Vortexa"&&cm.Names(1)=="Solara"&&cm.Names(2)=="Prismata"&&cm.Names(50)=="Owa"&&cm.Names(-1)=="Collectible"&&cm.Names(51)=="Collectible","original name pointer table boundaries and fallback");
            Check(r,cm.Ozellik("BowAttackArtisi")==Lang.Get.BowAttackArtisi_Title&&cm.Ozellik("MistikAttackArtisi")==Lang.Get.MistikAttackArtisi_Title&&cm.Ozellik("unknown")==""&&cm.Ozellik(null)=="","original stat-label dispatcher and empty unknown/null fallback");
            cm.allCollectibles[1].Collected=true;Invoke(cu,"OnEnable");Check(r,cu.content.GetChild(1).gameObject.activeSelf&&cu.content.GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>().text=="Solara","refresh displays newly supplied existing collected state without granting it");cm.allCollectibles[1].Collected=false;Invoke(cu,"OnEnable");Check(r,cu.content.GetChild(1).gameObject.activeSelf,"original refresh has no added uncollected-row reset branch");
            GuideJustGear.LockGearClick=true;cu.OpenClose();Check(r,!cuObject.activeSelf,"collection tutorial lock prevents opening");GuideJustGear.LockGearClick=false;cu.OpenClose();Check(r,cuObject.activeInHierarchy,"collection original toggle opens");cu.OpenClose();Check(r,!cuObject.activeSelf&&GameManager.PageAcildi,"collection original toggle closes without overwriting global page flag");
            Check(r,cm.allCollectibles.Count==2&&cm.allCollectibles[0].ID==37&&cm.allCollectibles[0].Value==12&&!cm.allCollectibles[1].Collected,"UI navigation preserves supplied collectible records and never calls collection/reward save logic");
        }catch(Exception e){r.failures.Add(e.ToString());}
        finally{foreach(var row in oldCurrencies)SetCurrency(row.Key,row.Value);Currencys.GearScroll=oldScroll;GuideJustGear.LockGearClick=oldLock;GameManager.PageAcildi=oldPage;GameManager.Language=oldLanguage;Lang.currentLang=oldLang;SoundManager.instance=oldSound;UnityEngine.Random.state=oldRandom;UnityEngine.Object.DestroyImmediate(root);if(sprite)UnityEngine.Object.DestroyImmediate(sprite);if(texture)UnityEngine.Object.DestroyImmediate(texture);}
        r.passed=r.failures.Count==0;var folder=Path.Combine(Directory.GetParent(Application.dataPath).FullName,"Verification");Directory.CreateDirectory(folder);File.WriteAllText(Path.Combine(folder,"growth-navigation.json"),JsonUtility.ToJson(r,true));return r;
    }
    public static void RunBatch(){var r=RunChecks();Debug.Log(JsonUtility.ToJson(r));EditorApplication.Exit(r.passed?0:1);}
}
