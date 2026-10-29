using UnityEngine;

[CreateAssetMenu(menuName = "Skills/Axe/AxeEpic")]
public class AxeEpic : Skill
{
	public override void Execute(Commander commander, WarController warController, bool[] isUnlocked, long damage)
	{
		// Offline recovery candidate; native RVA 0x1f675f0.
		if (!isUnlocked[0]) return;
		Enemy enemy=warController.GetRandomEnemyInRange(commander.transform.position,commander.Range*2f);
		if (enemy == null) return;
		SkillProjectile projectile=warController.objectPool.SpawnSkillProjectile("DonenBalta",commander.projectilePivot.transform.position,commander.transform.rotation);
		projectile.speed=30f; projectile.range=commander.Range; projectile.LastHitType=1; projectile.sekmesayisi=6; projectile.afterHitGOname="FireHit";
		projectile.effectType=isUnlocked[1] ? 8 : 0; projectile.effectPower=0f; projectile.effectSecond=3f; projectile.scale=1f; projectile.damage=damage; projectile._HedefEnemiyse=enemy;
		
		projectile.Launch(enemy.transform.position); projectile.commander=commander;
		projectile.gameObject.SetActive(true);
	}
}
