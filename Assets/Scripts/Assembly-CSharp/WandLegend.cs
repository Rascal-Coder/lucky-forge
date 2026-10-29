using UnityEngine;

[CreateAssetMenu(menuName = "Skills/Wand/WandLegend")]
public class WandLegend : Skill
{
	public override void Execute(Commander commander, WarController warController, bool[] isUnlocked, long damage)
	{
		// Offline recovery candidate; native RVA 0x1f6d9cc.
		if (!isUnlocked[0]) return;
		Enemy enemy=warController.GetClosestEnemy(commander.transform.position,commander.Range);
		if (enemy == null) return;
		GameObject spawned=warController.objectPool.SpawnFromPool("MaviLaser",commander.projectilePivot.transform.position,commander.transform.rotation);
		LaserTek laser=spawned.GetComponent<LaserTek>(); laser.range=commander.Range; laser.effectType=5;
		laser.atanObject=commander.projectilePivot.transform;
		laser.effectType=isUnlocked[1] && UnityEngine.Random.value < 0.4f ? 1 : 0;
		laser.effectPower=2f; laser.effectSecond=1f; laser.damage=damage; laser.commander=commander;
		laser.gameObject.SetActive(true);
	}
}
