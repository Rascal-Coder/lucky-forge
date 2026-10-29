using System.Collections.Generic;
using UnityEngine;

public class CommanderSpawner : MonoBehaviour
{
	private Dictionary<(WeaponType, WeaponRarity), string> standardTags;

	private Dictionary<int, string> mysticTags;

	public PoolObject PoolManager;

	public List<InventorySlot> inventorySlots;

	public List<Commander> activeCommanders;

	public MysticFavorites favorites;

	public int currentCommanderCount;

	public int maxCommanderCount = 20;

	public HeroController heroController;

	private void Awake()
	{
		// Offline recovery candidate; native RVA 0x21e2f78.
		InitializePoolTags();
	}

	public void ClearInventorys()
	{
		// Offline recovery candidate; native RVA 0x21e3888.
		foreach (InventorySlot slot in inventorySlots) slot.ClearArea();
		currentCommanderCount = 0;
		activeCommanders.Clear();
	}

	private void InitializePoolTags()
	{
		// Offline recovery candidate; native RVA 0x21e2f7c.
		standardTags = new Dictionary<(WeaponType, WeaponRarity), string>
		{
		 { ((WeaponType)3, (WeaponRarity)0), "SwordCommon" },
		 { ((WeaponType)3, (WeaponRarity)1), "SwordRare" },
		 { ((WeaponType)3, (WeaponRarity)2), "SwordEpic" },
		 { ((WeaponType)3, (WeaponRarity)3), "SwordLegendary" },
		 { ((WeaponType)0, (WeaponRarity)0), "AxeCommon" },
		 { ((WeaponType)0, (WeaponRarity)1), "AxeRare" },
		 { ((WeaponType)0, (WeaponRarity)2), "AxeEpic" },
		 { ((WeaponType)0, (WeaponRarity)3), "AxeLegendary" },
		 { ((WeaponType)2, (WeaponRarity)0), "WandCommon" },
		 { ((WeaponType)2, (WeaponRarity)1), "WandRare" },
		 { ((WeaponType)2, (WeaponRarity)2), "WandEpic" },
		 { ((WeaponType)2, (WeaponRarity)3), "WandLegendary" },
		 { ((WeaponType)1, (WeaponRarity)0), "BowCommon" },
		 { ((WeaponType)1, (WeaponRarity)1), "BowRare" },
		 { ((WeaponType)1, (WeaponRarity)2), "BowEpic" },
		 { ((WeaponType)1, (WeaponRarity)3), "BowLegendary" },
		 { ((WeaponType)4, (WeaponRarity)0), "MaceCommon" },
		 { ((WeaponType)4, (WeaponRarity)1), "MaceRare" },
		 { ((WeaponType)4, (WeaponRarity)2), "MaceEpic" },
		 { ((WeaponType)4, (WeaponRarity)3), "MaceLegendary" },
		};
		mysticTags = new Dictionary<int,string>
		{
		 { 0, "Mystic_0" },
		 { 1, "Mystic_1" },
		 { 2, "Mystic_2" },
		 { 3, "Mystic_3" },
		 { 4, "Mystic_4" },
		 { 5, "Mystic_5" },
		 { 6, "Mystic_6" },
		 { 7, "Mystic_7" },
		 { 8, "Mystic_8" },
		 { 9, "Mystic_9" },
		 { 10, "Mystic_10" },
		 { 11, "Mystic_11" },
		 { 12, "Mystic_12" },
		 { 13, "Mystic_13" },
		 { 14, "Mystic_14" },
		 { 15, "Mystic_15" },
		 { 16, "Mystic_16" },
		 { 17, "Mystic_17" },
		};
	}

	public void ReturnCommanderToPool(Commander commander)
	{
		// Offline recovery candidate; native RVA 0x21e39fc.
		string tag = GetPoolTag(commander);
		if (!string.IsNullOrEmpty(tag)) PoolManager.ReturnToPool(tag,commander.gameObject);
		currentCommanderCount = Mathf.Max(0,unchecked(currentCommanderCount - 1));
		heroController.warController.UpdateInventoryCount();
		activeCommanders.Remove(commander);
	}

	public bool IsFull()
	{
		// Offline recovery candidate; native RVA 0x21e3bb4.
		if (currentCommanderCount >= maxCommanderCount) return true;
		foreach (InventorySlot slot in inventorySlots) if (slot.IsEmpty()) return false;
		return true;
	}

	public Commander MergeCommander(WeaponType type, WeaponRarity rarity, Vector3 position, Quaternion rotation, int mysticID = -1)
	{
		// Offline recovery candidate; native RVA 0x21e3d0c.
		string tag = GetPoolTag(type,rarity,mysticID);
		if (string.IsNullOrEmpty(tag)) return null;
		return PoolManager.SpawnFromPool(tag,position,rotation,false,false).GetComponent<Commander>();
	}

	public void TryAddToInventory(int typeIndex, int rarityIndex, Vector3 startPos, int mysticID = -1)
	{
		// Offline recovery candidate; native RVA 0x21e3f1c.
		string tag = GetPoolTag((WeaponType)typeIndex,(WeaponRarity)rarityIndex,mysticID);
		if (string.IsNullOrEmpty(tag)) return;
		Commander commander = PoolManager.SpawnFromPool(tag,transform.position,transform.rotation,false,false).GetComponent<Commander>();
		currentCommanderCount = unchecked(currentCommanderCount + 1);
		heroController.warController.UpdateInventoryCount();
		if (commander.IsMystic)
		{
		 foreach (InventorySlot slot in inventorySlots)
		 {
		  if (!slot.IsEmpty()) continue;
		  slot.AddCommander(commander);
		  activeCommanders.Add(commander);
		  commander.SendTrail(startPos);
		  favorites.RefreshPanel();
		  heroController.MainHeroSkillActivate(0,1);
		  if (heroController.MainHeroNum == 0)
		   foreach (Commander active in activeCommanders) active.DataGuncelle();
		  heroController.warController.CharAnim.Play("Base Layer.CharMistikKoyuldu",0,0f);
		  return;
		 }
		 ReturnCommanderToPool(commander);
		 return;
		}
		foreach (InventorySlot slot in inventorySlots)
		{
		 if (!slot.IsCompatible(commander) || slot.IsFull()) continue;
		 slot.AddCommander(commander);
		 activeCommanders.Add(commander);
		 commander.SendTrail(startPos);
		 favorites.RefreshPanel();
		 return;
		}
		foreach (InventorySlot slot in inventorySlots)
		{
		 if (!slot.IsEmpty()) continue;
		 slot.AddCommander(commander);
		 activeCommanders.Add(commander);
		 commander.SendTrail(startPos);
		 favorites.RefreshPanel();
		 return;
		}
		ReturnCommanderToPool(commander);
	}

	private string GetPoolTag(Commander commander)
	{
		// Offline recovery candidate; native RVA 0x21e3acc.
		string tag;
		if ((int)commander.Rarity == 4) return mysticTags.TryGetValue(commander.MysticID,out tag) ? tag : null;
		return standardTags.TryGetValue((commander.Type,commander.Rarity),out tag) ? tag : null;
	}

	private string GetPoolTag(WeaponType type, WeaponRarity rarity, int mysticID = -1)
	{
		// Offline recovery candidate; native RVA 0x21e3e28.
		string tag;
		if ((int)rarity == 4) return mysticTags.TryGetValue(mysticID,out tag) ? tag : null;
		return standardTags.TryGetValue((type,rarity),out tag) ? tag : null;
	}

	public int GetCurrentCommanderCount()
	{
		// Offline recovery candidate; native RVA 0x21e4788.
		return currentCommanderCount;
	}

	public int GetCurrentMysticCommanderCount()
	{
		// Offline recovery candidate; native RVA 0x21e4790.
		int count = 0;
		foreach (Commander commander in activeCommanders) if ((int)commander.Rarity == 4) count++;
		return count;
	}

	// Offline adapter only: call explicitly after inspecting startup dictionaries.
	// Original Awake tail-calls InitializePoolTags; normally this adapter is unnecessary.
	public void OfflineRecoveryInitialize()
	{
		if (standardTags == null || mysticTags == null) InitializePoolTags();
	}
}
