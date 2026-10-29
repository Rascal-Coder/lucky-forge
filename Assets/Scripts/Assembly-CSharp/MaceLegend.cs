using UnityEngine;

[CreateAssetMenu(menuName = "Skills/Mace/MaceLegend")]
public class MaceLegend : Skill
{
	public override void Execute(Commander commander, WarController warController, bool[] isUnlocked, long damage)
	{
		// Offline recovery candidate; native RVA 0x1f67fa4.
		if (!isUnlocked[0]) return;
		Enemy enemy=warController.GetClosestEnemy(commander.transform.position,commander.Range);
		if (enemy == null) return;
		SkillProjectile projectile=warController.objectPool.SpawnSkillProjectile("MorSpike",commander.projectilePivot.transform.position,commander.transform.rotation);
		projectile.speed=70f; projectile.range=commander.Range; projectile.LastHitType=0; projectile.sekmesayisi=0; projectile.afterHitGOname="MorPatlama";
		projectile.effectType=isUnlocked[1] ? 3 : 0; projectile.effectPower=0f; projectile.effectSecond=1f; projectile.scale=1f; projectile.damage=damage; projectile._HedefEnemiyse=enemy;
		projectile.SummonAttackerControl=true;
		projectile.commander=commander; projectile.Launch(enemy.transform.position);
		projectile.gameObject.SetActive(true);
	}
}
