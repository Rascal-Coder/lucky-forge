using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace FunGames.Monetization.IAP.UnityIAP
{
	public class FGUnityServices : FGSingleton<FGUnityServices>
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CInitializeAsync_003Ed__1 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public FGUnityServices _003C_003E4__this;

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

		private string environment;

		[AsyncStateMachine(typeof(_003CInitializeAsync_003Ed__1))]
		public void InitializeAsync()
		{
		}
	}
}
