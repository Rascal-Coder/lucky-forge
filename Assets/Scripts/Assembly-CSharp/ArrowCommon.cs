using UnityEngine;

[CreateAssetMenu(menuName = "Skills/Arrow/ArrowCommon")]
public class ArrowCommon : Skill
{
	public override void Execute(Commander commander, WarController warController, bool[] isUnlocked, long damage)
	{
		// Offline recovery candidate; native RVA 0x1f667a4.
		if (!isUnlocked[0]) return;
		commander.NextAttackType = 0;
		if (UnityEngine.Random.value < 0.20000000298023224f)
		{
		 commander.NextAttackType = 4;
		 commander.NextAttackEffectSecond = 2f;
		}
	}
}
