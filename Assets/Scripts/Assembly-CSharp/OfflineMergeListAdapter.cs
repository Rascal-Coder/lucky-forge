using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Offline view adapter around the original exported gear cell prefab and layout settings.
// Item mutation/progression belongs to the restored MergeUIManager methods.
public sealed class OfflineMergeListAdapter : MonoBehaviour
{
    readonly List<GameObject> rows = new List<GameObject>();
    public static Color RarityColor(MergeUIManager ui, int rarity)
    {
        var colors = ui && ui.inventoryManager ? ui.inventoryManager.RarityColors : null;
        return colors != null && rarity >= 0 && rarity < colors.Length ? (Color)colors[rarity] : Color.white;
    }
    public void Rebuild(MergeUIManager ui, List<GearInstance> data)
    {
        foreach(var old in rows) if(old) { old.SetActive(false); Destroy(old); }
        rows.Clear();
        var scroll = ui.gearScroll;
        Transform parent = scroll && scroll.content ? scroll.content : ui.inventoryItemParent;
        GameObject prefab = scroll && scroll.itemPrefab ? scroll.itemPrefab : ui.gearButtonPrefab;
        if(!parent || !prefab) return;
        bool nativeLayout=parent.GetComponent<LayoutGroup>();
        int columns=scroll ? Mathf.Max(1,scroll.itemsPerRow) : 1;
        for(int i=0;i<data.Count;i++)
        {
            var gear=data[i]; if(gear==null || !gear.template) continue;
            var row=Instantiate(prefab,parent,false); rows.Add(row);
            row.SetActive(true);
            if(scroll && !nativeLayout) {
                var rect=row.transform as RectTransform;
                if(rect) {
                    rect.anchorMin=rect.anchorMax=new Vector2(0,1);rect.pivot=new Vector2(0,1);
                    rect.sizeDelta=new Vector2(scroll.itemWidth,scroll.itemHeight);
                    rect.anchoredPosition=new Vector2(scroll.paddingLeft+(i%columns)*(scroll.itemWidth+scroll.spacing),-scroll.paddingTop-(i/columns)*(scroll.itemHeight+scroll.spacing));
                }
            }
            var cell=row.GetComponent<MergeInventoryTekliUI>();
            if(cell) { cell.mergeUIManager=ui; cell.SetData(gear,i); }
        }
        if(scroll && scroll.content && !nativeLayout) {
            float height=scroll.paddingTop+Mathf.CeilToInt((float)data.Count/columns)*(scroll.itemHeight+scroll.spacing);
            scroll.content.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical,height);
        }
    }
}
