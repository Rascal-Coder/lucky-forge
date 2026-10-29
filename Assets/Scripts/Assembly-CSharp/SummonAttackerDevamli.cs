using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SummonAttackerDevamli : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CDamageRoutine_003Ed__16 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public SummonAttackerDevamli _003C_003E4__this;

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
		public _003CDamageRoutine_003Ed__16(int _003C_003E1__state)
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

	[CompilerGenerated]
	private sealed class _003CDeactivateAfterDuration_003Ed__18 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public SummonAttackerDevamli _003C_003E4__this;

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
		public _003CDeactivateAfterDuration_003Ed__18(int _003C_003E1__state)
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

	public Collider coll;

	public PoolObject pool;

	public string poolName;

	public long damage;

	public long damageCalculated;

	public float activeDuration = 2f;

	public float damageInterval = 0.5f;

	private List<Enemy> enemiesInZone = new List<Enemy>();

	private Coroutine damageCoroutine;

	public int effectType;

	public float effectPower;

	public float effectSecond;

	public Commander commander;

	public WarController warController;

	private void OnEnable()
	{
		// Offline recovery candidate; native RVA 0x2047554.
		coll.enabled=true;
		damageCalculated=unchecked((long)((float)damage/activeDuration)+50L);
		damageCoroutine=StartCoroutine(DamageRoutine()); StartCoroutine(DeactivateAfterDuration());
	}

	private void OnDisable()
	{
		// Offline recovery candidate; native RVA 0x20476c4.
		pool.ReturnToPool(poolName,gameObject);
	}

	private IEnumerator DamageRoutine()
	{
		// Offline recovery candidate; native RVA 0x2047cdc.
		while (true)
		{
		 for (int i=enemiesInZone.Count-1;i>=0;i--)
		 {
		  if (enemiesInZone[i]!=null) DealDamage(enemiesInZone[i]);
		  else enemiesInZone.RemoveAt(i);
		 }
		 yield return new WaitForSeconds(damageInterval);
		}
	}

	private void DealDamage(Enemy enemy)
	{
		// Offline recovery candidate; native RVA 0x2047724.
		switch(effectType)
		{
		 case 0: enemy.TakeDamage(damageCalculated,false,0); break;
		 case 1: enemy.KnockBack(effectPower); enemy.TakeDamage(damageCalculated,false,0); break;
		 case 2: enemy.Slow(effectPower,effectSecond); enemy.TakeDamage(damageCalculated,false,0); break;
		 case 3: enemy.Freeze(effectSecond); enemy.TakeDamage(damageCalculated,false,0); break;
		 case 4: enemy.AddPoisonEffect(damageCalculated,effectSecond); break;
		 case 5: enemy.AddBurnEffect(damageCalculated,effectSecond,3f); break;
		 case 6: enemy.AddPoisonEffect(damageCalculated,effectSecond); enemy.Slow(effectPower,effectSecond); break;
		 case 7: enemy.TakeDamage(damageCalculated,false,0); enemy.AddPoisonEffect(damageCalculated,effectSecond); enemy.AddBurnEffect(damageCalculated,effectSecond,3f); break;
		 case 8: enemy.TakeDamage(damageCalculated,false,0); enemy.AddBurnEffect(damageCalculated,effectSecond,3f); break;
		 case 9: enemy.TakeDamage(damageCalculated,false,0); enemy.AddPoisonEffect(damageCalculated,effectSecond); break;
		}
		
		if (commander!=null) warController.TotalUiDamages[commander.HeroNum]+=(double)damageCalculated;
	}

	private IEnumerator DeactivateAfterDuration()
	{
		// Offline recovery candidate; native RVA 0x2047ec4.
		yield return new WaitForSeconds(activeDuration);
		StopCoroutine(damageCoroutine); coll.enabled=false; enemiesInZone.Clear();
		yield return new WaitForSeconds(0.3f);
		gameObject.SetActive(false);
	}

	private void OnTriggerEnter(Collider other)
	{
		// Offline recovery candidate; native RVA 0x20479b8.
		if (!other.CompareTag("Enemy")) return;
		Enemy enemy=other.GetComponent<Enemy>();
		if (enemy!=null && !enemiesInZone.Contains(enemy)) enemiesInZone.Add(enemy);
	}

	private void OnTriggerExit(Collider other)
	{
		// Offline recovery candidate; native RVA 0x2047b28.
		if (!other.CompareTag("Enemy")) return;
		Enemy enemy=other.GetComponent<Enemy>();
		if (enemy!=null && enemiesInZone.Contains(enemy)) enemiesInZone.Remove(enemy);
	}
}
