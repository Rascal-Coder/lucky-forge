using UnityEngine;

[CreateAssetMenu(menuName = "Skills/Mistik/Mistik11")]
public class Mistik11 : Skill
{
	public override void Execute(Commander commander, WarController warController, bool[] isUnlocked, long damage)
	{
		// Offline recovery candidate; native RVA 0x1f688d8.
		if (!isUnlocked[0]) return;
		Enemy enemy=warController.GetClosestEnemy(commander.transform.position,commander.Range);
		if (enemy==null) return;
		GameObject spawned=warController.objectPool.SpawnFromPool("BuzLazeri",commander.projectilePivot.transform.position,commander.transform.rotation);
		LaserTek laser=spawned.GetComponent<LaserTek>(); laser.range=commander.Range; laser.commander=commander;
		laser.atanObject=commander.projectilePivot.transform;
		laser.effectType=isUnlocked[1] ? 7 : 2; laser.effectPower=2f; laser.effectSecond=1f;
		laser.damage=unchecked(damage << (isUnlocked[2] ? 0 : 1));
		laser.gameObject.SetActive(true);
	}
}
