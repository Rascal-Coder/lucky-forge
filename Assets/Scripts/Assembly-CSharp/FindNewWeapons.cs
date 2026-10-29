using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class FindNewWeapons : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003COpenChestsAndShowResults_003Ed__49 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public int kaclik;

		public FindNewWeapons _003C_003E4__this;

		public int numberOfChests;

		private int _003CkaclikNet_003E5__2;

		private List<Commander> _003CfoundWeapons_003E5__3;

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
		public _003COpenChestsAndShowResults_003Ed__49(int _003C_003E1__state)
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
	private sealed class _003CanimPlayer_003Ed__54 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public FindNewWeapons _003C_003E4__this;

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
		public _003CanimPlayer_003Ed__54(int _003C_003E1__state)
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

	public static int CurrentExp;

	public static int CurrentLevel;

	private int MaxSimultaneousOpens = 6;

	public FindedWeaponTekliUi[] WeaponResults;

	public Button closeButton;

	public KarakterlerGenelUI karakterlerGenelUI;

	public HeroController heroController;

	public Slider _ChestSlider;

	public TextMeshProUGUI _levelKacaKac;

	public TextMeshProUGUI[] summonx;

	public Button[] summonbtns;

	public TextMeshProUGUI[] summonprice;

	public TextMeshProUGUI lvl;

	public Sprite iconCurrency;

	public TextMeshProUGUI[] forgetxts;

	public TextMeshProUGUI subtitle;

	public TextMeshProUGUI perfectlow;

	public TextMeshProUGUI olasilikyuzde;

	public Animator playAnim;

	private float[] openTimers = new float[]{0.06f,0.06f,0.08f,0.1f,0.4f};

	private bool isOpening;

	private bool guidedone;

	public TextMeshProUGUI weapontokenkac;

	public GameObject areusure;

	public TextMeshProUGUI spendingtitle;

	public TextMeshProUGUI spendingsubtitle;

	public TextMeshProUGUI spendingfiyat;

	public GameObject kartsayfasi;

	public GameObject levelupanim;

	public TextMeshProUGUI leveluptxt;

	public TextMeshProUGUI levelupsub;

	public GameObject topluparent;

	public ParticleSystem particlepatlama;

	public GameObject animilerle;

	public GameObject[] alttakim;

	public GameObject anasayfa;

	public List<Commander> guidecommanders;

	public TextMeshProUGUI title;

	public TextMeshProUGUI subtitlex;

	private bool readyforclick;

	private int sonacilan;

	private static readonly Dictionary<int, float[]> LevelToRarityMap = new Dictionary<int, float[]> {
 {0,new float[]{80f,13f,5f,2f,0f}}, {5,new float[]{70f,15f,8f,5f,0f}},
 {10,new float[]{60f,19f,14f,8f,0f}}, {15,new float[]{50f,23f,18f,12f,0f}},
 {20,new float[]{40f,27f,21f,16f,0f}}, {25,new float[]{30f,25f,25f,20f,0f}}
};

	public bool IsSummonInProgress => isOpening;

	public int MaxExp()
	{
		// Offline recovery candidate; native RVA 0x2209588.
		return unchecked(CurrentLevel*30+15);
	}

	public void TextUpdate()
	{
		// Offline recovery candidate; native RVA 0x22095f4.
		_ChestSlider.maxValue = MaxExp();
		_ChestSlider.value = CurrentExp < MaxExp() ? CurrentExp : MaxExp();
		_levelKacaKac.text = CurrentExp < MaxExp() ? CurrentExp.ToString()+"/"+MaxExp().ToString() : "MAX";
		lvl.text = CurrentLevel.ToString();
		olasilikyuzde.gameObject.SetActive(false);
		perfectlow.text = Lang.Get.boostTitle1;
	}

	private void OnEnable()
	{
		// Offline recovery candidate; native RVA 0x2209854.
		anasayfa.SetActive(true);
		topluparent.SetActive(false);
		animilerle.gameObject.SetActive(false);
		kartsayfasi.SetActive(false);
		ResetAllResults();
		TextUpdate();
		levelupanim.gameObject.SetActive(false);
		alttakim[0].SetActive(true);
		alttakim[1].SetActive(true);
	}

	private void Start()
	{
		// Offline recovery candidate; native RVA 0x22099b0.
		title.text = Lang.Get.forgeweaponstitle;
		subtitlex.text = Lang.Get.forgeweaponssub;
		subtitle.text = Lang.Get.gagchadescription;
		forgetxts[0].text = Lang.Get.forge+" x1";
		forgetxts[1].text = Lang.Get.forge+" x5";
		spendingtitle.text = Lang.Get.crystalspending;
		spendingsubtitle.text = Lang.Get.crystalspendingsub;
		leveluptxt.text = Lang.Get.LevelUpTxt;
		levelupsub.text = Lang.Get.LevelUpSub;
	}

	public void AddChestExp(int exp)
	{
		// Offline recovery candidate; native RVA 0x2209c84.
		CurrentExp = unchecked(CurrentExp+exp);
		while (CurrentLevel <= 24 && CurrentExp >= MaxExp())
		{
		 CurrentExp = unchecked(CurrentExp-MaxExp());
		 CurrentLevel = unchecked(CurrentLevel+1);
		 ES3.Save<int>("WeaponChestLevel",CurrentLevel);
		 SoundManager.instance.AmbienceEffectSfx(SoundManager.earthquake);
		 levelupanim.gameObject.SetActive(true);
		}
	}

	private List<Commander> OpenChests(int numberOfChests)
	{
		// Offline recovery candidate; native RVA 0x2209e60.
		List<Commander> found = new List<Commander>();
		if (numberOfChests < 1) return found;
		List<float> distribution = GetCurrentChestLevel();
		for (int i=0; i<numberOfChests; i++)
		{
		 Commander weapon = GetRandomWeapon(distribution);
		 if (weapon != null) found.Add(weapon);
		}
		return found;
	}

	private Commander GetRandomWeapon(List<float> chestLevel)
	{
		// Offline recovery candidate; native RVA 0x220a024.
		float roll = UnityEngine.Random.Range(0f,100f);
		float sum = 0f;
		for (int i=0; i<chestLevel.Count; i++)
		{
		 sum = (float)(sum+chestLevel[i]);
		 if (roll <= sum) return GenerateRandomWeapon((WeaponRarity)i);
		}
		return null;
	}

	private Commander GenerateRandomWeapon(WeaponRarity rarity)
	{
		// Offline recovery candidate; native RVA 0x220a104.
		List<Commander> candidates = System.Linq.Enumerable.ToList(System.Linq.Enumerable.Where(heroController.HeroCommanders, c => c.Rarity == rarity && c.Level < c.MaxLevel));
		if (candidates.Count == 0) return null;
		return candidates[UnityEngine.Random.Range(0,candidates.Count)];
	}

	public IEnumerator OpenChestsAndShowResults(int numberOfChests, int kaclik)
	{
		// Offline recovery candidate; native RVA 0x220a264 / MoveNext 0x220adbc.
		int kaclikNet = Mathf.Clamp(kaclik,1,10);
		isOpening = true;
		List<Commander> foundWeapons;
		if (guidecommanders.Count >= 1 && guidecommanders[0].Level <= 1) foundWeapons = guidecommanders;
		else foundWeapons = OpenChests(numberOfChests);
		for (int i=0; i<numberOfChests; i++)
		{
		 playAnim.Play("Base Layer.gachaanimaction",0,0f);
		 string animString = "skillacildi";
		 if (i < foundWeapons.Count)
		 {
		  Commander weapon = foundWeapons[i];
		  List<float> distribution = GetCurrentChestLevel();
		  if (distribution[(int)weapon.Rarity] < 5f) animString = "skillacildiozel";
		  WeaponResults[i].bilgiGir(weapon.icon.sprite,(int)weapon.Rarity,weapon.HeroName.ToString(),false,animString,kaclikNet);
		 }
		 else
		 {
		  WeaponResults[i].bilgiGir(iconCurrency,0,"payback",true,animString,1);
		  Currencys.AddWeaponToken(10,"Meta","ForgeWeapon");
		 }
		 SoundManager.instance.RandomizeSfx(SoundManager._crystal);
		 yield return new WaitForSeconds(0.2f);
		}
		ES3.Save<int>("WeaponChestCurrentExp",CurrentExp);
		foreach (Commander weapon in foundWeapons) weapon.AddKartExp(kaclikNet);
		yield return new WaitForSeconds(0.1f);
		isOpening = false;
		TextUpdate();
		foundWeapons.Clear();
		GunlukGorevler.UpdateTaskProgressK(6,numberOfChests);
	}

	public void Close()
	{
		// Offline recovery candidate; native RVA 0x220a310.
		isOpening = false;
		ES3.Save<int>("WeaponChestCurrentExp",CurrentExp);
		karakterlerGenelUI.Guncelle();
		kartsayfasi.SetActive(true);
		SoundManager.instance.RandomizeSfx(SoundManager._close);
		gameObject.SetActive(false);
	}

	private void Update()
	{
		// Offline recovery candidate; native RVA 0x220a46c.
		weapontokenkac.text = Currencys.WeaponToken.ToString();
		summonbtns[0].interactable = Currencys.WeaponToken >= 250 && !isOpening;
		summonbtns[1].interactable = Currencys.WeaponToken >= 50 && !isOpening;
	}

	private void OpenMultiple(int count, int kaclikcikar)
	{
		// Offline recovery candidate; native RVA 0x220a640.
		StartCoroutine(animPlayer());
		ResetAllResults();
		openTimers = CurrentLevel < 6 ? new float[]{0.02f,0.02f,0.03f,0.08f,0.4f} : new float[]{0.02f,0.02f,0.03f,0.05f,0.1f};
		ResetAllResults();
		StartCoroutine(OpenChestsAndShowResults(count,kaclikcikar));
		AddChestExp(unchecked(count*kaclikcikar));
		areusure.SetActive(false);
		SoundManager.instance.RandomizeSfx(SoundManager._bass);
	}

	private IEnumerator animPlayer()
	{
		// Offline recovery candidate; native RVA 0x220a810 / MoveNext 0x220b3d4.
		topluparent.SetActive(false);
		animilerle.gameObject.SetActive(false);
		readyforclick = false;
		anasayfa.SetActive(false);
		alttakim[0].SetActive(false);
		alttakim[1].SetActive(false);
		animilerle.gameObject.SetActive(true);
		yield return new WaitForSeconds(0.42f);
		particlepatlama.Play();
		yield return new WaitForSeconds(0.02f);
		topluparent.SetActive(true);
		animilerle.gameObject.SetActive(false);
		yield return new WaitForSeconds(0.06f);
		alttakim[0].SetActive(true);
		alttakim[1].SetActive(true);
		readyforclick = true;
	}

	public void Spend(int kim)
	{
		// Offline recovery candidate; native RVA 0x220a8a4.
		if (kim == 0 && Currencys.WeaponToken >= 250)
		{
		 OpenMultiple(6,5);
		 Currencys.SpendWeaponToken(250,"Meta","ForgeWeapon");
		}
		else if (kim == 1 && Currencys.WeaponToken >= 50)
		{
		 OpenMultiple(6,1);
		 Currencys.SpendWeaponToken(50,"Meta","ForgeWeapon");
		}
	}

	public void closeAreusure()
	{
		// Offline recovery candidate; native RVA 0x220aa28.
		areusure.SetActive(false);
	}

	private void ResetAllResults()
	{
		// Offline recovery candidate; native RVA 0x2209940.
		foreach (FindedWeaponTekliUi result in WeaponResults) result.gameObject.SetActive(false);
	}

	public List<float> GetCurrentChestLevel()
	{
		// Offline recovery candidate; native RVA 0x2209fbc.
		return CalculateRarityDistribution(Mathf.Clamp(CurrentLevel,0,25));
	}

	public List<float> CalculateRarityDistribution(int level)
	{
		// Offline recovery candidate; native RVA 0x21fdd50.
		int lower = System.Linq.Enumerable.Max(System.Linq.Enumerable.Where(LevelToRarityMap.Keys, key => key <= level));
		int upper = System.Linq.Enumerable.Min(System.Linq.Enumerable.DefaultIfEmpty(System.Linq.Enumerable.Where(LevelToRarityMap.Keys, key => key > level),lower));
		int maximum = System.Linq.Enumerable.Max(LevelToRarityMap.Keys);
		if (level >= maximum) return System.Linq.Enumerable.ToList(LevelToRarityMap[maximum]);
		float[] lowerValues = LevelToRarityMap[lower];
		float[] upperValues = LevelToRarityMap[upper];
		float factor = (float)((float)unchecked(level-lower) / (float)unchecked(upper-lower));
		List<float> result = new List<float>();
		for (int i=0; i<lowerValues.Length; i++)
		 result.Add((float)(lowerValues[i] + (float)(factor * (float)(upperValues[i]-lowerValues[i]))));
		float total = System.Linq.Enumerable.Sum(result);
		for (int i=0; i<result.Count; i++) result[i] = (float)((float)(result[i]/total)*100f);
		return result;
	}
}
