using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SkillProjectile : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CDisableAfterParticles_003Ed__41 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public SkillProjectile _003C_003E4__this;

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
		public _003CDisableAfterParticles_003Ed__41(int _003C_003E1__state)
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

	public float speed;

	public float range;

	public int LastHitType;

	public int sekmesayisi;

	public string afterHitGOname;

	public int effectType;

	public float effectPower;

	public float effectSecond;

	public float scale = 1f;

	public long damage;

	public bool SummonAttackerControl;

	public bool SummonAttackerDevamli;

	private int aktifsekmesayisi;

	public bool rotation;

	public float RotateX = 82f;

	public bool selfRotateZ;

	public float selfRotateSpeed = 360f;

	public Vector3 targetPosition;

	public Enemy _HedefEnemiyse;

	public PoolObject poolObjects;

	public WarController warController;

	private bool isMoving;

	public TrailRenderer trail;

	private Vector3 direction;

	public SphereCollider coll;

	public GameObject icon;

	private bool isDead;

	public bool saltolu;

	public float curveOffset = 15f;

	private Vector3 startPos;

	private Vector3 controlPoint;

	private float t;

	public Commander commander;

	public Vector3 varsaNullHedefi = new Vector3(0f,4f,0f);

	private void OnEnable()
	{
		// Offline recovery candidate; native RVA 0x2041b00.
		if (trail != null) trail.Clear();
		aktifsekmesayisi=0; icon.SetActive(true); coll.enabled=true; isDead=false; t=0f;
		transform.localScale=new Vector3(scale,scale,scale);
	}

	private void OnDisable()
	{
		// Offline recovery candidate; native RVA 0x2041bd0.
		poolObjects.ReturnToSkillProjectilePool(gameObject.name,this);
	}

	public void Launch(Vector3 vv)
	{
		// Offline recovery candidate; native RVA 0x2041c18.
		targetPosition=new Vector3(vv.x,4f,vv.z); startPos=transform.position;
		direction=(targetPosition-startPos).normalized; isMoving=true;
		transform.rotation=Quaternion.Euler(RotateX,90f,90f);
		if (saltolu)
		{
		 Vector3 midpoint=(startPos+targetPosition)*0.5f;
		 controlPoint=midpoint+Vector3.right*(UnityEngine.Random.Range(0,2)==0 ? -curveOffset : curveOffset);
		}
		UpdateRotation();
	}

	private void FixedUpdate()
	{
		// Offline recovery candidate; native RVA 0x2041ed0.
		if (!isMoving) return;
		Vector3 next;
		if (saltolu)
		{
		 t+=Time.deltaTime*(t<1f ? 1f : 0.5f);
		 float u=1f-t;
		 next=startPos*(u*u)+controlPoint*(t*(u+u))+targetPosition*(t*t);
		}
		else next=transform.position+direction*speed*Time.fixedDeltaTime;
		transform.position=new Vector3(next.x,4f,next.z);
	}

	private void DealDamage()
	{
		// Offline recovery candidate; native RVA 0x2042020.
		switch(effectType)
		{
		 case 0: _HedefEnemiyse.TakeDamage(damage,false,0); break;
		 case 1: _HedefEnemiyse.KnockBack(effectPower); _HedefEnemiyse.TakeDamage(damage,false,0); break;
		 case 2: _HedefEnemiyse.Slow(effectPower,effectSecond); _HedefEnemiyse.TakeDamage(damage,false,0); break;
		 case 3: _HedefEnemiyse.Freeze(effectSecond); _HedefEnemiyse.TakeDamage(damage,false,0); break;
		 case 4: _HedefEnemiyse.AddPoisonEffect(damage,effectSecond); break;
		 case 5: _HedefEnemiyse.AddBurnEffect(damage,effectSecond,3f); break;
		 case 6: _HedefEnemiyse.AddPoisonEffect(damage,effectSecond); _HedefEnemiyse.Slow(effectPower,effectSecond); break;
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
		// Offline recovery candidate; native RVA 0x204229c.
		if (isDead) return;
		if (other.CompareTag("Enemy"))
		{
		 _HedefEnemiyse=other.GetComponent<Enemy>(); DealDamage();
		 if (saltolu) return;
		 if (LastHitType!=1)
		 {
		  if (LastHitType==2 && aktifsekmesayisi<sekmesayisi) { aktifsekmesayisi++; OrbuSektir(); }
		  else StartCoroutine(DisableAfterParticles());
		 }
		}
		if (other.CompareTag("Death")) StartCoroutine(DisableAfterParticles());
	}

	private void OrbuSektir()
	{
		// Offline recovery candidate; native RVA 0x2042448.
		Enemy next=warController.GetClosestEnemyExept(transform.position,_HedefEnemiyse);
		if (next==null) { StartCoroutine(DisableAfterParticles()); return; }
		Vector3 destination=next.transform.position;
		targetPosition=new Vector3(destination.x,4f,destination.z); startPos=transform.position;
		direction=(targetPosition-startPos).normalized; t=0f; UpdateRotation();
		if (saltolu) controlPoint=(startPos+targetPosition)*0.5f+Vector3.right*(UnityEngine.Random.Range(0,2)==0 ? -curveOffset : curveOffset);
	}

	private IEnumerator DisableAfterParticles()
	{
		// Offline recovery candidate; native RVA 0x204296c.
		GameObject hit=warController.objectPool.SpawnFromPool(afterHitGOname,transform.position,Quaternion.identity);
		hit.gameObject.SetActive(true);
		if (SummonAttackerControl)
		{
		 SummonAttacker area=hit.GetComponent<SummonAttacker>();
		 area.commander=commander; area.damage=damage; area.effectType=effectType; area.effectPower=effectPower; area.effectSecond=effectSecond;
		}
		if (SummonAttackerDevamli)
		{
		 SummonAttackerDevamli area=hit.GetComponent<SummonAttackerDevamli>();
		 area.commander=commander; area.damage=damage; area.effectType=effectType; area.effectPower=effectPower; area.effectSecond=effectSecond;
		}
		isMoving=false; icon.SetActive(false); coll.enabled=false;
		yield return new WaitForSeconds(0.7f);
		gameObject.SetActive(false);
	}

	public void UpdateRotation()
	{
		// Offline recovery candidate; native RVA 0x2041e2c.
		if (!rotation) return;
		Vector3 delta=targetPosition-transform.position;
		float angle=Mathf.Atan2(delta.z,delta.x)*Mathf.Rad2Deg;
		transform.rotation=Quaternion.Euler(RotateX,90f,angle);
	}
}
