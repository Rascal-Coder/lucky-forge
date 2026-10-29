public class SkillUnit
{
	public int Num;

	public string TargetStat;

	public float EffectValue;

	public int Level;

	public int MaxLevel;

	public RaritySkill Rarity;

	public int IconNum;

	public int forATK;

	public SkillUnit(int num, string targetStat, float effectValue, int maxLevel, RaritySkill rarity, int iconNum, int forATKS = 0)
	{
		// Recovered from original ARM64 0x202fda8.
		Num=num; TargetStat=targetStat; EffectValue=effectValue; Level=0; MaxLevel=maxLevel; Rarity=rarity; IconNum=iconNum; forATK=forATKS;
	}

	public void FindSkill()
	{
		// Recovered from original ARM64 0x202fe20.
		Level=unchecked(Level+1);
	}

	public float GetTotalEffect()
	{
		// Recovered from original ARM64 0x202fe30.
		return EffectValue*Level;
	}
}
