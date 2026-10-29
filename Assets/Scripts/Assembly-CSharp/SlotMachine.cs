using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlotMachine : MonoBehaviour
{
	public enum Type
	{
		Silah = 0,
		Kart = 1,
		Coin = 2
	}

	[Serializable]
	public class SpinResult
	{
		public Type[] slots;

		public Dictionary<Type, int> typeCounts;

		public HashSet<Type> winningTypes;

		public int rarityIndex;
	}

	[Serializable]
	public class RarityChance
	{
		public float common;

		public float rare;

		public float epic;

		public float legendary;

		public float[] ToArray()
		{
		return new float[]{common,rare,epic,legendary};
	}
	}

	[CompilerGenerated]
	private sealed class _003CLateShowResult_003Ed__33 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public SpinResult result;

		public SlotMachine _003C_003E4__this;

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
		public _003CLateShowResult_003Ed__33(int _003C_003E1__state)
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

	public CommanderSpawner commanderSpawner;

	public WarController warController;

	public RarityChance[] rarityChancesByLevel;

	public Animator RotateAnim;

	public Animator ButtonPressAnim;

	public bool spining;

	public int SpinAdet;

	[Range(0f, 19f)]
	public int currentLevel;

	private readonly int[] rarityMatchCounts = new int[]{3,4,5,6};

	private int silahsaRandom;

	public GameObject slotinfo;

	public TextMeshProUGUI[] chanceraritys;

	public TextMeshProUGUI levelslot;

	[Header("LowChance")]
	public GameObject lowchanceObj;

	public TextMeshProUGUI[] dusukChanceTitles;

	public Image[] dusukChanceColors;

	public AudioSource audioYay;

	[Header("Guide Preview")]
	[HideInInspector]
	public bool guidePreview;

	[HideInInspector]
	public Type nextSpinType;

	[HideInInspector]
	public int nextSpinRarity;

	[HideInInspector]
	public int guideSilahsaNedir;

	[HideInInspector]
	public Type[] guidePreviewSlots;

	public int BolumRollsayisi;

	public int SpinFiyat()
	{
		// Native RVA0x2042c50, float arithmetic followed by truncation toward zero.
		int price=unchecked(SpinAdet*2+10);
		return unchecked(price-(int)((float)price*(float)PlayerData.mainWallEffect.SpinFiyatiDusur/100f));
	}

	public void SetNextSpinPreview(Type[] slotOrder, int rarityIndex, int silahsaHangi)
	{
		guidePreviewSlots=slotOrder; nextSpinRarity=rarityIndex; guideSilahsaNedir=silahsaHangi; guidePreview=true;
	}

	public void ClearSpinPreview()
	{
		guidePreview=false;
	}

	public void LowChanceGir(float chance, int rarity)
	{
		// Native RVA0x2042d38: original ten equally selected localized reward titles.
		if(dusukChanceTitles!=null&&dusukChanceTitles.Length>0&&dusukChanceTitles[0]) dusukChanceTitles[0].text=chance.ToString("0.0")+"% "+Lang.Get.Chance;
		int title=UnityEngine.Random.Range(0,10);
		string line;
		switch(title) {
		case 0:line=Lang.Get.boostTitle1;break;case 1:line=Lang.Get.boostTitle2;break;
		case 2:line=Lang.Get.boostTitle3;break;case 3:line=Lang.Get.boostTitle4;break;
		case 4:line=Lang.Get.boostTitle5;break;case 5:line=Lang.Get.boostTitle6;break;
		case 6:line=Lang.Get.boostTitle7;break;case 7:line=Lang.Get.boostTitle8;break;
		case 8:line=Lang.Get.boostTitle9;break;default:line=Lang.Get.boostTitle10;break;
		}
		if(dusukChanceTitles!=null&&dusukChanceTitles.Length>1&&dusukChanceTitles[1]) dusukChanceTitles[1].text=line;
		var color=warController.heroController.rarityColors[rarity];
		if(dusukChanceColors!=null&&dusukChanceColors.Length>0&&dusukChanceColors[0]) dusukChanceColors[0].color=color;
		// Original compiled shader/UI receives alpha=123f here; do not replace it with a guessed normalized alpha.
		if(dusukChanceColors!=null&&dusukChanceColors.Length>1&&dusukChanceColors[1]) dusukChanceColors[1].color=new Color(color.r,color.g,color.b,123f);
		if(lowchanceObj) lowchanceObj.SetActive(true);
		if(warController.CharAnim) warController.CharAnim.Play("Base Layer.CharCokiyibiryuzde",0,0f);
		SoundManager.TitretGuclu();
		if(audioYay) audioYay.Play();
	}

	private void OnEnable()
	{
		BolumRollsayisi=0; currentLevel=(int)PlayerData.TalentStats.SpinLevelIncrease; UpdateLevelText();
	}

	public SpinResult RollSlots()
	{
		// Native RVA0x2043354. All distributions come from original serialized RarityChance entries.
		if(rarityChancesByLevel==null||currentLevel<0||currentLevel>=rarityChancesByLevel.Length||rarityChancesByLevel[currentLevel]==null) return null;
		spining=true;
		if(warController) { warController.craftandsellopentimer=0f; if(warController.craftandsell) warController.craftandsell.Closeit(); }
		if(ButtonPressAnim) ButtonPressAnim.Play("Base Layer.Rollbtnpressed",0,0f);
		if(RotateAnim) RotateAnim.Play("Base Layer.SlotRotation",0,0f);
		GetRandomRarityIndex(); // Original first discarded draw is required to preserve RNG consumption.
		var result=new SpinResult { typeCounts=new Dictionary<Type,int>(),winningTypes=new HashSet<Type>() };
		float unusedOriginalDraw=UnityEngine.Random.value;
		bool preview=GameManager.Level<=2&&guidePreview;
		Type selected;
		if(preview) { result.rarityIndex=nextSpinRarity;silahsaRandom=guideSilahsaNedir;selected=nextSpinType; }
		else {
		    silahsaRandom=UnityEngine.Random.Range(0,5);
		    result.rarityIndex=GetRandomRarityIndex();
		    selected=GetRandomType();
		    if(BolumRollsayisi<=2) selected=Type.Silah;
		}
		var slots=new Type[6];
		if(preview) guidePreviewSlots.CopyTo(slots,0);
		else {
		    var indices=new List<int>{0,1,2,3,4,5};Shuffle(indices);
		    int matched=rarityMatchCounts[result.rarityIndex];
		    for(int i=0;i<matched;i++) slots[indices[i]]=selected;
		    for(int i=matched;i<6;i++) { Type other;do {other=GetRandomType();}while(other==selected);slots[indices[i]]=other; }
		}
		if(GameManager.Level>=1) guidePreview=false;
		BolumRollsayisi++;
		result.slots=slots;CountTypes(slots,result.typeCounts);
		foreach(var pair in result.typeCounts) if(pair.Value>=3) result.winningTypes.Add(pair.Key);
		if(Application.isPlaying&&isActiveAndEnabled) StartCoroutine(LateShowResult(result));
		return result;
	}

	private Type GetRandomType()
	{
		float roll=UnityEngine.Random.value; return roll<0.36f ? Type.Coin : roll<0.76f ? Type.Silah : Type.Kart;
	}

	[IteratorStateMachine(typeof(_003CLateShowResult_003Ed__33))]
	private IEnumerator LateShowResult(SpinResult result)
	{
		// Native MoveNext RVA0x2044320, unscaled delay remains active during the tutorial's timeScale=0.
		yield return new WaitForSecondsRealtime(0.5f);
		if(result.winningTypes.Count>0) {
		    foreach(var type in result.winningTypes) {
		        if(type==Type.Silah) commanderSpawner.TryAddToInventory(silahsaRandom,result.rarityIndex,warController.trailReferans.position,-1);
		        else if(type==Type.Kart) { warController._skillSecimPage.CurrentRarity=(RaritySkill)result.rarityIndex;warController._skillSecimPage.gameObject.SetActive(true); }
		        else if(type==Type.Coin) warController.AddSilver(unchecked(SpinFiyat()*(result.rarityIndex+1)));
		    }
		    float chance=rarityChancesByLevel[currentLevel].ToArray()[result.rarityIndex];
		    if(chance<9f) LowChanceGir(chance,result.rarityIndex);
		}
		spining=false;
		if(warController) {
		    warController.craftandsellopentimer=0f;
		    if(warController.craftandsell) warController.craftandsell.Closeit();
		    if(warController.heroController) warController.heroController.MainHeroSkillActivate(2,1);
		}
	}

	private int GetRandomRarityIndex()
	{
		var chances=rarityChancesByLevel[currentLevel].ToArray();
		float roll=UnityEngine.Random.Range(0f,100f),sum=0f;
		for(int i=0;i<chances.Length;i++) { sum+=chances[i]; if(roll<sum) return i; }
		return 0;
	}

	private void CountTypes(Type[] slotTypes, Dictionary<Type, int> counts)
	{
		foreach(var type in slotTypes) { int value; counts.TryGetValue(type,out value); counts[type]=value+1; }
	}

	private void Shuffle(List<int> list)
	{
		for(int n=list.Count;n>1;n--) { int j=UnityEngine.Random.Range(0,n); int old=list[n-1];list[n-1]=list[j];list[j]=old; }
	}

	public void OpenSlotInfo()
	{
		if(slotinfo) slotinfo.SetActive(!slotinfo.activeInHierarchy);
		var values=rarityChancesByLevel[currentLevel].ToArray();
		if(chanceraritys!=null) for(int i=0;i<Math.Min(values.Length,chanceraritys.Length);i++) if(chanceraritys[i]) chanceraritys[i].text="%"+values[i].ToString();
	}

	public void UpdateLevelText()
	{
		if(levelslot) levelslot.text=(currentLevel+1).ToString();
	}
}
