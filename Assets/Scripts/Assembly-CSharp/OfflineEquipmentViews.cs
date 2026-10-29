using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Bounded view adapter. All cells use the exported original GearItemUI prefab and layout dimensions.
public sealed class OfflineEquipmentViews : MonoBehaviour
{
    readonly List<GameObject> rows=new List<GameObject>();
    public static Color ColorFor(InventoryManager owner,int rarity)
    {
        var colors=owner?owner.RarityColors:null;
        return colors!=null&&rarity>=0&&rarity<colors.Length?(Color)colors[rarity]:Color.white;
    }
    public void Rebuild(InventoryGearUI ui)
    {
        foreach(var row in rows)if(row){row.SetActive(false);Destroy(row);}rows.Clear();
        var owner=ui.inventoryManager;if(!owner||owner.inventory==null)return;
        var scroll=ui.gearScroll;
        Transform parent=scroll&&scroll.content?scroll.content:ui.itemParent;
        GameObject prefab=scroll&&scroll.itemPrefab?scroll.itemPrefab:ui.itemPrefab;
        if(!parent||!prefab)return;
        bool layout=parent.GetComponent<LayoutGroup>();int columns=scroll?Mathf.Max(1,scroll.itemsPerRow):1;
        for(int i=0;i<owner.inventory.Count;i++) {
            var item=owner.inventory[i];if(item==null||!item.template)continue;
            var row=Instantiate(prefab,parent,false);row.SetActive(true);rows.Add(row);
            if(scroll&&!layout) {
                var rect=row.transform as RectTransform;
                if(rect){rect.anchorMin=rect.anchorMax=new Vector2(0,1);rect.pivot=new Vector2(0,1);rect.sizeDelta=new Vector2(scroll.itemWidth,scroll.itemHeight);rect.anchoredPosition=new Vector2(scroll.paddingLeft+(i%columns)*(scroll.itemWidth+scroll.spacing),-scroll.paddingTop-(i/columns)*(scroll.itemHeight+scroll.spacing));}
            }
            var cell=row.GetComponent<GearItemUI>();if(cell){cell.inventoryManager=owner;cell.SetData(item,i);}
        }
        if(scroll&&scroll.content&&!layout)scroll.content.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical,scroll.paddingTop+Mathf.CeilToInt((float)owner.inventory.Count/columns)*(scroll.itemHeight+scroll.spacing));
    }
}
