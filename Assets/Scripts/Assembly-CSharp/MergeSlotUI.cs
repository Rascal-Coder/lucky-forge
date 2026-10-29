using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MergeSlotUI : MonoBehaviour
{
	public Image icon;

	public TextMeshProUGUI lvl;

	public TextMeshProUGUI GearBonusPlus;

	public Image raritycolor;

	public Image slotBack;

	public Image gearlvlBack;

	public Image sloticon;

	public GameObject dolu;

	public MergeUIManager uIManager;

	public GearInstance Item { get; private set; }

	public void SetItem(GearInstance item)
	{
		Item=item;
		if(dolu) dolu.SetActive(item != null);
		if(item == null || !item.template) return;
		if(icon) icon.sprite=item.template.icon;
		if(sloticon) sloticon.sprite=item.template.sloticon;
		var color=OfflineMergeListAdapter.RarityColor(uIManager,(int)item.rarity);
		if(raritycolor) raritycolor.color=color;
		if(slotBack) slotBack.color=color;
		if(gearlvlBack) gearlvlBack.color=color;
		if(lvl) lvl.text=item.level.ToString();
		if(GearBonusPlus) { GearBonusPlus.text="+"+item.GearRarityBonus; GearBonusPlus.gameObject.SetActive(item.GearRarityBonus>0); }
	}
}
