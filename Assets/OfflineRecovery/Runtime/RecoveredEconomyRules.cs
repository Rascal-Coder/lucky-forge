using System;

namespace LuckyForge.Offline.Recovered
{
    // Executable reconstruction of selected Lucky Forge 1.49.9 routines.
    // Native SHA256: 20443ec6846e3b7b36ff1e48b43986d5703d74ad356c060322cff209137469c4
    // These routines do not represent the complete original client.
    public enum RewardKind { Weapon = 0, Coin = 1, Mystic = 2, Crystal = 3, Empty = 4 }
    public enum Rarity { Common = 0, Rare = 1, Epic = 2, Legendary = 3, Mystic = 4 }

    [Serializable]
    public sealed class GearRuleView
    {
        public object TemplateIdentity;
        public Rarity Rarity;
        public int Slot;
        public int Level;
        public int Bonus;
        public int MergeCount;
    }

    public static class RecoveredEconomyRules
    {
        // ForgeSpinner.GetRewardTypeByChance 0x220c52c;
        // GenerateRandomReward 0x220c580 maps internal buckets to actual enum values.
        public static RewardKind ForgeRewardForRoll(int roll0To99)
        {
            if ((uint)roll0To99 >= 100u) throw new ArgumentOutOfRangeException(nameof(roll0To99));
            if (roll0To99 < 7) return RewardKind.Coin;
            if (roll0To99 < 12) return RewardKind.Crystal;
            if (roll0To99 == 12) return RewardKind.Mystic;
            if (roll0To99 <= 57) return RewardKind.Empty;
            return RewardKind.Weapon;
        }

        // Weapon rarity/icon selection is performed by the original separate routine.
        public static int ForgeCurrencyAmount(RewardKind kind, int multiplier)
        {
            switch (kind)
            {
                case RewardKind.Coin: return unchecked(200 * multiplier);
                case RewardKind.Crystal: return unchecked(5 * multiplier);
                case RewardKind.Mystic: return multiplier;
                case RewardKind.Empty: return 0;
                default: throw new ArgumentException("Weapon generation has a separate path", nameof(kind));
            }
        }

        // SpinforWeapon.successChance 0x2045d10. Bonus source recovered through metadata usage:
        // PlayerData.TalentStats.SansTokenEpicArtis / SansTokenLegendArtis.
        public static float WeaponSpinChance(Rarity rarity, float epicTalentBonus, float legendaryTalentBonus)
        {
            if (rarity == Rarity.Epic) return 20f + epicTalentBonus;
            if (rarity == Rarity.Legendary) return 10f + legendaryTalentBonus;
            return 60f;
        }

        // <SpinAnimation>d__27.MoveNext 0x2046680. Input is the original float Random.Range roll.
        public static bool PassWeaponSpin(float roll, float chance, bool forGuide, bool dontwork, int candidateCount)
        {
            if (forGuide) roll = 0f;
            if (dontwork) roll = 100f;
            return roll <= chance && candidateCount > 0;
        }

        // IsValidCandidate 0x200cb24. Equipped membership is supplied by the real inventory adapter.
        public static bool IsMergeCandidate(GearRuleView main, GearRuleView candidate, bool candidateEquipped)
        {
            if (main == null || candidate == null || candidateEquipped) return false;
            if (main.Rarity == Rarity.Mystic)
                return candidate.Rarity == Rarity.Mystic && candidate.Slot == main.Slot;
            if (main.Rarity == Rarity.Legendary && (uint)main.Bonus <= 1u)
                return candidate.Rarity == Rarity.Legendary && candidate.Bonus == main.Bonus && candidate.Slot == main.Slot;
            if (main.Rarity == Rarity.Epic && (uint)main.Bonus <= 1u)
                return candidate.Rarity == Rarity.Epic && candidate.Bonus == 0 && candidate.Slot == main.Slot;
            return ReferenceEquals(main.TemplateIdentity, candidate.TemplateIdentity) && main.Rarity == candidate.Rarity && main.Bonus == candidate.Bonus;
        }

        // CreatePreviewItem 0x200f978; mutates a NEW constructor-initialized object.
        // It increments that new object's merge count, rather than copying the source count.
        public static void PopulateMergePreview(GearRuleView source, GearRuleView initializedNewObject)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (initializedNewObject == null) throw new ArgumentNullException(nameof(initializedNewObject));
            initializedNewObject.TemplateIdentity = source.TemplateIdentity;
            initializedNewObject.Rarity = source.Rarity;
            initializedNewObject.Level = source.Level;
            initializedNewObject.Bonus = source.Bonus;
            if (((source.Rarity == Rarity.Epic || source.Rarity == Rarity.Legendary) && source.Bonus <= 1) || source.Rarity == Rarity.Mystic)
                initializedNewObject.Bonus = unchecked(source.Bonus + 1);
            else
            {
                initializedNewObject.Rarity = (Rarity)unchecked((int)source.Rarity + 1);
                initializedNewObject.Bonus = 0;
            }
            initializedNewObject.MergeCount = unchecked(initializedNewObject.MergeCount + 1);
        }

        // WarController.BossBaseHP 0x2052c70; currentWaveIndex, not the displayed wave label.
        public static long BossBaseHealth(int waveIndex)
        {
            if (waveIndex < 10) return 2000;
            if (waveIndex < 20) return 3000;
            if (waveIndex < 30) return 13000;
            if (waveIndex < 40) return 30000;
            if (waveIndex < 50) return 45000;
            if (waveIndex < 60) return 55000;
            if (waveIndex < 70) return 80000;
            if (waveIndex < 80) return 90000;
            if (waveIndex < 90) return 110000;
            if (waveIndex < 100) return 150000;
            return 250000;
        }

        // ResearchManager.KristalFiyati 0x202d368, ordinary finite values only.
        // Callers must resolve the original config flag; its semantic identity is not assumed here.
        public static int ResearchSpeedupPrice(float remainingMinutes, bool originalConfigFlag)
        {
            if (!originalConfigFlag) return 1;
            int price = (int)(remainingMinutes * 2f);
            if (price < 3) return 3;
            if (price > 10000) return 10000;
            return price;
        }
    }
}
