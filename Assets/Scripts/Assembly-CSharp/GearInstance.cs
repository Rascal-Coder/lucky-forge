using System;

[Serializable]
public class GearInstance
{
	public int gearName;

	public GearTemplate template;

	public GearRarity rarity;

	public int level;

	public int GearRarityBonus;

	public int GearMergeCount;

	public bool canmerge;

	public int CommonAttackArtisi;

	public int RareAttackArtisi;

	public int EpicAttackArtisi;

	public int LegendAttackArtisi;

	public int MistikAttackArtisi;

	public int AxeAttackArtisi;

	public int BowAttackArtisi;

	public int WandAttackArtisi;

	public int SwordAttackArtisi;

	public int MaceAttackArtisi;

	public int AxeCritChanceArtisi;

	public int BowCritChanceArtisi;

	public int WandCritChanceArtisi;

	public int SwordCritChanceArtisi;

	public int MaceCritChanceArtisi;

	public int AxeCritDamageArtisi;

	public int BowCritDamageArtisi;

	public int WandCritDamageArtisi;

	public int SwordCritDamageArtisi;

	public int MaceCritDamageArtisi;

	public int AxeATKSpeedArtisi;

	public int BowATKSpeedArtisi;

	public int WandATKSpeedArtisi;

	public int SwordATKSpeedArtisi;

	public int MaceATKSpeedArtisi;

	public int CastleHpArtisi;

	public int AlevHasariArtisi;

	public int PoisonHasariArtisi;

	public int StunOlanDusmanlarSaldiriArtisi;

	public int SavasBasindaFreeCoin;

	public int GearScore()
	{
		return unchecked(unchecked((int)rarity+1)*unchecked(level+(int)GetAttack(0))+unchecked((int)rarity+1));
	}

	public long GetAttack(int upgvarsa = 0)
	{
		// Native RVA0x1f65900: signed 64-bit multiplication, integer division by100, and int32 level arithmetic.
		int effectiveLevel=unchecked(level+upgvarsa);
		long scaled=unchecked(template.baseAttackRaritys[(int)rarity]*(long)unchecked(GearMergeCount+1)*(long)unchecked(100+effectiveLevel*10));
		return unchecked(scaled/100L+(long)unchecked(effectiveLevel*3));
	}

	public double UpgradeCoin()
	{
		return (double)unchecked(unchecked(level*unchecked((int)rarity+1))*100+20);
	}

	public GearSlot GetSlot()
	{
		// Offline recovery; native RVA 0x1f659ac.
		return template.slot;
	}

	public new GearType GetType()
	{
		// Offline recovery; native RVA 0x1f659c4.
		return template.type;
	}

	public void CalculateBonuses()
	{
		// Native RVA0x1f659dc, all30 string branches verified against field offsets.
		CommonAttackArtisi=0;
		RareAttackArtisi=0;
		EpicAttackArtisi=0;
		LegendAttackArtisi=0;
		MistikAttackArtisi=0;
		AxeAttackArtisi=0;
		BowAttackArtisi=0;
		WandAttackArtisi=0;
		SwordAttackArtisi=0;
		MaceAttackArtisi=0;
		AxeCritChanceArtisi=0;
		BowCritChanceArtisi=0;
		WandCritChanceArtisi=0;
		SwordCritChanceArtisi=0;
		MaceCritChanceArtisi=0;
		AxeCritDamageArtisi=0;
		BowCritDamageArtisi=0;
		WandCritDamageArtisi=0;
		SwordCritDamageArtisi=0;
		MaceCritDamageArtisi=0;
		AxeATKSpeedArtisi=0;
		BowATKSpeedArtisi=0;
		WandATKSpeedArtisi=0;
		SwordATKSpeedArtisi=0;
		MaceATKSpeedArtisi=0;
		CastleHpArtisi=0;
		AlevHasariArtisi=0;
		PoisonHasariArtisi=0;
		StunOlanDusmanlarSaldiriArtisi=0;
		SavasBasindaFreeCoin=0;
		if(!template||template.perks==null)return;
		for(int i=0;i<template.perks.Count && i<=(int)rarity;i++) {
		var perk=template.perks[i]; if(perk==null)continue;
		switch(perk.stat) {
		case "MistikAttackArtisi": MistikAttackArtisi=unchecked(MistikAttackArtisi+(int)perk.value);break;
		case "MaceCritChanceArtisi": MaceCritChanceArtisi=unchecked(MaceCritChanceArtisi+(int)perk.value);break;
		case "WandATKSpeedArtisi": WandATKSpeedArtisi=unchecked(WandATKSpeedArtisi+(int)perk.value);break;
		case "AxeAttackArtisi": AxeAttackArtisi=unchecked(AxeAttackArtisi+(int)perk.value);break;
		case "SwordCritDamageArtisi": SwordCritDamageArtisi=unchecked(SwordCritDamageArtisi+(int)perk.value);break;
		case "BowAttackArtisi": BowAttackArtisi=unchecked(BowAttackArtisi+(int)perk.value);break;
		case "StunOlanDusmanlarSaldiriArtisi": StunOlanDusmanlarSaldiriArtisi=unchecked(StunOlanDusmanlarSaldiriArtisi+(int)perk.value);break;
		case "MaceCritDamageArtisi": MaceCritDamageArtisi=unchecked(MaceCritDamageArtisi+(int)perk.value);break;
		case "SwordAttackArtisi": SwordAttackArtisi=unchecked(SwordAttackArtisi+(int)perk.value);break;
		case "BowATKSpeedArtisi": BowATKSpeedArtisi=unchecked(BowATKSpeedArtisi+(int)perk.value);break;
		case "AxeATKSpeedArtisi": AxeATKSpeedArtisi=unchecked(AxeATKSpeedArtisi+(int)perk.value);break;
		case "MaceATKSpeedArtisi": MaceATKSpeedArtisi=unchecked(MaceATKSpeedArtisi+(int)perk.value);break;
		case "BowCritDamageArtisi": BowCritDamageArtisi=unchecked(BowCritDamageArtisi+(int)perk.value);break;
		case "AlevHasariArtisi": AlevHasariArtisi=unchecked(AlevHasariArtisi+(int)perk.value);break;
		case "SwordATKSpeedArtisi": SwordATKSpeedArtisi=unchecked(SwordATKSpeedArtisi+(int)perk.value);break;
		case "WandAttackArtisi": WandAttackArtisi=unchecked(WandAttackArtisi+(int)perk.value);break;
		case "AxeCritDamageArtisi": AxeCritDamageArtisi=unchecked(AxeCritDamageArtisi+(int)perk.value);break;
		case "CastleHpArtisi": CastleHpArtisi=unchecked(CastleHpArtisi+(int)perk.value);break;
		case "EpicAttackArtisi": EpicAttackArtisi=unchecked(EpicAttackArtisi+(int)perk.value);break;
		case "CommonAttackArtisi": CommonAttackArtisi=unchecked(CommonAttackArtisi+(int)perk.value);break;
		case "PoisonHasariArtisi": PoisonHasariArtisi=unchecked(PoisonHasariArtisi+(int)perk.value);break;
		case "SavasBasindaFreeCoin": SavasBasindaFreeCoin=unchecked(SavasBasindaFreeCoin+(int)perk.value);break;
		case "WandCritChanceArtisi": WandCritChanceArtisi=unchecked(WandCritChanceArtisi+(int)perk.value);break;
		case "AxeCritChanceArtisi": AxeCritChanceArtisi=unchecked(AxeCritChanceArtisi+(int)perk.value);break;
		case "SwordCritChanceArtisi": SwordCritChanceArtisi=unchecked(SwordCritChanceArtisi+(int)perk.value);break;
		case "RareAttackArtisi": RareAttackArtisi=unchecked(RareAttackArtisi+(int)perk.value);break;
		case "LegendAttackArtisi": LegendAttackArtisi=unchecked(LegendAttackArtisi+(int)perk.value);break;
		case "MaceAttackArtisi": MaceAttackArtisi=unchecked(MaceAttackArtisi+(int)perk.value);break;
		case "WandCritDamageArtisi": WandCritDamageArtisi=unchecked(WandCritDamageArtisi+(int)perk.value);break;
		case "BowCritChanceArtisi": BowCritChanceArtisi=unchecked(BowCritChanceArtisi+(int)perk.value);break;
		}
		}
	}
}
