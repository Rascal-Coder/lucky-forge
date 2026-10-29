// Executable pure-math reconstruction from Lucky Forge 1.49.9 ARM64 instructions.
// NOT original source. Does not cover the entire battle, skills, economy, or spawn selection.
// Ordinary finite values only; explicit unchecked operations preserve native integer wraparound.
// libil2cpp SHA256:20443ec6846e3b7b36ff1e48b43986d5703d74ad356c060322cff209137469c4
using System;

public static class RecoveredBattleMath
{
    // Commander.ATK RVA0x21dd0b8, before EquipmentATKArtislari / ATKBonusRogueLike.
    public static long AttackBeforePercentageBonuses(long startAttack, int rarity,
        long equipmentFlatAttack, int level, int upgradePreview, float attackGrowth,
        long directAttackPerLevel)
    {
        long flat = unchecked(startAttack + equipmentFlatAttack * unchecked(rarity + 1));
        float growth = attackGrowth * unchecked(level + upgradePreview) + 1f;
        if (growth < 1f) growth = 1f;
        return (long)(growth * (float)flat + (float)unchecked(directAttackPerLevel * level));
    }

    // Commander.ATKBonusRogueLike RVA0x21dd77c. Caller first adds equipment helper result.
    public static long RogueLikeAttackIncrease(long attackAfterEquipment, float raritySkillSum,
        float mainHeroMysticBonus)
    {
        return (long)((float)attackAfterEquipment / 100f * (raritySkillSum + mainHeroMysticBonus));
    }

    // Commander.AtkSpeed RVA0x21ddf48: rate (attacks/second), not cooldown seconds.
    public static float AttackRate(float startRate, float perkPercent, float equipmentPercent,
        float talentAttackSpeed)
    {
        float percent = perkPercent + equipmentPercent;
        percent += talentAttackSpeed;
        return startRate + startRate * percent / 100f;
    }

    // Commander.CritChance RVA0x21ddfe8, no clamp observed here.
    public static float CriticalChance(float talentChance, float equipmentChance, float perkChance)
    {
        return (talentChance + equipmentChance) + perkChance;
    }

    // Commander.CritMultipler RVA0x21de06c; percentage multiplier consumed by Projectile.
    public static float CriticalMultiplier(int rarity, float equipmentCritDamage, float perkCritDamage)
    {
        return perkCritDamage + (equipmentCritDamage + (float)unchecked(rarity * 10));
    }

    // Projectile.DealDamage RVA0x20271c4. Random.Range(0,100) is integer here.
    // The <= comparison is preserved: chance0 succeeds for roll0; chance5 for rolls0..5.
    public static bool IsCritical(int integerRoll0To99, float criticalChance)
    {
        if (integerRoll0To99 < 0 || integerRoll0To99 >= 100)
            throw new ArgumentOutOfRangeException("integerRoll0To99");
        return criticalChance >= (float)integerRoll0To99;
    }

    public static long ProjectileDamage(long attackDamage, double criticalMultiplier, bool isCritical)
    {
        return isCritical ? (long)((double)attackDamage * criticalMultiplier / 100.0) : attackDamage;
    }

    // Enemy.TakeDamage RVA0x2204ac0. Each positive modifier uses the UPDATED damage.
    // Do not combine into one summed percentage; order and float truncation matter.
    private static long AddPositivePercent(long damage, int percent)
    {
        if (percent < 1) return damage;
        long multiplied = unchecked(damage * (long)percent);
        return unchecked(damage + (long)((float)multiplied / 100f));
    }

    public static long DamageReceived(long incomingDamage, bool shocked, bool frozen,
        int stunnedEquipmentPercent, int vulnerability1, int vulnerability2,
        bool boss, int dailyFortuneBossDamagePercent)
    {
        long damage = incomingDamage;
        if (shocked || frozen) damage = AddPositivePercent(damage, stunnedEquipmentPercent);
        damage = AddPositivePercent(damage, vulnerability1);
        damage = AddPositivePercent(damage, vulnerability2);
        if (boss) damage = AddPositivePercent(damage, dailyFortuneBossDamagePercent);
        return damage;
    }

    // WarController.Update RVA0x2059338..0x2059378.
    public static bool BattleWon(long castleHealth, int activeEnemyCount, int currentWaveIndex,
        int totalWaves, bool resultAlreadyOpened)
    {
        return castleHealth >= 1 && activeEnemyCount == 0 && currentWaveIndex != 0 &&
            totalWaves <= currentWaveIndex && !resultAlreadyOpened;
    }

    // MeduPow.Pow RVA0x2008b48: exponentiation by squaring; negative exponent returns1.
    public static double IntegerPower(int exponent, double value)
    {
        double result = 1.0;
        while (exponent > 0)
        {
            if ((exponent & 1) != 0) result *= value;
            value *= value;
            exponent = (int)((uint)exponent >> 1);
        }
        return result;
    }

    // Enemy.HpStartData RVA0x2203ae8: ONLY ordinary non-boss, non-guild, non-dungeon,
    // non-daily branch. Other modes require their own recovered branches.
    public static long NormalEnemyHealth(int currentWaveIndex, long baseBonus, long growthBonus,
        long healthMultiplier, float talentEnemyHealthReduction, int collectibleEnemyHealthReduction,
        double collectedDps, float dpsBaseFactor, float dpsWaveIncrease)
    {
        long exponential = (long)((double)growthBonus * IntegerPower(unchecked(currentWaveIndex + 1), 1.0460000038146973));
        long health = unchecked(healthMultiplier * unchecked(baseBonus + exponential + 1));
        float reduction = talentEnemyHealthReduction + (float)collectibleEnemyHealthReduction;
        if (reduction > 0f) health = unchecked(health - (long)((float)health * reduction / 100f));
        if (currentWaveIndex <= 9)
        {
            float scaled = (float)health * 0.30000001192092896f;
            if (scaled > 500f) scaled = 500f;
            if (scaled < 2f) scaled = 2f;
            health = (long)scaled;
        }
        float dpsFactor = dpsBaseFactor + (float)currentWaveIndex * dpsWaveIncrease;
        return unchecked(health + (long)(collectedDps * (double)dpsFactor));
    }
}
