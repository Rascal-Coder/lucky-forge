using UnityEngine;

[CreateAssetMenu(menuName = "Skills/Arrow/ArrowLegend")]
public class ArrowLegend : Skill
{
	public override void Execute(Commander commander, WarController warController, bool[] isUnlocked, long damage)
	{
		// Offline recovery candidate; native RVA 0x1f66c54.
		if (!isUnlocked[0]) return;
		Enemy enemy=warController.GetClosestEnemy(commander.transform.position,commander.Range);
		if (enemy == null) return;
		GameObject spawned=warController.objectPool.SpawnFromPool("PoisonCloud",enemy.transform.position,Quaternion.identity);
		SummonAttacker area=spawned.GetComponent<SummonAttacker>();
		area.commander=commander; area.damage=damage;
		spawned.transform.localScale=Vector3.one;
		area.effectType=isUnlocked[1] ? 6 : 4; area.effectPower=0f; area.effectSecond=2f;
	}
}
