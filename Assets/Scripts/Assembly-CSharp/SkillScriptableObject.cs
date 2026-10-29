using UnityEngine;

[CreateAssetMenu(fileName = "NewSkill", menuName = "Skill System/Skill")]
public class SkillScriptableObject : ScriptableObject
{
	public SkillEffectType effectType;

	public string skillAciklamaTR;

	public SkillRarity skillRarity;

	public Sprite skillIcon;

	public int maxLevel;

	public float artisDegeri;

	[HideInInspector]
	public int currentLevel;
}
