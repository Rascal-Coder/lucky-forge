using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	private class PoisonEffect
	{
		public long DamagePerSecond;

		public float Duration;
	}

	private class BurnEffect
	{
		public long InitialDamagePerSecond;

		public float Duration;

		public float ScalingFactor;
	}

	public int VerdigiCoin = 1;

	public WarController warController;

	public SpriteRenderer icon;

	private Vector3 DeathPosition;

	private Vector3 ShieldPosition;

	public UnitDatas unitData;

	public int AttackDamage;

	public int SkillExp = 1;

	public Transform Char;

	public string deathParticle;

	public bool boss;

	public bool guildboss;

	public bool dead;

	public bool shocked;

	private float shockedtimer;

	public Animator anim;

	public CollectedUnitsSpin collectspin;

	public bool WallShockMe;

	private bool wallshocking;

	private float timerwallshocking;

	private int DahaFazlaHasarAl;

	private int DahaFazlaHasarAl2;

	private int VerdigiExtraCoin;

	public int ChefNumber = -1;

	private List<PoisonEffect> activePoisons = new List<PoisonEffect>();

	private List<BurnEffect> activeBurns = new List<BurnEffect>();

	private const float minZ = -34f;

	public long MaxHealthCarpani;

	public Rigidbody rigidbody;

	[Header("DungeonlaAlakaliysaa")]
	public int DungeonHpArtisi;

	[Header("DailyWarsise")]
	public int DailyWarHpArtisi;

	[Header("Chef")]
	public bool chef;

	private Vector3 spawnPoint;

	private Vector3 moveDirection = Vector3.back;

	private float lastKnockbackTime = -999f;

	private float knockbackCooldown = 1f;

	public float burnTimer;

	public float poisonTimer;

	private void OnEnable()
	{
		// Offline recovery candidate; native RVA 0x220375c.
		activePoisons.Clear();
		activeBurns.Clear();
		spawnPoint = transform.position;
		DeathPosition = new Vector3(spawnPoint.x,0f,warController.CastlePos.position.z);
		rigidbody.constraints = (RigidbodyConstraints)116;
		rigidbody.linearVelocity = Vector3.zero;
		rigidbody.angularVelocity = Vector3.zero;
		transform.rotation = Quaternion.Euler(0f,0f,0f);
		dead = false;
		WallShockMe = false;
		wallshocking = false;
		anim.speed = 1f;
		DahaFazlaHasarAl = DahaFazlaHasarAl2 = VerdigiExtraCoin = 0;
		timerwallshocking = 0f;
		unitData.MaxHealth = HpStartData();
		unitData.health = unitData.MaxHealth;
		warController.remoteSettings.texts[5].text = "Enemy HP: " + HpStartData().ToString();
		warController.remoteSettings.texts[6].text = "DPSten Eklenen: " + ((long)(warController.collectedDpsNedir * (double)warController.DpsEnemyCarpanReel())).ToString();
		warController.RegisterEnemy(this);
		shocked = false;
		if (boss) warController.bosscominginfoobj.SetActive(true);
	}

	public long HpStartData()
	{
		// Offline recovery candidate; native RVA 0x2203ae8.
		return RecoveredSpawnMath.EnemyHealth(new RecoveredSpawnMath.HealthInput {
		    LiveWave = warController.currentWaveIndex,
		    GameManagerLevel = GameManager.Level,
		    DungeonLevel = WarController.DungeonLevel,
		    SelectedDungeonCompletionLevel = WarController.Dungeondayim ? GameManager.DungeonLevels[DungeonUi.choosenDungeon] : 0,
		    DailyWars = GunlukWars.dailyWars,
		    Boss = boss, GuildBoss = guildboss, Dungeon = WarController.Dungeondayim, Daily = WarController.DailyWardayim,
		    MaxHealthMultiplier = MaxHealthCarpani, BossMultiplier = warController.BossHpCarpan,
		    BaseBonus = warController.enemiesbonushp, GrowthBonus = warController.enemiesbonushpARTAN,
		    BossTier = warController.bossCarpanTier,
		    BossHealthDecrease = PlayerData.TalentStats.BossDecreaseHealth,
		    EnemyHealthDecrease = PlayerData.TalentStats.EnemyDecreaseHealth,
		    CollectibleEnemyHealthDecrease = PlayerData.collectibles.EnemyDecreaseHealth,
		    CollectedDps = warController.collectedDpsNedir,
		    DpsEnemyBase = warController.DpsEnemyCarpan, DpsEnemyIncrease = warController.DpsEnemyCarpanArtan,
		    DpsBossBase = warController.DpsBossCarpan, DpsBossIncrease = warController.DpsBossCarpanArtan
		});
	}

	private void OnDisable()
	{
		// Offline recovery candidate; native RVA 0x2203ebc.
		warController.UnregisterEnemy(this);
	}

	private void FixedUpdate()
	{
		// Offline recovery candidate; native RVA 0x2203ed8.
		if (WarController.StopGame || !isActiveAndEnabled || !rigidbody) return;
		Vector3 position = rigidbody.position;
		if (unitData.knockback)
		    position -= (moveDirection * unitData.knockbackmeter) * Time.fixedDeltaTime;
		else if (!unitData.frozen && !shocked && position.z > -34f)
		    position += (moveDirection * unitData.RunSpeed()) * Time.fixedDeltaTime;
		position.z = Mathf.Max(position.z,-34f);
		rigidbody.MovePosition(position);
	}

	private void Update()
	{
		// Offline recovery candidate; native RVA 0x2204084.
		if (shocked)
		{
		    shockedtimer += Time.deltaTime;
		    if (shockedtimer > 0.20000000298023224f) { shocked = false; shockedtimer = 0f; }
		}
		if (unitData.frozen)
		{
		    unitData.freezetime -= Time.deltaTime;
		    if (unitData.freezetime < 0f) { unitData.frozen = false; unitData.freezetime = 1.5f; }
		}
		if (activePoisons.Count > 0) UpdatePoisonEffects(Time.deltaTime);
		if (activeBurns.Count > 0) UpdateBurnEffects(Time.deltaTime);
		if ((transform.position.x > 70f || transform.position.x < -70f) && !dead) { Die(); dead = true; }
		if (WallShockMe && wallshocking)
		{
		    timerwallshocking += Time.deltaTime;
		    if (timerwallshocking > (float)PlayerData.mainWallEffect.DusmanlarShockSaniye)
		    { wallshocking = false; anim.speed = 1f; timerwallshocking = 0f; }
		}
	}

	public void TakeDamage(long damage, bool anakaraktervurdu = false, int damagetype = 0)
	{
		// Offline recovery candidate; native RVA 0x2204ac0.
		damage = RecoveredBattleMath.DamageReceived(damage,shocked,unitData.frozen,
		    PlayerData.KiyafetData.StunOlanDusmanlarSaldiriArtisi,DahaFazlaHasarAl,DahaFazlaHasarAl2,boss,PlayerData.dailyFortune.BossDamage);
		unitData.health = unchecked(unitData.health - damage);
		unitData.damageDealed = 1f;
		warController.SwordSesVer();
		if (guildboss) warController.guildbossdamagedealt = unchecked(warController.guildbossdamagedealt + damage);
		if (unitData.health <= 0 && !dead) { Die(); dead = true; }
		if (damage >= 1 && !MenuGeneralSettings.CloseTextObjects) warController.TextVer(damage,transform.position,damagetype);
	}

	private void Die()
	{
		// Offline recovery candidate; native RVA 0x2204764.
		if (!MenuGeneralSettings.CloseTextObjects)
		    warController.objectPool.SpawnFromPool(deathParticle,new Vector3(transform.position.x,0f,transform.position.z),Quaternion.identity,false,false);
		warController.AddSilver((float)unchecked(VerdigiCoin + VerdigiExtraCoin));
		warController.KesilenDusmanSayisi = unchecked(warController.KesilenDusmanSayisi + 1);
		SoundManager.instance.RandomizeSfx(SoundManager.coindrop);
		if (collectspin != null && warController.CastleHp >= 1) collectspin.StartSpin();
		if (boss || chef)
		{
		    if (GameManager.BankadaBirikenCrystal < 1000)
		    {
		        GameManager.BankadaBirikenCrystal = unchecked(GameManager.BankadaBirikenCrystal + 10);
		        ES3.Save<int>("BankadaBirikenCrystal",GameManager.BankadaBirikenCrystal);
		    }
		    warController.KesilenBossSayisi = unchecked(warController.KesilenBossSayisi + 1);
		    MerdivenEventManager.MerdivenMateryali = unchecked(MerdivenEventManager.MerdivenMateryali + 2);
		    if (boss) warController.BossDestroyed(4,-1);
		    else warController.BossDestroyed(warController.ChefRewards[warController.siradakiChef-1],ChefNumber);
		}
		gameObject.SetActive(false);
	}

	public void Freeze(float freezetime)
	{
		// Offline recovery candidate; native RVA 0x2204d84.
		unitData.freezetime = freezetime; unitData.frozen = true;
	}

	public void KnockBack(float knockmeter)
	{
		// Offline recovery candidate; native RVA 0x2204da4.
		if (Time.time - lastKnockbackTime < knockbackCooldown) return;
		unitData.knockbackmeter = knockmeter;
		unitData.knockback = true;
		lastKnockbackTime = Time.time;
	}

	public void DefansKir(int yuzde)
	{
		// Offline recovery candidate; native RVA 0x2204dfc.
		DahaFazlaHasarAl2 = yuzde;
	}

	public void ExtraCoinVer(int kac)
	{
		// Offline recovery candidate; native RVA 0x2204e04.
		VerdigiExtraCoin = kac;
	}

	public void Slow(float slowpower, float slowtimer)
	{
		// Offline recovery candidate; native RVA 0x2204e0c.
		if (unitData.slowyedi) return;
		unitData.slowpower = slowpower;
		unitData.slowmaxtimer = slowtimer;
		unitData.slowyedi = true;
	}

	public void AddBurnEffect(long initialDamage, float newDuration, float scalingFactor)
	{
		// Offline recovery candidate; native RVA 0x2204e3c.
		int percent = PlayerData.KiyafetData.AlevHasariArtisi;
		if (percent >= 1) initialDamage = unchecked(initialDamage + (long)((float)unchecked(initialDamage * (long)percent) / 100f));
		TakeDamage((long)((float)initialDamage * 0.5f),false,1);
		if (activeBurns.Count <= 4)
		    activeBurns.Add(new BurnEffect { InitialDamagePerSecond = initialDamage, Duration = newDuration, ScalingFactor = scalingFactor });
	}

	public void AddPoisonEffect(long newDamage, float newDuration)
	{
		// Offline recovery candidate; native RVA 0x220502c.
		int percent = PlayerData.KiyafetData.PoisonHasariArtisi;
		if (percent >= 1) newDamage = unchecked(newDamage + (long)((float)unchecked(newDamage * (long)percent) / 100f));
		TakeDamage((long)((float)newDamage * 0.5f),false,2);
		if (activePoisons.Count <= 4)
		    activePoisons.Add(new PoisonEffect { DamagePerSecond = newDamage, Duration = newDuration });
	}

	private void UpdatePoisonEffects(float deltaTime)
	{
		// Offline recovery candidate; native RVA 0x2204280.
		poisonTimer += deltaTime;
		while (poisonTimer >= 0.5f)
		{
		    poisonTimer -= 0.5f;
		    long damage = 0;
		    foreach (PoisonEffect effect in activePoisons)
		        damage = unchecked(damage + (long)((float)effect.DamagePerSecond * 0.5f));
		    TakeDamage(damage,false,2);
		}
		for (int i = activePoisons.Count - 1; i >= 0; i--)
		{
		    PoisonEffect effect = activePoisons[i];
		    effect.Duration -= deltaTime;
		    if (effect.Duration <= 0f) activePoisons.RemoveAt(i);
		}
	}

	private void UpdateBurnEffects(float deltaTime)
	{
		// Offline recovery candidate; native RVA 0x22044e0.
		burnTimer += deltaTime;
		while (burnTimer >= 0.5f)
		{
		    burnTimer -= 0.5f;
		    long damage = 0;
		    foreach (BurnEffect effect in activeBurns)
		        damage = unchecked(damage + (long)(((effect.ScalingFactor + 1f) * (float)effect.InitialDamagePerSecond) * 0.15000000596046448f));
		    TakeDamage(damage,false,1);
		}
		for (int i = activeBurns.Count - 1; i >= 0; i--)
		{
		    BurnEffect effect = activeBurns[i];
		    effect.Duration -= deltaTime;
		    if (effect.Duration <= 0f) activeBurns.RemoveAt(i);
		}
	}

	public void Attack()
	{
		// Offline recovery candidate; native RVA 0x2205218.
		if (WarController.StopGame) return;
		if (PlayerData.mainWallEffect.DusmanlarIskaGecer >= 1 && UnityEngine.Random.Range(0,100) < (float)PlayerData.mainWallEffect.DusmanlarIskaGecer)
		{
		    if (!MenuGeneralSettings.CloseTextObjects) warController.TextVer(-200L,transform.position,0);
		    return;
		}
		warController.CastleTakeDamage((long)AttackDamage);
		if (PlayerData.mainWallEffect.HealthDusurYuzde >= 1 && UnityEngine.Random.Range(0,100) < (float)PlayerData.mainWallEffect.HealthDusurYuzde)
		    TakeDamage((long)((float)unchecked(unitData.health * 2L) / 100f),false,0);
	}

	private void OnTriggerEnter(Collider other)
	{
		// Offline recovery candidate; native RVA 0x2205434.
		if (other.tag == "Castle")
		{
		    if (PlayerData.mainWallEffect.DusmanlarShockSaniye >= 1 && !WallShockMe)
		    {
		        anim.speed = 0.05000000074505806f;
		        warController.objectPool.SpawnFromPool("Frozen",new Vector3(transform.position.x,0f,transform.position.z),Quaternion.identity,false,false);
		        WallShockMe = true;
		        wallshocking = true;
		    }
		    if (PlayerData.mainWallEffect.DusmanlarDahaFazlaHasarYer >= 1)
		        DahaFazlaHasarAl = PlayerData.mainWallEffect.DusmanlarDahaFazlaHasarYer;
		    if (anim && anim.isActiveAndEnabled) anim.Play("Base Layer.attack",0,0f);
		    rigidbody.constraints = (RigidbodyConstraints)124;
		}
		if (other.tag == "iceYer") unitData.slowAEO = true;
		if (other.tag == "Death") TakeDamage(unitData.MaxHealth,false,0);
	}

	private void OnTriggerExit(Collider other)
	{
		// Offline recovery candidate; native RVA 0x2205748.
		if (other.tag == "iceYer") unitData.slowAEO = false;
	}
}
