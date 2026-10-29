using UnityEngine;

[CreateAssetMenu(menuName = "Skills/Mistik/Mistik4")]
public class Mistik4 : Skill
{
	public override void Execute(Commander commander, WarController warController, bool[] isUnlocked, long damage)
	{
		// Offline recovery candidate; native RVA 0x1f6ae40.
		if (!isUnlocked[0]) return;
		Enemy enemy=warController.GetClosestEnemy(commander.transform.position,commander.Range);
		if (enemy==null) return;
		SkillProjectile projectile=warController.objectPool.SpawnSkillProjectile("AlevliMizrak",commander.projectilePivot.transform.position,commander.transform.rotation);
		projectile.speed=90f; projectile.range=commander.Range; projectile.LastHitType=0; projectile.sekmesayisi=0; projectile.afterHitGOname="AlevAlan";
		projectile.effectPower=0f; projectile.effectSecond=1f; projectile.effectType=isUnlocked[1] ? 8 : 0;
		projectile.SummonAttackerDevamli=true; if (isUnlocked[2] && UnityEngine.Random.value<0.2f) damage=unchecked(damage*2L);
		projectile.damage=damage; projectile.scale=1f; projectile._HedefEnemiyse=enemy;
		projectile.commander=commander; projectile.Launch(enemy.transform.position); projectile.gameObject.SetActive(true);
	}
}
