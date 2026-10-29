using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using CBS.Models;
using UnityEngine;
using UnityEngine.UI;

namespace CBS.Core
{
	public class ChatScroller : PreloadScroller<ChatMessage>
	{
		[CompilerGenerated]
		private sealed class _003CApplyScrollPosition_003Ed__7 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ChatScroller _003C_003E4__this;

			public ScrollRect sr;

			public float verticalPos;

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
			public _003CApplyScrollPosition_003Ed__7(int _003C_003E1__state)
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

		[SerializeField]
		private float AutoScrollSpeed;

		protected override float DeltaToPreload => 0f;

		public GameObject GetContentRoot()
		{
			return null;
		}

		public void PushNewMessage(ChatMessage message)
		{
		}

		public void SetScrollPosition(float position)
		{
		}

		public void SetPoolCount(int count)
		{
		}

		[IteratorStateMachine(typeof(_003CApplyScrollPosition_003Ed__7))]
		private IEnumerator ApplyScrollPosition(ScrollRect sr, float verticalPos)
		{
			return null;
		}
	}
}
