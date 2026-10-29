using UnityEngine;

[CreateAssetMenu(menuName = "Skills/Axe/AxeLegend")]
public class AxeLegend : Skill
{
	public override void Execute(Commander commander, WarController warController, bool[] isUnlocked, long damage)
	{
		// Offline recovery candidate; native RVA 0x1f6785c.
		if (!isUnlocked[0]) return;
		Enemy enemy=warController.GetClosestEnemy(commander.transform.position,commander.Range);
		if (enemy == null) return;
		GameObject spawned=warController.objectPool.SpawnFromPool("KazikMeteor",enemy.transform.position,Quaternion.identity);
		SummonAttackerDevamli area=spawned.GetComponent<SummonAttackerDevamli>();
		area.commander=commander; area.damage=damage;
		spawned.transform.localScale=Vector3.one;
		area.effectType=isUnlocked[1] ? 3 : 0; area.effectPower=0f; area.effectSecond=1f;
	}
}
