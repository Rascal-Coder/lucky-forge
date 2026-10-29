// Reconstructed from Lucky Forge1.49.9 ARM64 + serialized data; not original source.
// Ordinary finite game inputs only. No Unity/game DLL dependency.
// See source-evidence and spawning-recovery.txt for instruction ranges and omitted state dispatch.
using System;
using System.Collections.Generic;

public static class RecoveredSpawnMath
{
    // GetEnemyTagsForWave RVA0x2057038: seed argument is supplied CurrentLevel by SpawnWave.
    public static string[] EnemyTags(int currentLevel, int maxEnemyType, bool dungeon, int chosenDungeon, bool daily)
    {
        if (maxEnemyType < 3) throw new ArgumentOutOfRangeException("maxEnemyType");
        Random rng = new Random(currentLevel); // Original System.Random, not UnityEngine.Random.
        HashSet<int> used = new HashSet<int>();
        string[] tags = new string[3];
        int i = 0;
        while (i < 3)
        {
            int id = rng.Next(1, unchecked(maxEnemyType + 1));
            if (used.Add(id)) tags[i++] = "enemy" + id;
        }
        if (dungeon) for (i = 0; i < 3; i++) tags[i] = "DungeonEnemy" + chosenDungeon;
        if (daily) for (i = 0; i < 3; i++) tags[i] = "dailywarenemy1";
        return tags;
    }

    // GetSpawnCountForWave RVA0x20571e8. Unity integration should supply Mathf.Pow,
    // preserving the original native powf. Math.Pow is not claimed bit-identical to powf.
    public static int SpawnCountPerGroup(int wave, int totalWaves, int maxEnemyCount,
        Func<float, float, float> powf)
    {
        float ratio = (float)unchecked(wave - 1) / (float)unchecked(totalWaves - 1);
        float value = powf(ratio, 1.149999976158142f);
        if (value > 1f) value = 1f;
        if (value < 0f) value = 0f;
        float count = 2f + ((float)maxEnemyCount - 2f) * value;
        return (int)Math.Round((double)count, MidpointRounding.ToEven);
    }

    public static bool SampleDpsAtStart(int capturedWave) { return capturedWave % 3 == 0; }
    public static bool StartBoss(int capturedWave, bool alreadySpawned) { return !alreadySpawned && capturedWave % 10 == 0; }
    // StartNextWave RVA0x2056cdc. GuideDone only controls setting isSpawningWave,
    // and does not add another guard to this predicate.
    public static bool CanStartNextWave(int liveWave, int totalWaves, bool isSpawningWave, long castleHp)
    {
        return liveWave < totalWaves && !isSpawningWave && castleHp >= 1;
    }
    public static bool SchedulerHasMoreWaves(int liveWave, int totalWaves, long castleHp)
    {
        return liveWave < totalWaves && castleHp > 0;
    }

    // One boss is spawned immediately by its coroutine, followed by a1second yield.
    public static string BossTag(int currentLevel, bool dungeon, int chosenDungeon, bool daily)
    {
        string tag = "boss" + unchecked(currentLevel % 14 + 1);
        if (dungeon) tag = "DungeonBoss" + chosenDungeon;
        if (daily) tag = "dailywarboss";
        return tag;
    }

    // Evaluate each family when execution reaches that block; liveWave can change during yields.
    public static int EasyEnemyCount(int liveWave, float balanceMinions, bool alreadySpawned)
    {
        if (balanceMinions <= 0f || liveWave % 3 != 0 || alreadySpawned) return 0;
        return (int)Math.Ceiling((double)balanceMinions);
    }
    public static int SpeedyCount(int liveWave, int currentLevel, bool daily, bool alreadySpawned)
    {
        return liveWave % 7 == 0 && currentLevel >= 3 && !daily && !alreadySpawned ? liveWave / 7 + 1 : 0;
    }
    public static int WispCount(int liveWave, int currentLevel, bool dungeon, bool daily, bool alreadySpawned)
    {
        return liveWave % 5 == 0 && currentLevel >= 5 && !daily && !dungeon && !alreadySpawned ? liveWave / 6 + 5 : 0;
    }
    public static int DailyEnemy0Count(int liveWave, bool daily) { return daily && liveWave % 6 == 0 ? liveWave / 10 + 2 : 0; }
    public static int DailyEnemy2Count(int liveWave, bool daily) { return daily && liveWave % 8 == 0 ? liveWave / 20 + 2 : 0; }
    public static bool ActivateEliteMeteor(int liveWave, bool elite) { return elite && liveWave % 5 == 0; }
    public static int HeroChoice(int capturedWave, int gameManagerLevel)
    {
        if (capturedWave == 45) return 2;
        if (capturedWave == 12 && gameManagerLevel >= 3 && gameManagerLevel <= 5) return 1;
        return 0;
    }

    private static int Clamp(int v, int min, int max) { return v < min ? min : v > max ? max : v; }

    // Normal entry tables: MaxWaveCountLevels caps by table length; enemy count caps index20.
    public static int WorldTotalWaves(int level, int[] table) { return table[Clamp(level, 0, table.Length - 1)]; }
    public static int WorldMaxEnemies(int level, int[] table) { return table[Clamp(level, 0, 20)]; }
    public static int BossTier(int level) { return Clamp(level / 10, 0, 9999) + 1; }
    public static float WorldWaveInterval(int gameManagerLevel, float talentWaveTimingDecrease)
    {
        return gameManagerLevel >= 1 ? 8.5f - talentWaveTimingDecrease : 6f;
    }
    public static float DungeonWaveInterval(float talentWaveTimingDecrease) { return 6f - talentWaveTimingDecrease; }
    public static float DailyWaveInterval(float talentWaveTimingDecrease) { return 7f - talentWaveTimingDecrease; }

    // enemieshphesap / enemieshphesapARTAN: tail extrapolation + Elite scaling.
    public static long WorldBaseBonus(int level, long[] table, bool elite)
    {
        if (level < 0) throw new IndexOutOfRangeException();
        long selected;
        if (level < table.Length) selected = table[level];
        else { long last = table[table.Length - 1]; selected = unchecked(last + unchecked(last * Clamp(unchecked(level - 3), 1, 100000)) / 8); }
        return elite ? unchecked(selected * 5 + 2500) : unchecked(selected + 1);
    }
    public static long WorldGrowthBonus(int level, long[] table, bool elite)
    {
        if (level < 0) throw new IndexOutOfRangeException();
        long selected;
        if (level < table.Length) selected = table[level];
        else { long last = table[table.Length - 1]; selected = unchecked(last + unchecked(last * Clamp(unchecked(level - 3), 1, 100000)) / 4); }
        return elite ? unchecked(selected * 5 + 1000) : unchecked(selected + 1);
    }
    // enemiesDungeonArtanStart uses dungeon completion level, NOT chosen dungeon index.
    public static long DungeonGrowthStart(int dungeonCompletionLevel, long[] table)
    {
        if (dungeonCompletionLevel < 0) throw new IndexOutOfRangeException();
        if (dungeonCompletionLevel < table.Length) return table[dungeonCompletionLevel];
        long last = table[table.Length - 1];
        return unchecked(last + unchecked(last * Clamp(unchecked(dungeonCompletionLevel - 9), 1, 100000)) / 4);
    }
    public static long DungeonGrowthBonus(int dungeonCompletionLevel, int chosenDungeon, long[] table)
    {
        return unchecked(DungeonGrowthStart(dungeonCompletionLevel, table) * unchecked(chosenDungeon + 1));
    }
    // These entry products are calculated as int32 and then sign-extended to long.
    public static long DungeonBaseBonus(int dungeonCompletionLevel) { return unchecked(dungeonCompletionLevel * 30 + 30); }
    public static long DailyBaseBonus(int dailyWars) { return unchecked(unchecked(dailyWars + 1) * 20); }
    public static long DailyGrowthBonus(int dailyWars) { return unchecked(unchecked(dailyWars + 1) * 80); }
    public static long BossMultiplier(int level, long[] table)
    {
        if (level < 0) throw new IndexOutOfRangeException();
        return table[level < table.Length ? level : table.Length - 1];
    }

    public static long BossBaseHealth(int liveWave)
    {
        if (liveWave < 10) return 2000;
        if (liveWave < 20) return 3000;
        if (liveWave < 30) return 13000;
        if (liveWave < 40) return 30000;
        if (liveWave < 50) return 45000;
        if (liveWave < 60) return 55000;
        if (liveWave < 70) return 80000;
        if (liveWave < 80) return 90000;
        if (liveWave < 90) return 110000;
        if (liveWave < 100) return 150000;
        return 250000;
    }

    private static double MeduPow(int exponent, double value)
    {
        double result = 1.0;
        while (exponent > 0) { if ((exponent & 1) != 0) result *= value; value *= value; exponent = (int)((uint)exponent >> 1); }
        return result;
    }

    // All Enemy.HpStartData branches with explicit caller-resolved mode values.
    public sealed class HealthInput
    {
        public int LiveWave, GameManagerLevel, DungeonLevel, SelectedDungeonCompletionLevel, DailyWars;
        public bool Boss, GuildBoss, Dungeon, Daily;
        public long MaxHealthMultiplier, BossMultiplier, BaseBonus, GrowthBonus;
        public int BossTier;
        public float BossHealthDecrease, EnemyHealthDecrease;
        public int CollectibleEnemyHealthDecrease;
        public double CollectedDps;
        public float DpsEnemyBase, DpsEnemyIncrease, DpsBossBase, DpsBossIncrease;
    }
    public static long EnemyHealth(HealthInput s)
    {
        long multiplier = s.Boss && s.MaxHealthMultiplier == -1 ? s.BossMultiplier : s.MaxHealthMultiplier;
        long growth = (long)((double)s.GrowthBonus * MeduPow(unchecked(s.LiveWave + 1), 1.0460000038146973));
        long hp = unchecked(multiplier * unchecked(s.BaseBonus + growth + 1));
        int tier;
        if (s.Dungeon)
        {
            hp = unchecked(hp * unchecked(s.DungeonLevel + 1));
            tier = unchecked(s.SelectedDungeonCompletionLevel + 1);
        }
        else if (s.Daily)
        {
            tier = unchecked(s.DailyWars + 1);
            hp = unchecked(hp * tier);
        }
        else tier = unchecked(s.GameManagerLevel + 1);
        if (s.Boss)
        {
            int tierProduct = unchecked(s.BossTier * tier + 3);
            hp = unchecked(hp + BossBaseHealth(s.LiveWave) + unchecked(s.BaseBonus * tierProduct * unchecked(s.LiveWave + 1)));
            if (s.BossHealthDecrease > 0f) hp = unchecked(hp - (long)((float)hp * s.BossHealthDecrease / 100f));
        }
        else
        {
            float reduction = s.EnemyHealthDecrease + (float)s.CollectibleEnemyHealthDecrease;
            if (reduction > 0f) hp = unchecked(hp - (long)((float)hp * reduction / 100f));
            if (s.LiveWave <= 9)
            {
                float scaled = (float)hp * 0.30000001192092896f;
                if (scaled > 500f) scaled = 500f;
                if (scaled < 2f) scaled = 2f;
                hp = (long)scaled;
            }
        }
        if (s.GuildBoss) hp = long.MaxValue - 2000;
        float dpsFactor = s.Boss ? s.DpsBossBase + (float)s.LiveWave * s.DpsBossIncrease
            : s.DpsEnemyBase + (float)s.LiveWave * s.DpsEnemyIncrease;
        return unchecked(hp + (long)(s.CollectedDps * (double)dpsFactor));
    }
}
