using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using CBS.Context;
using CBS.Models;
using CBS.Scriptable;
using PlayFab.Internal;

namespace CBS
{
	public class OnlineStatusProcessor : IDisposable
	{
		[CompilerGenerated]
		private sealed class _003CUpdateLoop_003Ed__12 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public OnlineStatusProcessor _003C_003E4__this;

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
			public _003CUpdateLoop_003Ed__12(int _003C_003E1__state)
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

		private readonly IProfile Profile;

		private readonly ProfileConfigData ConfigData;

		private readonly OnlineStatusBehavior UpdateBehavior;

		private readonly int UpdateInterval;

		private readonly List<string> Triggers;

		private readonly ICoroutineRunner CoroutineRunner;

		private bool IsStarted { get; set; }

		public OnlineStatusProcessor(IProfile profile, ProfileConfigData configData, ICoroutineRunner coroutineRunner)
		{
		}

		public void StartUpdate()
		{
		}

		[IteratorStateMachine(typeof(_003CUpdateLoop_003Ed__12))]
		private IEnumerator UpdateLoop()
		{
			return null;
		}

		private void OnApiCall(ApiProcessingEventArgs args)
		{
		}

		public void Dispose()
		{
		}
	}
}
