using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class inGameHeroChoose : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CskillsecildiKapat_003Ed__19 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public inGameHeroChoose _003C_003E4__this;

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
		public _003CskillsecildiKapat_003Ed__19(int _003C_003E1__state)
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

	public TextMeshProUGUI headtitle;

	public TextMeshProUGUI paused;

	public TextMeshProUGUI[] heronames;

	public Image[] heroicons;

	public Animator animpage;

	public HeroController heros;

	public Commander[] choosens;

	public CommanderSpawner commanderSpawner;

	public WarController warController;

	public Color[] epiccolors;

	public Color[] rarecolors;

	public Image[] rarityColorImgs1;

	public Image[] rarityColorImgs2;

	public Image[] rarityColorImgs3;

	private int rarityNum;

	private WeaponRarity rarity;

	private void OnEnable()
	{
	}

	private void Start()
	{
	}

	public void Clicked(int who)
	{
	}

	[IteratorStateMachine(typeof(_003CskillsecildiKapat_003Ed__19))]
	private IEnumerator skillsecildiKapat()
	{
		return null;
	}

	public void OzelHeroChoose(int rarityT)
	{
	}
}
