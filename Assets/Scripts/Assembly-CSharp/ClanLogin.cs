using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using CBS;
using CBS.Models;
using CBS.Scriptable;
using TMPro;
using UnityEngine;

public class ClanLogin : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003Clateit_003Ed__38 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ClanLogin _003C_003E4__this;

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
		public _003Clateit_003Ed__38(int _003C_003E1__state)
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
	private Action<CBSLoginResult> m_OnLogined;

	public TextMeshProUGUI giveinfo;

	public GameObject loadingscreen;

	public static bool alreadylogin;

	public GameObject[] clanvaryok;

	public GameObject createArea;

	public GameObject searchArea;

	private bool clearedalredy;

	public CBSisimBelirle isimAlani;

	public ClanTaskLocal clanTaskLocal;

	public GameObject bakimcalismasi;

	public ClanPerks clanPerks;

	public TextMeshProUGUI guild;

	public TextMeshProUGUI bestguilds;

	public TextMeshProUGUI top5guild;

	public GameObject bestguildsGO;

	public GameObject bestguildsBtn;

	private int clankatkipayi;

	private IAuth Auth { get; set; }

	private AuthPrefabs AuthUIData { get; set; }

	public IProfile Profile { get; set; }

	private ICurrency CurrencyModule { get; set; }

	public event Action<CBSLoginResult> OnLogined
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	private void Start()
	{
	}

	public void OpenCloseBestGuilds(bool durum)
	{
	}

	public void ilkdefagirdim()
	{
	}

	[IteratorStateMachine(typeof(_003Clateit_003Ed__38))]
	private IEnumerator lateit()
	{
		return null;
	}

	public void OpenClose(bool durum)
	{
	}

	private void OnEnable()
	{
	}

	public void OpenCreate(bool durum)
	{
	}

	public void OpenSearch(bool durum)
	{
	}

	private void Update()
	{
	}

	public void OnLoginWithCustomID()
	{
	}

	private void OnUserLogined(CBSLoginResult result)
	{
	}

	public void LoginSonrasiKontrol()
	{
	}

	private void ClanKatkiCekveResetle(CBSGetCurrenciesResult result)
	{
	}

	private void OnSubtract(CBSUpdateCurrencyResult result)
	{
	}
}
