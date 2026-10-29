using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
	public List<GearInstance> inventory;

	public Dictionary<GearSlot, GearInstance> equipped;

	public Color32[] RarityColors;

	public string[] RarityTextColors;

	public InventoryGearUI GearUI;

	public List<EquippedGearUI> equippedSlotUIs;

	public infoIcons infoicon;

	public MergeUIManager mergeui;

	public CanvasJobs canvasJobs;

	public GearTemplate[] gearTemplates;

	private float timergearsave;

	public bool GearSave;

	public List<GearInstance> pendingRewards = new List<GearInstance>();

	public List<GearInstance> OfflinependingRewards = new List<GearInstance>();

	public List<GearInstance> OfidleRewards = new List<GearInstance>();

	public List<GearInstance> eventRewards = new List<GearInstance>();

	private void Start()
	{
		if(inventory==null)inventory=new List<GearInstance>();
		if(equipped==null)equipped=new Dictionary<GearSlot,GearInstance>();
		foreach(GearSlot slot in Enum.GetValues(typeof(GearSlot)))if(!equipped.ContainsKey(slot))equipped[slot]=null;
		CalculateEquippedPerks();
	}

	private void OnEnable()
	{
	}

	private void Awake()
	{
		Load();
	}

	private void Update()
	{
		timergearsave += Time.deltaTime;
		if (GearSave && timergearsave > 1f) { SaveGears(); timergearsave=0f; GearSave=false; }
	}

	public void Save()
	{
		timergearsave = 0f; GearSave = true;
	}

	public void AddToInventory(GearInstance gear)
	{
		if (gear == null) return;
		if (inventory == null) inventory = new List<GearInstance>();
		inventory.Add(gear);
		if (infoicon) infoicon.EquipmentInfoVer();
	}

	public void EquipGear(GearInstance gear)
	{
		if (gear == null || !gear.template) return;
		if (inventory == null) inventory = new List<GearInstance>();
		if (equipped == null) equipped = new Dictionary<GearSlot, GearInstance>();
		GearInstance old;
		if (equipped.TryGetValue(gear.GetSlot(), out old) && old != null) inventory.Add(old);
		equipped[gear.GetSlot()] = gear;
		inventory.Remove(gear);
		CalculateEquippedPerks(); UpdateEquippedUI();
	}

	public void UnequipGear(GearSlot slot)
	{
		if (equipped == null) return;
		GearInstance old;
		if (equipped.TryGetValue(slot, out old)) {
		    if (inventory == null) inventory = new List<GearInstance>();
		    if (old != null) inventory.Add(old);
		    equipped[slot] = null;
		}
		CalculateEquippedPerks(); UpdateEquippedUI();
	}

	public void UpdateEquippedUI()
	{
		if (equippedSlotUIs != null) foreach (var ui in equippedSlotUIs) if (ui) { ui.SetInventoryManager(this); ui.UpdateSlotUI(); }
	}

	public GearInstance GetEquipped(GearSlot slot)
	{
		GearInstance result; return equipped != null && equipped.TryGetValue(slot, out result) ? result : null;
	}

	public void SaveGears()
	{
		if (inventory == null) inventory = new List<GearInstance>();
		if (equipped == null) equipped = new Dictionary<GearSlot, GearInstance>();
		ES3.Save("inventoryGear", inventory);
		ES3.Save("equippedSlots", new List<GearSlot>(equipped.Keys));
		ES3.Save("equippedItems", new List<GearInstance>(equipped.Values));
	}

	public void Load()
	{
		inventory = ES3.Load<List<GearInstance>>("inventoryGear", defaultValue: new List<GearInstance>());
		var slots = ES3.Load<List<GearSlot>>("equippedSlots", defaultValue: new List<GearSlot>());
		var gears = ES3.Load<List<GearInstance>>("equippedItems", defaultValue: new List<GearInstance>());
		if (inventory == null) inventory = new List<GearInstance>();
		equipped = new Dictionary<GearSlot, GearInstance>();
		if (slots != null && gears != null) for (int i=0; i<Math.Min(slots.Count,gears.Count); i++) equipped[slots[i]] = gears[i];
		UpdateEquippedUI();
	}

	public void CalculateEquippedPerks()
	{
		// Native RVA0x22341c4: CalculateBonuses on equipped.Values, then31 null-filtered Enumerable.Sum selectors.
		if(PlayerData.KiyafetData==null)PlayerData.KiyafetData=new PlayerData.NewKiyafetData();
		var data=PlayerData.KiyafetData;
		data.AllDamageArtisiFlat=0L;
		data.CommonAttackArtisi=0;
		data.RareAttackArtisi=0;
		data.EpicAttackArtisi=0;
		data.LegendAttackArtisi=0;
		data.MistikAttackArtisi=0;
		data.AxeAttackArtisi=0;
		data.BowAttackArtisi=0;
		data.WandAttackArtisi=0;
		data.SwordAttackArtisi=0;
		data.MaceAttackArtisi=0;
		data.AxeCritChanceArtisi=0;
		data.BowCritChanceArtisi=0;
		data.WandCritChanceArtisi=0;
		data.SwordCritChanceArtisi=0;
		data.MaceCritChanceArtisi=0;
		data.AxeCritDamageArtisi=0;
		data.BowCritDamageArtisi=0;
		data.WandCritDamageArtisi=0;
		data.SwordCritDamageArtisi=0;
		data.MaceCritDamageArtisi=0;
		data.AxeATKSpeedArtisi=0;
		data.BowATKSpeedArtisi=0;
		data.WandATKSpeedArtisi=0;
		data.SwordATKSpeedArtisi=0;
		data.MaceATKSpeedArtisi=0;
		data.CastleHpArtisi=0;
		data.AlevHasariArtisi=0;
		data.PoisonHasariArtisi=0;
		data.StunOlanDusmanlarSaldiriArtisi=0;
		data.SavasBasindaFreeCoin=0;
		if(equipped==null)return;
		foreach(var gear in equipped.Values) {
		if(gear==null)continue;
		gear.CalculateBonuses();
		data.AllDamageArtisiFlat=checked(data.AllDamageArtisiFlat+gear.GetAttack(0));
		data.CommonAttackArtisi=checked(data.CommonAttackArtisi+gear.CommonAttackArtisi);
		data.RareAttackArtisi=checked(data.RareAttackArtisi+gear.RareAttackArtisi);
		data.EpicAttackArtisi=checked(data.EpicAttackArtisi+gear.EpicAttackArtisi);
		data.LegendAttackArtisi=checked(data.LegendAttackArtisi+gear.LegendAttackArtisi);
		data.MistikAttackArtisi=checked(data.MistikAttackArtisi+gear.MistikAttackArtisi);
		data.AxeAttackArtisi=checked(data.AxeAttackArtisi+gear.AxeAttackArtisi);
		data.BowAttackArtisi=checked(data.BowAttackArtisi+gear.BowAttackArtisi);
		data.WandAttackArtisi=checked(data.WandAttackArtisi+gear.WandAttackArtisi);
		data.SwordAttackArtisi=checked(data.SwordAttackArtisi+gear.SwordAttackArtisi);
		data.MaceAttackArtisi=checked(data.MaceAttackArtisi+gear.MaceAttackArtisi);
		data.AxeCritChanceArtisi=checked(data.AxeCritChanceArtisi+gear.AxeCritChanceArtisi);
		data.BowCritChanceArtisi=checked(data.BowCritChanceArtisi+gear.BowCritChanceArtisi);
		data.WandCritChanceArtisi=checked(data.WandCritChanceArtisi+gear.WandCritChanceArtisi);
		data.SwordCritChanceArtisi=checked(data.SwordCritChanceArtisi+gear.SwordCritChanceArtisi);
		data.MaceCritChanceArtisi=checked(data.MaceCritChanceArtisi+gear.MaceCritChanceArtisi);
		data.AxeCritDamageArtisi=checked(data.AxeCritDamageArtisi+gear.AxeCritDamageArtisi);
		data.BowCritDamageArtisi=checked(data.BowCritDamageArtisi+gear.BowCritDamageArtisi);
		data.WandCritDamageArtisi=checked(data.WandCritDamageArtisi+gear.WandCritDamageArtisi);
		data.SwordCritDamageArtisi=checked(data.SwordCritDamageArtisi+gear.SwordCritDamageArtisi);
		data.MaceCritDamageArtisi=checked(data.MaceCritDamageArtisi+gear.MaceCritDamageArtisi);
		data.AxeATKSpeedArtisi=checked(data.AxeATKSpeedArtisi+gear.AxeATKSpeedArtisi);
		data.BowATKSpeedArtisi=checked(data.BowATKSpeedArtisi+gear.BowATKSpeedArtisi);
		data.WandATKSpeedArtisi=checked(data.WandATKSpeedArtisi+gear.WandATKSpeedArtisi);
		data.SwordATKSpeedArtisi=checked(data.SwordATKSpeedArtisi+gear.SwordATKSpeedArtisi);
		data.MaceATKSpeedArtisi=checked(data.MaceATKSpeedArtisi+gear.MaceATKSpeedArtisi);
		data.CastleHpArtisi=checked(data.CastleHpArtisi+gear.CastleHpArtisi);
		data.AlevHasariArtisi=checked(data.AlevHasariArtisi+gear.AlevHasariArtisi);
		data.PoisonHasariArtisi=checked(data.PoisonHasariArtisi+gear.PoisonHasariArtisi);
		data.StunOlanDusmanlarSaldiriArtisi=checked(data.StunOlanDusmanlarSaldiriArtisi+gear.StunOlanDusmanlarSaldiriArtisi);
		data.SavasBasindaFreeCoin=checked(data.SavasBasindaFreeCoin+gear.SavasBasindaFreeCoin);
		}
	}

	public void GenerateRewards(int sayi)
	{
		if(pendingRewards==null)pendingRewards=new List<GearInstance>();
		OfflineEquipmentRecovery.Generate(this,pendingRewards,sayi,GearRarity.Common,false);
	}

	public void GuideicinUret(int sayi)
	{
	}

	public void ClaimEquipments(int multiplier)
	{
		OfflineEquipmentRecovery.Claim(this,pendingRewards,multiplier,true);
	}

	public void GenerateOfflineRewards(int sayi)
	{
		if(OfflinependingRewards==null)OfflinependingRewards=new List<GearInstance>();
		OfflineEquipmentRecovery.Generate(this,OfflinependingRewards,sayi,GearRarity.Common,false);
	}

	public void ClaimOfflineEquipments(int multiplier)
	{
		OfflineEquipmentRecovery.Claim(this,OfflinependingRewards,multiplier,true);
	}

	public void GenerateidleRewards(int sayi)
	{
		if(OfidleRewards==null)OfidleRewards=new List<GearInstance>();
		OfflineEquipmentRecovery.Generate(this,OfidleRewards,sayi,GearRarity.Common,false);
	}

	public void ClaimidleEquipments(int multiplier)
	{
		OfflineEquipmentRecovery.Claim(this,OfidleRewards,multiplier,true);
	}

	public void GenerateEventRewards(int sayi, int rarity)
	{
		if(eventRewards==null)eventRewards=new List<GearInstance>();
		OfflineEquipmentRecovery.Generate(this,eventRewards,sayi,(GearRarity)rarity,true);
	}

	public void ClaimEventEquipments()
	{
		OfflineEquipmentRecovery.Claim(this,eventRewards,1,false);
	}

	private void OnApplicationPause(bool pause)
	{
		if (pause) SaveGears();
	}
}
