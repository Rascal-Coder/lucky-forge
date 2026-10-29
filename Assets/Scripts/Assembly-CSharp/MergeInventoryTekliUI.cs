using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MergeInventoryTekliUI : MonoBehaviour, IVirtualScrollItem<GearInstance>
{
	public Button btn;

	public Image icon;

	public TextMeshProUGUI level;

	public Image rarityBack;

	public Image slotBack;

	public Image gearlvlBack;

	public Image sloticon;

	public GameObject checkobj;

	public GameObject lockobj;

	public GameObject equippedobj;

	public TextMeshProUGUI equippedtxt;

	public TextMeshProUGUI GearBonusPlus;

	public MergeUIManager mergeUIManager;

	public GameObject arrow;

	public void SetItem(Sprite iconum, int levelim, int rarityim, Sprite slotum, bool locked, bool check, bool equipped, int gearbonus)
	{
		if(icon) icon.sprite=iconum;
		if(sloticon) sloticon.sprite=slotum;
		if(level) { level.text=levelim.ToString(); level.gameObject.SetActive(levelim >= 0); }
		var color=OfflineMergeListAdapter.RarityColor(mergeUIManager,rarityim);
		if(rarityBack) rarityBack.color=color;
		if(slotBack) slotBack.color=color;
		if(gearlvlBack) gearlvlBack.color=color;
		if(lockobj) lockobj.SetActive(locked);
		if(checkobj) checkobj.SetActive(check);
		if(equippedobj) equippedobj.SetActive(equipped);
		if(GearBonusPlus) { GearBonusPlus.text="+"+gearbonus; GearBonusPlus.gameObject.SetActive(gearbonus>0); }
	}

	public void SetData(GearInstance data, int index)
	{
		if(data==null||!data.template||!mergeUIManager){gameObject.SetActive(false);return;}
		bool selected=data==mergeUIManager.mainItem||data==mergeUIManager.secondItem||data==mergeUIManager.thirdItem;
		bool locked=mergeUIManager.mainItem!=null&&!mergeUIManager.IsValidCandidate(mergeUIManager.mainItem,data);
		bool equipped=mergeUIManager.inventoryManager.equipped!=null&&mergeUIManager.inventoryManager.equipped.ContainsValue(data);
		SetItem(data.template.icon,data.level,(int)data.rarity,data.template.sloticon,locked,selected,equipped,data.GearRarityBonus);
		if(btn){btn.onClick.RemoveAllListeners();btn.interactable=!locked&&!selected;btn.onClick.AddListener(()=>mergeUIManager.OnItemClick(data,transform));}
	}
}
