using UnityEngine;

[CreateAssetMenu(menuName = "Skills/Mistik/Mistik8")]
public class Mistik8 : Skill
{
	public override void Execute(Commander commander, WarController warController, bool[] isUnlocked, long damage)
	{
		// Offline recovery candidate; native RVA 0x1f6bf3c.
		if (!isUnlocked[0]) return;
		Enemy enemy=warController.GetClosestEnemy(commander.transform.position,commander.Range);
		if (enemy==null) return;
		SkillProjectile projectile=warController.objectPool.SpawnSkillProjectile("SimsekTopu",commander.projectilePivot.transform.position,commander.transform.rotation);
		projectile.speed=140f; projectile.range=commander.Range; projectile.LastHitType=2; projectile.sekmesayisi=isUnlocked[2] ? 14 : 8; projectile.afterHitGOname="ElectricHit";
		projectile.effectPower=0f; projectile.effectSecond=1f; projectile.effectType=isUnlocked[1] ? 3 : 0;
		
		projectile.damage=damage; projectile.scale=1f; projectile._HedefEnemiyse=enemy;
		projectile.commander=commander; projectile.Launch(enemy.transform.position); projectile.gameObject.SetActive(true);
	}
}
