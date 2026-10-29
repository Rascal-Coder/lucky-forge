using UnityEngine;

[CreateAssetMenu(menuName = "Skills/Wand/WandEpic")]
public class WandEpic : Skill
{
	public override void Execute(Commander commander, WarController warController, bool[] isUnlocked, long damage)
	{
		// Offline recovery candidate; native RVA 0x1f6d75c.
		if (!isUnlocked[0]) return;
		Enemy enemy=warController.GetRandomEnemyInRange(commander.transform.position,commander.Range*2f);
		if (enemy == null) return;
		SkillProjectile projectile=warController.objectPool.SpawnSkillProjectile("MagicBall1",commander.projectilePivot.transform.position,commander.transform.rotation);
		projectile.speed=20f; projectile.range=commander.Range; projectile.LastHitType=1; projectile.sekmesayisi=0; projectile.afterHitGOname="NormalHit";
		projectile.effectType=isUnlocked[1] ? 1 : 0; projectile.effectPower=3f; projectile.effectSecond=0.6f; projectile.scale=1f; projectile.damage=damage; projectile._HedefEnemiyse=enemy;
		
		projectile.commander=commander; projectile.Launch(enemy.transform.position);
		projectile.gameObject.SetActive(true);
	}
}
