using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using CBS;
using CBS.Models;
using CBS.Scriptable;
using UnityEngine;

public class AutoLoginCBS : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003COpenLater_003Ed__19 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public AutoLoginCBS _003C_003E4__this;

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
		public _003COpenLater_003Ed__19(int _003C_003E1__state)
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

	public GameObject cbsClanButton;

	public ClanPerks clanPerks;

	public ClanLogin clanlogin;

	private IAuth Auth { get; set; }

	private AuthPrefabs AuthUIData { get; set; }

	private AuthData AuthData { get; set; }

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

	[IteratorStateMachine(typeof(_003COpenLater_003Ed__19))]
	private IEnumerator OpenLater()
	{
		return null;
	}

	private void Init()
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
}
