using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

[CreateAssetMenu(menuName = "Skills/Arrow/ArrowRare")]
public class ArrowRare : Skill
{
	[CompilerGenerated]
	private sealed class _003CFireArrowsWithDelay_003Ed__1 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public List<Enemy> targets;

		public WarController warController;

		public Commander commander;

		public long damage;

		public float delay;

		private List<Enemy>.Enumerator _003C_003E7__wrap1;

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
		public _003CFireArrowsWithDelay_003Ed__1(int _003C_003E1__state)
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

		private void _003C_003Em__Finally1()
		{
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	public override void Execute(Commander commander, WarController warController, bool[] isUnlocked, long damage)
	{
		// Offline recovery candidate; native RVA 0x1f66e9c.
		if (!isUnlocked[0] || !(UnityEngine.Random.value < 0.15f)) return;
		List<Enemy> targets = warController.GetClosestEnemiesMulti(commander.transform.position,255f,3);
		if (targets.Count > 0) warController.StartCoroutine(FireArrowsWithDelay(commander,warController,targets,damage,0.2f));
	}

	private IEnumerator FireArrowsWithDelay(Commander commander, WarController warController, List<Enemy> targets, long damage, float delay)
	{
		// Offline recovery candidate; native RVA 0x1f670a0.
		foreach (Enemy enemy in targets)
		{
		 if (enemy == null || !enemy.isActiveAndEnabled) continue;
		 SkillProjectile projectile = warController.objectPool.SpawnSkillProjectile("PoisonedArrow",commander.projectilePivot.transform.position,commander.transform.rotation);
		 projectile.speed=80f; projectile.range=commander.Range;
		 projectile.LastHitType=1; projectile.sekmesayisi=0; projectile.afterHitGOname="PoisonHit";
		 projectile.effectType=9; projectile.effectPower=0f; projectile.effectSecond=1f;
		 projectile.scale=1f; projectile.damage=damage; projectile._HedefEnemiyse=enemy; projectile.commander=commander;
		 projectile.Launch(enemy.transform.position); projectile.gameObject.SetActive(true);
		 yield return new WaitForSeconds(delay);
		}
	}
}
