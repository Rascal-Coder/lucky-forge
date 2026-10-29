using UnityEngine;

public abstract class Skill : ScriptableObject
{
	public Sprite[] skillicon;

	public string[] skillName;

	public int[] requiredLevel;

	public bool triggerByAttack;

	public float cooldown = 3f;

	public long startDamagePercent;

	public Commander commanderforINFO;

	public abstract void Execute(Commander commander, WarController controller, bool[] isUnlocked, long damage);

	public virtual long DamagePercentAtLevel(int commanderLevel)
	{
		// Offline recovery candidate; native RVA 0x1f6c9b4.
		return unchecked(startDamagePercent + (long)unchecked(commanderLevel * 5 - 5));
	}
}
