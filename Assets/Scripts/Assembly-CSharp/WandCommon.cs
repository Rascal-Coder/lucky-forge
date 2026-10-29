using UnityEngine;

[CreateAssetMenu(menuName = "Skills/Wand/WandCommon")]
public class WandCommon : Skill
{
	public override void Execute(Commander commander, WarController warController, bool[] isUnlocked, long damage)
	{
		// Offline recovery candidate; native RVA 0x1f6d6f0.
		if (!isUnlocked[0]) return;
		commander.NextAttackType = 0;
		if (UnityEngine.Random.value < 0.20000000298023224f)
		{
		 commander.NextAttackType = 5;
		 commander.NextAttackEffectSecond = 2f;
		}
	}
}
