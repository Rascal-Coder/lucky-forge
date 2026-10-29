using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using AdjustSdk;
using FunGames.Core;
using FunGames.Core.Modules;

namespace FunGames.MMP.AdjustMMP
{
	public class FGAdjust : FGModuleAbstract<FGAdjust, FGMMPCallbacks, FGAdjustSettings>
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CGetAdjustId_003Ed__48 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<string> _003C_003Et__builder;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CGetAdjustSdkStringParam_003Ed__53 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<string> _003C_003Et__builder;

			public FGAdjustSdkParameter param;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CGetAmazonAdId_003Ed__51 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<string> _003C_003Et__builder;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CGetGoogleAdId_003Ed__52 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<string> _003C_003Et__builder;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CGetIdfa_003Ed__49 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<string> _003C_003Et__builder;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CGetIdfv_003Ed__50 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<string> _003C_003Et__builder;

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

		private const string AdjustAdRevenueSourceAppLovinMAX = "applovin_max_sdk";

		private const string RC_ADJUST_SANDBOX = "AdjustSandbox";

		public const string RC_REV_EVENT_FREQ = "RevenueEventFrequency";

		public const string RC_REV_AMOUNT_MULT = "RevenueAmountMultiplier";

		public const string RC_REV_AMOUNT_INCR = "RevenueAmountIncrementer";

		private const string PP_PLAYTIME = "playtime";

		private const string PP_NB_RV = "nbRV";

		private const string PP_NB_INTERSTITIAL = "nbInterstitial";

		private const string PP_ADJUST_TOKEN_RET_PREFIX = "AdjustTokenRet";

		private int daysSinceFirstConnection;

		private int nbRV;

		private int nbInterstitial;

		private int _revenueEventCounter;

		private double _revenuAmountCounter;

		private int _revenueEventFrequency;

		private double _revenueAmountMultiplier;

		private double _revenueAmountIncrementer;

		private Action<string, FGAdInfo> _interImpressionCallback;

		private Action<string, FGAdInfo> _bannerImpressionCallback;

		private Action<string, FGAdInfo> _rewardedImpressionCallback;

		private Action<string, FGAdInfo> _crosspromoImpressionCallback;

		private Action<string, FGAdInfo> _mrecImpressionCallback;

		private Action<string, FGAdInfo> _appOpenImpressionCallback;

		public override FGAdjustSettings Settings => null;

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

		private void InitializePlayerPrefs()
		{
		}

		private void TrackDayRetention()
		{
		}

		private void RunCallback(FGAdType adType, FGAdInfo adInfo)
		{
		}

		private void TrackInterstitialEvent()
		{
		}

		private void TrackRewardedVideoEvent()
		{
		}

		public void attributionChangedDelegate(AdjustAttribution attribution)
		{
		}

		public static AdjustEnvironment GetEnvironment()
		{
			return AdjustEnvironment.Sandbox;
		}

		private void TrackRevenue(FGAdInfo adInfo)
		{
		}

		private void SendSimpleRevenueEvent(FGAdInfo adInfo)
		{
		}

		private void SendAggregatedRevenueEvent(FGAdInfo adInfo)
		{
		}

		private void UpdateRemoteConfValues(bool res)
		{
		}

		private void OnDeferredDeepLink(string obj)
		{
		}

		public static void TrackSimpleEvent(string token)
		{
		}

		[AsyncStateMachine(typeof(_003CGetAdjustId_003Ed__48))]
		public static Task<string> GetAdjustId()
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CGetIdfa_003Ed__49))]
		public static Task<string> GetIdfa()
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CGetIdfv_003Ed__50))]
		public static Task<string> GetIdfv()
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CGetAmazonAdId_003Ed__51))]
		public static Task<string> GetAmazonAdId()
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CGetGoogleAdId_003Ed__52))]
		public static Task<string> GetGoogleAdId()
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CGetAdjustSdkStringParam_003Ed__53))]
		private static Task<string> GetAdjustSdkStringParam(FGAdjustSdkParameter param)
		{
			return null;
		}

		protected override void ClearInitialization()
		{
		}
	}
}
