using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class fotoicinSC : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CStart_003Ed__5 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public fotoicinSC _003C_003E4__this;

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
		public _003CStart_003Ed__5(int _003C_003E1__state)
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

	public Animator _anim;

	public Transform sapkalar;

	public bool dusman;

	public GameObject _tasidigi;

	public GameObject _silah;

	[IteratorStateMachine(typeof(_003CStart_003Ed__5))]
	private IEnumerator Start()
	{
		return null;
	}

	private void SapkaAyarla()
	{
	}

	private void Update()
	{
	}
}
