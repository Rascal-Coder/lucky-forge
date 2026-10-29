using UnityEngine;

[CreateAssetMenu(menuName = "Skills/Mace/MaceEpic")]
public class MaceEpic : Skill
{
	public override void Execute(Commander commander, WarController warController, bool[] isUnlocked, long damage)
	{
		// Offline recovery candidate; native RVA 0x1f67d54.
		if (!isUnlocked[0]) return;
		Enemy enemy=warController.GetClosestEnemy(commander.transform.position,commander.Range);
		if (enemy == null) return;
		GameObject spawned=warController.objectPool.SpawnFromPool("iceArea",enemy.transform.position,Quaternion.identity);
		SummonAttackerDevamli area=spawned.GetComponent<SummonAttackerDevamli>();
		area.commander=commander; area.damage=damage;
		spawned.transform.localScale=Vector3.one;
		area.effectType=2; area.effectPower=isUnlocked[1] ? 4f : 2f; area.effectSecond=1.4f;
	}
}
