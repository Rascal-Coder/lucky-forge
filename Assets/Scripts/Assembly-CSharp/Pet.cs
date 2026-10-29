using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Pet : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CLateShoot_003Ed__44 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Pet _003C_003E4__this;

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
		public _003CLateShoot_003Ed__44(int _003C_003E1__state)
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

	public WarController warController;

	public HeroController heroController;

	public PetPage petPage;

	public string PetName;

	public int Num;

	public float BaslangicAtkSpeed;

	public float BaslangicAtk;

	public int StartLevel;

	public int Level;

	public int LevelExp;

	public int MaxLevel = 30;

	public int BaslangicExp;

	public string DegerSonu = "%";

	public string ProjectileName;

	public int[] BonusLevel = new int[] {0,2,4,8,12,20,30,50,70};

	public int[] SetPetStone = new int[] {50,100,250,700,1200,2000,3500,5000};

	private int[] LevelMaxList = new int[] {2,2,4,8,16,25,50,75};

	public SpriteRenderer icon;

	public Animator petatkanim;

	public ParticleSystem skillparticle;

	private float atkSpeedBonus = 1f;

	public Enemy target;

	public float attacksecond;

	public int NextAttackType;

	public float NextAttackEffectPower;

	public float NextAttackEffectSecond;

	public bool NextAttackIcindenGec;

	public int Bonus(int lvlarti = 0)
	{
		// Offline recovery candidate; native RVA 0x2020034.
		return BonusLevel[unchecked(Level + lvlarti)];
	}

	public int LevelExpMax()
	{
		// Offline recovery candidate; native RVA 0x202006c.
		return LevelMaxList[Level];
	}

	public void AddKartExp(int kart = 1)
	{
		// Offline recovery candidate; native RVA 0x20200a0.
		ilkKezAlindi();
		LevelExp = unchecked(LevelExp + kart);
		ES3.Save<int>("PetExp" + Num.ToString(),LevelExp);
	}

	public float PetAtkSpeed()
	{
		// Offline recovery candidate; native RVA 0x20201d4.
		return BaslangicAtkSpeed + (float)Level * 0.1f;
	}

	public float ShowAtkSpeed()
	{
		// Offline recovery candidate; native RVA 0x20201f4.
		return 3f / (BaslangicAtkSpeed + (float)Level * 0.1f);
	}

	public float PetAtk()
	{
		// Offline recovery candidate; native RVA 0x202021c.
		return BaslangicAtk + (float)Level * 0.1f;
	}

	public bool isUpgradeable()
	{
		// Offline recovery candidate; native RVA 0x202023c.
		return Level < 7;
	}

	public string SkillSubtitle()
	{
		// Offline recovery candidate; native RVA 0x202024c.
		return Lang.MainPetSkillSub(Num,Bonus(0));
	}

	public void LevelUp()
	{
		// Offline recovery candidate; native RVA 0x20202c0.
		int price = SetPetStone[Level];
		if (price > Currencys.PetFood || LevelExp < LevelExpMax())
		{
		 heroController.canvasJobs.OpenGoldYok(-1);
		 return;
		}
		if (Level > 6 || SetPetStone[Level] > Currencys.PetFood || LevelExp < LevelExpMax()) return;
		Currencys.SpendPetFood(SetPetStone[Level],"Meta","PetUpgrade");
		int needed = LevelExpMax();
		Level = unchecked(Level + 1);
		LevelExp = unchecked(LevelExp - needed);
		ES3.Save<int>("PetLevel" + Num.ToString(),Level);
		if (Level >= MaxLevel) { Level = MaxLevel; LevelExp = 0; }
		ES3.Save<int>("PetExp" + Num.ToString(),LevelExp);
		petPage.Upgraded();
	}

	public void LoadData()
	{
        // Recovered from original ARM64 0x20205ec.
        Level = ES3.Load<int>("PetLevel" + Num.ToString(), defaultValue: StartLevel);
        LevelExp = ES3.Load<int>("PetExp" + Num.ToString(), defaultValue: BaslangicExp);
	}

	private void ilkKezAlindi()
	{
		// Offline recovery candidate; native RVA 0x202013c.
		if (Level != 0) return;
		Level = 1;
		ES3.Save<int>("PetLevel" + Num.ToString(),Level);
	}

	public void Use()
	{
		// Offline recovery candidate; native RVA 0x20206bc.
		if (Level == 0) return;
		heroController.currentMainPet = Num;
		ES3.Save<int>("currentMainPet",Num);
		heroController.LoadPets();
	}

	private void OnEnable()
	{
		// Offline recovery candidate; native RVA 0x2020750.
		petatkanim.speed = BaslangicAtkSpeed + (float)Level * 0.1f;
		atkSpeedBonus = 1f;
	}

	private void Update()
	{
		// Offline recovery candidate; native RVA 0x2020798.
		FindClosestEnemy();
		if (Num == 7)
		{
		 atkSpeedBonus = (float)warController.MaxCastleHealth * 0.3f < (float)warController.CastleHp ? 1f : 1f + (float)Bonus(0) * 0.01f;
		 petatkanim.speed = atkSpeedBonus * (BaslangicAtkSpeed + (float)Level * 0.1f);
		}
		if (target != null && Mathf.Abs(-41f - target.transform.position.z) <= 50f)
		{
		 attacksecond += Time.deltaTime;
		 if (!(attacksecond < 3f / (BaslangicAtkSpeed + (float)Level * 0.1f) / atkSpeedBonus))
		 {
		  petatkanim.Play("Base Layer.attack",0,0f);
		  attacksecond = 0f;
		 }
		}
	}

	public void Attack()
	{
		// Offline recovery candidate; native RVA 0x20209b4.
		Skills();
		ShootArrow(target);
	}

	private void Skills()
	{
		// Offline recovery candidate; native RVA 0x20209d0.
		NextAttackType = 0;
		NextAttackEffectPower = 0f;
		NextAttackEffectSecond = 0f;
		NextAttackIcindenGec = false;
		if ((float)UnityEngine.Random.Range(0,100) > (float)Bonus(0)) return;
		skillparticle.Play();
		switch (Num)
		{
		 case 0: NextAttackType = 1; NextAttackEffectPower = 20f; break;
		 case 1: NextAttackType = 2; NextAttackEffectPower = 2f; NextAttackEffectSecond = 3f; break;
		 case 2: NextAttackType = 6; NextAttackEffectPower = 20f; break;
		 case 3: NextAttackType = 7; NextAttackEffectPower = 1f; break;
		 case 4: StartCoroutine(LateShoot()); break;
		 case 5: NextAttackType = 5; NextAttackEffectSecond = 3f; break;
		 case 6: ShootMultiple(3); break;
		 case 8: NextAttackIcindenGec = true; break;
		}
	}

	public void LateShootForSkill()
	{
		// Offline recovery candidate; native RVA 0x2020d94.
		StartCoroutine(LateShoot());
	}

	private IEnumerator LateShoot()
	{
		// Offline recovery candidate; native RVA 0x2021194 / MoveNext 0x2021a1c.
		yield return new WaitForSeconds(0.15f);
		ShootArrow(target);
	}

	private void ShootArrow(Enemy target)
	{
		// Offline recovery candidate; native RVA 0x2020b14.
		if (target == null) return;
		Projectile projectile = warController.objectPool.SpawnProjectile(ProjectileName,transform.position,transform.rotation);
		projectile.targetPosition = target.transform;
		// Explicit casts retain each original ARM64 single-register rounding boundary on Mono.
		float percent = (float)(BaslangicAtk + (float)((float)Level * 0.1f));
		long damage = unchecked((long)(float)((float)(percent * (float)target.unitData.health) / 100f));
		if (target.guildboss) damage = unchecked((long)(float)((float)(percent * 50000f) / 100f));
		projectile.attackDamage = unchecked(damage + 10L);
		projectile.critChance = 0f;
		projectile.critMultipler = 0.0;
		projectile.transform.position = transform.position;
		projectile.UpdateRotation();
		projectile.Launch(target.transform);
		projectile.anaKaraterVurdu = false;
		projectile.icindenGecForSkill = NextAttackIcindenGec;
		projectile.gameObject.SetActive(true);
		projectile.effectType = NextAttackType;
		projectile.effectPower = NextAttackEffectPower;
		projectile.effectSecond = NextAttackEffectSecond;
		warController.ThrowSesVer();
	}

	private void ShootMultiple(int adet)
	{
		// Offline recovery candidate; native RVA 0x2020db4.
		// Native enumeration counts the selected enemies, but every shot uses this.target.
		foreach (Enemy unused in warController.GetClosestEnemiesMulti(transform.position,50f,adet))
		{
		 Projectile projectile = warController.objectPool.SpawnProjectile(ProjectileName,transform.position,transform.rotation);
		 projectile.targetPosition = target.transform;
		 // Same fmul/fadd/fmul/fdiv single precision boundaries as the original extra-shot loop.
		 float percent = (float)(BaslangicAtk + (float)((float)Level * 0.1f));
		 projectile.attackDamage = unchecked((long)(float)((float)(percent * (float)target.unitData.health) / 100f));
		 projectile.critChance = 0f;
		 projectile.critMultipler = 0.0;
		 projectile.transform.position = transform.position;
		 projectile.UpdateRotation();
		 projectile.Launch(target.transform);
		 projectile.anaKaraterVurdu = false;
		 projectile.icindenGecForSkill = NextAttackIcindenGec;
		 projectile.gameObject.SetActive(true);
		 projectile.effectType = NextAttackType;
		 projectile.effectPower = NextAttackEffectPower;
		 projectile.effectSecond = NextAttackEffectSecond;
		 warController.ThrowSesVer();
		}
	}

	private void FindClosestEnemy()
	{
		// Offline recovery candidate; native RVA 0x202095c.
		target = warController.GetCachedClosestEnemy(transform.position,50f);
	}
}
