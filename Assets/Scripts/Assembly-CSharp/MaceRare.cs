using UnityEngine;

[CreateAssetMenu(menuName = "Skills/Mace/MaceRare")]
public class MaceRare : Skill
{
	public override void Execute(Commander commander, WarController warController, bool[] isUnlocked, long damage)
	{
		// Offline recovery candidate; native RVA 0x1f68228.
		if (isUnlocked[0] && UnityEngine.Random.value < 0.2f) { commander.NextAttackType=1; commander.NextAttackEffectPower=3f; }
	}
}
