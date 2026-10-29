using UnityEngine;

[CreateAssetMenu(menuName = "Skills/Mistik/Mistik1")]
public class Mistik1 : Skill
{
	private Vector3[] hedefPos = new Vector3[] {new Vector3(-30f,4f,60f),new Vector3(-22f,4f,60f),new Vector3(-13f,4f,60f),new Vector3(0f,4f,60f),new Vector3(13f,4f,60f),new Vector3(22f,4f,60f),new Vector3(30f,4f,60f),new Vector3(15f,4f,60f)};

	public override void Execute(Commander commander, WarController warController, bool[] isUnlocked, long damage)
	{
		// Offline recovery candidate; native RVA 0x1f68284.
		if (!isUnlocked[0]) return;
		// Native iterates seven entries of its eight-entry constructor array.
		for (int i=0;i<7;i++)
		{
		 SkillProjectile projectile=warController.objectPool.SpawnSkillProjectile("AshArrow",commander.projectilePivot.transform.position,commander.projectilePivot.transform.rotation);
		 projectile.speed=90f; projectile.range=commander.Range; projectile.commander=commander;
		 projectile.LastHitType=isUnlocked[2] && UnityEngine.Random.value<0.1f ? 1 : 0;
		 projectile.sekmesayisi=0; projectile.afterHitGOname="NormalHit"; projectile.effectPower=1f; projectile.effectSecond=0f;
		 projectile.effectType=isUnlocked[1] ? 1 : 0; projectile.scale=1f; projectile.damage=damage; projectile._HedefEnemiyse=null;
		 projectile.varsaNullHedefi=hedefPos[i]; projectile.targetPosition=hedefPos[i]; projectile.Launch(hedefPos[i]); projectile.gameObject.SetActive(true);
		}
	}
}
