using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using CBS.Models;
using CBS.Playfab;
using PlayFab.MultiplayerModels;
using UnityEngine;

namespace CBS
{
	public class CBSMatchmakingModule : CBSModule, IMatchmaking
	{
		[CompilerGenerated]
		private sealed class _003CCompareWorkTaskCoroutine_003Ed__43 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CBSMatchmakingModule _003C_003E4__this;

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
			public _003CCompareWorkTaskCoroutine_003Ed__43(int _003C_003E1__state)
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

		[CompilerGenerated]
		private Action<MatchmakingStatus> m_OnStatusChanged;

		[CompilerGenerated]
		private Action<CBSStartMatchResult> m_OnMatchStart;

		private IFabMatchmaking FabMatchmaking { get; set; }

		private IProfile Profile { get; set; }

		public string ActiveQueue { get; private set; }

		public string ActiveTicketID { get; private set; }

		public MatchmakingStatus Status { get; private set; }

		private bool CompareIsRunning { get; set; }

		private Coroutine CompareCoroutine { get; set; }

		public event Action<MatchmakingStatus> OnStatusChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<CBSStartMatchResult> OnMatchStart
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		protected override void Init()
		{
		}

		public void FindMatch(CBSFindMatchRequest request, Action<CBSFindMatchResult> result)
		{
		}

		public void GetMatchmakingQueue(string queueName, Action<CBSGetQueueResult> result)
		{
		}

		public void GetMatchmakingQueuesList(Action<CBSGetMatchmakingListResult> result)
		{
		}

		public void CancelMatch(string queueName, Action<CBSBaseResult> result)
		{
		}

		public void GetMatch(string queueName, string matchID, Action<CBSGetMatchResult> result)
		{
		}

		private void StartRefreshTask()
		{
		}

		private void StopRefreshTask()
		{
		}

		private void CompareWorkTask()
		{
		}

		[IteratorStateMachine(typeof(_003CCompareWorkTaskCoroutine_003Ed__43))]
		private IEnumerator CompareWorkTaskCoroutine()
		{
			return null;
		}

		private void SetStatus(MatchmakingStatus status)
		{
		}

		private void StartMatch(GetMatchmakingTicketResult result)
		{
		}

		protected override void OnLogout()
		{
		}

		private void ClearInternalProcess()
		{
		}
	}
}
