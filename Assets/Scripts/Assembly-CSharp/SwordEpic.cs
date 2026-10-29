using UnityEngine;

[CreateAssetMenu(menuName = "Skills/Sword/SwordEpic")]
public class SwordEpic : Skill
{
	public override void Execute(Commander commander, WarController warController, bool[] isUnlocked, long damage)
	{
		// Offline recovery candidate; native RVA 0x1f6ce40.
		if (!isUnlocked[0]) return;
		Enemy enemy=warController.GetClosestEnemy(commander.transform.position,commander.Range);
		if (enemy == null) return;
		SkillProjectile projectile=warController.objectPool.SpawnSkillProjectile("Simsek",commander.projectilePivot.transform.position,commander.transform.rotation);
		projectile.speed=140f; projectile.range=commander.Range; projectile.LastHitType=2; projectile.sekmesayisi=5; projectile.afterHitGOname="ElectricHit";
		projectile.effectType=isUnlocked[1] && UnityEngine.Random.value < 0.3f ? 3 : 0; projectile.effectPower=0f; projectile.effectSecond=1.2f; projectile.scale=1f; projectile.damage=damage; projectile._HedefEnemiyse=enemy;
		
		projectile.commander=commander; projectile.Launch(enemy.transform.position);
		projectile.gameObject.SetActive(true);
	}
}
