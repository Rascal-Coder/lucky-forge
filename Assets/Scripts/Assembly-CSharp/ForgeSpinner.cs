using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ForgeSpinner : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CAnimateSelector_003Ed__56 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public int count;

		public int targetIndex;

		public ForgeSpinner _003C_003E4__this;

		public RewardForgeSpinner rewardData;

		private int _003CtotalSteps_003E5__2;

		private int _003Cindex_003E5__3;

		private int _003Ci_003E5__4;

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
		public _003CAnimateSelector_003Ed__56(int _003C_003E1__state)
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

	[CompilerGenerated]
	private sealed class _003CSpinCompleted_003Ed__53 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ForgeSpinner _003C_003E4__this;

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
		public _003CSpinCompleted_003Ed__53(int _003C_003E1__state)
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

	[CompilerGenerated]
	private sealed class _003CSpinRoutine_003Ed__51 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ForgeSpinner _003C_003E4__this;

		private int _003Ccount_003E5__2;

		private List<int> _003Cresults_003E5__3;

		private List<RewardForgeSpinner> _003CspinRewards_003E5__4;

		private HashSet<int> _003CchosenSlots_003E5__5;

		private int _003CspinsToDo_003E5__6;

		private int _003Ci_003E5__7;

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
		public _003CSpinRoutine_003Ed__51(int _003C_003E1__state)
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

	[Header("UI")]
	public Transform[] rewardItems;

	public Animator[] rewardLockedAnims;

	public Transform selector;

	public GameObject ShowRewardPopupsObj;

	public Transform rewardPopupContainer;

	public Toggle skipAnimationToggle;

	public GameObject idleobjs;

	public GameObject spinsirasindakiobjs;

	public TextMeshProUGUI forinfotext;

	public ParticleSystem konfettiplay;

	public GameObject skipbtn;

	public TextMeshProUGUI skiptxt;

	public GameObject closebtn;

	private int bulunanadet;

	private int currentFreeThreshold = 5;

	public TextMeshProUGUI youcanforgetxt;

	public TextMeshProUGUI cikanweaponadet;

	public TextMeshProUGUI[] Drawx;

	public TextMeshProUGUI freeforge;

	public TextMeshProUGUI chances;

	public TextMeshProUGUI titlehead;

	public Transform altrewardcontent;

	public RectTransform altrewardrect;

	public GameObject freeSpinBtn;

	public GameObject saveLoading;

	public CanvasJobs canvasJobs;

	private bool loadingsave;

	private int KacXGirildi;

	public FindNewWeapons findNewWeapons;

	[Header("Rewards")]
	public List<RewardForgeSpinner> rewardGachas;

	[Header("Commanders")]
	public Commander[] allCommanders;

	public HeroController heroController;

	private bool Skipit;

	private bool isSpinning;

	private int lastSelectorIndex;

	public Button[] summonbtns;

	private Dictionary<int, RewardForgeSpinner> slotRewards = new Dictionary<int, RewardForgeSpinner>();

	private int bulunansilah;

	public bool IsSpinInProgress => isSpinning;

	private void OnEnable()
	{
		// Offline recovery candidate; native RVA 0x220b6fc.
		SetBuild();
		closebtn.SetActive(true);
		selector.gameObject.SetActive(false);
		// Original FGAnalytics page event omitted in the local offline rebuild.
	}

	private void Update()
	{
		// Offline recovery candidate; native RVA 0x220b9a0.
		summonbtns[0].interactable = Currencys.WeaponToken >= 50 && !isSpinning;
		summonbtns[1].interactable = Currencys.WeaponToken >= 250 && !isSpinning;
	}

	private void Start()
	{
		// Offline recovery candidate; native RVA 0x220bb04.
		titlehead.text = Lang.Get.Forgeweapons;
		skiptxt.text = Lang.Get.Skip;
		youcanforgetxt.text = Lang.Get.youcanforge;
		Drawx[0].text = Lang.Get.forge + " x1";
		Drawx[1].text = Lang.Get.forge + " x5";
		freeforge.text = Lang.Get.free + " " + Lang.Get.forge;
		chances.text = Lang.Get.Chance;
	}

	private void SetBuild()
	{
		// Offline recovery candidate; native RVA 0x220b860.
		for (int i=0; i<rewardItems.Length; i++)
		{
		 rewardLockedAnims[i].Play("Base Layer.animForgeLockedidle",0,0f);
		 rewardItems[i].GetChild(5).gameObject.SetActive(true);
		}
		cikanweaponadet.transform.parent.gameObject.SetActive(false);
		youcanforgetxt.gameObject.SetActive(true);
	}

	private void SetupRewards()
	{
		// Offline recovery candidate; native RVA 0x220bdb0.
		for (int i=0; i<rewardItems.Length; i++)
		{
		 if (i >= rewardGachas.Count) continue;
		 RewardForgeSpinner reward = rewardGachas[i];
		 UnityEngine.UI.Image icon = rewardItems[i].GetChild(1).GetComponent<UnityEngine.UI.Image>();
		 TMPro.TextMeshProUGUI amount = rewardItems[i].GetChild(2).GetComponent<TMPro.TextMeshProUGUI>();
		 if (reward.rewardType == RewardType.Empty)
		 {
		  icon.gameObject.SetActive(false);
		  amount.text = "";
		 }
		 else
		 {
		  icon.gameObject.SetActive(true);
		  icon.sprite = reward.icon;
		  amount.text = reward.amount > 1 ? "x"+reward.amount.ToString() : "";
		 }
		}
	}

	public void StartSpin(int kacX = 1)
	{
		// Offline recovery candidate; native RVA 0x220bff0.
		if (isSpinning) return;
		KacXGirildi = kacX;
		StartCoroutine(SpinRoutine());
	}

	public void Spin10x()
	{
		// Offline recovery candidate; native RVA 0x220c094.
		if (Currencys.WeaponToken < 50)
		{
		 SoundManager.instance.RandomizeSfx(SoundManager._balikgone);
		 canvasJobs.OpenGoldYok(3);
		 return;
		}
		if (isSpinning || Currencys.WeaponToken < 50) return;
		SoundManager.instance.RandomizeSfx(SoundManager._kirilma);
		Currencys.SpendWeaponToken(50,"Meta","ForgeWeapon");
		StartSpin(1);
	}

	public void Spin50x()
	{
		// Offline recovery candidate; native RVA 0x220c2e0.
		if (Currencys.WeaponToken < 250)
		{
		 SoundManager.instance.RandomizeSfx(SoundManager._balikgone);
		 canvasJobs.OpenGoldYok(3);
		 return;
		}
		if (isSpinning || Currencys.WeaponToken < 250) return;
		SoundManager.instance.RandomizeSfx(SoundManager._kirilma);
		Currencys.SpendWeaponToken(250,"Meta","ForgeWeapon");
		StartSpin(5);
	}

	private int GetRewardTypeByChance()
	{
		// Offline recovery candidate; native RVA 0x220c52c.
		int roll = UnityEngine.Random.Range(0,100);
		if (roll < 7) return 0;
		if (roll < 12) return 1;
		if (roll == 12) return 2;
		return roll <= 57 ? 3 : 4;
	}

	private RewardForgeSpinner GenerateRandomReward()
	{
		// Offline recovery candidate; native RVA 0x220c580.
		int type = GetRewardTypeByChance();
		RewardForgeSpinner reward = new RewardForgeSpinner();
		RewardType iconType;
		switch (type)
		{
		 case 0: reward.rewardType = RewardType.Coin; reward.amount = unchecked(KacXGirildi*200); iconType = RewardType.Coin; break;
		 case 1: reward.rewardType = RewardType.Crystal; reward.amount = unchecked(KacXGirildi*5); iconType = RewardType.Crystal; break;
		 case 2: reward.rewardType = RewardType.Mystic; reward.amount = KacXGirildi; iconType = RewardType.Mystic; break;
		 case 3: reward.rewardType = RewardType.Empty; reward.amount = 0; iconType = RewardType.Empty; break;
		 default:
		  reward.rewardType = RewardType.Weapon;
		  WeaponRarity rarity = GetRandomRarityByLevel(FindNewWeapons.CurrentLevel);
		  reward.rarityNum = (int)rarity;
		  Commander[] candidates = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Where(allCommanders, c => c.Rarity == rarity));
		  if (candidates.Length == 0) return reward;
		  Commander selected = candidates[UnityEngine.Random.Range(0,candidates.Length)];
		  if (selected.Level < 31)
		  {
		   reward.icon = selected.icon.sprite;
		   reward.amount = KacXGirildi;
		   return reward;
		  }
		  reward.rewardType = RewardType.Crystal;
		  reward.amount = 3;
		  iconType = RewardType.Crystal;
		  break;
		}
		RewardForgeSpinner iconData = System.Linq.Enumerable.FirstOrDefault(rewardGachas, r => r.rewardType == iconType);
		reward.icon = iconData == null ? null : iconData.icon;
		return reward;
	}

	private WeaponRarity GetRandomRarityByLevel(int level)
	{
		// Offline recovery candidate; native RVA 0x220cb28.
		List<float> distribution = findNewWeapons.CalculateRarityDistribution(level);
		float roll = UnityEngine.Random.Range(0f,100f);
		float sum = 0f;
		for (int i=0; i<distribution.Count; i++)
		{
		 sum = (float)(sum + distribution[i]);
		 if (roll <= sum) return (WeaponRarity)i;
		}
		return WeaponRarity.Common;
	}

	private IEnumerator SpinRoutine()
	{
		// Offline recovery candidate; native RVA 0x220c020 / MoveNext 0x220e778.
		int count = 10;
		Skipit = false;
		closebtn.SetActive(false);
		SetBuild();
		slotRewards.Clear();
		for (int i=0; i<rewardItems.Length; i++) rewardItems[i].GetChild(3).gameObject.SetActive(false);
		bulunanadet = 0;
		cikanweaponadet.text = bulunanadet.ToString()+"/"+currentFreeThreshold.ToString();
		idleobjs.SetActive(false);
		spinsirasindakiobjs.SetActive(true);
		youcanforgetxt.gameObject.SetActive(false);
		cikanweaponadet.transform.parent.gameObject.SetActive(true);
		isSpinning = true;
		skipbtn.SetActive(GameManager.Level > 2);
		List<int> results = new List<int>();
		List<RewardForgeSpinner> spinRewards = new List<RewardForgeSpinner>();
		HashSet<int> chosenSlots = new HashSet<int>();
		int spinsToDo = Mathf.Min(count,10);
		for (int i=0; i<spinsToDo; i++)
		{
		 int index;
		 do { index = UnityEngine.Random.Range(0,rewardItems.Length); } while (chosenSlots.Contains(index));
		 chosenSlots.Add(index);
		 results.Add(index);
		 if (!slotRewards.ContainsKey(index)) slotRewards[index] = GenerateRandomReward();
		 RewardForgeSpinner reward = slotRewards[index];
		 spinRewards.Add(reward);
		 if (!skipAnimationToggle.isOn) yield return StartCoroutine(AnimateSelector(index,reward,count));
		}
		findNewWeapons.AddChestExp(bulunansilah);
		GunlukGorevler.UpdateTaskProgressK(8,bulunansilah);
		slotRewards.Clear();
		skipbtn.SetActive(false);
		bulunansilah = 0;
		CheckForFreeSpin();
		findNewWeapons.TextUpdate();
	}

	private void CheckForFreeSpin()
	{
		// Offline recovery candidate; native RVA 0x220cbfc.
		if (bulunanadet >= currentFreeThreshold && currentFreeThreshold <= 7)
		{
		 freeSpinBtn.SetActive(true);
		 forinfotext.text = Lang.Get.freeforge;
		 konfettiplay.Play();
		 forinfotext.transform.parent.gameObject.SetActive(true);
		 isSpinning = false;
		 closebtn.SetActive(true);
		}
		else
		{
		 freeSpinBtn.SetActive(false);
		 StartCoroutine(SpinCompleted());
		}
	}

	private IEnumerator SpinCompleted()
	{
		// Offline recovery candidate; native RVA 0x220cd40 / MoveNext 0x220e3c4.
		forinfotext.text = Lang.Get.forgecompleted;
		forinfotext.transform.parent.gameObject.SetActive(true);
		yield return new WaitForSeconds(1f);
		SetBuild();
		slotRewards.Clear();
		idleobjs.SetActive(true);
		isSpinning = false;
		closebtn.SetActive(true);
		spinsirasindakiobjs.SetActive(false);
		youcanforgetxt.gameObject.SetActive(true);
		cikanweaponadet.transform.parent.gameObject.SetActive(false);
		for (int i=0; i<rewardItems.Length; i++) rewardItems[i].GetChild(3).gameObject.SetActive(false);
		for (int i=0; i<altrewardcontent.childCount; i++) altrewardcontent.GetChild(i).gameObject.SetActive(false);
		bulunanadet = 0;
		currentFreeThreshold = 5;
		cikanweaponadet.text = bulunanadet.ToString()+"/"+currentFreeThreshold.ToString();
	}

	public void OnFreeSpinButton()
	{
		// Offline recovery candidate; native RVA 0x220cdd4.
		freeSpinBtn.SetActive(false);
		bulunanadet = 0;
		cikanweaponadet.text = bulunanadet.ToString() + "/" + currentFreeThreshold.ToString();
		slotRewards.Clear();
		currentFreeThreshold = unchecked(currentFreeThreshold+1);
		StartSpin(KacXGirildi);
	}

	private int GetRandomSlotIndex()
	{
		// Offline recovery candidate; native RVA 0x220cec4.
		return UnityEngine.Random.Range(0,rewardItems.Length);
	}

	private IEnumerator AnimateSelector(int targetIndex, RewardForgeSpinner rewardData, int count = 1)
	{
		// Offline recovery candidate; native RVA 0x220cee4 / MoveNext 0x220daa4.
		int totalSteps = (targetIndex-lastSelectorIndex+rewardItems.Length)%rewardItems.Length + (count == 10 ? 0 : 1);
		int index = lastSelectorIndex;
		for (int i=0; i<=totalSteps; i++,index++)
		{
		 selector.gameObject.SetActive(true);
		 selector.position = rewardItems[index%rewardItems.Length].position;
		 rewardItems[index%rewardItems.Length].GetChild(6).gameObject.SetActive(true);
		 if (i>0) rewardItems[(index+rewardItems.Length-1)%rewardItems.Length].GetChild(4).gameObject.SetActive(false);
		 if (!Skipit)
		 {
		  yield return new WaitForSeconds((float)(0.025f+(float)((float)i*0.001f)));
		  SoundManager.instance.RandomizeSfx(SoundManager.necroattack2);
		 }
		}
		int finalIndex = (index+rewardItems.Length-1)%rewardItems.Length;
		if (!rewardItems[finalIndex].GetChild(3).gameObject.activeInHierarchy)
		 rewardLockedAnims[finalIndex].Play("Base Layer.animForgeLocked",0,0f);
		UnityEngine.UI.Image icon = rewardItems[finalIndex].GetChild(1).GetComponent<UnityEngine.UI.Image>();
		UnityEngine.UI.Image background = rewardItems[finalIndex].GetComponent<UnityEngine.UI.Image>();
		TMPro.TextMeshProUGUI amount = rewardItems[finalIndex].GetChild(2).GetComponent<TMPro.TextMeshProUGUI>();
		icon.sprite = rewardData.icon;
		if (rewardData.rewardType == RewardType.Empty)
		{
		 background.color = new Color(0f,0f,0f,1f);
		 amount.text = "";
		}
		else if (rewardData.rewardType == RewardType.Weapon)
		{
		 background.color = GetColorByRarity((WeaponRarity)rewardData.rarityNum);
		 amount.text = "x" + rewardData.amount.ToString();
		 bulunanadet = unchecked(bulunanadet+1);
		 bulunansilah = unchecked(bulunansilah+rewardData.amount);
		 if (rewardData.rarityNum == 2) Basarimlar.UpdateBasarimlarT(1,bulunanadet);
		 if (rewardData.rarityNum == 1) Basarimlar.UpdateBasarimlarT(6,bulunanadet);
		 if (rewardData.rarityNum == 0) Basarimlar.UpdateBasarimlarT(10,bulunanadet);
		 if (rewardData.rarityNum == 3) Basarimlar.UpdateBasarimlarT(27,bulunanadet);
		}
		else
		{
		 background.color = GetColorByRarity(WeaponRarity.Epic);
		 amount.text = "x"+rewardData.amount.ToString();
		 bulunanadet = unchecked(bulunanadet+1);
		}
		if (rewardData.rewardType != RewardType.Empty)
		{
		 SoundManager.instance.CashSound(SoundManager._collecting);
		 rewardItems[finalIndex].GetChild(3).gameObject.SetActive(true);
		 AddRewardToAltContent(rewardData);
		}
		GiveReward(rewardData);
		cikanweaponadet.text = bulunanadet.ToString()+"/"+currentFreeThreshold.ToString();
		SoundManager.instance.RandomizeSfx(SoundManager.win3x);
		lastSelectorIndex = finalIndex;
		selector.gameObject.SetActive(false);
	}

	private void GiveReward(RewardForgeSpinner reward)
	{
		// Offline recovery candidate; native RVA 0x220cfac.
		switch (reward.rewardType)
		{
		 case RewardType.Weapon:
		  Commander[] candidates = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Where(allCommanders, c => (int)c.Rarity == reward.rarityNum));
		  if (candidates.Length != 0) candidates[UnityEngine.Random.Range(0,candidates.Length)].AddKartExp(reward.amount);
		  break;
		 case RewardType.Coin: Currencys.AddCoin((double)reward.amount,"Meta","ForgeWeapon"); break;
		 case RewardType.Mystic: Currencys.AddMistikToken(reward.amount,"Meta","ForgeWeapon"); break;
		 case RewardType.Crystal: Currencys.AddCrystal(reward.amount,"Meta","ForgeWeapon"); break;
		}
	}

	private void AddRewardToAltContent(RewardForgeSpinner reward)
	{
		// Offline recovery candidate; native RVA 0x220d230.
		for (int i=0; i<altrewardcontent.childCount; i++)
		{
		 Transform item = altrewardcontent.GetChild(i);
		 if (item.gameObject.activeSelf) continue;
		 item.gameObject.SetActive(true);
		 UnityEngine.UI.Image background = item.GetComponent<UnityEngine.UI.Image>();
		 UnityEngine.UI.Image icon = item.GetChild(1).GetComponent<UnityEngine.UI.Image>();
		 TMPro.TextMeshProUGUI amount = item.GetChild(2).GetComponent<TMPro.TextMeshProUGUI>();
		 if (reward.rewardType == RewardType.Empty)
		 {
		  background.color = new Color(.5f,.5f,.5f,1f);
		  amount.text = "";
		 }
		 else
		 {
		  background.color = GetColorByRarity(reward.rewardType == RewardType.Weapon ? (WeaponRarity)reward.rarityNum : WeaponRarity.Epic);
		  amount.text = "x" + reward.amount.ToString();
		 }
		 if (i >= 5) altrewardrect.anchoredPosition = new Vector2(altrewardrect.anchoredPosition.x - 1200f,altrewardrect.anchoredPosition.y);
		 icon.sprite = reward.icon;
		 return;
		}
	}

	public void ClosePopup()
	{
		// Offline recovery candidate; native RVA 0x220d5b0.
		ShowRewardPopupsObj.SetActive(false);
		SoundManager.instance.RandomizeSfx(SoundManager._collecting);
	}

	private int GetRandomWeightedIndex()
	{
		// Offline recovery candidate; native RVA 0x220d670.
		int total = System.Linq.Enumerable.Sum(rewardGachas, reward => reward.chanceWeight);
		int roll = UnityEngine.Random.Range(0,total);
		int sum = 0;
		for (int i=0; i<rewardGachas.Count; i++)
		{
		 sum = unchecked(sum+rewardGachas[i].chanceWeight);
		 if (roll < sum) return i;
		}
		return 0;
	}

	public void SkipitBtn()
	{
		// Offline recovery candidate; native RVA 0x220d804.
		Skipit = true;
		SoundManager.instance.CashSound(SoundManager._speeduptime);
	}

	private Color GetColorByRarity(WeaponRarity rarity)
	{
		// Offline recovery candidate; native RVA 0x220d498.
		switch (rarity)
		{
		 case WeaponRarity.Common: return heroController.rarityColors[0];
		 case WeaponRarity.Rare: return heroController.rarityColors[1];
		 case WeaponRarity.Epic: return heroController.rarityColors[2];
		 case WeaponRarity.Legendary: return heroController.rarityColors[3];
		 default: return Color.white;
		}
	}
}
