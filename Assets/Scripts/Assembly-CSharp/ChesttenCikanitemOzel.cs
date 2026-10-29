using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ChesttenCikanitemOzel : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003Cgotopos_003Ed__9 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ChesttenCikanitemOzel _003C_003E4__this;

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
		public _003Cgotopos_003Ed__9(int _003C_003E1__state)
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

	public Transform _itemChild;

	public Transform chestPos;

	public Transform goPos;

	public Vector3 targetpos;

	public bool started;

	public bool ended;

	private void OnEnable()
	{
	}

	private void Update()
	{
	}

	public void GoToChest()
	{
	}

	[IteratorStateMachine(typeof(_003Cgotopos_003Ed__9))]
	private IEnumerator gotopos()
	{
		return null;
	}
}
