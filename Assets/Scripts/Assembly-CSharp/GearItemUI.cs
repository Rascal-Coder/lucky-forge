using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GearItemUI : MonoBehaviour, IVirtualScrollItem<GearInstance>
{
	public Image icon;

	public TextMeshProUGUI levelText;

	public Image rarity;

	public Image slotBack;

	public Image gearlvlBack;

	public Image category;

	public InventoryManager inventoryManager;

	private GearInstance gear;

	public TextMeshProUGUI GearBonusPlus;

	public void SetGear(GearInstance gear)
	{
		this.gear=gear;if(gear==null||!gear.template)return;
		if(icon)icon.sprite=gear.template.icon;
		if(category)category.sprite=gear.template.sloticon;
		if(levelText)levelText.text=gear.level.ToString();
		var color=OfflineEquipmentViews.ColorFor(inventoryManager,(int)gear.rarity);
		if(rarity)rarity.color=color;if(slotBack)slotBack.color=color;if(gearlvlBack)gearlvlBack.color=color;
		if(GearBonusPlus){GearBonusPlus.text="+"+gear.GearRarityBonus;GearBonusPlus.gameObject.SetActive(gear.GearRarityBonus>0);}
	}

	public void SetData(GearInstance data, int index)
	{
		SetGear(data);
	}

	public void OnClick()
	{
		if(inventoryManager&&inventoryManager.GearUI&&gear!=null)inventoryManager.GearUI.OneCikar(gear);
	}
}
