using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class TalentFinder : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003COpenChestsAndShowResults_003Ed__20 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public TalentFinder _003C_003E4__this;

		public int numberOfChests;

		private List<Talent> _003CfoundTalents_003E5__2;

		private int _003Ci_003E5__3;

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
		public _003COpenChestsAndShowResults_003Ed__20(int _003C_003E1__state)
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

	private static readonly Dictionary<int, float[]> LevelToRarityMap = new Dictionary<int, float[]> { {0,new float[]{100f,0f,0f,0f}}, {5,new float[] { 83.0f, 20.0f, 1.0f, 0.0f }}, {10,new float[] { 60.0f, 30.0f, 8.0f, 0.10000000149011612f }}, {15,new float[] { 35.0f, 38.0f, 12.0f, 0.5f }}, {20,new float[] { 15.0f, 45.0f, 16.0f, 6.0f }}, {25,new float[] { 10.0f, 30.0f, 40.0f, 15.0f }} };

	public static int CurrentExp;

	public static int CurrentLevel;

	private int MaxSimultaneousOpens = 10;

	public TalentFindedTekli[] TalentResults;

	public Button closeButton;

	public TaskManager taskManager;

	public TalentManager talentManager;

	public TalentsUiManager talentsUiManager;

	private float[] openTimers = new float[] { 0.05999999865889549f, 0.05999999865889549f, 0.07999999821186066f, 0.10000000149011612f, 0.4000000059604645f };

	private bool isOpening;

	private bool guidedone;

	public bool IsSummonInProgress => isOpening;

	public int MaxExp()
	{
        // Original ARM64 recovery 0x2048408.
        return CurrentLevel * 5;
	}

	public void AddChestExp(int exp)
	{
        // Original ARM64 recovery 0x204846c.
        CurrentExp += exp;
        while (CurrentLevel <= 24 && CurrentExp >= MaxExp())
        { CurrentExp -= MaxExp(); CurrentLevel++; ES3.Save<int>("TalentChestLevel",CurrentLevel); }
	}

	public List<float> GetCurrentChestLevel()
	{
        // Original ARM64 recovery 0x2048590.
        return CalculateRarityDistribution(System.Math.Max(System.Math.Min(CurrentLevel,25),0));
	}

	private List<Talent> OpenChests(int numberOfChests)
	{
        // Original ARM64 recovery 0x2048aa4.
        var found=new List<Talent>();
        if(numberOfChests<1)return found;
        var distribution=GetCurrentChestLevel();
        for(int i=0;i<numberOfChests;i++)
        {
            if(CurrentLevel==0 && CurrentExp==0 && !guidedone) {found.Add(talentManager.TalentsList[2]);guidedone=true;}
            else {var talent=GetRandomTalent(distribution);if(talent!=null)found.Add(talent);}
        }
        return found;
	}

	private Talent GetRandomTalent(List<float> chestLevel)
	{
        // Original ARM64 recovery 0x2048cc0.
        float roll=UnityEngine.Random.Range(0f,100f), sum=0f;
        for(int i=0;i<chestLevel.Count;i++) {sum+=chestLevel[i];if(roll<=sum)return GenerateRandomTalent((RarityTalent)i);}
        return null;
	}

	private Talent GenerateRandomTalent(RarityTalent rarity)
	{
        // Original ARM64 recovery 0x2048da0.
        var candidates=System.Linq.Enumerable.ToList(System.Linq.Enumerable.Where(talentManager.TalentsList,t=>t.Rarity==rarity && t.Level<t.MaxLevel));
        return candidates.Count==0 ? null : candidates[UnityEngine.Random.Range(0,candidates.Count)];
	}
	public IEnumerator OpenChestsAndShowResults(int numberOfChests)
	{
        // Original ARM64 recovery 0x204961c.
        isOpening=true;var foundTalents=OpenChests(numberOfChests);
        for(int i=0;i<numberOfChests;i++)
        {
            if(i<foundTalents.Count)
            {
                var talent=foundTalents[i];
                if(i<TalentResults.Length && TalentResults[i]!=null) TalentResults[i].bilgiGir(talentsUiManager.talentIcons[talent.Num],(int)talent.Rarity,Lang.GetTalentName(talent.Num));
                talent.AddExp();
            }
            else
            {
                if(i<TalentResults.Length && TalentResults[i]!=null) TalentResults[i].bilgiGir(talentsUiManager.talentIcons[0],0,"talentpayback",true);
                Currencys.AddTalentScroll(numberOfChests==1 ? 100:90,"Meta","TalentRefund");
            }
            if(SoundManager.instance!=null)SoundManager.instance.RandomizeSfx(SoundManager._crystal);
            yield return new UnityEngine.WaitForSeconds(.1f);
        }
        ES3.Save<int>("TalentChestCurrentExp",CurrentExp);isOpening=false;talentManager.SaveTalents();talentsUiManager.LoadData();
        GunlukGorevler.UpdateTaskProgressK(9,numberOfChests);ClanTaskLocal.ClanTaskPointEkle(4,numberOfChests);
	}

	public void Close()
	{
        // Original ARM64 recovery 0x2048fa4.
        isOpening=false; ES3.Save<int>("TalentChestCurrentExp",CurrentExp);gameObject.SetActive(false);
	}

	private void Update()
	{
        // Original ARM64 recovery 0x204905c.
        if(closeButton!=null)closeButton.gameObject.SetActive(!isOpening);
	}

	public void OpenMultiple(int count)
	{
        // Original ARM64 recovery 0x2049094.
        openTimers=CurrentLevel<10 ? new float[]{.02f,.02f,.03f,.08f,.4f} : new float[]{.02f,.02f,.03f,.05f,.1f};
        gameObject.SetActive(true);ResetAllResults();StartCoroutine(OpenChestsAndShowResults(count));AddChestExp(count);
        if(SoundManager.instance!=null)SoundManager.instance.RandomizeSfx(SoundManager._bass);
	}

	private void ResetAllResults()
	{
        // Original ARM64 recovery 0x2049240.
        foreach(var result in TalentResults)if(result!=null)result.gameObject.SetActive(false);
	}

	public List<float> CalculateRarityDistribution(int level)
	{
        // Original ARM64 recovery 0x20485f8.
        int lower=System.Linq.Enumerable.Max(System.Linq.Enumerable.Where(LevelToRarityMap.Keys,k=>k<=level));
        int upper=System.Linq.Enumerable.Min(System.Linq.Enumerable.DefaultIfEmpty(System.Linq.Enumerable.Where(LevelToRarityMap.Keys,k=>k>level),lower));
        int max=System.Linq.Enumerable.Max(LevelToRarityMap.Keys);
        if(level>=max) return new List<float>(LevelToRarityMap[max]);
        float t=(float)(level-lower)/(float)(upper-lower); var values=new List<float>();
        for(int i=0;i<LevelToRarityMap[lower].Length;i++) values.Add(LevelToRarityMap[lower][i]+(LevelToRarityMap[upper][i]-LevelToRarityMap[lower][i])*t);
        float sum=System.Linq.Enumerable.Sum(values); for(int i=0;i<values.Count;i++) values[i]=values[i]/sum*100f;
        return values;
	}
}
