using System.Collections.Generic;
using UnityEngine;

public class TalentManager : MonoBehaviour
{
	public List<Talent> TalentsList = new List<Talent>();

	private const string TalentSaveKey = "PlayerTalentsX";

	public Color32[] rarityColorspublic;

	public static Color32[] RarityColors;

	public TalentsUiManager talentsUiManager;

	public static bool[] Kullaniliyor = new bool[40];

	public static int[] maxExps = new int[] { 1, 3, 8, 15, 20, 25, 30, 35, 40, 45, 50, 55, 60, 65, 70, 75, 80, 85, 90, 95, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100 };

	private void Awake()
	{
        // Original ARM64 recovery 0x204a26c.
        RarityColors = rarityColorspublic; TalentsList.Clear();
	}

	private void Start()
	{
        // Original ARM64 recovery 0x204a320.
        if (ES3.KeyExists("KullanilanTalentlar")) Kullaniliyor = ES3.Load<bool[]>("KullanilanTalentlar");
        if (ES3.KeyExists(TalentSaveKey)) LoadTalents(); else { InitializeTalents(); SaveTalents(); }
        ApplyTalents(); DatalariUilaraGir();
        if (talentsUiManager != null) talentsUiManager.LoadChoosenlar();
	}

	public void DatalariUilaraGir()
	{
        // Original ARM64 recovery 0x204b90c.
        for (int i = 0; i < talentsUiManager._talentUis.Length && i < TalentsList.Count; i++)
        {
            var talent = TalentsList[i]; talentsUiManager._talentUis[i].talent = talent;
            if (talent.Level >= talent.MaxLevel) { talent.Level = talent.MaxLevel; talent.CurrentExp = talent.MaxExp(); }
        }
	}

	public bool checkforinfo()
	{
		return false;
	}

	private void InitializeTalents()
	{
        // Original ARM64 recovery 0x204a434.
        TalentsList.Add(new Talent(0, "GoldIncome", 0.10000000149011612f, 10, 1.0f, (RarityTalent)0));
        TalentsList.Add(new Talent(1, "Range", 0.5f, 10, 3.0f, (RarityTalent)0));
        TalentsList.Add(new Talent(2, "BossDecreaseHealth", 3.0f, 10, 0.0f, (RarityTalent)0));
        TalentsList.Add(new Talent(3, "CommonAttackArtisi", 10.0f, 20, 0.0f, (RarityTalent)0));
        TalentsList.Add(new Talent(4, "RareAttackArtisi", 10.0f, 20, 0.0f, (RarityTalent)0));
        TalentsList.Add(new Talent(5, "ExtraParaileBasla", 10.0f, 10, 10.0f, (RarityTalent)0));
        TalentsList.Add(new Talent(6, "CriticalChance", 2.0f, 10, 3.0f, (RarityTalent)0));
        TalentsList.Add(new Talent(7, "SilverIncome", 0.20000000298023224f, 10, 1.0f, (RarityTalent)1));
        TalentsList.Add(new Talent(8, "SpinLevelIncrease", 1.0f, 4, 0.0f, (RarityTalent)1));
        TalentsList.Add(new Talent(9, "Health", 100.0f, 20, 1.0f, (RarityTalent)1));
        TalentsList.Add(new Talent(10, "Attack", 4.0f, 30, 1.0f, (RarityTalent)1));
        TalentsList.Add(new Talent(11, "EpicAttackArtisi", 10.0f, 20, 0.0f, (RarityTalent)1));
        TalentsList.Add(new Talent(12, "EnemyDecreaseHealth", 3.0f, 10, 5.0f, (RarityTalent)1));
        TalentsList.Add(new Talent(13, "AttackSpeed", 10.0f, 10, 0.0f, (RarityTalent)2));
        TalentsList.Add(new Talent(14, "EnemyBalanceMinions", 2.0f, 5, 2.0f, (RarityTalent)2));
        TalentsList.Add(new Talent(15, "WaveTimingDecrease", 0.5f, 5, 1.0f, (RarityTalent)2));
        TalentsList.Add(new Talent(16, "LastStanding", 1.0f, 10, 0.0f, (RarityTalent)2));
        TalentsList.Add(new Talent(17, "LegendaryAttackArtisi", 10.0f, 20, 0.0f, (RarityTalent)2));
        TalentsList.Add(new Talent(18, "EveryWaveSilver", 5.0f, 10, 1.0f, (RarityTalent)3));
        TalentsList.Add(new Talent(19, "MysticAttackArtisi", 10.0f, 20, 1.0f, (RarityTalent)3));
        TalentsList.Add(new Talent(20, "SansTokenEpicArtis", 1.0f, 10, 1.0f, (RarityTalent)3));
        TalentsList.Add(new Talent(21, "SansTokenLegendArtis", 0.5f, 10, 1.0f, (RarityTalent)3));
	}

	public string EnglishNamesTalent(int num)
	{
		return null;
	}

	public void SaveTalents()
	{
        // Original ARM64 recovery 0x2049d78.
        ES3.Save<System.Collections.Generic.List<Talent>>(TalentSaveKey, TalentsList);
	}

	public void LoadTalents()
	{
        // Original ARM64 recovery 0x204b59c.
        TalentsList = ES3.Load<System.Collections.Generic.List<Talent>>(TalentSaveKey); NewFixes();
	}

	private void NewFixes()
	{
        // Original ARM64 recovery 0x204bda4.
        if (TalentsList.Count > 5 && !GameManager.NewUserTapNation && TalentsList[5] != null && TalentsList[5].TargetStat == "ExtraParaileBasla" && TalentsList[5].BaseEffectValue != 10f)
        { TalentsList[5].BaseEffectValue = 10f; TalentsList[5].EffectValue = 10f; }
	}

	public void AddTalent(int num, string targetStat, float effectValue, int maxLevel, float baseEffectValue, RarityTalent rarity, int typeofskill)
	{
	}

	public void UpgradeTalent(int num)
	{
        // Original ARM64 recovery 0x204c108.
        var talent=TalentsList.Find(t=>t.Num==num);
        if(talent!=null && talent.CurrentExp>=talent.MaxExp())
        { talent.UpgradeTalent(); SaveTalents(); ApplyTalents(); }
        if(SoundManager.instance!=null)SoundManager.instance.CashSound(SoundManager.herostone);
	}

	public void ApplyTalents()
	{
        // Original ARM64 recovery 0x204b618.
        // Native constructs a local TalentData but does not assign it to PlayerData.TalentStats.
        new PlayerData.TalentData();
        for (int i = 0; i < TalentsList.Count; i++)
        {
            var talent = TalentsList[i]; var field = typeof(PlayerData.TalentData).GetField(talent.TargetStat);
            if (field != null && Kullaniliyor[i])
            { field.GetValue(PlayerData.TalentStats); field.SetValue(PlayerData.TalentStats, talent.GetTotalEffect()); }
        }
	}

	public void ClearTalent(string target)
	{
        // Original ARM64 recovery 0x204c2a4.
        foreach (var talent in TalentsList)
        {
            var field = typeof(PlayerData.TalentData).GetField(target);
            if (field != null) field.SetValue(PlayerData.TalentStats, 0);
        }
	}

	public void ShowTalents()
	{
	}
}
