using UnityEngine;

[CreateAssetMenu(menuName = "Skills/Mistik/Mistik13")]
public class Mistik13 : Skill
{
	public override void Execute(Commander commander, WarController warController, bool[] isUnlocked, long damage)
	{
		// Offline recovery candidate; native RVA 0x1f68fb0.
		if (!isUnlocked[0]) return;
		Enemy enemy=warController.GetClosestEnemy(commander.transform.position,commander.Range);
		if (enemy==null) return;
		SkillProjectile projectile=warController.objectPool.SpawnSkillProjectile("TuruncuSpike",commander.projectilePivot.transform.position,commander.transform.rotation);
		projectile.speed=50f; projectile.range=commander.Range; projectile.LastHitType=0; projectile.sekmesayisi=0; projectile.afterHitGOname="TuruncuPatlama";
		projectile.effectPower=0f; projectile.effectSecond=1f; projectile.effectType=isUnlocked[1] ? 3 : 0;
		projectile.SummonAttackerControl=true;
		projectile.damage=damage; projectile.scale=1f; projectile._HedefEnemiyse=enemy;
		projectile.commander=commander; projectile.Launch(enemy.transform.position); projectile.gameObject.SetActive(true);
	}
}
