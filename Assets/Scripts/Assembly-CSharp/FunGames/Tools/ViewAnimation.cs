using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace FunGames.Tools
{
	public class ViewAnimation
	{
		[CompilerGenerated]
		private sealed class _003CAnimateRectHeightCoroutine_003Ed__3 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public RectTransform rectTransform;

			public float targetHeight;

			public float duration;

			public Action perFrameAction;

			private float _003CstartHeight_003E5__2;

			private float _003CelapsedTime_003E5__3;

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
			public _003CAnimateRectHeightCoroutine_003Ed__3(int _003C_003E1__state)
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

		private static Dictionary<int, Coroutine> _heightAnimations;

		public static void AnimateRectHeight(MonoBehaviour rectTransformMonoBehaviour, float targetHeight, float duration = 0.2f, Action perFrameAction = null)
		{
		}

		private static Coroutine GetCurrentHeightAnimation(RectTransform rectTransform)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CAnimateRectHeightCoroutine_003Ed__3))]
		private static IEnumerator AnimateRectHeightCoroutine(RectTransform rectTransform, float targetHeight, float duration = 0.2f, Action perFrameAction = null)
		{
			return null;
		}
	}
}
