public class SkillInstance
{
	public Skill skill;

	public bool[] isUnlocked;

	public float cooldownTimer;

	public bool TriggerByAttack;

	private Commander commander;

	private WarController warController;

	public long Damage()
	{
		// Offline recovery candidate; native RVA 0x1f6c9c8.
		long attack = commander.ATK(false,0);
		long percent = skill.DamagePercentAtLevel(commander.Level);
		return (long)(((float)attack / 100f) * (float)percent);
	}

	public SkillInstance(Skill skill, Commander commander, WarController controller)
	{
		// Offline recovery candidate; native RVA 0x1f6ca50.
		this.skill = skill;
		this.commander = commander;
		this.warController = controller;
		isUnlocked = new bool[skill.requiredLevel.Length];
	}

	public void CheckUnlock()
	{
		// Offline recovery candidate; native RVA 0x1f6cb08.
		for (int i=0; i<isUnlocked.Length; i++) isUnlocked[i] = commander.Level >= skill.requiredLevel[i];
	}

	public void UpdateCooldown(float deltaTime)
	{
		// Offline recovery candidate; native RVA 0x1f6cb90.
		if (skill.triggerByAttack) return;
		cooldownTimer -= deltaTime;
	}

	public bool CanUseSkill()
	{
		// Offline recovery candidate; native RVA 0x1f6cbbc.
		return isUnlocked[0] && (cooldownTimer <= 0f || TriggerByAttack);
	}

	public void TriggerSkill()
	{
		// Offline recovery candidate; native RVA 0x1f6cc10.
		if (!CanUseSkill()) return;
		skill.Execute(commander,warController,isUnlocked,Damage());
		cooldownTimer = skill.cooldown;
	}

	public string NameT(int who)
	{
		// Offline recovery candidate; native RVA 0x1f6cc80.
		return Lang.WeaponSkillTitle(skill.skillName[who] + "Title");
	}

	public string SubtitleT(int who)
	{
		// Offline recovery candidate; native RVA 0x1f6cd30.
		Lang.WeaponSkillHasar = Damage();
		return Lang.WeaponSkillSubtitles(skill.skillName[who]);
	}
}
