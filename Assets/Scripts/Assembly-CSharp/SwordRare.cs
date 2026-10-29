using UnityEngine;

[CreateAssetMenu(menuName = "Skills/Sword/SwordRare")]
public class SwordRare : Skill
{
	public override void Execute(Commander commander, WarController warController, bool[] isUnlocked, long damage)
	{
		// Offline recovery candidate; native RVA 0x1f6d358.
		if (!isUnlocked[0] || !(UnityEngine.Random.value < 0.3f)) return;
		foreach (Enemy enemy in warController.GetClosestEnemiesMulti(commander.transform.position,commander.Range,2))
		{
		 SkillProjectile projectile=warController.objectPool.SpawnSkillProjectile("Bone",commander.projectilePivot.transform.position,commander.transform.rotation);
		 projectile.commander=commander; projectile.speed=60f; projectile.range=commander.Range;
		 projectile.LastHitType=0; projectile.sekmesayisi=0; projectile.afterHitGOname="BoneHit";
		 projectile.effectType=0; projectile.effectPower=0f; projectile.effectSecond=0f; projectile.scale=1f;
		 projectile.damage=damage; projectile._HedefEnemiyse=enemy;
		 projectile.Launch(enemy.transform.position); projectile.gameObject.SetActive(true);
		}
	}
}
