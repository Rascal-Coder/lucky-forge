using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

[CreateAssetMenu(menuName = "Skills/Mistik/Mistik12")]
public class Mistik12 : Skill
{
	[CompilerGenerated]
	private sealed class _003CShootProjectiles_003Ed__1 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public WarController warController;

		public Commander commander;

		public bool[] isUnlocked;

		public long damage;

		public int adet;

		private int _003Ci_003E5__2;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CShootProjectiles_003Ed__1(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	public override void Execute(Commander commander, WarController warController, bool[] isUnlocked, long damage)
	{
		// Offline recovery candidate; native RVA 0x1f68b30.
		if (isUnlocked[0]) commander.StartCoroutine(ShootProjectiles(commander,warController,isUnlocked,damage,isUnlocked[2] ? 10 : 6));
	}

	private IEnumerator ShootProjectiles(Commander commander, WarController warController, bool[] isUnlocked, long damage, int adet)
	{
		// Offline recovery candidate; native RVA 0x1f68c7c.
		for (int i=0;i<adet;i++)
		{
		 Enemy enemy=warController.GetClosestEnemy(commander.transform.position,commander.Range);
		 if (enemy!=null)
		 {
		  SkillProjectile projectile=warController.objectPool.SpawnSkillProjectile("LightBallAxe",commander.projectilePivot.transform.position,commander.transform.rotation);
		  projectile.speed=30f; projectile.range=commander.Range; projectile.LastHitType=0; projectile.sekmesayisi=0; projectile.afterHitGOname="NormalHit";
		  projectile.SummonAttackerControl=false; projectile.effectPower=1f; projectile.effectSecond=1f;
		  projectile.effectType=isUnlocked[1] ? 1 : 0; projectile.scale=1f; projectile.damage=damage; projectile._HedefEnemiyse=enemy;
		  
		  projectile.commander=commander; projectile.Launch(enemy.transform.position); projectile.gameObject.SetActive(true);
		 }
		 yield return new WaitForSeconds(0.15f);
		}
	}
}
