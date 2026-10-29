using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace LuckyForge.Offline.Editor
{
    public static class ForgeMergeVerification
    {
        [Serializable] public sealed class Result { public bool passed; public int checks; public List<string> failures=new List<string>(); }
        static void Check(Result r,bool ok,string name) { r.checks++;if(!ok)r.failures.Add(name); }
        static object Invoke(object target,string method,params object[] args) => target.GetType().GetMethod(method,BindingFlags.NonPublic|BindingFlags.Public|BindingFlags.Instance).Invoke(target,args);
        static GearInstance Gear(GearTemplate template,GearRarity rarity=GearRarity.Common) => new GearInstance {template=template,rarity=rarity,level=7};
        public static Result RunChecks()
        {
            var r=new Result();
            var root=Path.Combine(Directory.GetParent(Application.dataPath).FullName,"Verification","ForgeMergeTests",Guid.NewGuid().ToString("N"));
            OfflineKeyStore.SetVerificationRoot(root);
            var go=new GameObject("ForgeMergeVerification");go.SetActive(false);
            var originalStats=PlayerData.KiyafetData;
            var t=ScriptableObject.CreateInstance<GearTemplate>();t.slot=GearSlot.Head;
            t.baseAttackRaritys=new long[5];t.perks=new List<GearTemplate.Perk>();
            var other=ScriptableObject.CreateInstance<GearTemplate>();other.slot=GearSlot.Head;
            other.baseAttackRaritys=new long[5];other.perks=new List<GearTemplate.Perk>();
            OfflineAssetReferenceCatalog.Register("forge-merge-test-template:11400000",t);
            try {
                var inventory=go.AddComponent<InventoryManager>(); inventory.inventory=new List<GearInstance>();inventory.equipped=new Dictionary<GearSlot,GearInstance>();
                var merge=go.AddComponent<MergeUIManager>();merge.inventoryManager=inventory;
                var one=Gear(t);var two=Gear(t);var three=Gear(t);
                inventory.inventory.AddRange(new[]{one,two,three});
                Check(r,merge.IsValidCandidate(one,two),"same Common template is valid");
                Check(r,!merge.IsValidCandidate(one,Gear(other)),"different template is rejected for Common");
                Check(r,!merge.IsValidCandidate(one,Gear(t,GearRarity.Rare)),"different rarity is rejected");
                inventory.equipped[t.slot]=two;
                Check(r,!merge.IsValidCandidate(one,two),"equipped candidate is rejected");
                inventory.equipped.Clear();
                Check(r,merge.IsAnyMergeAvailable(),"three ordinary copies enable manual merge");
                merge.OnItemClick(one,null);merge.OnItemClick(two,null);merge.OnItemClick(two,null);merge.OnItemClick(three,null);
                Check(r,merge.mainItem==one&&merge.secondItem==two&&merge.thirdItem==three,"original selection route rejects reusing same object");
                var preview=(GearInstance)Invoke(merge,"CreatePreviewItem",one);
                Check(r,preview!=one&&preview.template==t&&preview.rarity==GearRarity.Rare&&preview.level==7&&preview.GearRarityBonus==0,"preserved original preview progression");
                merge.thirdItem=two;merge.Merge();
                Check(r,inventory.inventory.Count==3,"duplicate material never consumes inventory");
                merge.thirdItem=three;
                // Complete the actual Merge route while intercepting only the coroutine presentation at its public UI boundary.
                // In edit-mode Unity does not run coroutine frames; core mutation is synchronous before StartCoroutine.
                merge.Merge();
                Check(r,inventory.inventory.Count==1&&inventory.inventory[0].rarity==GearRarity.Rare&&inventory.inventory[0].template==t,"actual Merge consumes exactly three objects and adds original preview");
                Check(r,merge.mainItem==null&&merge.secondItem==null&&merge.thirdItem==null,"actual Merge clears selection after commit");
                inventory.inventory.Clear();inventory.inventory.AddRange(new[]{one,two,three});
                inventory.EquipGear(one);
                Check(r,inventory.GetEquipped(t.slot)==one&&!inventory.inventory.Contains(one)&&inventory.inventory.Count==2,"equip moves ownership out of inventory");
                inventory.UnequipGear(t.slot);
                Check(r,inventory.GetEquipped(t.slot)==null&&inventory.inventory.Contains(one)&&inventory.inventory.Count==3,"unequip returns same instance to inventory");
                inventory.EquipGear(one);inventory.SaveGears();ES3.StoreCachedFile("medupac.es3",new ES3Settings("medupac.es3",ES3.Location.File));
                OfflineKeyStore.ResetMemoryForVerification();inventory.Load();
                Check(r,inventory.inventory.Count==2&&inventory.GetEquipped(t.slot).template==t&&inventory.GetEquipped(t.slot).level==7,"actual original gear save keys reload asset reference and ownership");
                var war=go.AddComponent<WarController>();var spin=go.AddComponent<SpinforWeapon>();spin.warController=war;
                war.Fittoken(11);spin.fiyat=2;
                spin.SpinButtonPressed();
                Check(r,war.token==11&&!spin.spining,"missing spawner cannot charge tokens");
                var routine=(IEnumerator)Invoke(spin,"SpinAnimation");
                Check(r,routine.MoveNext()&&routine.Current is WaitForSeconds&&spin.spining,"original spin coroutine yields before outcome");
            } catch(Exception ex) { r.failures.Add(ex.ToString()); }
            finally { PlayerData.KiyafetData=originalStats;UnityEngine.Object.DestroyImmediate(go);UnityEngine.Object.DestroyImmediate(t);UnityEngine.Object.DestroyImmediate(other);OfflineKeyStore.SetVerificationRoot(null); }
            r.passed=r.failures.Count==0;
            var path=Path.Combine(Directory.GetParent(Application.dataPath).FullName,"Verification","forge-merge.json");Directory.CreateDirectory(Path.GetDirectoryName(path));File.WriteAllText(path,JsonUtility.ToJson(r,true));
            return r;
        }
        public static void RunBatch() { var r=RunChecks();Debug.Log(JsonUtility.ToJson(r));EditorApplication.Exit(r.passed?0:1); }
    }
}
