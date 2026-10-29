using UnityEngine;

[CreateAssetMenu(menuName = "Skills/Mace/MaceCommon")]
public class MaceCommon : Skill
{
	public override void Execute(Commander commander, WarController warController, bool[] isUnlocked, long damage)
	{
		// Offline recovery candidate; native RVA 0x1f67cf4.
		if (isUnlocked[0] && UnityEngine.Random.value < 0.20000000298023224f) commander.LateShootForSkill();
	}
}
