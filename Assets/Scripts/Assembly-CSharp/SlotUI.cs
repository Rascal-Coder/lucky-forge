using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class SlotUI : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003Clateit_003Ed__14 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public SlotUI _003C_003E4__this;

		public bool isWinning;

		public int rarityMatchCount;

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
		public _003Clateit_003Ed__14(int _003C_003E1__state)
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

	public Image background;

	public Image typeIcon;

	public Image randomicon;

	public GameObject karartmaImage;

	public Color commonColor;

	public Color rareColor;

	public Color epicColor;

	public Color legendaryColor;

	public GameObject[] rarityrotates;

	public GameObject[] raritypatlama;

	public Sprite[] typeSprites;

	public Animator animWinScale;

	public Animator animShinelittle;

	public void SetSlot(SlotMachine.Type type, int rarityMatchCount, bool isWinning)
	{
		if(karartmaImage) karartmaImage.SetActive(false);
		if(background) background.color=commonColor;
		if(rarityrotates!=null) foreach(var go in rarityrotates) if(go) go.SetActive(false);
		if(raritypatlama!=null) foreach(var go in raritypatlama) if(go) go.SetActive(false);
		if(typeSprites!=null&&typeSprites.Length>0) {
		    int random=UnityEngine.Random.Range(0,typeSprites.Length);
		    if(randomicon) randomicon.sprite=typeSprites[random];
		    if(typeIcon) typeIcon.sprite=typeSprites[(int)type];
		}
		if(Application.isPlaying&&isActiveAndEnabled) StartCoroutine(lateit(rarityMatchCount,isWinning));
	}

	[IteratorStateMachine(typeof(_003Clateit_003Ed__14))]
	private IEnumerator lateit(int rarityMatchCount, bool isWinning)
	{
		yield return new WaitForSeconds(0.4f);
		if(karartmaImage) karartmaImage.SetActive(!isWinning);
		if(background) background.color=GetColorByRarity(rarityMatchCount);
		if(isWinning) {
		    int rarity=GetRarity(rarityMatchCount);
		    if(rarityrotates!=null) for(int i=0;i<rarityrotates.Length;i++) if(rarityrotates[i]) rarityrotates[i].SetActive(i==rarity);
		    if(raritypatlama!=null) for(int i=0;i<raritypatlama.Length;i++) if(raritypatlama[i]) raritypatlama[i].SetActive(i==rarity);
		    if(animWinScale) animWinScale.Play("Base Layer.winscale",0,0f);
		    if(animShinelittle) animShinelittle.Play("Base Layer.ShinePatlama",0,0f);
		}
	}

	private Color GetColorByRarity(int matchCount)
	{
		switch(matchCount) {case 3:return commonColor;case 4:return rareColor;case 5:return epicColor;case 6:return legendaryColor;default:return Color.white;}
	}

	private int GetRarity(int matchCount)
	{
		return matchCount>=4&&matchCount<=6 ? matchCount-3 : 0;
	}
}
