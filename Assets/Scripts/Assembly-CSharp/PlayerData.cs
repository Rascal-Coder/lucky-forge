using System;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
	[Serializable]
	public class Player
	{
		private long CalculateStatLONG(long baseValue, float yuzdeseletki, float carpanetki)
		{
			// Offline recovery; native RVA 0x2022d80.
			long added = (long)((float)baseValue / 100f * yuzdeseletki);
			return (long)((float)unchecked(baseValue + added) * Mathf.Clamp(carpanetki,1f,10000f));
		}

		private double CalculateStatDOUBLE(double baseValue, float yuzdeseletki, float carpanetki)
		{
			// Offline recovery; native RVA 0x2022de4.
			return (baseValue + baseValue / 100.0 * (double)yuzdeseletki) * (double)Mathf.Clamp(carpanetki,1f,10000f);
		}

		private float CalculateWithPlus(float YuzdeToplama)
		{
			// Offline recovery; native RVA 0x2022e24.
			return YuzdeToplama;
		}

		public float AttackRange(int projectionLvl = 0)
		{
			// Offline recovery; native RVA 0x2022e28.
			return Mathf.Clamp(TalentStats.Range + researchDatas.Range() + 50f,50f,70f);
		}

		public long HP(int projectionLvl = 0)
		{
			// Offline recovery; native RVA 0x2022f3c.
			long baseHp = unchecked((long)TalentStats.Health + 500L);
			int percentage = unchecked(KiyafetData.CastleHpArtisi + collectibles.HP + mainWallEffect.KaleHpArttir);
			float clan = clanPerksDatam.WallHp < 1f ? 1f : clanPerksDatam.WallHp;
			float multiplier = Mathf.Clamp(researchDatas.Health() * clan,1f,10000f);
			long added = (long)((float)baseHp / 100f * (float)percentage);
			return (long)((float)unchecked(baseHp + added) * multiplier);
		}

		public float SilverIncomeX(int projectionLvl = 0)
		{
			// Offline recovery; native RVA 0x2023100.
			return TalentStats.SilverIncome > 1f ? TalentStats.SilverIncome : 1f;
		}

		public float GoldIncomeX(int projectionLvl = 0)
		{
			// Offline recovery; native RVA 0x2023198.
			float talent = TalentStats.GoldIncome < 1f ? 1f : TalentStats.GoldIncome;
			float milestone = GameManager.MilestoneGoldBonus < 1f ? 1f : GameManager.MilestoneGoldBonus;
			float booster = GameManager.KazancBooster < 1f ? 1f : GameManager.KazancBooster;
			float clan = clanPerksDatam.WarIncome < 1f ? 1f : clanPerksDatam.WarIncome;
			return clan * (milestone * (talent * booster));
		}

		public float SilverBonusEveryWave(int projectionLvl = 0)
		{
			// Offline recovery; native RVA 0x202327c.
			return TalentStats.EveryWaveSilver + researchDatas.SilverBonusEveryWave();
		}

		public float GameSpeed(float projection = 0f)
		{
			// Offline recovery; native RVA 0x2023374.
			float value = researchDatas.GameSpeed() + 1f;
			value += WarController.IsBoostActive;
			value += projection;
			value += (float)GameManager.NoAdsGameSpeed;
			value += (float)GameManager.ExtraGameSpeed;
			return Mathf.Clamp(value,1f,2f);
		}
	}

	[Serializable]
	public class ClanPerksData
	{
		public float TotalDamage;

		public int StartCoin;

		public float WallHp;

		public int AxeAttack;

		public int SwordAttack;

		public int WandAttack;

		public int ArrowAttack;

		public int MaceAttack;

		public int CommonAttack;

		public int RareAttack;

		public int EpicAttack;

		public int LegendAttack;

		public int MysticAttack;

		public float WarIncome;

		public int MaxEnergy;
	}

	[Serializable]
	public class DailyFortune
	{
		public int LuckyStone;

		public int StartCoin;

		public float SavasSonuGold;

		public int AxeAttack;

		public int SwordAttack;

		public int WandAttack;

		public int ArrowAttack;

		public int MaceAttack;

		public float DungeonDrops;

		public int BossDamage;
	}

	[Serializable]
	public class MainHeroEffect
	{
		public float HerMistikYuzdeBonusu;

		public float SavasSonuGanimetArtisi;
	}

	[Serializable]
	public class WallEffect
	{
		public int KaleRegen;

		public int HealthDusurYuzde;

		public int DusmanlarShockSaniye;

		public int SpinFiyatiDusur;

		public int KaleHpArttir;

		public int GoldCoinKazanimArttir;

		public int DusmanlarIskaGecer;

		public int DusmanlarDahaFazlaHasarYer;
	}

	[Serializable]
	public class TalentData
	{
		public float GoldIncome;

		public float Range;

		public float BossDecreaseHealth;

		public float CommonAttackArtisi;

		public float RareAttackArtisi;

		public float ExtraParaileBasla;

		public float CriticalChance;

		public float SilverIncome;

		public float SpinLevelIncrease;

		public float Health;

		public float Attack;

		public float EpicAttackArtisi;

		public float EnemyDecreaseHealth;

		public float AttackSpeed;

		public float EnemyBalanceMinions;

		public float WaveTimingDecrease;

		public float LastStanding;

		public float LegendaryAttackArtisi;

		public float EveryWaveSilver;

		public float MysticAttackArtisi;

		public float SansTokenEpicArtis;

		public float SansTokenLegendArtis;
	}

	[Serializable]
	public class ResearchData
	{
		public float ArastirmaCenterLevel_ArtisKac = 1.0f;

		public float GameSpeed_ArtisKac = 0.20000000298023224f;

		public float AttackSpeed_ArtisKac = 0.10000000149011612f;

		public float Health_ArtisKac = 0.5f;

		public float Attack_ArtisKac = 0.10000000149011612f;

		public float SilverBonusEveryWave_ArtisKac = 0.10000000149011612f;

		public float SilverBonusEvery50kills_ArtisKac = 0.10000000149011612f;

		public float GoldBonusEveryWave_ArtisKac = 0.10000000149011612f;

		public float GoldBonusEvery100kills_ArtisKac = 0.10000000149011612f;

		public float SilverBonusafterBossKilled_ArtisKac = 0.10000000149011612f;

		public float GoldBonusafterBossKilled_ArtisKac = 0.10000000149011612f;

		public float Range_ArtisKac = 0.20000000298023224f;

		public float LighningOrbAttack_ArtisKac = 0.10000000149011612f;

		public float FireOrbAttack_ArtisKac = 0.10000000149011612f;

		public float IceOrbAttack_ArtisKac = 0.10000000149011612f;

		public float PoisonOrbAttack_ArtisKac = 0.10000000149011612f;

		public float BlastOrbAttack_ArtisKac = 0.10000000149011612f;

		public float SteelOrbAttack_ArtisKac = 0.10000000149011612f;

		public float GameSpeed()
		{
			// Offline recovery; native RVA 0x2023488.
			return GameSpeed_ArtisKac * (float)researchSaveData.GameSpeed_Level;
		}

		public float AttackSpeed()
		{
			// Offline recovery; native RVA 0x20234fc.
			return AttackSpeed_ArtisKac * (float)researchSaveData.AttackSpeed_Level;
		}

		public float Health()
		{
			// Offline recovery; native RVA 0x2023084.
			return Health_ArtisKac * (float)researchSaveData.Health_Level + 1f;
		}

		public float Attack()
		{
			// Offline recovery; native RVA 0x2023570.
			return Attack_ArtisKac * (float)researchSaveData.Attack_Level + 1f;
		}

		public float SilverBonusEveryWave()
		{
			// Offline recovery; native RVA 0x20232f8.
			return SilverBonusEveryWave_ArtisKac * (float)researchSaveData.SilverBonusEveryWave_Level + 1f;
		}

		public float SilverBonusEvery50kills()
		{
			// Offline recovery; native RVA 0x20235ec.
			return SilverBonusEvery50kills_ArtisKac * (float)researchSaveData.SilverBonusEvery50kills_Level + 1f;
		}

		public float GoldBonusEveryWave()
		{
			// Offline recovery; native RVA 0x2023668.
			return GoldBonusEveryWave_ArtisKac * (float)researchSaveData.GoldBonusEveryWave_Level + 1f;
		}

		public float GoldBonusEvery100kills()
		{
			// Offline recovery; native RVA 0x20236e4.
			return GoldBonusEvery100kills_ArtisKac * (float)researchSaveData.GoldBonusEvery100kills_Level + 1f;
		}

		public float SilverBonusafterBossKilled()
		{
			// Offline recovery; native RVA 0x2023760.
			return SilverBonusafterBossKilled_ArtisKac * (float)researchSaveData.SilverBonusafterBossKilled_Level + 1f;
		}

		public float GoldBonusafterBossKilled()
		{
			// Offline recovery; native RVA 0x20237dc.
			return GoldBonusafterBossKilled_ArtisKac * (float)researchSaveData.GoldBonusafterBossKilled_Level + 1f;
		}

		public float Range()
		{
			// Offline recovery; native RVA 0x2022ec8.
			return Range_ArtisKac * (float)researchSaveData.Range_Level;
		}

		public float LighningOrbAttack()
		{
			// Offline recovery; native RVA 0x2023858.
			return LighningOrbAttack_ArtisKac * (float)researchSaveData.LighningOrbAttack_Level;
		}

		public float FireOrbAttack()
		{
			// Offline recovery; native RVA 0x20238cc.
			return FireOrbAttack_ArtisKac * (float)researchSaveData.FireOrbAttack_Level;
		}

		public float IceOrbAttack()
		{
			// Offline recovery; native RVA 0x2023940.
			return IceOrbAttack_ArtisKac * (float)researchSaveData.IceOrbAttack_Level;
		}

		public float PoisonOrbAttack()
		{
			// Offline recovery; native RVA 0x20239b4.
			return PoisonOrbAttack_ArtisKac * (float)researchSaveData.PoisonOrbAttack_Level;
		}

		public float BlastOrbAttack()
		{
			// Offline recovery; native RVA 0x2023a28.
			return BlastOrbAttack_ArtisKac * (float)researchSaveData.BlastOrbAttack_Level;
		}

		public float SteelOrbAttack()
		{
			// Offline recovery; native RVA 0x2023a9c.
			return SteelOrbAttack_ArtisKac * (float)researchSaveData.SteelOrbAttack_Level;
		}

		public void SaveResearch()
		{
        // Original ARM64 recovery 0x2023b10.
        ES3.Save<PlayerData.ResearchSaved>("ResearchSavedLevels",PlayerData.researchSaveData);
	}
	}

	[Serializable]
	public class ResearchSaved
	{
		public int ArastirmaCenterLevel_Level;

		public int GameSpeed_Level;

		public int AttackSpeed_Level;

		public int Health_Level;

		public int Attack_Level;

		public int SilverBonusEveryWave_Level;

		public int SilverBonusEvery50kills_Level;

		public int GoldBonusEveryWave_Level;

		public int GoldBonusEvery100kills_Level;

		public int SilverBonusafterBossKilled_Level;

		public int GoldBonusafterBossKilled_Level;

		public int Range_Level;

		public int LighningOrbAttack_Level;

		public int FireOrbAttack_Level;

		public int IceOrbAttack_Level;

		public int PoisonOrbAttack_Level;

		public int BlastOrbAttack_Level;

		public int SteelOrbAttack_Level;
	}

	[Serializable]
	public class Skills
	{
		public float commonWeaponATK1;

		public float commonWeaponATK2;

		public float commonWeaponATK3;

		public float commonWeaponATK4;

		public float rareWeaponATK1;

		public float rareWeaponATK2;

		public float rareWeaponATK3;

		public float rareWeaponATK4;

		public float epicWeaponATK1;

		public float epicWeaponATK2;

		public float epicWeaponATK3;

		public float epicWeaponATK4;

		public float legendaryWeaponATK1;

		public float legendaryWeaponATK2;

		public float legendaryWeaponATK3;

		public float legendaryWeaponATK4;

		public float legendaryveMistiksWeaponATK1;

		public float legendaryveMistiksWeaponATK2;

		public float RareveCommonWeaponATK1;

		public float RareveCommonWeaponATK2;

		public float mistikWeaponATK1;

		public float mistikWeaponATK2;

		public float mistikWeaponATK3;

		public float mistikWeaponATK4;

		public void ResetAllStats()
		{
		// Recovered from original ARM64 0x2023b98.
		foreach(var field in typeof(Skills).GetFields()) if(field.FieldType==typeof(float)) field.SetValue(PlayerData.SkillsStats,0f);
	}
	}

	[Serializable]
	public class NewKiyafetData
	{
		public long AllDamageArtisiFlat;

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
	}

	[Serializable]
	public class Collectibles
	{
		public int AllDamageArtisiFlat;

		public int EnemyDecreaseHealth;

		public int HP;

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

		public void ClearData()
		{
		}
	}

	public static Player PlayerStats = new Player();

	public static ClanPerksData clanPerksDatam = new ClanPerksData();

	public static DailyFortune dailyFortune = new DailyFortune();

	public static MainHeroEffect mainHeroBonus = new MainHeroEffect();

	public static WallEffect mainWallEffect = new WallEffect();

	public static TalentData TalentStats = new TalentData();

	public static ResearchData researchDatas = new ResearchData();

	public static ResearchSaved researchSaveData = new ResearchSaved();

	public static Skills SkillsStats = new Skills();

	public static NewKiyafetData KiyafetData = new NewKiyafetData();

	public static Collectibles collectibles = new Collectibles();

	private void Start()
	{
        // Native RVA0x2022918. Static .cctor allocation restored above.
        if (ES3.KeyExists("ResearchSavedLevels")) researchSaveData = ES3.Load<ResearchSaved>("ResearchSavedLevels");
        else ES3.Save<ResearchSaved>("ResearchSavedLevels", researchSaveData);
	}

	private void Update()
	{
	}
}
