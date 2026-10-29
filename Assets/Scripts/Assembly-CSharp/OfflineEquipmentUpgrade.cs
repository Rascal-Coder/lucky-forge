using UnityEngine;

// Partial original-resource view, with source-backed prices, level caps and sprite indices.
public static class OfflineEquipmentUpgrade
{
    public static void Refresh(InventoryGearUI ui,GearInstance gear,int[] caps,int materialSprite)
    {
        if(!ui||gear==null||!gear.template)return;
        int slot=(int)gear.template.slot;
        int material=ui.UpgradeMaterial(gear.level);
        int balance=Currencys.GearScroll!=null&&slot>=0&&slot<Currencys.GearScroll.Length?Currencys.GearScroll[slot]:0;
        bool belowCap=(uint)(int)gear.rarity<(uint)caps.Length&&gear.level<caps[(int)gear.rarity];
        if(ui.OneCikan_Upgrade)ui.OneCikan_Upgrade.text=Lang.Get.gelistir;
        if(ui.OneCikan_UpgradeBonusKac)ui.OneCikan_UpgradeBonusKac.text=gear.GetAttack(0)+" → <color=#C7FF00>"+gear.GetAttack(1)+"</color>";
        if(ui.OneCikan_UpgradeCoin)ui.OneCikan_UpgradeCoin.text="<sprite=0>"+gear.UpgradeCoin().ToString();
        if(ui.OneCikan_UpgradeMaterial)ui.OneCikan_UpgradeMaterial.text="<sprite="+materialSprite+">"+material.ToString();
        if(ui.topMaterial)ui.topMaterial.text=balance.ToString();
        if(ui.topMaterialIconParent)for(int i=0;i<ui.topMaterialIconParent.childCount;i++)ui.topMaterialIconParent.GetChild(i).gameObject.SetActive(i==slot);
        if(ui.OneCikan_upgradeBtn)ui.OneCikan_upgradeBtn.interactable=belowCap;
    }
}
