using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace FunGames.Core
{
	public class FGPlaytimeMeasurement : FGSingleton<FGPlaytimeMeasurement>
	{
		[CompilerGenerated]
		private sealed class _003CCheckPlaytime_003Ed__8 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public FGPlaytimeMeasurement _003C_003E4__this;

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
			public _003CCheckPlaytime_003Ed__8(int _003C_003E1__state)
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

		private const string PP_TOTAL_PLAYTIME = "fg_total_playtime";

		private DateTime _lastStoredDate;

		private void Awake()
		{
		}

		public int GetTotalPlaytime()
		{
			return 0;
		}

		private int StoreTime()
		{
			return 0;
		}

		private void OnApplicationFocus(bool hasFocus)
		{
		}

		private void OnApplicationPause(bool pauseStatus)
		{
		}

		private void OnApplicationQuit()
		{
		}

		[IteratorStateMachine(typeof(_003CCheckPlaytime_003Ed__8))]
		private IEnumerator CheckPlaytime()
		{
			return null;
		}
	}
}
