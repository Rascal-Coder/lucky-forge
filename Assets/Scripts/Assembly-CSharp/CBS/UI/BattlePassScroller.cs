using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using CBS.Core;
using CBS.Models;

namespace CBS.UI
{
	public class BattlePassScroller : PreloadScroller<BattlePassLevelInfo>
	{
		[CompilerGenerated]
		private sealed class _003COnSetScrollPosition_003Ed__4 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public BattlePassScroller _003C_003E4__this;

			public float position;

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
			public _003COnSetScrollPosition_003Ed__4(int _003C_003E1__state)
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

		protected override float DeltaToPreload => 0f;

		public void SetPoolCount(int count)
		{
		}

		public void SetScrollPosition(float position)
		{
		}

		[IteratorStateMachine(typeof(_003COnSetScrollPosition_003Ed__4))]
		private IEnumerator OnSetScrollPosition(float position)
		{
			return null;
		}
	}
}
