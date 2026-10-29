using UnityEngine;

public class UnitDatas : MonoBehaviour
{
	public long MaxHealth = 50L;

	public long health = 50L;

	[HideInInspector]
	public long damage = 10L;

	public float runspeedStart = 5f;

	public float runSpeedRandom;

	public bool isInAttackRange;

	public bool frozen;

	public float freezetime;

	public float freeresettertimer;

	public bool knockback;

	public float knockbacktime;

	public float knockbackmeter;

	public bool slowyedi;

	public float slowpower = 1f;

	private float slowtimer;

	public float slowmaxtimer;

	public bool slowAEO;

	private float slowAEOtimer;

	[Header("Canvas")]
	public float damageDealed;

	public PoolObject poolObjects;

	public float RunSpeed()
	{
		// Offline recovery candidate; native RVA 0x204ed8c.
		return Mathf.Clamp(runSpeedRandom * 0.6499999761581421f / Mathf.Clamp(slowpower,1f,6f),1f,20f);
	}

	private void OnEnable()
	{
		// Offline recovery candidate; native RVA 0x204edd4.
		runSpeedRandom = runspeedStart + UnityEngine.Random.Range(-0.20000000298023224f,2f);
		slowyedi = false; frozen = false; slowpower = 1f; slowtimer = 0f;
	}

	private void OnDisable()
	{
		// Offline recovery candidate; native RVA 0x204ee20.
		poolObjects.ReturnToPool(gameObject.name,gameObject);
	}

	private void Update()
	{
		// Offline recovery candidate; native RVA 0x204ee78.
		if (slowyedi)
		{
		    slowtimer += Time.deltaTime;
		    if (slowtimer > slowmaxtimer) { slowyedi = false; slowpower = 1f; slowtimer = 0f; }
		}
		if (slowAEO)
		{
		    slowAEOtimer += Time.deltaTime;
		    if (slowAEOtimer > 2f) { slowAEOtimer = 0f; slowAEO = false; }
		}
		if (knockback)
		{
		    knockbacktime += Time.deltaTime;
		    if (knockbacktime > 0.18000000715255737f) { knockbacktime = 0f; knockback = false; }
		}
	}
}
