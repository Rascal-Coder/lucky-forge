using UnityEngine;

[CreateAssetMenu(menuName = "Skills/Mistik/Mistik2")]
public class Mistik2 : Skill
{
	public override void Execute(Commander commander, WarController warController, bool[] isUnlocked, long damage)
	{
		// Offline recovery candidate; native RVA 0x1f6a94c.
		if (!isUnlocked[0]) return;
		Enemy enemy=warController.GetClosestEnemy(commander.transform.position,commander.Range*2f);
		if (enemy==null) return;
		SkillProjectile projectile=warController.objectPool.SpawnSkillProjectile("YesilKristal",commander.projectilePivot.transform.position,commander.transform.rotation);
		projectile.speed=140f; projectile.range=commander.Range; projectile.LastHitType=2; projectile.sekmesayisi=8; projectile.afterHitGOname="NormalHit";
		projectile.effectPower=0f; projectile.effectSecond=1f; projectile.effectType=isUnlocked[1] && UnityEngine.Random.value<0.3f ? 2 : 0;
		
		projectile.damage=damage; projectile.scale=1f; projectile._HedefEnemiyse=enemy;
		projectile.Launch(enemy.transform.position); projectile.gameObject.SetActive(true); projectile.commander=commander;
	}
}
