using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace LuckyForge.Offline.Editor
{
    public static class SlotMachineVerification
    {
        [Serializable] public sealed class Result { public bool passed; public int checks; public List<string> failures=new List<string>(); }
        static void Check(Result r,bool ok,string name) {r.checks++;if(!ok)r.failures.Add(name);}
        static object Invoke(object target,string name,params object[] args) => target.GetType().GetMethod(name,BindingFlags.NonPublic|BindingFlags.Public|BindingFlags.Instance).Invoke(target,args);
        public static Result RunChecks()
        {
            var r=new Result();var go=new GameObject("SlotMachineVerification");go.SetActive(false);
            var oldWall=PlayerData.mainWallEffect;int oldLevel=GameManager.Level;var oldRandom=UnityEngine.Random.state;
            try {
                PlayerData.mainWallEffect=new PlayerData.WallEffect();
                var slot=go.AddComponent<SlotMachine>();slot.rarityChancesByLevel=new[]{new SlotMachine.RarityChance{common=100f}};slot.currentLevel=0;
                Check(r,slot.SpinFiyat()==10,"first spin original cost ten");slot.SpinAdet=2;
                Check(r,slot.SpinFiyat()==14,"two per spin escalation");PlayerData.mainWallEffect.SpinFiyatiDusur=20;
                Check(r,slot.SpinFiyat()==12,"original wall effect percent and truncation");
                var order=new[]{SlotMachine.Type.Silah,SlotMachine.Type.Silah,SlotMachine.Type.Coin,SlotMachine.Type.Coin,SlotMachine.Type.Silah,SlotMachine.Type.Kart};
                GameManager.Level=1;slot.SetNextSpinPreview(order,0,1);
                Check(r,slot.guidePreview&&ReferenceEquals(slot.guidePreviewSlots,order)&&slot.guideSilahsaNedir==1,"actual guide preview keeps original supplied array and weapon type");
                var result=slot.RollSlots();
                bool same=result.slots.Length==6;for(int i=0;i<6;i++)same&=result.slots[i]==order[i];
                Check(r,same&&result.rarityIndex==0,"first tutorial roll keeps exact six-slot order");
                Check(r,result.typeCounts[SlotMachine.Type.Silah]==3&&result.typeCounts[SlotMachine.Type.Coin]==2&&result.typeCounts[SlotMachine.Type.Kart]==1,"actual result count dictionary");
                Check(r,result.winningTypes.SetEquals(new[]{SlotMachine.Type.Silah}),"guide grants only original weapon winner");
                Check(r,!slot.guidePreview&&slot.BolumRollsayisi==1,"guide preview clears at Level one and advances local count");
                var delayed=(IEnumerator)Invoke(slot,"LateShowResult",result);
                Check(r,delayed.MoveNext()&&delayed.Current is WaitForSecondsRealtime,"reward uses real-time delay during paused tutorial");
                slot.spining=false;slot.BolumRollsayisi=0;GameManager.Level=3;
                UnityEngine.Random.InitState(721);
                for(int i=0;i<3;i++) {
                    result=slot.RollSlots();Check(r,result.typeCounts[SlotMachine.Type.Silah]==3&&result.rarityIndex==0,"first three ordinary rolls force weapon kind "+i);slot.spining=false;
                }
                var card=go.AddComponent<SlotUI>();
                Check(r,(int)Invoke(card,"GetRarity",3)==0&&(int)Invoke(card,"GetRarity",4)==1&&(int)Invoke(card,"GetRarity",5)==2&&(int)Invoke(card,"GetRarity",6)==3,"original match count rarity mapping");
                var war=go.AddComponent<WarController>();war.FitSilver(100);
                var ui=go.AddComponent<SlotMachineUI>();ui.slotMachine=slot;ui.warController=war;
                ui.Spin();Check(r,war.Silver==100,"missing spawner cannot charge Silver");
            }catch(Exception ex){r.failures.Add(ex.ToString());}
            finally {PlayerData.mainWallEffect=oldWall;GameManager.Level=oldLevel;UnityEngine.Random.state=oldRandom;UnityEngine.Object.DestroyImmediate(go);}
            r.passed=r.failures.Count==0;
            var path=Path.Combine(Directory.GetParent(Application.dataPath).FullName,"Verification","slot-machine.json");Directory.CreateDirectory(Path.GetDirectoryName(path));File.WriteAllText(path,JsonUtility.ToJson(r,true));return r;
        }
        public static void RunBatch() {var r=RunChecks();Debug.Log(JsonUtility.ToJson(r));EditorApplication.Exit(r.passed?0:1);}
    }
}
