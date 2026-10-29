using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SummonAttacker : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CDisableAfterParticles_003Ed__18 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public SummonAttacker _003C_003E4__this;

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
		public _003CDisableAfterParticles_003Ed__18(int _003C_003E1__state)
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

	private float closetimer;

	private Enemy _HedefEnemiyse;

	public PoolObject pool;

	public long damage;

	public string poolName;

	public int effectType;

	public float effectPower;

	public float effectSecond;

	public float disableafter = 0.1f;

	public float enabledafter = 1f;

	public float closeafter = 0.8f;

	public Commander commander;

	public WarController warController;

	private void OnEnable()
	{
		// Offline recovery candidate; native RVA 0x2046eb0.
		coll.enabled=false; StartCoroutine(DisableAfterParticles());
	}

	private void Update()
	{
		// Offline recovery candidate; native RVA 0x2046f0c.
		// Original single RET.
	}

	private void HitEffect()
	{
		// Offline recovery candidate; native RVA 0x2046eec.
		StartCoroutine(DisableAfterParticles());
	}

	private void OnDisable()
	{
		// Offline recovery candidate; native RVA 0x2046f7c.
		pool.ReturnToPool(poolName,gameObject);
	}

	private IEnumerator DisableAfterParticles()
	{
		// Offline recovery candidate; native RVA 0x2047358.
		yield return new WaitForSeconds(enabledafter);
		coll.enabled=true;
		yield return new WaitForSeconds(disableafter);
		coll.enabled=false;
		yield return new WaitForSeconds(closeafter);
		gameObject.SetActive(false);
	}

	private void DealDamage(Enemy enemy)
	{
		// Offline recovery candidate; native RVA 0x2046fe0.
		switch(effectType)
		{
		 case 0: enemy.TakeDamage(damage,false,0); break;
		 case 1: enemy.KnockBack(effectPower); enemy.TakeDamage(damage,false,0); break;
		 case 2: enemy.Slow(effectPower,effectSecond); enemy.TakeDamage(damage,false,0); break;
		 case 3: enemy.Freeze(effectSecond); enemy.TakeDamage(damage,false,0); break;
		 case 4: enemy.AddPoisonEffect(damage,effectSecond); break;
		 case 5: enemy.AddBurnEffect(damage,effectSecond,3f); break;
		 case 6: enemy.TakeDamage(damage,false,0); enemy.AddPoisonEffect(damage,effectSecond); break;
		 case 7: _HedefEnemiyse.TakeDamage(damage,false,0); _HedefEnemiyse.AddPoisonEffect(damage,effectSecond); _HedefEnemiyse.AddBurnEffect(damage,effectSecond,3f); break;
		 case 8: _HedefEnemiyse.TakeDamage(damage,false,0); _HedefEnemiyse.AddBurnEffect(damage,effectSecond,3f); break;
		 case 9: _HedefEnemiyse.TakeDamage(damage,false,0); _HedefEnemiyse.AddPoisonEffect(damage,effectSecond); break;
		}
		if (commander != null)
		{
		 float multiplier=(effectType>=4 && effectType<=7) ? Mathf.Max(effectSecond,1f) : 1f;
		 warController.TotalUiDamages[commander.HeroNum]+=(double)(multiplier*(float)damage);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		// Offline recovery candidate; native RVA 0x2047284.
		if (other.tag=="Enemy") { _HedefEnemiyse=other.GetComponent<Enemy>(); DealDamage(_HedefEnemiyse); }
	}
}
