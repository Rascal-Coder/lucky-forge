using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

namespace CBS.UI
{
	public abstract class BaseBadge : MonoBehaviour
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CStartUpdateInterval_003Ed__9 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public BaseBadge _003C_003E4__this;

			private TaskAwaiter _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[SerializeField]
		private TextMeshProUGUI Count;

		[SerializeField]
		protected GameObject Back;

		[SerializeField]
		private BadgeUpdateType UpdateLogic;

		[SerializeField]
		private int IntervalMiliseconds;

		private bool ActiveUpdate { get; set; }

		protected void UpdateCount(int count)
		{
		}

		[AsyncStateMachine(typeof(_003CStartUpdateInterval_003Ed__9))]
		protected void StartUpdateInterval()
		{
		}

		protected void StopUpdateInterval()
		{
		}

		protected virtual void OnUpdateInterval()
		{
		}
	}
}
