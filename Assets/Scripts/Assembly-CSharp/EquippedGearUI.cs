using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EquippedGearUI : MonoBehaviour
{
	public GearSlot slotType;

	public Image icon;

	public Image rarityBack;

	public Image slotBack;

	public Image gearlvlBack;

	public TextMeshProUGUI lvl;

	public TextMeshProUGUI gearsbonuslvl;

	public GameObject emptyPlaceholder;

	public GameObject upgarrow;

	private GearInstance currentGear;

	public InventoryManager inventoryManager;

	public void SetInventoryManager(InventoryManager manager)
	{
		inventoryManager=manager;UpdateSlotUI();
	}

	public void UpdateSlotUI()
	{
		currentGear=inventoryManager?inventoryManager.GetEquipped(slotType):null;
		bool filled=currentGear!=null&&currentGear.template;
		if(emptyPlaceholder)emptyPlaceholder.SetActive(!filled);
		if(icon)icon.gameObject.SetActive(filled);
		if(lvl)lvl.gameObject.SetActive(filled);
		if(gearsbonuslvl)gearsbonuslvl.gameObject.SetActive(filled&&currentGear.GearRarityBonus>0);
		if(!filled)return;
		if(icon)icon.sprite=currentGear.template.icon;
		if(lvl)lvl.text=Lang.Get.lv+currentGear.level;
		if(gearsbonuslvl)gearsbonuslvl.text="+"+currentGear.GearRarityBonus;
		var color=OfflineEquipmentViews.ColorFor(inventoryManager,(int)currentGear.rarity);
		if(rarityBack)rarityBack.color=color;if(slotBack)slotBack.color=color;if(gearlvlBack)gearlvlBack.color=color;
	}

	private void Update()
	{
	}

	public void OnClick_Unequip()
	{
		if(inventoryManager&&inventoryManager.GearUI&&currentGear!=null)inventoryManager.GearUI.OneCikar(currentGear);
	}
}
