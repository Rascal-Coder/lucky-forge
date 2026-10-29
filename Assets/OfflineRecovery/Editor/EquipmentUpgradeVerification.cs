using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace LuckyForge.Offline.Editor
{
    public static class EquipmentUpgradeVerification
    {
        [Serializable] public sealed class Result{public bool passed;public int checks;public List<string> failures=new List<string>();}
        static void Check(Result r,bool ok,string label){r.checks++;if(!ok)r.failures.Add(label);}
        static GearInstance Gear(GearTemplate t,GearRarity rarity,int level=2,int bonus=0)=>new GearInstance{template=t,rarity=rarity,level=level,GearRarityBonus=bonus};
        static T Child<T>(Transform parent,string name)where T:Component {var g=new GameObject(name,typeof(RectTransform));g.transform.SetParent(parent,false);return g.AddComponent<T>();}
        public static Result RunChecks()
        {
            var r=new Result();var root=new GameObject("EquipmentUpgradeVerification");root.SetActive(false);
            var oldData=PlayerData.KiyafetData;int oldLanguage=GameManager.Language;var oldLang=Lang.currentLang;
            var savedFields=new Dictionary<FieldInfo,object>();foreach(var name in new[]{"<Coin>k__BackingField","DataCoin","SaveCoin","SaveCoinTimer","GearScroll","DataGearScroll"}){var f=typeof(Currencys).GetField(name,BindingFlags.Static|BindingFlags.Public|BindingFlags.NonPublic);savedFields[f]=f.GetValue(null);}
            var template=ScriptableObject.CreateInstance<GearTemplate>();template.slot=GearSlot.Head;template.baseAttackRaritys=new long[]{100,200,300,400,500};template.perks=new List<GearTemplate.Perk>{new GearTemplate.Perk{stat="CommonAttackArtisi",value=7}};
            OfflineAssetReferenceCatalog.Register("equipment-upgrade-test:11400000",template);
            var store=Path.Combine(Directory.GetParent(Application.dataPath).FullName,"Verification","EquipmentUpgradeTests",Guid.NewGuid().ToString("N"));OfflineKeyStore.SetVerificationRoot(store);
            try{
                GameManager.Language=0;PlayerData.KiyafetData=new PlayerData.NewKiyafetData();
                Currencys.GearScroll=new int[6];typeof(Currencys).GetField("DataGearScroll",BindingFlags.Static|BindingFlags.NonPublic).SetValue(null,new int[6]);
                var owner=root.AddComponent<InventoryManager>();owner.inventory=new List<GearInstance>();owner.equipped=new Dictionary<GearSlot,GearInstance>();
                var ui=root.AddComponent<InventoryGearUI>();ui.inventoryManager=owner;owner.GearUI=ui;
                var merge=root.AddComponent<MergeUIManager>();merge.inventoryManager=owner;owner.mergeui=merge;
                ui.OneCikan_UpgradeCoin=Child<TextMeshProUGUI>(root.transform,"coin");ui.OneCikan_UpgradeMaterial=Child<TextMeshProUGUI>(root.transform,"scroll");ui.topMaterial=Child<TextMeshProUGUI>(root.transform,"balance");ui.OneCikan_UpgradeBonusKac=Child<TextMeshProUGUI>(root.transform,"attack");ui.OneCikan_upgradeBtn=Child<Button>(root.transform,"upgrade");
                ui.topMaterialIconParent=new GameObject("materialIcons").transform;ui.topMaterialIconParent.SetParent(root.transform,false);for(int i=0;i<6;i++)new GameObject("slot"+i).transform.SetParent(ui.topMaterialIconParent,false);
                Check(r,ui.UpgradeMaterial(0)==0&&ui.UpgradeMaterial(1)==12&&ui.UpgradeMaterial(2)==28&&ui.UpgradeMaterial(10)==252&&ui.UpgradeMaterial(60)==4431&&ui.UpgradeMaterial(250)==52500,"source float32 material curve across level range");
                var gear=Gear(template,GearRarity.Common);owner.inventory.Add(gear);Currencys.CoinFitle(1000);Currencys.FitleGearScroll(0,200);ui.OneCikar(gear);
                Check(r,ui.OneCikan_UpgradeCoin.text=="<sprite=0>220"&&ui.OneCikan_UpgradeMaterial.text=="<sprite=6>28"&&ui.topMaterial.text=="200"&&ui.OneCikan_UpgradeBonusKac.text.Contains("139"),"actual selected-gear UI shows coin, original slot sprite, material, balance and next attack");
                bool icons=true;for(int i=0;i<6;i++)icons&=ui.topMaterialIconParent.GetChild(i).gameObject.activeSelf==(i==0);Check(r,icons&&ui.OneCikan_upgradeBtn.interactable,"only original selected slot material icon active; below-cap button enabled");
                Currencys.CoinFitle(219);ui.UpgradeGear();Check(r,gear.level==2&&Currencys.Coin==219&&Currencys.GearScroll[0]==200,"insufficient coin leaves level and scrolls unchanged");
                Currencys.CoinFitle(1000);Currencys.FitleGearScroll(0,27);ui.UpgradeGear();Check(r,gear.level==2&&Currencys.Coin==1000&&Currencys.GearScroll[0]==27,"insufficient scroll leaves coin and level unchanged");
                Currencys.FitleGearScroll(0,200);ui.UpgradeGear();Check(r,gear.level==3&&Currencys.Coin==780&&Currencys.GearScroll[0]==172&&gear.GetAttack()==139,"actual UpgradeGear charges exact original costs before incrementing");
                Check(r,owner.GearSave,"actual upgrade schedules original gear save");
                owner.EquipGear(gear);long before=PlayerData.KiyafetData.AllDamageArtisiFlat;Currencys.CoinFitle(5000);Currencys.FitleGearScroll(0,500);int material=ui.UpgradeMaterial(gear.level);double coins=gear.UpgradeCoin();ui.UpgradeGear();Check(r,gear.level==4&&PlayerData.KiyafetData.AllDamageArtisiFlat==gear.GetAttack()&&PlayerData.KiyafetData.AllDamageArtisiFlat>before&&Currencys.Coin==5000-coins&&Currencys.GearScroll[0]==500-material,"equipped upgrade immediately changes PlayerData combat damage and debits correct level costs");
                owner.SaveGears();ES3.StoreCachedFile("medupac.es3",new ES3Settings("medupac.es3",ES3.Location.File));OfflineKeyStore.ResetMemoryForVerification();owner.Load();Check(r,owner.GetEquipped(GearSlot.Head).level==4&&ES3.Load<string>("Coin")==Currencys.Coin.ToString()&&ES3.Load<int>("GearScroll1")==Currencys.GearScroll[0],"real gear and currency save/reload preserves upgraded level and debits");
                var window=Gear(template,GearRarity.Common);Currencys.CoinFitle(1000);Currencys.FitleGearScroll(0,200);typeof(Currencys).GetField("DataCoin",BindingFlags.Static|BindingFlags.NonPublic).SetValue(null,0d);ui.OneCikar(window);ui.UpgradeGear();Check(r,window.level==3&&Currencys.Coin==0&&Currencys.GearScroll[0]==172,"native visible-balance precheck intentionally ignores later rejected SpendCoin return");
                window=Gear(template,GearRarity.Common);Currencys.CoinFitle(1000);Currencys.FitleGearScroll(0,200);((int[])typeof(Currencys).GetField("DataGearScroll",BindingFlags.Static|BindingFlags.NonPublic).GetValue(null))[0]=0;ui.OneCikar(window);ui.UpgradeGear();Check(r,window.level==3&&Currencys.Coin==780&&Currencys.GearScroll[0]==0,"native later rejected SpendGearScroll return does not add a refund/rejection branch");
                int[] caps={10,20,60,120,250};bool capped=true;for(int i=0;i<5;i++){var g=Gear(template,(GearRarity)i,caps[i]);Currencys.CoinFitle(10000000);Currencys.FitleGearScroll(0,1000000);ui.OneCikar(g);ui.UpgradeGear();capped&=g.level==caps[i]&&!ui.OneCikan_upgradeBtn.interactable&&Currencys.Coin==10000000&&Currencys.GearScroll[0]==1000000;}Check(r,capped,"all five original rarity caps prevent upgrades and costs");
                owner.inventory.Clear();owner.equipped.Clear();owner.inventory.AddRange(new[]{Gear(template,GearRarity.Common),Gear(template,GearRarity.Common),Gear(template,GearRarity.Common)});var results=merge.AutoMergeCore(20);Check(r,results.Count==1&&owner.inventory.Count==1&&owner.inventory[0].rarity==GearRarity.Rare,"actual auto core consumes three Common and keeps one Rare");
                owner.inventory.Clear();for(int i=0;i<9;i++)owner.inventory.Add(Gear(template,GearRarity.Common));results=merge.AutoMergeCore(20);Check(r,results.Count==4&&owner.inventory.Count==1&&owner.inventory[0].rarity==GearRarity.Epic,"auto results re-enter original work list to perform 9 Common to 1 Epic");
                owner.inventory.Clear();for(int i=0;i<6;i++)owner.inventory.Add(Gear(template,GearRarity.Common));results=merge.AutoMergeCore(1);Check(r,results.Count==1&&owner.inventory.Count==4,"maxMerge strictly bounds consumed triplets");
                owner.inventory.Clear();for(int i=0;i<3;i++)owner.inventory.Add(Gear(template,GearRarity.Epic));results=merge.AutoMergeCore(20);Check(r,results.Count==0&&owner.inventory.Count==3,"native auto strategy preserves Epic for manual selection");
                owner.inventory.Clear();for(int i=0;i<3;i++)owner.inventory.Add(Gear(template,GearRarity.Rare,2,1));results=merge.AutoMergeCore(20);Check(r,results.Count==0&&owner.inventory.Count==3,"native auto filter excludes nonzero rarity bonuses");
                owner.inventory.Clear();for(int i=0;i<3;i++)owner.inventory.Add(Gear(template,GearRarity.Common));results=merge.AutoMergeCore(0);Check(r,results.Count==0&&owner.inventory.Count==3,"zero auto limit cannot consume inventory");
                merge.autoMergeBtn=Child<Button>(root.transform,"auto");typeof(MergeUIManager).GetMethod("CheckAutoMergeAvailable",BindingFlags.Instance|BindingFlags.NonPublic).Invoke(merge,null);Check(r,merge.autoMergeBtn.interactable,"original auto button enables only for actual mergeable triplet");
                owner.inventory.RemoveAt(0);typeof(MergeUIManager).GetMethod("CheckAutoMergeAvailable",BindingFlags.Instance|BindingFlags.NonPublic).Invoke(merge,null);Check(r,!merge.autoMergeBtn.interactable,"two pieces do not enable auto merge");
            }catch(Exception ex){r.failures.Add(ex.ToString());}
            finally{foreach(var kv in savedFields)kv.Key.SetValue(null,kv.Value);PlayerData.KiyafetData=oldData;GameManager.Language=oldLanguage;Lang.currentLang=oldLang;OfflineKeyStore.SetVerificationRoot(null);UnityEngine.Object.DestroyImmediate(root);UnityEngine.Object.DestroyImmediate(template);}
            r.passed=r.failures.Count==0;var file=Path.Combine(Directory.GetParent(Application.dataPath).FullName,"Verification","equipment-upgrade.json");Directory.CreateDirectory(Path.GetDirectoryName(file));File.WriteAllText(file,JsonUtility.ToJson(r,true));return r;
        }
        public static void RunBatch(){var r=RunChecks();Debug.Log(JsonUtility.ToJson(r));EditorApplication.Exit(r.passed?0:1);}
    }
}
