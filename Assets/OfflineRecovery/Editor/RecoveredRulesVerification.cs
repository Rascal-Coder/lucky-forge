using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using LuckyForge.Offline.Recovered;

namespace LuckyForge.Offline.Editor
{
    public static class RecoveredRulesVerification
    {
        [Serializable] private sealed class Result { public bool passed; public int checks; public List<string> failures = new List<string>(); }
        private static void Check(Result result, bool success, string name)
        {
            result.checks++;
            if (!success) result.failures.Add(name);
        }

        public static void RunBatch()
        {
            var r = new Result();
            var distribution = new int[5];
            for (int roll = 0; roll < 100; roll++) distribution[(int)RecoveredEconomyRules.ForgeRewardForRoll(roll)]++;
            int[] expected = {42, 7, 1, 5, 45};
            for (int i = 0; i < 5; i++) Check(r, distribution[i] == expected[i], "reward distribution " + i);
            Check(r, RecoveredEconomyRules.ForgeRewardForRoll(6) == RewardKind.Coin && RecoveredEconomyRules.ForgeRewardForRoll(7) == RewardKind.Crystal, "coin/crystal boundary");
            Check(r, RecoveredEconomyRules.ForgeRewardForRoll(12) == RewardKind.Mystic && RecoveredEconomyRules.ForgeRewardForRoll(13) == RewardKind.Empty, "mystic/empty boundary");
            Check(r, RecoveredEconomyRules.ForgeRewardForRoll(57) == RewardKind.Empty && RecoveredEconomyRules.ForgeRewardForRoll(58) == RewardKind.Weapon, "empty/weapon boundary");
            Check(r, RecoveredEconomyRules.ForgeCurrencyAmount(RewardKind.Coin, 3) == 600 && RecoveredEconomyRules.ForgeCurrencyAmount(RewardKind.Crystal, 3) == 15, "reward multiplier");
            Check(r, RecoveredEconomyRules.WeaponSpinChance(Rarity.Epic, 7, 8) == 27 && RecoveredEconomyRules.WeaponSpinChance(Rarity.Legendary, 7, 8) == 18, "talent spin bonus");
            Check(r, RecoveredEconomyRules.PassWeaponSpin(99, 20, true, false, 1), "guide roll override");
            Check(r, !RecoveredEconomyRules.PassWeaponSpin(0, 20, true, true, 1), "dontwork override order");
            Check(r, !RecoveredEconomyRules.PassWeaponSpin(0, 100, false, false, 0), "empty candidate list");
            var main = new GearRuleView {Rarity = Rarity.Epic, Slot = 2, Bonus = 1};
            var other = new GearRuleView {Rarity = Rarity.Epic, Slot = 2, Bonus = 0};
            Check(r, RecoveredEconomyRules.IsMergeCandidate(main, other, false), "epic+1 accepts epic+0 same slot");
            other.Bonus = 1;
            Check(r, !RecoveredEconomyRules.IsMergeCandidate(main, other, false), "epic+1 rejects epic+1 fodder");
            var preview = new GearRuleView {MergeCount = 7};
            main.MergeCount = 99;
            RecoveredEconomyRules.PopulateMergePreview(main, preview);
            Check(r, preview.Bonus == 2 && preview.MergeCount == 8 && main.MergeCount == 99, "preview fields and new object count");
            Check(r, RecoveredEconomyRules.BossBaseHealth(9) == 2000 && RecoveredEconomyRules.BossBaseHealth(10) == 3000 && RecoveredEconomyRules.BossBaseHealth(100) == 250000, "boss tier boundaries");
            Check(r, RecoveredEconomyRules.ResearchSpeedupPrice(1, true) == 3 && RecoveredEconomyRules.ResearchSpeedupPrice(10000, true) == 10000 && RecoveredEconomyRules.ResearchSpeedupPrice(99, false) == 1, "speedup price clamp and gate");
            Check(r, RecoveredBattleMath.IsCritical(0, 0) && !RecoveredBattleMath.IsCritical(1, 0), "native <= critical threshold");
            Check(r, RecoveredBattleMath.ProjectileDamage(101, 150, true) == 151, "critical damage truncation");
            Check(r, RecoveredBattleMath.DamageReceived(100, true, false, 10, 10, 10, true, 10) == 146, "sequential damage truncation");
            Check(r, RecoveredBattleMath.BattleWon(1, 0, 10, 10, false) && !RecoveredBattleMath.BattleWon(1, 1, 10, 10, false), "win waits for active enemy list");
            r.passed = r.failures.Count == 0;
            string folder = Path.Combine(Directory.GetParent(Application.dataPath).FullName, "Verification");
            Directory.CreateDirectory(folder);
            File.WriteAllText(Path.Combine(folder, "recovered-rules.json"), JsonUtility.ToJson(r, true));
            Debug.Log("Recovered rule checks: " + r.checks + ", failures: " + r.failures.Count);
            EditorApplication.Exit(r.passed ? 0 : 1);
        }
    }
}
