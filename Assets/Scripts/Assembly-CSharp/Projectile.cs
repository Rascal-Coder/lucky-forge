using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CDisableAfterParticles_003Ed__40 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Projectile _003C_003E4__this;

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
		public _003CDisableAfterParticles_003Ed__40(int _003C_003E1__state)
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

	public float speedsalt;

	public long attackDamage = 10L;

	public float critChance;

	public double critMultipler;

	public bool anaKaraterVurdu;

	public bool saltolu;

	public float curveOffset = 15f;

	public Transform targetPosition;

	public Enemy _HedefEnemiyse;

	public PoolObject poolObjects;

	public WarController warController;

	public bool sloweffect;

	public bool rotation;

	public bool icindenGecForSkill;

	private bool dogruilerle;

	public bool following;

	private bool isMoving;

	private Vector3 targetNonFollower;

	public TrailRenderer trail;

	private Vector3 direction;

	private Vector3 startPos;

	private Vector3 controlPoint;

	private float t;

	public int atanCommanderNum;

	public float RotateX = 82f;

	public bool selfRotateZ;

	public float selfRotateSpeed = 360f;

	public int effectType;

	public float effectPower;

	public float effectSecond;

	[Header("Explode")]
	public SphereCollider coll;

	public bool explode;

	public ParticleSystem patlama;

	public SpriteRenderer icon;

	public float speed()
	{
		// Offline recovery candidate; native RVA 0x2026b04.
		return Mathf.Clamp(40f + speedsalt * 20f,10f,250f);
	}

	private void OnEnable()
	{
		// Offline recovery candidate; native RVA 0x2026b3c.
		trail.Clear();
		if (explode) { transform.localScale = Vector3.one; coll.enabled = true; icon.enabled = true; }
	}

	private void OnDisable()
	{
		// Offline recovery candidate; native RVA 0x2026bf8.
		poolObjects.ReturnToProjectilePool(gameObject.name,this);
		isMoving = false;
		t = 0f;
		icindenGecForSkill = false;
	}

	public void Launch(Transform targetpos)
	{
		// Offline recovery candidate; native RVA 0x2021664.
		targetPosition = targetpos;
		targetNonFollower = new Vector3(targetpos.position.x,4f,targetpos.position.z);
		dogruilerle = false;
		direction = (targetPosition.position - transform.position).normalized;
		isMoving = true;
		transform.rotation = Quaternion.Euler(RotateX,0f,0f);
		if (saltolu)
		{
		 startPos = transform.position;
		 Vector3 midpoint = (startPos + targetNonFollower) * 0.5f;
		 Vector3 lateral = Vector3.right;
		 float curve = UnityEngine.Random.Range(0,2) == 0 ? -curveOffset : curveOffset;
		 controlPoint = midpoint + lateral * curve;
		 t = 0f;
		}
		UpdateRotation();
	}

	private void FixedUpdate()
	{
		// Offline recovery candidate; native RVA 0x2026c4c.
		if (!isMoving) return;
		Vector3 next;
		if (saltolu)
		{
		 t += Time.deltaTime * (t < 1f ? 1.5f : 1f);
		 float u = 1f-t;
		 next = startPos * (u*u) + controlPoint * (t*(u+u)) + targetNonFollower * (t*t);
		}
		else
		{
		 if (following && targetPosition != null && targetPosition.gameObject.activeSelf && !dogruilerle)
		  direction = (targetPosition.position - transform.position).normalized;
		 if (!targetPosition.gameObject.activeSelf) dogruilerle = true;
		 next = transform.position + direction * speed() * Time.deltaTime;
		}
		transform.position = new Vector3(next.x,4f,next.z);
		if (selfRotateZ) transform.Rotate(0f,0f,-selfRotateSpeed * Time.deltaTime);
	}

	private void HitEffect()
	{
		// Offline recovery candidate; native RVA 0x2026f14.
		if (!icindenGecForSkill) isMoving = false;
		string hitTag = MenuGeneralSettings.CloseTextObjects ? "PerformansHit" : "NormalHit";
		warController.objectPool.SpawnFromPool(hitTag,transform.position,transform.rotation,false,false).gameObject.SetActive(true);
		if (explode)
		{
		 if (gameObject.activeInHierarchy) StartCoroutine(DisableAfterParticles());
		}
		else if (!icindenGecForSkill) gameObject.SetActive(false);
	}

	private IEnumerator DisableAfterParticles()
	{
		// Offline recovery candidate; native RVA 0x202751c.
		patlama.Play(true);
		icon.enabled = false;
		transform.localScale = Vector3.one * 1.899999976158142f;
		yield return new WaitForSeconds(0.10000000149011612f);
		coll.enabled = false;
		yield return new WaitForSeconds(0.800000011920929f);
		gameObject.SetActive(false);
		transform.localScale = Vector3.one;
	}

	public void UpdateRotation()
	{
		// Offline recovery candidate; native RVA 0x20215ac.
		if (!rotation) return;
		Vector3 delta = targetPosition.position - transform.position;
		float angle = Mathf.Atan2(delta.z,delta.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(RotateX,0f,angle);
	}

	private void DealDamage()
	{
		// Offline recovery candidate; native RVA 0x20271c4.
		int damageType = 0;
		if (UnityEngine.Random.Range(0,100) <= critChance)
		{
		 attackDamage = (long)((double)attackDamage * critMultipler / 100.0);
		 damageType = 3;
		}
		_HedefEnemiyse.TakeDamage(attackDamage,anaKaraterVurdu,damageType);
		switch (effectType)
		{
		 case 1: _HedefEnemiyse.KnockBack(effectPower); break;
		 case 2: _HedefEnemiyse.Slow(effectPower,effectSecond); break;
		 case 3: _HedefEnemiyse.Freeze(effectSecond); break;
		 case 4: _HedefEnemiyse.AddPoisonEffect(attackDamage,effectSecond); break;
		 case 5: _HedefEnemiyse.AddBurnEffect(attackDamage,effectSecond,3f); break;
		 case 6: _HedefEnemiyse.DefansKir((int)effectPower); break;
		 case 7: _HedefEnemiyse.ExtraCoinVer((int)effectPower); break;
		}
		float counterMultiplier = effectType == 4 || effectType == 5 ? Mathf.Max(effectSecond,1f) : 1f;
		effectType = 0;
		warController.TotalUiDamages[atanCommanderNum] += (double)(counterMultiplier * (float)attackDamage);
	}

	private void OnTriggerEnter(Collider other)
	{
		// Offline recovery candidate; native RVA 0x20273e0.
		if (other.tag == "Enemy")
		{
		 _HedefEnemiyse = other.GetComponent<Enemy>();
		 DealDamage();
		 sloweffect = false;
		 HitEffect();
		}
		if (other.tag == "Death") { sloweffect = false; gameObject.SetActive(false); }
	}
}
