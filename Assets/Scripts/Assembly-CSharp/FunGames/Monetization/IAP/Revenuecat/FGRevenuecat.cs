using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using FunGames.Core.Modules;
using FunGames.MMP;
using FunGames.RemoteConfig;
using UnityEngine;

namespace FunGames.Monetization.IAP.Revenuecat
{
	[RequireComponent(typeof(Purchases))]
	public class FGRevenuecat : FGModuleAbstract<FGRevenuecat, FGModuleCallbacks, FGRevenuecatSettings>
	{
		[CompilerGenerated]
		private sealed class _003CDelayedSyncAttributes_003Ed__40 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public float delay;

			public FGRevenuecat _003C_003E4__this;

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
			public _003CDelayedSyncAttributes_003Ed__40(int _003C_003E1__state)
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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CSetAdjustId_003Ed__31 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public FGRevenuecat _003C_003E4__this;

			private TaskAwaiter<string> _003C_003Eu__1;

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

		[CompilerGenerated]
		private sealed class _003CWaitForNetworkRemoteConfigToBeFetched_003Ed__37 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

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
			public _003CWaitForNetworkRemoteConfigToBeFetched_003Ed__37(int _003C_003E1__state)
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

		private const string RC_SYNC_ON_SUB_RESTORE = "RevenuecatSyncOnSubRestore";

		private const string RC_ELAY_BEFORE_CHECKING_NETWORK_COHORTS = "rc_delay_before_checking_network_cohorts";

		private const string RC_ENABLE_ATTRIBUTE_SYNC = "rc_enable_attribute_sync";

		private const string PP_ALREADY_SYNC = "RevenuecatAlreadySync";

		private const string ATTRIBUTE_APP_VERSION = "rc_app_version";

		private const string ATTRIBUTE_ABTEST_COHORT = "rc_cohort";

		private const string ATTRIBUTE_ABTEST_PROGRESSION_01 = "rc_progression_01";

		private const string ATTRIBUTE_ABTEST_PROGRESSION_02 = "rc_progression_02";

		private const string ATTRIBUTE_ABTEST_PROGRESSION_03 = "rc_progression_03";

		private const int MAX_SYNC_CALLS_PER_MINUTE = 5;

		private const float RATE_LIMIT_WINDOW_SECONDS = 60f;

		public Purchases Purchases;

		private Action<bool> _initialization;

		private int _cohortIndex;

		public List<Action> _poolEvents;

		private readonly Queue<float> _syncCallTimestamps;

		private bool _pendingSyncAttributes;

		public override FGRevenuecatSettings Settings => null;

		protected override FGModule Parent => null;

		protected override string EventName => null;

		protected override string RemoteConfigKey => null;

		protected override void InitializeCallbacks()
		{
		}

		protected override void OnAwake()
		{
		}

		protected override void OnStart()
		{
		}

		protected override void InitializeModule()
		{
		}

		private void AttributionChanged(bool obj)
		{
		}

		private void AttributionChanged(FGAttributionInfo obj)
		{
		}

		[AsyncStateMachine(typeof(_003CSetAdjustId_003Ed__31))]
		private void SetAdjustId()
		{
		}

		private void SyncAfterRestore(FGIAPProduct product, FGIAPPurchaseInfo arg2, IFGReceiptValidator[] arg3)
		{
		}

		private void SyncPurchases()
		{
		}

		public void SetProgressionAttributes(string progression01, string progression02 = "", string progression03 = "")
		{
		}

		public void SetAttribute(string key, string value)
		{
		}

		public void SetAttributes(Dictionary<string, string> attributes)
		{
		}

		[IteratorStateMachine(typeof(_003CWaitForNetworkRemoteConfigToBeFetched_003Ed__37))]
		private IEnumerator WaitForNetworkRemoteConfigToBeFetched()
		{
			return null;
		}

		private void SetCohortAttributes(List<FGABTest> abtests)
		{
		}

		private void SyncAttributesWithRateLimit()
		{
		}

		[IteratorStateMachine(typeof(_003CDelayedSyncAttributes_003Ed__40))]
		private IEnumerator DelayedSyncAttributes(float delay)
		{
			return null;
		}

		private void SyncAttributes()
		{
		}

		private void AttributeSynced(Purchases.Offerings offerings, Purchases.Error error)
		{
		}

		private void SendAllPoolEvents(bool moduleInitialized)
		{
		}

		protected override void ClearInitialization()
		{
		}
	}
}
