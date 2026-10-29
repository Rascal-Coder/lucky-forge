using UnityEngine;

[CreateAssetMenu(menuName = "Skills/Mistik/Mistik10")]
public class Mistik10 : Skill
{
	public override void Execute(Commander commander, WarController warController, bool[] isUnlocked, long damage)
	{
		// Offline recovery candidate; native RVA 0x1f6866c.
		if (!isUnlocked[0]) return;
		Enemy enemy=warController.GetClosestEnemy(commander.transform.position,commander.Range);
		if (enemy==null) return;
		GameObject spawned=warController.objectPool.SpawnFromPool("KarFirtinasi",enemy.transform.position,Quaternion.identity);
		SummonAttackerDevamli area=spawned.GetComponent<SummonAttackerDevamli>();
		area.commander=commander; area.damage=damage;
		spawned.transform.localScale=isUnlocked[2] ? new Vector3(1.5f,1.5f,1.5f) : Vector3.one; area.effectType=2; area.effectPower=2f; area.effectSecond=isUnlocked[1] ? 2f : 4f;
	}
}
