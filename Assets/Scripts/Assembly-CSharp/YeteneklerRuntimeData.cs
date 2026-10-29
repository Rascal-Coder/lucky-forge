using System;

[Serializable]
public class YeteneklerRuntimeData
{
	public SkillScriptableObject skill;

	public int currentLevel;

	public string isim;

	public string aciklama;

	public float GetEffectValue()
	{
		return 0f;
	}
}
