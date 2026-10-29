using UnityEngine;

[CreateAssetMenu(menuName = "Skills/Axe/AxeRare")]
public class AxeRare : Skill
{
	public override void Execute(Commander commander, WarController warController, bool[] isUnlocked, long damage)
	{
		// Offline recovery candidate; native RVA 0x1f67ab0.
		if (!isUnlocked[0]) return;
		if (!(UnityEngine.Random.value < 0.15f)) return;
		Enemy enemy=warController.GetClosestEnemy(commander.transform.position,commander.Range);
		if (enemy == null) return;
		GameObject spawned=warController.objectPool.SpawnFromPool("TornadoKucuk",enemy.transform.position,Quaternion.identity);
		SummonAttackerDevamli area=spawned.GetComponent<SummonAttackerDevamli>();
		area.commander=commander; area.damage=damage;
		spawned.transform.localScale=Vector3.one;
		area.effectType=0; area.effectPower=0f; area.effectSecond=3f;
	}
}
