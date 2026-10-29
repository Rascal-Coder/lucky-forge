using UnityEngine;

[CreateAssetMenu(menuName = "Skills/Axe/AxeCommon")]
public class AxeCommon : Skill
{
	public override void Execute(Commander commander, WarController warController, bool[] isUnlocked, long damage)
	{
		// Offline recovery candidate; native RVA 0x1f67594.
		if (!isUnlocked[0]) return;
		commander.AtilanIcindenGecsin = false;
		if (UnityEngine.Random.value < 0.20000000298023224f) commander.AtilanIcindenGecsin = true;
	}
}
