using UnityEngine;

[CreateAssetMenu(menuName = "Skills/Mistik/Mistik9")]
public class Mistik9 : Skill
{
	public override void Execute(Commander commander, WarController warController, bool[] isUnlocked, long damage)
	{
		// Offline recovery candidate; native RVA 0x1f6c1d4.
		if (!isUnlocked[0]) return;
		Enemy enemy=warController.GetClosestEnemy(commander.transform.position,commander.Range);
		if (enemy==null) return;
		GameObject spawned=warController.objectPool.SpawnFromPool("YildizYagmuru",enemy.transform.position,Quaternion.identity);
		SummonAttackerDevamli area=spawned.GetComponent<SummonAttackerDevamli>();
		area.commander=commander; area.damage=damage;
		spawned.transform.localScale=Vector3.one;
		area.effectType=isUnlocked[1] ? 2 : 0; area.effectPower=isUnlocked[2] ? 3f : 2f; area.effectSecond=1.5f;
	}
}
