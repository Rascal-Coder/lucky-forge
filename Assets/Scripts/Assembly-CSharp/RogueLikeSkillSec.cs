using System.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RogueLikeSkillSec : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CskillsecildiKapat_003Ed__35 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public RogueLikeSkillSec _003C_003E4__this;

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
		public _003CskillsecildiKapat_003Ed__35(int _003C_003E1__state)
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

	public SlotMachine slotMachine;

	public CommanderSpawner commanderSpawner;

	public List<SkillUnit> SkillList=new List<SkillUnit>();

	public List<SkillUnit> SelectedSkills=new List<SkillUnit>();

	public RaritySkill CurrentRarity;

	public Transform[] skilliconsArea;

	public Color[] rarityHighColors;

	public Material siyahbeyazmat;

	public int rollhakki;

	public GameObject[] skillObj;

	[Header("skillUis")]
	public Color32[] colorsnedir;

	public TextMeshProUGUI[] _skillName;

	public Image[] _colors;

	public TextMeshProUGUI[] _skillSubtitle;

	public Image[] _rarityBackHigh;

	public GameObject[] selectedobjs;

	[Header("genel")]
	public TextMeshProUGUI _paused;

	public TextMeshProUGUI _chooseaskill;

	public TextMeshProUGUI _reroll;

	public Button _rerollbtn;

	public Animator skillsecimanim;

	public TextMeshProUGUI kristaladet;

	public GameObject slotlevelupeff;

	private bool skillsecildi;

	private int skillindexlast;

	private void Start()
	{
		// Recovered from original ARM64 0x202fe40.
		_paused.text=Lang.Get.paused; _chooseaskill.text=Lang.Get.chooseaskill; _reroll.text=Lang.Get.reroll;
	}

	public void OpenSkillPageVarsa()
	{
		// Recovered from original ARM64 0x202ff44.
		if(warController.SkillLevel>=1) gameObject.SetActive(true);
	}

	private void OnEnable()
	{
		// Recovered from original ARM64 0x202ff84.
		SoundManager.instance.RandomizeSfx(SoundManager.runes); SoundManager.instance.CashSound(SoundManager.runes);
		Time.timeScale=0f; skillsecildi=false; for(int i=0;i<3;i++) selectedobjs[i].SetActive(false); SkillSecimAcildi();
	}

	public string GetValueAdd(int key)
	{
		// Recovered from original ARM64 0x2030694.
		int value=(int)SkillList[key].EffectValue;
		switch(key)
		{
		 case 0: return string.Format(Lang.Get.Tier2CommonAtk,value);
		 case 1: return string.Format(Lang.Get.Tier2CommonAtk,value);
		 case 2: return string.Format(Lang.Get.Tier2CommonAtk,value);
		 case 3: return string.Format(Lang.Get.Tier2CommonAtk,value);
		 case 4: return string.Format(Lang.Get.RareAtkIncrease,value);
		 case 5: return string.Format(Lang.Get.RareAtkIncrease,value);
		 case 6: return string.Format(Lang.Get.RareAtkIncrease,value);
		 case 7: return string.Format(Lang.Get.RareAtkIncrease,value);
		 case 8: return string.Format(Lang.Get.EpicAtkIncrease,value);
		 case 9: return string.Format(Lang.Get.EpicAtkIncrease,value);
		 case 10: return string.Format(Lang.Get.EpicAtkIncrease,value);
		 case 11: return string.Format(Lang.Get.EpicAtkIncrease,value);
		 case 12: return string.Format(Lang.Get.LegendaryAtkIncrease,value);
		 case 13: return string.Format(Lang.Get.LegendaryAtkIncrease,value);
		 case 14: return string.Format(Lang.Get.LegendaryAtkIncrease,value);
		 case 15: return string.Format(Lang.Get.LegendaryAtkIncrease,value);
		 case 16: return string.Format(Lang.Get.LegendaryMysticAtkIncrease,value);
		 case 17: return string.Format(Lang.Get.LegendaryMysticAtkIncrease,value);
		 case 18: return string.Format(Lang.Get.ObtainSummonTokens,value);
		 case 19: return string.Format(Lang.Get.ObtainSummonTokens,value);
		 case 20: return string.Format(Lang.Get.ObtainSummonTokens,value);
		 case 21: return string.Format(Lang.Get.ObtainSummonTokens,value);
		 case 22: return string.Format(Lang.Get.IncreaseSpinRarity,value);
		 case 23: return string.Format(Lang.Get.IncreaseSpinRarity,value);
		 case 24: return string.Format(Lang.Get.IncreaseSpinRarity,value);
		 case 25: return string.Format(Lang.Get.IncreaseSpinRarity,value);
		 case 26: return string.Format(Lang.Get.HealCastleHp,value);
		 case 27: return string.Format(Lang.Get.HealCastleHp,value);
		 case 28: return string.Format(Lang.Get.HealCastleHp,value);
		 case 29: return string.Format(Lang.Get.HealCastleHp,value);
		 case 30: return Lang.Get.SummonCommonWeapon;
		 case 31: return Lang.Get.SummonRareWeapon;
		 case 32: return Lang.Get.SummonEpicWeapon;
		 case 33: return Lang.Get.SummonLegendaryWeapon;
		 case 34: return string.Format(Lang.Get.CommonAndRareAtkIncrease,value);
		 case 35: return string.Format(Lang.Get.CommonAndRareAtkIncrease,value);
		 case 36: return string.Format(Lang.Get.MysticAtkIncrease,value);
		 case 37: return string.Format(Lang.Get.MysticAtkIncrease,value);
		 case 38: return string.Format(Lang.Get.MysticAtkIncrease,value);
		 case 39: return string.Format(Lang.Get.MysticAtkIncrease,value);
		 default: return "Unknown";
		}
	}

	public void InitializeSkills()
	{
		// Recovered from original ARM64 0x2030a74.
		// Native InitializeSkills appends the original40 records. Caller clears the list.
		SkillList.Add(new SkillUnit(0, "commonWeaponATK1", 10.0f, 10, (RaritySkill)0, 0, 0));
		SkillList.Add(new SkillUnit(1, "commonWeaponATK2", 20.0f, 10, (RaritySkill)1, 0, 0));
		SkillList.Add(new SkillUnit(2, "commonWeaponATK3", 40.0f, 10, (RaritySkill)2, 0, 0));
		SkillList.Add(new SkillUnit(3, "commonWeaponATK4", 800.0f, 10, (RaritySkill)3, 0, 0));
		SkillList.Add(new SkillUnit(4, "rareWeaponATK1", 10.0f, 10, (RaritySkill)0, 1, 1));
		SkillList.Add(new SkillUnit(5, "rareWeaponATK2", 20.0f, 10, (RaritySkill)1, 1, 1));
		SkillList.Add(new SkillUnit(6, "rareWeaponATK3", 40.0f, 10, (RaritySkill)2, 1, 1));
		SkillList.Add(new SkillUnit(7, "rareWeaponATK4", 80.0f, 10, (RaritySkill)3, 1, 1));
		SkillList.Add(new SkillUnit(8, "epicWeaponATK1", 10.0f, 10, (RaritySkill)0, 3, 2));
		SkillList.Add(new SkillUnit(9, "epicWeaponATK2", 20.0f, 10, (RaritySkill)1, 3, 2));
		SkillList.Add(new SkillUnit(10, "epicWeaponATK3", 40.0f, 10, (RaritySkill)2, 3, 2));
		SkillList.Add(new SkillUnit(11, "epicWeaponATK4", 80.0f, 10, (RaritySkill)3, 3, 2));
		SkillList.Add(new SkillUnit(12, "legendaryWeaponATK1", 10.0f, 10, (RaritySkill)0, 4, 3));
		SkillList.Add(new SkillUnit(13, "legendaryWeaponATK2", 20.0f, 10, (RaritySkill)1, 4, 3));
		SkillList.Add(new SkillUnit(14, "legendaryWeaponATK3", 40.0f, 10, (RaritySkill)2, 4, 3));
		SkillList.Add(new SkillUnit(15, "legendaryWeaponATK4", 80.0f, 10, (RaritySkill)3, 4, 3));
		SkillList.Add(new SkillUnit(16, "legendaryveMistiksWeaponATK1", 10.0f, 10, (RaritySkill)1, 5, 4));
		SkillList.Add(new SkillUnit(17, "legendaryveMistiksWeaponATK2", 50.0f, 10, (RaritySkill)3, 5, 4));
		SkillList.Add(new SkillUnit(18, "token1", 1.0f, 10, (RaritySkill)0, 6, 0));
		SkillList.Add(new SkillUnit(19, "token2", 2.0f, 10, (RaritySkill)1, 6, 0));
		SkillList.Add(new SkillUnit(20, "token3", 3.0f, 10, (RaritySkill)2, 6, 0));
		SkillList.Add(new SkillUnit(21, "token4", 5.0f, 10, (RaritySkill)3, 6, 0));
		SkillList.Add(new SkillUnit(22, "drawlvl1", 1.0f, 10, (RaritySkill)0, 7, 0));
		SkillList.Add(new SkillUnit(23, "drawlvl2", 2.0f, 10, (RaritySkill)1, 7, 0));
		SkillList.Add(new SkillUnit(24, "drawlvl3", 3.0f, 10, (RaritySkill)2, 7, 0));
		SkillList.Add(new SkillUnit(25, "drawlvl4", 3.0f, 10, (RaritySkill)3, 7, 0));
		SkillList.Add(new SkillUnit(26, "life1", 20.0f, 10, (RaritySkill)0, 8, 0));
		SkillList.Add(new SkillUnit(27, "life2", 40.0f, 10, (RaritySkill)1, 8, 0));
		SkillList.Add(new SkillUnit(28, "life3", 60.0f, 10, (RaritySkill)2, 8, 0));
		SkillList.Add(new SkillUnit(29, "life4", 100.0f, 10, (RaritySkill)3, 8, 0));
		SkillList.Add(new SkillUnit(30, "weaponrandom1", 1.0f, 10, (RaritySkill)0, 9, 0));
		SkillList.Add(new SkillUnit(31, "weaponrandom2", 1.0f, 10, (RaritySkill)1, 9, 0));
		SkillList.Add(new SkillUnit(32, "weaponrandom3", 1.0f, 10, (RaritySkill)2, 9, 0));
		SkillList.Add(new SkillUnit(33, "weaponrandom4", 1.0f, 10, (RaritySkill)3, 9, 0));
		SkillList.Add(new SkillUnit(34, "RareveCommonWeaponATK1", 10.0f, 10, (RaritySkill)1, 2, 5));
		SkillList.Add(new SkillUnit(35, "RareveCommonWeaponATK2", 80.0f, 10, (RaritySkill)3, 2, 5));
		SkillList.Add(new SkillUnit(36, "mistikWeaponATK1", 10.0f, 10, (RaritySkill)0, 10, 6));
		SkillList.Add(new SkillUnit(37, "mistikWeaponATK2", 20.0f, 10, (RaritySkill)1, 10, 6));
		SkillList.Add(new SkillUnit(38, "mistikWeaponATK3", 30.0f, 10, (RaritySkill)2, 10, 6));
		SkillList.Add(new SkillUnit(39, "mistikWeaponATK4", 60.0f, 10, (RaritySkill)3, 10, 6));
	}

	public void ApplySkills()
	{
		// Recovered from original ARM64 0x2032930.
		_ = new PlayerData.Skills();
		foreach(SkillUnit skill in SkillList) {
		 if((uint)skill.IconNum>=6u && skill.IconNum!=10) continue;
		 var field=typeof(PlayerData.Skills).GetField(skill.TargetStat);
		 if(field!=null) { _ = field.GetValue(PlayerData.SkillsStats); field.SetValue(PlayerData.SkillsStats,skill.EffectValue*skill.Level); }
		}
	}

	public void SkillSecimAcildi()
	{
		// Recovered from original ARM64 0x203013c.
		IEnumerable<SkillUnit> choices=SkillList.Where(s=>s.Rarity==CurrentRarity && s.Level<s.MaxLevel);
		if(warController.CastleHp>warController.MaxCastleHealth/2) choices=choices.Where(s=>s.IconNum!=8);
		if(slotMachine.currentLevel>=19) choices=choices.Where(s=>s.IconNum!=7);
		if(commanderSpawner.currentCommanderCount>=20) choices=choices.Where(s=>s.IconNum!=9);
		if(GameManager.Level<=1) choices=choices.Where(s=>s.IconNum!=6);
		SelectedSkills=choices.ToList().OrderBy(s=>UnityEngine.Random.value).Take(3).ToList();
		for(int i=0;i<3;i++) { if(i<SelectedSkills.Count) { SkillBilgiGir(i); skillObj[i].SetActive(true); } else skillObj[i].SetActive(false); }
		skillsecildi=false;
	}

	private void SkillBilgiGir(int num)
	{
		// Recovered from original ARM64 0x2032bb8.
		SkillUnit skill=SelectedSkills[num];
		_colors[num].color=colorsnedir[(int)skill.Rarity]; _skillName[num].text="Card";
		for(int i=0;i<skilliconsArea[num].childCount;i++) skilliconsArea[num].GetChild(i).gameObject.SetActive(i==skill.IconNum);
		_skillSubtitle[num].text=GetValueAdd(skill.Num); _rarityBackHigh[num].color=rarityHighColors[(int)skill.Rarity];
	}

	public void SkillSecildi(int skillIndex)
	{
		// Recovered from original ARM64 0x2032eb8.
		if(skillsecildi) return;
		skillindexlast=skillIndex; SkillUnit skill=SelectedSkills[skillIndex]; skill.FindSkill(); ApplySkills();
		if((uint)skill.IconNum<6u || skill.IconNum==10) {
		 foreach(Commander commander in commanderSpawner.activeCommanders) {
		  bool selected=false;
		  switch(skill.forATK) {
		   case 0: selected=(int)commander.Rarity==0; Basarimlar.UpdateBasarimlarT(3,1); break;
		   case 1: selected=(int)commander.Rarity==1; Basarimlar.UpdateBasarimlarT(23,1); break;
		   case 2: selected=(int)commander.Rarity==2; Basarimlar.UpdateBasarimlarT(29,1); break;
		   case 3: selected=(int)commander.Rarity==3; Basarimlar.UpdateBasarimlarT(26,1); break;
		   case 4: selected=unchecked((uint)((int)commander.Rarity-3))<2u; break;
		   case 5: selected=(uint)commander.Rarity<2u; break;
		   case 6: selected=(int)commander.Rarity==4; Basarimlar.UpdateBasarimlarT(14,1); break;
		  }
		  if(selected) commander.UpgradedSkillSelect(); commander.DataGuncelle();
		 }
		}
		if(skill.IconNum==6) warController.Addtoken((int)skill.EffectValue);
		if(skill.IconNum==8) { warController.CastleHp=unchecked(warController.CastleHp+(long)(skill.EffectValue*((float)warController.MaxCastleHealth/100f))); Basarimlar.UpdateBasarimlarT(8,1); }
		if(skill.IconNum==7) {
		 slotMachine.currentLevel=Mathf.Min(unchecked(slotMachine.currentLevel+(int)skill.EffectValue),19); slotMachine.UpdateLevelText(); slotlevelupeff.SetActive(true);
		 if(!warController.slotacildi) { slotMachine.OpenSlotInfo(); warController.slotacildi=true; } Basarimlar.UpdateBasarimlarT(13,1);
		}
		if(skill.IconNum==9) commanderSpawner.TryAddToInventory(UnityEngine.Random.Range(0,4),(int)skill.Rarity,warController.trailReferans.position,-1);
		SelectedSkills.Clear(); selectedobjs[skillIndex].SetActive(true);
		if((uint)skill.IconNum<6u || skill.IconNum==10) for(int i=0;i<commanderSpawner.activeCommanders.Count;i++) commanderSpawner.activeCommanders[i].DataGuncelle();
		skillsecildi=true; StartCoroutine(skillsecildiKapat()); SoundManager.instance.CashSound(SoundManager.yerevur);
	}

	private IEnumerator skillsecildiKapat()
	{
		// Recovered from original ARM64 0x2033c1c.
		string animation=skillindexlast==0?"Base Layer.SkillSecimKapanmaAnim0":skillindexlast==1?"Base Layer.SkillSecimKapanmaAnim1":"Base Layer.SkillSecimKapanmaAnim2";
		skillsecimanim.Play(animation,0,0f); yield return new WaitForSecondsRealtime(0.44999998807907104f);
		gameObject.SetActive(false); Time.timeScale=GameManager.TimeScale;
	}

	public void ReRoll()
	{
		// Recovered from original ARM64 0x2033680.
		if(Currencys.Crystal<20 || rollhakki>4) return;
		skillsecimanim.Play("Base Layer.SkillSecimAnim",0,0f); Currencys.SpendCrystal(20,"Core","Reroll"); SelectedSkills.Clear(); SkillSecimAcildi();
		rollhakki=unchecked(rollhakki+1); SoundManager.instance.RandomizeSfx(SoundManager.runes);
	}

	private void Update()
	{
		// Recovered from original ARM64 0x2033874.
		_rerollbtn.interactable=Currencys.Crystal>19; _rerollbtn.gameObject.SetActive(rollhakki<5);
		kristaladet.text=Lang.Get.owned+": <sprite=1>"+Currencys.Crystal.ToString(); if(warController.CastleHp<=0) Time.timeScale=1f;
	}
}
