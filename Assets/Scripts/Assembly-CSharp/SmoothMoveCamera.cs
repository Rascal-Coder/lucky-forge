using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SmoothMoveCamera : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CSmoothMove_003Ed__6 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public SmoothMoveCamera _003C_003E4__this;

		public float targetY;

		private Vector3 _003CtargetPosition_003E5__2;

		private Vector3 _003CstartPosition_003E5__3;

		private float _003Celapsed_003E5__4;

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
		public _003CSmoothMove_003Ed__6(int _003C_003E1__state)
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

	public float moveDuration;

	public float targetYPosition;

	private Vector3 originalPosition;

	private Coroutine moveCoroutine;

	private void Start()
	{
	}

	public void StartSmoothMove()
	{
	}

	[IteratorStateMachine(typeof(_003CSmoothMove_003Ed__6))]
	private IEnumerator SmoothMove(float targetY)
	{
		return null;
	}
}
