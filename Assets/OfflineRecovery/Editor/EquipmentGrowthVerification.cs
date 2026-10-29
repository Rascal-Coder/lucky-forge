using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace LuckyForge.Offline.Editor
{
    public static class EquipmentGrowthVerification
    {
        [Serializable] public sealed class Result{public bool passed;public int checks;public List<string> failures=new List<string>();}
        static void Check(Result r,bool ok,string label){r.checks++;if(!ok)r.failures.Add(label);}
        static GearInstance Gear(GearTemplate t,GearRarity rarity,int bonus=0)=>new GearInstance{template=t,rarity=rarity,level=2,GearRarityBonus=bonus};
        static void Select(MergeUIManager ui,InventoryManager owner,GearInstance a,GearInstance b,GearInstance c){owner.inventory.Clear();owner.equipped.Clear();owner.inventory.AddRange(new[]{a,b,c});ui.ClearSlots();ui.OnItemClick(a,null);ui.OnItemClick(b,null);ui.OnItemClick(c,null);}
        public static Result RunChecks()
        {
            var r=new Result();var root=new GameObject("EquipmentGrowthVerification");root.SetActive(false);
            var originalKiyafet=PlayerData.KiyafetData;int capacity=GameManager.MaxGearSize;var random=UnityEngine.Random.state;
            var a=ScriptableObject.CreateInstance<GearTemplate>();a.slot=GearSlot.Head;a.baseAttackRaritys=new long[]{100,200,300,400,500};a.perks=new List<GearTemplate.Perk>{new GearTemplate.Perk{stat="CommonAttackArtisi",value=7.9f},new GearTemplate.Perk{stat="CastleHpArtisi",value=13.2f},new GearTemplate.Perk{stat="AxeAttackArtisi",value=3},new GearTemplate.Perk{stat="AxeCritChanceArtisi",value=2},new GearTemplate.Perk{stat="SavasBasindaFreeCoin",value=9}};
            var b=ScriptableObject.CreateInstance<GearTemplate>();b.slot=GearSlot.Head;b.baseAttackRaritys=a.baseAttackRaritys;b.perks=a.perks;
            var wrongSlot=ScriptableObject.CreateInstance<GearTemplate>();wrongSlot.slot=GearSlot.Boots;wrongSlot.baseAttackRaritys=a.baseAttackRaritys;wrongSlot.perks=a.perks;
            OfflineAssetReferenceCatalog.Register("equipment-test-a:11400000",a);OfflineAssetReferenceCatalog.Register("equipment-test-b:11400000",b);
            var store=Path.Combine(Directory.GetParent(Application.dataPath).FullName,"Verification","EquipmentGrowthTests",Guid.NewGuid().ToString("N"));OfflineKeyStore.SetVerificationRoot(store);
            try {
                PlayerData.KiyafetData=new PlayerData.NewKiyafetData();GameManager.MaxGearSize=1000;
                var owner=root.AddComponent<InventoryManager>();owner.inventory=new List<GearInstance>();owner.equipped=new Dictionary<GearSlot,GearInstance>();owner.gearTemplates=new[]{a,b};
                var merge=root.AddComponent<MergeUIManager>();merge.inventoryManager=owner;owner.mergeui=merge;
                var common=Gear(a,GearRarity.Common);
                Check(r,common.GetAttack()==126&&common.GetAttack(1)==139&&common.GearScore()==129&&common.UpgradeCoin()==220,"native attack/score/upgrade cost arithmetic");
                common.GearMergeCount=2;Check(r,common.GetAttack()==366,"merge count scales base attack before integer division");common.GearMergeCount=0;
                common.CalculateBonuses();Check(r,common.CommonAttackArtisi==7&&common.CastleHpArtisi==0,"Common only unlocks perk index0 and truncates float");
                var rare=Gear(a,GearRarity.Rare);rare.CalculateBonuses();Check(r,rare.CommonAttackArtisi==7&&rare.CastleHpArtisi==13&&rare.AxeAttackArtisi==0,"Rare unlocks second original perk");
                var mystic=Gear(a,GearRarity.Mystic,99);mystic.CalculateBonuses();Check(r,mystic.SavasBasindaFreeCoin==9&&mystic.AxeCritChanceArtisi==2,"Mystic unlocks all five perks without invented bonus multiplier");
                mystic.rarity=GearRarity.Common;mystic.CalculateBonuses();Check(r,mystic.SavasBasindaFreeCoin==0&&mystic.AxeCritChanceArtisi==0,"recalculate clears stale higher-rarity bonuses");
                owner.inventory.Add(rare);owner.EquipGear(rare);Check(r,PlayerData.KiyafetData.AllDamageArtisiFlat==246&&PlayerData.KiyafetData.CastleHpArtisi==13&&!owner.inventory.Contains(rare),"actual EquipGear writes combat KiyafetData");
                owner.UnequipGear(a.slot);Check(r,PlayerData.KiyafetData.AllDamageArtisiFlat==0&&PlayerData.KiyafetData.CastleHpArtisi==0&&owner.inventory.Contains(rare),"actual UnequipGear removes combat bonuses");
                owner.inventory.Clear();UnityEngine.Random.InitState(401);owner.GenerateRewards(4);
                bool generated=owner.pendingRewards.Count==4;foreach(var gear in owner.pendingRewards)generated&=(gear.template==a||gear.template==b)&&gear.rarity==GearRarity.Common&&(gear.level==1||gear.level==2);
                Check(r,generated&&owner.inventory.Count==0,"real GenerateRewards only fills original pending list");
                owner.ClaimEquipments(2);Check(r,owner.inventory.Count==8&&owner.pendingRewards.Count==0&&!ReferenceEquals(owner.inventory[0],owner.inventory[4]),"real ClaimEquipments clones requested copies and clears pending");
                owner.ClaimEquipments(2);Check(r,owner.inventory.Count==8,"repeated claim cannot duplicate cleared rewards");
                var earned=owner.inventory[0];owner.EquipGear(earned);long effect=PlayerData.KiyafetData.AllDamageArtisiFlat;owner.SaveGears();ES3.StoreCachedFile("medupac.es3",new ES3Settings("medupac.es3",ES3.Location.File));OfflineKeyStore.ResetMemoryForVerification();owner.Load();
                typeof(InventoryManager).GetMethod("Start",BindingFlags.NonPublic|BindingFlags.Instance).Invoke(owner,null);
                Check(r,owner.inventory.Count==7&&owner.GetEquipped(a.slot)!=null&&PlayerData.KiyafetData.AllDamageArtisiFlat==effect,"earned reward save/reload restores equipped identity and combat effect");
                var epic=Gear(a,GearRarity.Epic,1);var epicZero=Gear(b,GearRarity.Epic,0);
                Check(r,merge.IsValidCandidate(epic,epicZero)&&!merge.IsValidCandidate(epic,Gear(b,GearRarity.Epic,1))&&!merge.IsValidCandidate(epic,Gear(wrongSlot,GearRarity.Epic,0)),"Epic+1 accepts only Epic+0 same slot, across original templates");
                Select(merge,owner,epic,epicZero,Gear(b,GearRarity.Epic,0));merge.Merge();Check(r,owner.inventory.Count==1&&owner.inventory[0].rarity==GearRarity.Epic&&owner.inventory[0].GearRarityBonus==2,"actual manual Epic+1 three-piece merge reaches Epic+2");
                Select(merge,owner,Gear(a,GearRarity.Epic,2),Gear(a,GearRarity.Epic,2),Gear(a,GearRarity.Epic,2));merge.Merge();Check(r,owner.inventory.Count==1&&owner.inventory[0].rarity==GearRarity.Legendary&&owner.inventory[0].GearRarityBonus==0,"actual manual Epic+2 exact-template merge reaches Legend");
                var legend=Gear(a,GearRarity.Legendary,1);Check(r,merge.IsValidCandidate(legend,Gear(b,GearRarity.Legendary,1))&&!merge.IsValidCandidate(legend,Gear(b,GearRarity.Legendary,0)),"Legend candidate bonus must match until +2");
                Select(merge,owner,legend,Gear(b,GearRarity.Legendary,1),Gear(b,GearRarity.Legendary,1));merge.Merge();Check(r,owner.inventory.Count==1&&owner.inventory[0].rarity==GearRarity.Legendary&&owner.inventory[0].GearRarityBonus==2,"actual manual Legend+1 reaches Legend+2");
                Select(merge,owner,Gear(a,GearRarity.Legendary,2),Gear(a,GearRarity.Legendary,2),Gear(a,GearRarity.Legendary,2));merge.Merge();Check(r,owner.inventory.Count==1&&owner.inventory[0].rarity==GearRarity.Mystic&&owner.inventory[0].GearRarityBonus==0,"actual Legend+2 exact-template merge reaches Mystic");
                Select(merge,owner,Gear(a,GearRarity.Mystic,3),Gear(b,GearRarity.Mystic,0),Gear(b,GearRarity.Mystic,2));merge.Merge();Check(r,owner.inventory.Count==1&&owner.inventory[0].rarity==GearRarity.Mystic&&owner.inventory[0].GearRarityBonus==4,"actual Mystic merge accepts any Mystic bonus of same slot");
                var main=Gear(a,GearRarity.Epic,0);var material1=Gear(b,GearRarity.Epic);var material2=Gear(b,GearRarity.Epic);Select(merge,owner,main,material1,material2);owner.EquipGear(main);merge.Merge();Check(r,owner.inventory.Count==0&&owner.GetEquipped(a.slot)!=main&&owner.GetEquipped(a.slot).GearRarityBonus==1&&PlayerData.KiyafetData.AxeAttackArtisi==3,"equipped advanced main is replaced and combat perks recalculate");
                owner.inventory.Clear();owner.equipped.Clear();owner.GenerateEventRewards(2,3);owner.ClaimEventEquipments();Check(r,owner.inventory.Count==2&&owner.inventory[0].rarity==GearRarity.Legendary&&owner.inventory[0].level==1&&owner.eventRewards.Count==0,"real event reward uses requested rarity and original level1");
            }catch(Exception ex){r.failures.Add(ex.ToString());}
            finally {PlayerData.KiyafetData=originalKiyafet;GameManager.MaxGearSize=capacity;UnityEngine.Random.state=random;OfflineKeyStore.SetVerificationRoot(null);UnityEngine.Object.DestroyImmediate(root);UnityEngine.Object.DestroyImmediate(a);UnityEngine.Object.DestroyImmediate(b);UnityEngine.Object.DestroyImmediate(wrongSlot);}
            r.passed=r.failures.Count==0;var file=Path.Combine(Directory.GetParent(Application.dataPath).FullName,"Verification","equipment-growth.json");Directory.CreateDirectory(Path.GetDirectoryName(file));File.WriteAllText(file,JsonUtility.ToJson(r,true));return r;
        }
        public static void RunBatch(){var r=RunChecks();Debug.Log(JsonUtility.ToJson(r));EditorApplication.Exit(r.passed?0:1);}
    }
}
