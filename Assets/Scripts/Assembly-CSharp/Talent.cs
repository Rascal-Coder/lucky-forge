using System;

[Serializable]
public class Talent
{
	public int Num;

	public string TargetStat;

	public float EffectValue;

	public int CurrentExp;

	public int Level;

	public int MaxLevel;

	public float BaseEffectValue;

	public RarityTalent Rarity;

	public int MaxExp()
	{
        // Original ARM64 recovery 0x204a09c.
        return TalentManager.maxExps[Level];
	}

	public Talent(int num, string targetStat, float effectValue, int maxLevel, float baseEffectValue, RarityTalent rarity)
	{
        // Original ARM64 recovery 0x204a11c.
        Num=num; TargetStat=targetStat; EffectValue=effectValue; CurrentExp=0; Level=0; MaxLevel=maxLevel; BaseEffectValue=baseEffectValue; Rarity=rarity;
	}

	public void UpgradeTalent()
	{
        // Original ARM64 recovery 0x204a18c.
        if (CurrentExp >= MaxExp() && Level < MaxLevel) { CurrentExp -= MaxExp(); Level++; } if (Level == MaxLevel) CurrentExp = MaxExp();
	}

	public bool CheckforUpg()
	{
        // Original ARM64 recovery 0x204a1f8.
        return CurrentExp >= MaxExp() && Level >= 1 && Level != MaxLevel;
	}

	public void AddExp()
	{
        // Original ARM64 recovery 0x2049d58.
        CurrentExp++; if (Level == 0) Level = 1;
	}

	public void Maxit()
	{
        // Original ARM64 recovery 0x204a244.
        Level=MaxLevel;
	}

	public float GetTotalEffect()
	{
        // Original ARM64 recovery 0x204a250.
        return BaseEffectValue + EffectValue * (float)Level;
	}
}
