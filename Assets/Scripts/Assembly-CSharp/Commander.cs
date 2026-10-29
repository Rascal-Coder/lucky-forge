using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Commander : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CLateOpen_003Ed__87 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Commander _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CLateOpen_003Ed__87(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CLateShoot_003Ed__98 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Commander _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CLateShoot_003Ed__98(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	public Enemy target;

	public SpriteRenderer icon;

	public Animator anim;

	public string animPlayName;

	public WarController warController;

	public CommanderSkills commanderSkills;

	public HeroController heroController;

	public Transform Char;

	public Transform projectilePivot;

	public string ProjectileName;

	[HideInInspector]
	public bool AtilanIcindenGecsin;

	[HideInInspector]
	public float Range = 50f;

	private Vector3 attackpos = new Vector3(0f,0f,-41f);

	[HideInInspector]
	public float attacksecond;

	public ParticleSystem[] upgEffs;

	public Transform commanderHierarcy;

	public Commander sourceCommander;

	public bool Clone;

	[HideInInspector]
	public InventorySlot invSlot;

	public ParticleSystem spawnColorParticle;

	public int NextAttackType;

	public float NextAttackEffectPower;

	public float NextAttackEffectSecond;

	[Header("BASLANGIC")]
	public long StartATK;

	public float StartAtkSpeed = 1f;

	public WeaponType Type;

	public WeaponRarity Rarity;

	[Header("Skin INFOS")]
	public string HeroName;

	public int HeroNum;

	public float Atk_artiskacolacak;

	public long Atk_artisiDirectLong = 10L;

	[HideInInspector]
	public float CritDamage_PerksTotal;

	[HideInInspector]
	public float AttackSpeed_PerksTotal;

	[HideInInspector]
	public float CriticalChance_PerksTotal;

	[HideInInspector]
	public float ATK_PerksTotal;

	public int StartLevel = 1;

	public int Level;

	public int LevelExp;

	public int MaxLevel = 30;

	public int BaslangicExp;

	private int[] LevelMaxList = new int[] {2,5,10,30,50,70,100,140,180,220,260,320,360,400,450,500,550,600,650,700,750,800,850,900,950,1000,1100,1200,1300,1400,1500,1600};

	public List<Perk> perks = new List<Perk>();

	[Header("EldeEt")]
	public int CrystalPrice;

	public bool StarterPackile;

	public bool DailyWarile;

	public bool inappile;

	private bool simdieklendi;

	[Header("guncelVeriler")]
	public long attack;

	public float attackspeed;

	public float critchance;

	public double critmultipler;

	[Header("TrailMove")]
	private float moveDuration = 0.699999988079071f;

	private float arcHeight = 5f;

	private float sideArcRange = 8f;

	private Vector3 startPos;

	private Vector3 endPos;

	private Vector3 sideOffset;

	private float moveTimer;

	private bool isMoving;

	public TrailRenderer trail;

	[Header("MYSTIC")]
	public List<Commander> RequiredCommander = new List<Commander>();

	public int MysticID;

	public bool MyFavorite;

	public bool IsMystic => (int)Rarity == 4; // Native get_IsMystic RVA0x21de584.

	public string typetxt()
	{
		// Offline recovery candidate; native RVA 0x21dcbec.
		switch ((int)Type) {
		case 0: return Lang.Get.typeAxe;
		case 1: return Lang.Get.typeBow;
		case 2: return Lang.Get.typeWand;
		case 3: return Lang.Get.typeSword;
		case 4: return Lang.Get.typeMace;
		case 5: return Lang.Get.typeSpecial;
		default: return Lang.Get.typeUnknown;
		}
	}

	public string raritytxt()
	{
		// Offline recovery candidate; native RVA 0x21dcd68.
		switch ((int)Rarity) {
		case 0: return Lang.Get.common;
		case 1: return Lang.Get.rare;
		case 2: return Lang.Get.epic;
		case 3: return Lang.Get.kalite_legendery;
		case 4: return Lang.Get.mystic;
		default: return "Unknown";
		}
	}

	public double UpgradePrice()
	{
		// Offline recovery candidate; native RVA 0x21dcef8.
		double[] prices;
		switch ((int)Rarity)
		{
		 case 0: prices = heroController.CommonUpgradePrice; break;
		 case 1: prices = heroController.RareUpgradePrice; break;
		 case 3: prices = heroController.LegendUpgradePrice; break;
		 case 4: prices = heroController.MistikUpgradePrice; break;
		 default: prices = heroController.EpicUpgradePrice; break;
		}
		double price = prices[Level];
		return price + price;
	}

	public bool isUpgradeable()
	{
		// Offline recovery candidate; native RVA 0x21dcfa8.
		double price = UpgradePrice();
		return price < Currencys.Coin && Level >= 1 && Level < MaxLevel && LevelExp >= LevelExpMax();
	}

	public long ATK(bool bonussuz = false, int upgradevarsa = 0)
	{
		// Offline recovery candidate; native RVA 0x21dd0b8.
		long flat = unchecked(StartATK + PlayerData.KiyafetData.AllDamageArtisiFlat * ((int)Rarity + 1));
		float growth = Mathf.Max(1f, 1f + Atk_artiskacolacak * unchecked(Level + upgradevarsa));
		long result = (long)(growth * (float)flat + (float)unchecked(Atk_artisiDirectLong * Level));
		result = unchecked(result + EquipmentATKArtislari(result));
		if (!bonussuz) result = unchecked(result + ATKBonusRogueLike(result));
		return result;
	}

	private long EquipmentATKArtislari(long baseATK)
	{
		// Offline recovery candidate; native RVA 0x21dd1c0.
		int rarityPercent = 0;
		switch ((int)Rarity)
		{
		 case 0: rarityPercent = unchecked(PlayerData.KiyafetData.CommonAttackArtisi + PlayerData.collectibles.CommonAttackArtisi + PlayerData.clanPerksDatam.CommonAttack + (int)PlayerData.TalentStats.CommonAttackArtisi); break;
		 case 1: rarityPercent = unchecked(PlayerData.KiyafetData.RareAttackArtisi + PlayerData.collectibles.RareAttackArtisi + PlayerData.clanPerksDatam.RareAttack + (int)PlayerData.TalentStats.RareAttackArtisi); break;
		 case 2: rarityPercent = unchecked(PlayerData.KiyafetData.EpicAttackArtisi + PlayerData.collectibles.EpicAttackArtisi + PlayerData.clanPerksDatam.EpicAttack + (int)PlayerData.TalentStats.EpicAttackArtisi); break;
		 case 3: rarityPercent = unchecked(PlayerData.KiyafetData.LegendAttackArtisi + PlayerData.collectibles.LegendAttackArtisi + PlayerData.clanPerksDatam.LegendAttack + (int)PlayerData.TalentStats.LegendaryAttackArtisi); break;
		 case 4: rarityPercent = unchecked(PlayerData.KiyafetData.MistikAttackArtisi + PlayerData.collectibles.MistikAttackArtisi + PlayerData.clanPerksDatam.MysticAttack + (int)PlayerData.TalentStats.MysticAttackArtisi); break;
		}
		int typePercent = 0;
		switch ((int)Type)
		{
		 case 0: typePercent = unchecked(PlayerData.KiyafetData.AxeAttackArtisi + PlayerData.collectibles.AxeAttackArtisi + PlayerData.clanPerksDatam.AxeAttack + PlayerData.dailyFortune.AxeAttack); break;
		 case 1: typePercent = unchecked(PlayerData.KiyafetData.BowAttackArtisi + PlayerData.collectibles.BowAttackArtisi + PlayerData.clanPerksDatam.ArrowAttack + PlayerData.dailyFortune.ArrowAttack); break;
		 case 2: typePercent = unchecked(PlayerData.KiyafetData.WandAttackArtisi + PlayerData.collectibles.WandAttackArtisi + PlayerData.clanPerksDatam.WandAttack + PlayerData.dailyFortune.WandAttack); break;
		 case 3: typePercent = unchecked(PlayerData.KiyafetData.SwordAttackArtisi + PlayerData.collectibles.SwordAttackArtisi + PlayerData.clanPerksDatam.SwordAttack + PlayerData.dailyFortune.SwordAttack); break;
		 case 4: typePercent = unchecked(PlayerData.KiyafetData.MaceAttackArtisi + PlayerData.collectibles.MaceAttackArtisi + PlayerData.clanPerksDatam.MaceAttack + PlayerData.dailyFortune.MaceAttack); break;
		}
		int total = unchecked(rarityPercent + typePercent + (int)ATK_PerksTotal + PlayerData.collectibles.AllDamageArtisiFlat + (int)PlayerData.TalentStats.Attack + (int)PlayerData.clanPerksDatam.TotalDamage);
		return (long)((float)unchecked((long)total * baseATK) / 100f);
	}

	private float EquipmentCritChanceArtislari()
	{
		// Offline recovery candidate; native RVA 0x21dd834.
		switch ((int)Type)
		{
		 case 0: return (float)unchecked(PlayerData.KiyafetData.AxeCritChanceArtisi + PlayerData.collectibles.AxeCritChanceArtisi);
		 case 1: return (float)unchecked(PlayerData.KiyafetData.BowCritChanceArtisi + PlayerData.collectibles.BowCritChanceArtisi);
		 case 2: return (float)unchecked(PlayerData.KiyafetData.WandCritChanceArtisi + PlayerData.collectibles.WandCritChanceArtisi);
		 case 3: return (float)unchecked(PlayerData.KiyafetData.SwordCritChanceArtisi + PlayerData.collectibles.SwordCritChanceArtisi);
		 case 4: return (float)unchecked(PlayerData.KiyafetData.MaceCritChanceArtisi + PlayerData.collectibles.MaceCritChanceArtisi);
		 default: return 0f;
		}
	}

	private float EquipmentCritDamageArtislari()
	{
		// Offline recovery candidate; native RVA 0x21dda1c.
		switch ((int)Type)
		{
		 case 0: return (float)unchecked(PlayerData.KiyafetData.AxeCritDamageArtisi + PlayerData.collectibles.AxeCritDamageArtisi);
		 case 1: return (float)unchecked(PlayerData.KiyafetData.BowCritDamageArtisi + PlayerData.collectibles.BowCritDamageArtisi);
		 case 2: return (float)unchecked(PlayerData.KiyafetData.WandCritDamageArtisi + PlayerData.collectibles.WandCritDamageArtisi);
		 case 3: return (float)unchecked(PlayerData.KiyafetData.SwordCritDamageArtisi + PlayerData.collectibles.SwordCritDamageArtisi);
		 case 4: return (float)unchecked(PlayerData.KiyafetData.MaceCritDamageArtisi + PlayerData.collectibles.MaceCritDamageArtisi);
		 default: return 0f;
		}
	}

	private float EquipmentSpeedArtislari()
	{
		// Offline recovery candidate; native RVA 0x21ddc04.
		switch ((int)Type)
		{
		 case 0: return (float)unchecked(PlayerData.KiyafetData.AxeATKSpeedArtisi);
		 case 1: return (float)unchecked(PlayerData.KiyafetData.BowATKSpeedArtisi);
		 case 2: return (float)unchecked(PlayerData.KiyafetData.WandATKSpeedArtisi);
		 case 3: return (float)unchecked(PlayerData.KiyafetData.SwordATKSpeedArtisi);
		 case 4: return (float)unchecked(PlayerData.KiyafetData.MaceATKSpeedArtisi);
		 default: return 0f;
		}
	}

	public long ATKBonusRogueLike(long atk)
	{
		// Offline recovery candidate; native RVA 0x21dd77c.
		return (long)(((float)atk / 100f) * (GetRarityATKBonus(Rarity) + PlayerData.mainHeroBonus.HerMistikYuzdeBonusu));
	}

	private float GetRarityATKBonus(WeaponRarity rarity)
	{
		// Offline recovery candidate; native RVA 0x21ddd9c.
		var s = PlayerData.SkillsStats;
		switch ((int)rarity)
		{
		 case 0: return s.commonWeaponATK1+s.commonWeaponATK2+s.commonWeaponATK3+s.commonWeaponATK4+s.RareveCommonWeaponATK1+s.RareveCommonWeaponATK2;
		 case 1: return s.rareWeaponATK1+s.rareWeaponATK2+s.rareWeaponATK3+s.rareWeaponATK4+s.RareveCommonWeaponATK1+s.RareveCommonWeaponATK2;
		 case 2: return s.epicWeaponATK1+s.epicWeaponATK2+s.epicWeaponATK3+s.epicWeaponATK4;
		 case 3: return s.legendaryWeaponATK1+s.legendaryWeaponATK2+s.legendaryWeaponATK3+s.legendaryWeaponATK4+s.legendaryveMistiksWeaponATK1+s.legendaryveMistiksWeaponATK2;
		 case 4: return s.legendaryveMistiksWeaponATK1+s.legendaryveMistiksWeaponATK2+s.mistikWeaponATK1+s.mistikWeaponATK2+s.mistikWeaponATK3+s.mistikWeaponATK4;
		 default: return 0f;
		}
	}

	public float AtkSpeed()
	{
		// Offline recovery candidate; native RVA 0x21ddf48.
		return StartAtkSpeed + StartAtkSpeed * (AttackSpeed_PerksTotal + EquipmentSpeedArtislari() + PlayerData.TalentStats.AttackSpeed) / 100f;
	}

	public float CritChance()
	{
		// Offline recovery candidate; native RVA 0x21ddfe8.
		return PlayerData.TalentStats.CriticalChance + EquipmentCritChanceArtislari() + CriticalChance_PerksTotal;
	}

	public float CritMultipler()
	{
		// Offline recovery candidate; native RVA 0x21de06c.
		return CritDamage_PerksTotal + (EquipmentCritDamageArtislari() + (float)unchecked((int)Rarity * 10));
	}

	public int LevelExpMax()
	{
		// Offline recovery candidate; native RVA 0x21dd084.
		return LevelMaxList[Level];
	}

	public void AddKartExp(int kart = 1)
	{
		// Offline recovery candidate; native RVA 0x21de0a4.
		LevelExp = unchecked(LevelExp + kart);
		ES3.Save<int>("CommanderHeroExpZ" + HeroNum.ToString(),LevelExp);
	}

	public void LevelArttir()
	{
		// Offline recovery candidate; native RVA 0x21de138.
		if (LevelExp < LevelExpMax()) return;
		int cost = LevelExpMax();
		Level = unchecked(Level + 1);
		LevelExp = unchecked(LevelExp - cost);
		ES3.Save<int>("CommanderHeroLvZ" + HeroNum.ToString(),Level);
		commanderSkills.CheckAllSkillUnlocks();
		if (Level >= MaxLevel) { Level = MaxLevel; LevelExp = 0; }
		ES3.Save<int>("CommanderHeroExpZ" + HeroNum.ToString(),LevelExp);
	}

	public void MistikLevelUp()
	{
		// Offline recovery candidate; native RVA 0x21de260.
		Level = unchecked(Level + 1);
		ES3.Save<int>("CommanderHeroLvZ" + HeroNum.ToString(),Level);
		commanderSkills.CheckAllSkillUnlocks();
	}

	public void SatinAlindiInapp()
	{
	}

	public void AlindiDailyGift()
	{
		// Offline recovery candidate; native RVA 0x21de3a4.
		Level = 1;
		ES3.Save<int>("CommanderHeroLvZ" + HeroNum.ToString(), Level);
		commanderSkills.CheckAllSkillUnlocks();
	}

	public void Resetit()
	{
	}

	public void Maxit()
	{
	}

	private IEnumerator LateOpen()
	{
		// Offline recovery candidate; native RVA 0x21df9d0.
		Char.gameObject.SetActive(false);
		yield return new WaitForSeconds(0.699999988079071f);
		Char.gameObject.SetActive(true);
	}

	public void SendTrail(Vector3 poz)
	{
		// Offline recovery candidate; native RVA 0x21de608.
		startPos = poz;
		endPos = transform.position;
		moveTimer = 0f;
		isMoving = true;
		Color32 packed = warController.heroController.rarityColors[(int)Rarity];
		trail.startColor = warController.heroController.rarityColors[(int)Rarity];
		trail.endColor = new Color(packed.r/255f,packed.g/255f,packed.b/255f,0.7843137383460999f);
		trail.transform.position = startPos;
		trail.emitting = true;
		UnityEngine.Random.Range(-sideArcRange,sideArcRange);
		UnityEngine.Random.Range(-sideArcRange,sideArcRange);
		sideOffset = new Vector3(10f,5f,8f);
		trail.Clear();
	}

	private void OnEnable()
	{
		// Offline recovery candidate; native RVA 0x21de7a4.
		Clone = true;
		target = null;
		if (sourceCommander == null) sourceCommander = commanderHierarcy.GetChild(HeroNum).GetComponent<Commander>();
		Level = sourceCommander.Level;
		StartCoroutine(LateOpen());
		DataGuncelle();
		icon.material.SetFloat("_FlashAmount",0f);
		simdieklendi = true;
		Range = PlayerData.PlayerStats.AttackRange(0);
		foreach (var effect in upgEffs)
		{
		 var main = effect.main;
		 main.startColor = warController.heroController.rarityColors[(int)Rarity];
		}
		var spawnMain = spawnColorParticle.main;
		spawnMain.startColor = warController.heroController.rarityColors[(int)Rarity];
	}

	public void UpgradedSkillSelect()
	{
		// Offline recovery candidate; native RVA 0x21deaec.
		upgEffs[0].Play();
	}

	public void DataGuncelle()
	{
		// Offline recovery candidate; native RVA 0x21dea60.
		attack = sourceCommander.ATK(false,0);
		attackspeed = sourceCommander.AtkSpeed();
		critchance = sourceCommander.CritChance();
		critmultipler = (double)sourceCommander.CritMultipler();
	}

	private void OnDisable()
	{
		// Offline recovery candidate; native RVA 0x21deb1c.
		simdieklendi = false;
	}

	private void TrailMoving()
	{
		// Offline recovery candidate; native RVA 0x21deb24.
		if (!isMoving) return;
		moveTimer += Time.deltaTime * 1.3700000047683716f;
		float progress = Mathf.Clamp01(moveTimer / moveDuration);
		float sine = Mathf.Sin(progress * 3.1415927410125732f);
		trail.transform.position = Vector3.Lerp(startPos,endPos,progress) + Vector3.up * (sine * arcHeight) + sideOffset * sine;
		if (progress >= 1f) { isMoving = false; trail.emitting = false; }
	}

	private void Update()
	{
		// Offline recovery candidate; native RVA 0x21deca0.
		TrailMoving();
		if (WarController.StopGame) return;
		if (target == null || target.unitData.health <= 0) FindClosestEnemy();
		if (target == null) return;
		if (Mathf.Abs(-41f - target.transform.position.z) > Range) { FindClosestEnemy(); return; }
		attacksecond += Time.deltaTime;
		if (attacksecond >= 1f / attackspeed)
		{
		 anim.speed = attackspeed;
		 anim.Play("Base Layer." + animPlayName,0,0f);
		 attacksecond = 0f;
		}
	}

	private void FindClosestEnemy()
	{
		// Offline recovery candidate; native RVA 0x21dee80.
		target = warController.GetCachedClosestEnemy(attackpos,Range);
	}

	public void Attack()
	{
		// Offline recovery candidate; native RVA 0x21deeb8.
		ShootArrow(target);
		commanderSkills.tryAttack();
	}

	public void LateShootForSkill()
	{
		// Offline recovery candidate; native RVA 0x21df138.
		StartCoroutine(LateShoot());
	}

	private IEnumerator LateShoot()
	{
		// Offline recovery candidate; native RVA 0x21dfb34.
		yield return new WaitForSeconds(0.15000000596046448f);
		ShootArrow(target);
	}

	private void ShootArrow(Enemy target)
	{
		// Offline recovery candidate; native RVA 0x21deee0.
		if (target == null) return;
		Projectile p = warController.objectPool.SpawnProjectile(ProjectileName,projectilePivot.transform.position,projectilePivot.transform.rotation);
		p.targetPosition = target.transform;
		p.attackDamage = attack;
		p.critChance = critchance;
		p.critMultipler = critmultipler;
		p.transform.position = projectilePivot.transform.position;
		p.UpdateRotation();
		p.Launch(target.transform);
		p.anaKaraterVurdu = true;
		p.icindenGecForSkill = AtilanIcindenGecsin;
		p.gameObject.SetActive(true);
		AtilanIcindenGecsin = false;
		p.effectType = NextAttackType;
		p.effectPower = NextAttackEffectPower;
		p.effectSecond = NextAttackEffectSecond;
		p.atanCommanderNum = HeroNum;
		if ((int)Rarity == 2) warController.heroController.MainHeroSkillActivate(1,1);
		warController.ThrowSesVer();
	}

	public void LoadData()
	{
		// Offline recovery candidate; native RVA 0x21df1cc.
		Level = ES3.Load<int>("CommanderHeroLvZ" + HeroNum.ToString(),StartLevel);
		LevelExp = ES3.Load<int>("CommanderHeroExpZ" + HeroNum.ToString(),BaslangicExp);
		MyFavorite = ES3.Load<bool>("CommanderHeroFavorite" + HeroNum.ToString(),false);
		commanderSkills = GetComponent<CommanderSkills>();
		HeroName = Lang.GetIWeaponNames(HeroNum);
		Atk_artiskacolacak = heroController.AtkArtislari[(int)Rarity];
		if ((int)Rarity == 4)
		{
		 long sum = 0;
		 for (int i=0; i<RequiredCommander.Count; i++) sum = unchecked(sum + RequiredCommander[i].StartATK * 2);
		 StartATK = unchecked(sum + 1000);
		}
		commanderSkills.InitFirst();
	}

	public void BaskaYerdenBulundu()
	{
	}

	public void CalculateBonuses()
	{
		// Offline recovery candidate; native RVA 0x21df4c4.
		CritDamage_PerksTotal = 0f;
		AttackSpeed_PerksTotal = 0f;
		CriticalChance_PerksTotal = 0f;
		ATK_PerksTotal = 0f;
		foreach (Perk perk in perks)
		{
		 if (Level < perk.level) continue;
		 switch (perk.stat)
		 {
		  case "CritDamage": CritDamage_PerksTotal += perk.value; break;
		  case "AttackSpeed": AttackSpeed_PerksTotal += perk.value; break;
		  case "CritChance": CriticalChance_PerksTotal += perk.value; break;
		  case "ATK": ATK_PerksTotal += perk.value; break;
		  default: UnityEngine.Debug.LogWarning("Bilinmeyen stat: " + perk.stat); break;
		 }
		}
	}

	public void Favorite()
	{
		// Offline recovery candidate; native RVA 0x21df79c.
		MyFavorite = !MyFavorite;
		ES3.Save<bool>("CommanderHeroFavorite" + HeroNum.ToString(), MyFavorite);
	}
}
