using UnityEngine;

[CreateAssetMenu(menuName = "Skills/Wand/WandRare")]
public class WandRare : Skill
{
	public override void Execute(Commander commander, WarController warController, bool[] isUnlocked, long damage)
	{
		// Offline recovery candidate; native RVA 0x1f6dc3c.
		if (!isUnlocked[0]) return;
		if (!(UnityEngine.Random.value < 0.25f)) return;
		Enemy enemy=warController.GetRandomEnemyInRange(commander.transform.position,commander.Range*2f);
		if (enemy == null) return;
		SkillProjectile projectile=warController.objectPool.SpawnSkillProjectile("AlevBombasi",commander.projectilePivot.transform.position,commander.transform.rotation);
		projectile.speed=50f; projectile.range=commander.Range; projectile.LastHitType=1; projectile.sekmesayisi=6; projectile.afterHitGOname="FireHit";
		projectile.effectType=5; projectile.effectPower=0f; projectile.effectSecond=3f; projectile.scale=1f; projectile.damage=damage; projectile._HedefEnemiyse=enemy;
		
		projectile.commander=commander; projectile.Launch(enemy.transform.position);
		projectile.gameObject.SetActive(true);
	}
}
