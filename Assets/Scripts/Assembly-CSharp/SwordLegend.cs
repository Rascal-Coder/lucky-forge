using UnityEngine;

[CreateAssetMenu(menuName = "Skills/Sword/SwordLegend")]
public class SwordLegend : Skill
{
	public override void Execute(Commander commander, WarController warController, bool[] isUnlocked, long damage)
	{
		// Offline recovery candidate; native RVA 0x1f6d0d4.
		if (!isUnlocked[0]) return;
		Enemy enemy=warController.GetClosestEnemy(commander.transform.position,commander.Range);
		if (enemy == null) return;
		GameObject spawned=warController.objectPool.SpawnFromPool("SwordLegend",enemy.transform.position,Quaternion.identity);
		SummonAttacker area=spawned.GetComponent<SummonAttacker>();
		area.commander=commander; area.damage=damage;
		spawned.transform.localScale=Vector3.one;
		if (isUnlocked[1] && UnityEngine.Random.value < 0.2f) spawned.transform.localScale=new Vector3(1.3f,1.3f,1.3f);
	}
}
