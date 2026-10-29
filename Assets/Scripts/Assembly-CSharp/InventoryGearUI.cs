using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryGearUI : MonoBehaviour
{
	public Transform itemParent;

	public GameObject itemPrefab;

	public VirtualScroll<GearInstance> gearScroll;

	public MergeUIManager mergeUI;

	public InventoryManager inventoryManager;

	public CanvasJobs canvasJobs;

	private int[] MaxGearLevelsRarity = new int[]{10,20,60,120,250};

	public TextMeshProUGUI totalGearScore;

	public TextMeshProUGUI mygears;

	public TextMeshProUGUI merge;

	public TextMeshProUGUI characters;

	public TextMeshProUGUI inventory;

	public TextMeshProUGUI pets;

	public TextMeshProUGUI walls;

	public TextMeshProUGUI collections;

	public GameObject mergearrow;

	[Header("OneCikan")]
	public GameObject OneCikan;

	public TextMeshProUGUI OneCikan_title;

	public TextMeshProUGUI OneCikan_gearscore;

	public Image OneCikan_RarityImg;

	public Image OneCikan_icon;

	public TextMeshProUGUI OneCikan_gearLeveltxt;

	public TextMeshProUGUI OneCikan_gearLevel;

	public TextMeshProUGUI OneCikan_typetxt;

	public TextMeshProUGUI OneCikan_type;

	public TextMeshProUGUI OneCikan_EquippedBasicBonus;

	public TextMeshProUGUI OneCikan_EquippedBasicKac;

	public TextMeshProUGUI OneCikan_EquippedRarityPerks;

	public TextMeshProUGUI OneCikan_Perk1;

	public TextMeshProUGUI OneCikan_Perk2;

	public TextMeshProUGUI OneCikan_Perk3;

	public TextMeshProUGUI OneCikan_Perk4;

	public TextMeshProUGUI OneCikan_Perk5;

	public TextMeshProUGUI OneCikan_UpgradeBonus;

	public TextMeshProUGUI OneCikan_UpgradeBonusKac;

	public TextMeshProUGUI OneCikan_Equip;

	public TextMeshProUGUI OneCikan_Upgrade;

	public TextMeshProUGUI OneCikan_UpgradeMaterial;

	public TextMeshProUGUI OneCikan_UpgradeCoin;

	public TextMeshProUGUI topMaterial;

	public Transform topMaterialIconParent;

	private GearInstance OneCikan_gear;

	public Animator OneCikan_UpgradeAnim;

	public Button OneCikan_upgradeBtn;

	public Button OneCikan_gearBtn;

	public TextMeshProUGUI OneCikan_gearbonuslvl;

	public GameObject equipArrow;

	public GameObject[] OneCikan_perksKilits;

	public infoIcons infoicon;

	public RectTransform rect;

	[Header("Hero")]
	public Image[] characterSet;

	public HeroController heroController;

	public bool helmet_degisti;

	public bool body_degisti;

	public bool shoe_degisti;

	public bool ring_degisti;

	public bool neck_degisti;

	public bool legs_degisti;

	public bool character_degisti;

	public bool pet_degisti;

	public bool wall_degisti;

	public int UpgradeMaterial(int level)
	{
		// RVA0x2231c08; powf import and both float32 constants independently decoded from ELF.
		float curved=Mathf.Pow((float)level/250f,1.8f)*50000f;
		int extra=curved==float.PositiveInfinity?int.MinValue:(int)curved;
		return unchecked(level*10+extra);
	}

	private int gearSpriteNum(int num)
	{
		// RVA0x2231c60 / original switch table0xc62ef8.
		switch(num){case 1:return 7;case 2:return 8;case 3:return 9;case 4:return 11;case 5:return 10;default:return 6;}
	}

	public void OneCikar(GearInstance kim)
	{
		// Partial view recovery. The selected object and all shown numerical values are original, not synthesized.
		if(kim==null||!kim.template)return;
		OneCikan_gear=kim;
		if(OneCikan_title)OneCikan_title.text=Lang.ItemGearName(kim.template.gearName);
		if(OneCikan_gearscore)OneCikan_gearscore.text=kim.GearScore().ToString();
		if(OneCikan_icon)OneCikan_icon.sprite=kim.template.icon;
		if(OneCikan_RarityImg)OneCikan_RarityImg.color=OfflineEquipmentViews.ColorFor(inventoryManager,(int)kim.rarity);
		if(OneCikan_gearLevel)OneCikan_gearLevel.text=kim.level.ToString();
		if(OneCikan_type)OneCikan_type.text=Lang.ItemGearType((int)kim.template.type);
		if(OneCikan_EquippedBasicKac)OneCikan_EquippedBasicKac.text=kim.GetAttack(0).ToString();
		if(OneCikan_gearbonuslvl){OneCikan_gearbonuslvl.text="+"+kim.GearRarityBonus;OneCikan_gearbonuslvl.gameObject.SetActive(kim.GearRarityBonus>0);}
		bool equipped=inventoryManager&&inventoryManager.equipped!=null&&inventoryManager.equipped.ContainsValue(kim);
		if(OneCikan_Equip)OneCikan_Equip.text=equipped?Lang.Get.Unequip:Lang.Get.Equip;
		if(OneCikan_gearBtn)OneCikan_gearBtn.interactable=true;
		OfflineEquipmentUpgrade.Refresh(this,kim,MaxGearLevelsRarity,gearSpriteNum((int)kim.template.slot));
		if(OneCikan)OneCikan.SetActive(true);
	}

	public void EquipUnequip()
	{
		if(!inventoryManager||OneCikan_gear==null||!OneCikan_gear.template)return;
		if(inventoryManager.equipped!=null&&inventoryManager.equipped.ContainsValue(OneCikan_gear))inventoryManager.UnequipGear(OneCikan_gear.GetSlot());
		else {
		 if(inventoryManager.inventory==null||!inventoryManager.inventory.Contains(OneCikan_gear))return;
		 inventoryManager.EquipGear(OneCikan_gear);
		}
		inventoryManager.Save();inventoryManager.UpdateEquippedUI();RefreshUI();OneCikar(OneCikan_gear);
	}

	private void UpdateGearScore()
	{
	}

	public void HeroGoster()
	{
        // Original ARM64 recovery 0x2233a28.
        int[] map={0,1,2,3,4,5,2,3,4,5};
        for(int i=0;i<10;i++)characterSet[i].sprite=heroController.currentMainHero.iconSet[map[i]];
	}

	public void UpgradeGear()
	{
		// RVA0x2233d2c. Preserve native affordability, cap, debit, save and combat-update order.
		var gear=OneCikan_gear;if(gear==null||!gear.template||!inventoryManager)return;
		int slot=(int)gear.template.slot;double coins=gear.UpgradeCoin();int material=UpgradeMaterial(gear.level);
		bool enoughCoin=Currencys.Coin>=coins;
		bool enoughMaterial=Currencys.GearScroll!=null&&slot>=0&&slot<Currencys.GearScroll.Length&&Currencys.GearScroll[slot]>=material;
		if(!enoughCoin||!enoughMaterial){
		 if(canvasJobs)canvasJobs.OpenGoldYok(enoughCoin?1:0);
		 if(SoundManager.instance)SoundManager.instance.RandomizeSfx(SoundManager._balikgone);
		 return;
		}
		if((uint)(int)gear.rarity>=(uint)MaxGearLevelsRarity.Length||gear.level>=MaxGearLevelsRarity[(int)gear.rarity])return;
		// Native deliberately ignores both Spend return values after the above visible-balance prechecks.
		Currencys.SpendCoin(coins,"Meta","UpgradeGear");
		Currencys.SpendGearScroll(slot,material,"Meta","UpgradeGear");
		gear.level=unchecked(gear.level+1);
		inventoryManager.UpdateEquippedUI();inventoryManager.Save();
		if(inventoryManager.equipped!=null&&inventoryManager.equipped.ContainsValue(gear))inventoryManager.CalculateEquippedPerks();
		OneCikar(gear);
		if(OneCikan_UpgradeAnim)OneCikan_UpgradeAnim.Play("Base Layer.talentshowanim",0,0f);
		GunlukGorevler.UpdateTaskProgressK(11,1);
		if(SoundManager.instance)SoundManager.instance.RandomizeSfx(SoundManager._upgrade2);
	}

	public void CloseOneCikan()
	{
		if(OneCikan)OneCikan.SetActive(false);RefreshUI();
	}

	private void OnEnable()
	{
		RefreshUI();
	}

	private void Start()
	{
	}

	public void RefreshUI()
	{
		if(!inventoryManager)return;
		var adapter=GetComponent<OfflineEquipmentViews>();if(!adapter)adapter=gameObject.AddComponent<OfflineEquipmentViews>();
		adapter.Rebuild(this);
		if(mygears)mygears.text=Lang.Get.MyGears+": "+inventoryManager.inventory.Count+"/"+GameManager.MaxGearSize;
		if(mergearrow&&mergeUI)mergearrow.SetActive(mergeUI.IsAnyMergeAvailable());
	}

	private InventoryManager InventoryManagerRef()
	{
		return null;
	}

	private void OnDisable()
	{
	}

	private void DegisiklikEventGonder()
	{
	}
}
