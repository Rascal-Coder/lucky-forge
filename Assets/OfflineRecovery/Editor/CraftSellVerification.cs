using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace LuckyForge.Offline.Editor
{
    public static class CraftSellVerification
    {
        [Serializable] public sealed class Result { public bool passed; public int checks; public List<string> failures=new List<string>(); }
        static void Check(Result r,bool ok,string name) {r.checks++;if(!ok)r.failures.Add(name);}
        static void Invoke(object target,string method) {target.GetType().GetMethod(method,BindingFlags.NonPublic|BindingFlags.Public|BindingFlags.Instance).Invoke(target,null);}
        public static Result RunChecks()
        {
            var r=new Result();bool guide=GameManager.GuideDone;
            var root=new GameObject("CraftSellVerification");root.SetActive(false);
            var panel=new GameObject("Panel");panel.SetActive(false);
            try {
                var war=root.AddComponent<WarController>();war.CastleHp=100;
                var craft=panel.AddComponent<CraftAndSell>();craft.warController=war;
                var target=new GameObject("Slot");target.transform.SetParent(root.transform);var slot=target.AddComponent<InventorySlot>();
                var unit=new GameObject("Unit");unit.transform.SetParent(root.transform);var commander=unit.AddComponent<Commander>();commander.Rarity=WeaponRarity.Common;
                slot.commanders=new List<Commander>{commander};slot.warController=war;
                var button=new GameObject("MergeButton",typeof(RectTransform),typeof(Button));button.transform.SetParent(panel.transform);craft.mergebtn=button.GetComponent<Button>();
                // Keep WarController and Commander inactive: test only the real CraftAndSell panel lifecycle.
                target.SetActive(false);unit.SetActive(false);
                war.craftandsellopentimer=0.199f;Check(r,!craft.readytoopen(),"original 0.2 second readiness gate");
                war.craftandsellopentimer=0.2f;Check(r,craft.readytoopen(),"ready at exact 0.2 threshold");
                war.CastleHp=0;Check(r,!craft.readytoopen(),"dead castle cannot open unit panel");war.CastleHp=100;
                craft.OpenCraftSell(slot);
                Check(r,panel.activeInHierarchy&&war.craftandsellopentimer==0f&&craft.closetimer==0f,"actual OpenCraftSell activates panel and resets both timers");
                Check(r,!craft.readytoopen()&&!craft.mergebtn.interactable,"open panel is not ready and one unit cannot merge");
                craft.closetimer=0.1f;craft.Closeit();Check(r,panel.activeInHierarchy,"close gate excludes equality at 0.1");
                craft.closetimer=0.10001f;craft.Closeit();Check(r,!panel.activeInHierarchy,"close gate opens strictly above 0.1");
                slot.commanders.Add(commander);slot.commanders.Add(commander);war.craftandsellopentimer=0.2f;craft.OpenCraftSell(slot);
                Check(r,panel.activeInHierarchy&&craft.mergebtn.interactable,"actual full Common slot enables merge button");
                commander.Rarity=WeaponRarity.Legendary;craft.closetimer=1;craft.Closeit();war.craftandsellopentimer=0.2f;craft.OpenCraftSell(slot);
                Check(r,!craft.mergebtn.interactable,"original Legend cap disables merge button");
                // Exercise callback at <3 units, where original MergeCommanders returns before external pool dependencies.
                slot.commanders.RemoveAt(2);slot.commanders.RemoveAt(1);war.craftandsellopentimer=9;
                craft.Merge();Check(r,!panel.activeInHierarchy&&war.craftandsellopentimer==0f&&slot.commanders.Count==1,"actual Merge callback closes UI/resets timer and delegates safely to original slot guard");
                var prices=(float[])typeof(CraftAndSell).GetField("satisfiyati",BindingFlags.NonPublic|BindingFlags.Instance).GetValue(craft);
                Check(r,prices.Length==5&&prices[0]==30&&prices[1]==1&&prices[4]==4,"original FieldRef45 sale values initialized");
            }catch(Exception ex){r.failures.Add(ex.ToString());}
            finally{GameManager.GuideDone=guide;UnityEngine.Object.DestroyImmediate(panel);UnityEngine.Object.DestroyImmediate(root);}
            r.passed=r.failures.Count==0;
            var file=Path.Combine(Directory.GetParent(Application.dataPath).FullName,"Verification","craft-sell.json");Directory.CreateDirectory(Path.GetDirectoryName(file));File.WriteAllText(file,JsonUtility.ToJson(r,true));return r;
        }
        public static void RunBatch(){var r=RunChecks();Debug.Log(JsonUtility.ToJson(r));EditorApplication.Exit(r.passed?0:1);}
    }
}
