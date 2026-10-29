using System.Collections.Generic;
using CBS;
using CBS.Models;
using UnityEngine;

public class ClanPerks : MonoBehaviour
{
	private IClan ClanModule;

	private IProfile ProfileModule;

	public int ClanLevel;

	private int TotalDamage;

	private int StartCoin;

	private float WallHp;

	private int AxeAttack;

	private int SwordAttack;

	private int WandAttack;

	private int ArrowAttack;

	private int MaceAttack;

	private int CommonAttack;

	private int RareAttack;

	private int EpicAttack;

	private int LegendAttack;

	private int MysticAttack;

	private float WarIncome;

	private int MaxEnergy;

	public List<Perk> perks;

	public void LoadStart()
	{
	}

	public void UpdatePerks()
	{
	}

	private void OnGet(CBSGetClanFullInfoResult result)
	{
	}

	public void CalculateBonuses()
	{
	}

	public void PlayerDatayaAktar()
	{
	}

	private void Update()
	{
	}
}
