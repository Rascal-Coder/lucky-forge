using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class LaserTek : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CLaserRoutine_003Ed__19 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public LaserTek _003C_003E4__this;

		private float _003CelapsedTime_003E5__2;

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
		public _003CLaserRoutine_003Ed__19(int _003C_003E1__state)
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

	public LineRenderer lineRenderer;

	public long damage;

	public float damageInterval = 0.33f;

	public float duration = 3f;

	public float range = 10f;

	public WarController warController;

	private Enemy target;

	public Transform atanObject;

	private bool isFiring;

	public Transform flash;

	public float laserSpeed = 10f;

	private Vector3 laserEndPos;

	public int effectType;

	public float effectPower;

	public float effectSecond;

	public Commander commander;

	private void OnEnable()
	{
		// Offline recovery candidate; native RVA 0x2000e88.
		StartCoroutine(LaserRoutine());
	}

	private void Update()
	{
		// Offline recovery candidate; native RVA 0x2000f14.
		target=warController.GetClosestEnemy(atanObject.transform.position,range); DrawLaser();
	}

	private void DrawLaser()
	{
		// Offline recovery candidate; native RVA 0x2000f78.
		if (target!=null)
		{
		 lineRenderer.enabled=true; lineRenderer.SetPosition(0,atanObject.transform.position);
		 laserEndPos=Vector3.Lerp(laserEndPos,target.transform.position,Time.deltaTime*laserSpeed);
		 lineRenderer.SetPosition(1,laserEndPos); flash.position=laserEndPos; flash.gameObject.SetActive(true);
		}
		else { lineRenderer.enabled=false; flash.gameObject.SetActive(false); }
	}

	private IEnumerator LaserRoutine()
	{
		// Offline recovery candidate; native RVA 0x20012f0.
		float elapsedTime=0f;
		while (elapsedTime<duration)
		{
		 if (target!=null) DealDamage();
		 yield return new WaitForSeconds(damageInterval);
		 elapsedTime+=damageInterval;
		}
		gameObject.SetActive(false);
	}

	private void DealDamage()
	{
		// Offline recovery candidate; native RVA 0x2001164.
		target.TakeDamage(damage,false,0);
		switch(effectType)
		{
		 case 1: target.KnockBack(effectPower); break;
		 case 2: target.Slow(effectPower,effectSecond); break;
		 case 3: target.Freeze(effectSecond); break;
		 case 4: target.AddPoisonEffect(damage,effectSecond); break;
		 case 5: target.AddBurnEffect(damage,effectSecond,3f); break;
		 case 7: target.Slow(effectPower,effectSecond); target.AddBurnEffect(damage,effectSecond,3f); break;
		}
		float multiplier=(effectType>=4 && effectType<=7) ? Mathf.Max(effectSecond,1f) : 1f;
		warController.TotalUiDamages[commander.HeroNum]+=(double)(multiplier*(float)damage);
	}
}
