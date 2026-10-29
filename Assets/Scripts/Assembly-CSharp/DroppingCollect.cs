using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DroppingCollect : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CMoveToRandomPoint_003Ed__5 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public DroppingCollect _003C_003E4__this;

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
		public _003CMoveToRandomPoint_003Ed__5(int _003C_003E1__state)
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

	private Vector3 randomPoint;

	private float moveSpeed;

	private float waitTime;

	public WarController warController;

	private void OnEnable()
	{
	}

	[IteratorStateMachine(typeof(_003CMoveToRandomPoint_003Ed__5))]
	private IEnumerator MoveToRandomPoint()
	{
		return null;
	}
}
