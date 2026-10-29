using System.Collections.Generic;
using UnityEngine;

public class CommanderSkills : MonoBehaviour
{
	private Commander commander;

	public SkillInstance activeSkills;

	public Skill skill;

	private WarController warController;

	public List<SkillInstance> skillInstances = new List<SkillInstance>();

	public void InitFirst()
	{
		// Offline recovery candidate; native RVA 0x21e2b5c.
		commander = GetComponent<Commander>();
		warController = commander.warController;
		InitializeSkills(skill,warController);
		activeSkills.CheckUnlock();
	}

	public void InitializeSkills(Skill skills, WarController warController)
	{
		// Offline recovery candidate; native RVA 0x21e2bf4.
		// Original reads this.skill; the skills parameter is unused.
		skillInstances.Clear();
		activeSkills = new SkillInstance(skill,commander,warController);
		skillInstances.Add(activeSkills);
	}

	private void OnEnable()
	{
		// Offline recovery candidate; native RVA 0x21e2d44.
		if (commander == null || warController == null)
		{
		 commander = GetComponent<Commander>();
		 warController = commander.warController;
		}
		InitializeSkills(skill,warController);
		activeSkills.CheckUnlock();
	}

	public void CheckAllSkillUnlocks()
	{
		// Offline recovery candidate; native RVA 0x21e2d2c.
		activeSkills.CheckUnlock();
	}

	public void tryAttack()
	{
		// Offline recovery candidate; native RVA 0x21e2e44.
		if (activeSkills.CanUseSkill() && warController.activeEnemies.Count >= 1) activeSkills.TriggerSkill();
	}

	private void Update()
	{
		// Offline recovery candidate; native RVA 0x21e2ec8.
		activeSkills.UpdateCooldown(Time.deltaTime);
	}
}
