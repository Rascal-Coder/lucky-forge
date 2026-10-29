using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpinforWeapon : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CSpinAnimation_003Ed__27 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public SpinforWeapon _003C_003E4__this;

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
		public _003CSpinAnimation_003Ed__27(int _003C_003E1__state)
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

	[Header("Settings")]
	public WeaponRarity currentRarity;

	public HeroController heroController;

	[Header("UI")]
	public Image resultIcon;

	public Sprite failIcon;

	public TextMeshProUGUI chanceText;

	public ParticleSystem successParticle;

	public ParticleSystem failParticle;

	public TextMeshProUGUI fiyattxt;

	public Button spinbtn;

	public bool spining;

	public int fiyat;

	public bool forGuide;

	public bool dontwork;

	public Animator falserWinLosetxt;

	private List<Commander> filteredCommanders;

	public Animator animSpin;

	public TextMeshProUGUI winlosetext;

	public WarController warController;

	public CommanderSpawner commanderSpawner;

	public Button closebtn;

	private float idletimer;

	public AudioSource spinsound;

	public float successChance()
	{
		// Offline recovery; native RVA 0x2045d10.
		return LuckyForge.Offline.Recovered.RecoveredEconomyRules.WeaponSpinChance(
			(LuckyForge.Offline.Recovered.Rarity)currentRarity,
			PlayerData.TalentStats.SansTokenEpicArtis,
			PlayerData.TalentStats.SansTokenLegendArtis);
	}

	private void OnEnable()
	{
		UpdateChanceText();
		if (successParticle) successParticle.Stop();
		if (failParticle) failParticle.Stop();
		if (fiyattxt) fiyattxt.text = "<sprite=7>" + fiyat.ToString();
		if (closebtn) closebtn.interactable = true;
		spining = false; idletimer = 2f;
		if (winlosetext) winlosetext.gameObject.SetActive(false);
	}

	private void Update()
	{
		if (spinbtn) spinbtn.interactable = warController && warController.token >= fiyat && !spining;
		idletimer += Time.deltaTime;
		if (idletimer > 1.3f && !spining) { if (animSpin) animSpin.Play("Base Layer.spinminiidle", 0, 0f); idletimer = 0f; }
	}

	private void UpdateChanceText()
	{
		if (!chanceText) return;
		float extra = 0f;
		if (PlayerData.TalentStats != null) {
		    if (currentRarity == WeaponRarity.Epic) extra = PlayerData.TalentStats.SansTokenEpicArtis;
		    else if (currentRarity == WeaponRarity.Legendary) extra = PlayerData.TalentStats.SansTokenLegendArtis;
		}
		chanceText.text = extra > 0f ? "%" + successChance().ToString("00") + "<color=#C0FF00>+" + extra.ToString("F2") + "</color>" : "%" + successChance().ToString("00");
	}

	public void SpinButtonPressed()
	{
		// Native RVA0x2046218; guard against duplicate UI events is an offline repair.
		if (spining || !warController || !commanderSpawner || !heroController) return;
		if (warController.token < fiyat || commanderSpawner.IsFull()) {
		    warController.InfoVer("<sprite=\"MeduSprite3\" index=0>" + commanderSpawner.currentCommanderCount + "/" + commanderSpawner.maxCommanderCount + " " + Lang.Get.limit);
		    return;
		}
		filteredCommanders = new List<Commander>();
		if (heroController.HeroCommanders != null) foreach (var c in heroController.HeroCommanders)
		    if (c && c.Rarity == currentRarity) filteredCommanders.Add(c);
		if (falserWinLosetxt) falserWinLosetxt.gameObject.SetActive(false);
		warController.Spendtoken(fiyat);
		if (closebtn) closebtn.interactable = false;
		StartCoroutine(SpinAnimation());
	}

	[IteratorStateMachine(typeof(_003CSpinAnimation_003Ed__27))]
	private IEnumerator SpinAnimation()
	{
		// Native coroutine MoveNext RVA0x2046680. Probability is sampled after the animation delay.
		if (spinsound) spinsound.Play();
		if (animSpin) animSpin.Play("Base Layer.spinmini", 0, 0f);
		spining = true;
		yield return new WaitForSeconds(0.62f);
		float roll = UnityEngine.Random.Range(0f, 100f);
		if (forGuide) roll = 0f;
		if (dontwork) roll = 100f;
		if (roll <= successChance() && filteredCommanders != null && filteredCommanders.Count > 0) {
		    var chosen = filteredCommanders[UnityEngine.Random.Range(0, filteredCommanders.Count)];
		    if (resultIcon && chosen.icon) resultIcon.sprite = chosen.icon.sprite;
		    if (winlosetext) winlosetext.text = Lang.Get.boostTitle5;
		    if (successParticle) successParticle.Play();
		    commanderSpawner.TryAddToInventory((int)chosen.Type, (int)chosen.Rarity, warController.trailReferans.position, -1);
		    if (SoundManager.instance) SoundManager.instance.CashSound(SoundManager._catch);
		    if (chosen.Rarity == WeaponRarity.Rare) Basarimlar.UpdateBasarimlarT(31, 1);
		    if (chosen.Rarity == WeaponRarity.Epic) Basarimlar.UpdateBasarimlarT(4, 1);
		    if (chosen.Rarity == WeaponRarity.Legendary) Basarimlar.UpdateBasarimlarT(18, 1);
		} else {
		    if (resultIcon) resultIcon.sprite = failIcon;
		    if (winlosetext) winlosetext.text = Lang.Get.Fail;
		    if (failParticle) failParticle.Play();
		    if (SoundManager.instance) SoundManager.instance.CashSound(SoundManager._oltaat);
		}
		forGuide = false; spining = false;
		if (closebtn) closebtn.interactable = true;
		if (falserWinLosetxt) falserWinLosetxt.Play("Base Layer.losewintxt", 0, 0f);
		if (winlosetext) winlosetext.gameObject.SetActive(true);
		idletimer = 0f;
		if (heroController) heroController.MainHeroSkillActivate(3, (int)currentRarity);
	}
}
