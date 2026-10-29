using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class RemoteConfigManagerMedu : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CLoadConfigCoroutine_003Ed__5 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public RemoteConfigManagerMedu _003C_003E4__this;

		private UnityWebRequest _003Creq_003E5__2;

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
		public _003CLoadConfigCoroutine_003Ed__5(int _003C_003E1__state)
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

		private void _003C_003Em__Finally1()
		{
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	public static RemoteConfigManagerMedu Instance;

	public GameConfig Config;

	public WarController warController;

	public TextMeshProUGUI[] texts;

	private void Start()
	{
	}

	[IteratorStateMachine(typeof(_003CLoadConfigCoroutine_003Ed__5))]
	private IEnumerator LoadConfigCoroutine()
	{
		return null;
	}
}
