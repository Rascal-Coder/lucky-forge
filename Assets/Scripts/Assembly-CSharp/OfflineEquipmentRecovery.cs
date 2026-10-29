using System;
using System.Collections.Generic;
using UnityEngine;

// Shared port of the identical original battle/offline/idle reward loops, not a new reward source.
public static class OfflineEquipmentRecovery
{
    public static void Generate(InventoryManager owner,List<GearInstance> pending,int count,GearRarity rarity,bool eventReward)
    {
        pending.Clear();
        if(count<=0)return;
        if(owner.gearTemplates==null||owner.gearTemplates.Length==0)throw new InvalidOperationException("Original gearTemplates are required for gear reward generation.");
        for(int i=0;i<count;i++) {
            var template=owner.gearTemplates[UnityEngine.Random.Range(0,owner.gearTemplates.Length)];
            pending.Add(new GearInstance{template=template,rarity=rarity,level=eventReward?1:UnityEngine.Random.Range(1,3)});
        }
    }
    public static void Claim(InventoryManager owner,List<GearInstance> pending,int multiplier,bool capacityCheck)
    {
        if(pending==null)return;
        if(owner.inventory==null)owner.inventory=new List<GearInstance>();
        for(int copy=0;copy<multiplier;copy++)foreach(var reward in pending) {
            if(reward==null)throw new InvalidOperationException("Pending original reward is missing.");
            if(capacityCheck&&owner.inventory.Count>=GameManager.MaxGearSize&&owner.mergeui)owner.mergeui.AutoMergeCore(20);
            if(!capacityCheck||owner.inventory.Count<GameManager.MaxGearSize) {
                owner.AddToInventory(new GearInstance{template=reward.template,rarity=reward.rarity,level=reward.level});
            } else {
                if(owner.canvasJobs)owner.canvasJobs.OpenGoldYok(5);
                Currencys.AddGearScroll((int)reward.template.slot,7,"Meta","GearDestroyed");
            }
        }
        owner.Save();pending.Clear();
    }
}
