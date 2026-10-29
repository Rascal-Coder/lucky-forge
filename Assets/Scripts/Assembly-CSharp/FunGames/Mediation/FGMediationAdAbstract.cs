using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using FunGames.Core;
using FunGames.Core.Settings;
using UnityEngine;

namespace FunGames.Mediation
{
	public abstract class FGMediationAdAbstract<M, MP> : MonoBehaviour, IFGMediationAd where M : FGMediationAdAbstract<M, MP> where MP : FGMediationAbstract<MP, IFGModuleSettings>
	{
		[CompilerGenerated]
		private sealed class _003CTriggerLoadFailAfterTimeout_003Ed__58 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public FGMediationAdAbstract<M, MP> _003C_003E4__this;

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
			public _003CTriggerLoadFailAfterTimeout_003Ed__58(int _003C_003E1__state)
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
		private sealed class _003CWaitToReloadAd_003Ed__60 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public float delay;

			public FGMediationAdAbstract<M, MP> _003C_003E4__this;

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
			public _003CWaitToReloadAd_003Ed__60(int _003C_003E1__state)
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

		private string _adId;

		protected const string EVENT_LOADING_TIME = "AdLoadingTime";

		protected const string EVENT_PARAM_TYPE = "type";

		protected const string EVENT_PARAM_UNIT_ID = "unitId";

		protected const string EVENT_PARAM_NETWORK = "network";

		protected const string EVENT_PARAM_PLACEMENT = "placement";

		protected const string EVENT_PARAM_TIME = "time";

		protected const string EVENT_PARAM_LOAD_ITERATION = "loadIteration";

		protected FGAdInfo LoadedAdInfo;

		protected FGAdInfo ShowingAdInfo;

		protected Action<bool> CurrentCallback;

		private int _adIteration;

		private float _timeToLoad;

		protected bool _isLoading;

		protected bool _isShowing;

		protected bool _isShowRequested;

		private bool _isFirstLoadRequested;

		private bool _interrupted;

		private int _timeout;

		private Action<IFGMediationAd> _onAdLoaded;

		private Action<IFGMediationAd> _onAdLoadFailed;

		private Action<IFGMediationAd> _onAdClosed;

		private Action<IFGMediationAd> _onAdDisplayFailed;

		public string AdUnitId
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public abstract FGAdType adType { get; }

		protected abstract FGMediationAbstract<MP, IFGModuleSettings> MediationInstance { get; }

		public event Action<IFGMediationAd> OnAdLoaded
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action<IFGMediationAd> OnAdLoadFailed
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action<IFGMediationAd> OnAdClosed
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action<IFGMediationAd> OnAdDisplayFailed
		{
			add
			{
			}
			remove
			{
			}
		}

		public bool IsLoading()
		{
			return false;
		}

		public static M Initialize(FGAdType adType, string adId, int timeout = -1)
		{
			return null;
		}

		private void Awake()
		{
		}

		public abstract void InitializeCallbacks();

		protected abstract void LoadImpl();

		protected abstract void ShowImpl();

		protected abstract void HideImpl();

		public abstract bool IsReady();

		protected abstract void TriggerLoadedEventImpl();

		protected abstract void TriggerDisplayedEventImpl();

		protected abstract void TriggerClosedEventImpl();

		protected abstract void TriggerClickedEventImpl();

		protected abstract void TriggerImpressionEventImpl();

		protected abstract void TriggerLoadFailedEventImpl();

		protected abstract void TriggerDisplayFailedEventImpl();

		public void Load()
		{
		}

		[IteratorStateMachine(typeof(FGMediationAdAbstract<, >._003CTriggerLoadFailAfterTimeout_003Ed__58))]
		private IEnumerator TriggerLoadFailAfterTimeout()
		{
			return null;
		}

		public void LoadWithDelay(float delay)
		{
		}

		[IteratorStateMachine(typeof(FGMediationAdAbstract<, >._003CWaitToReloadAd_003Ed__60))]
		private IEnumerator WaitToReloadAd(float delay)
		{
			return null;
		}

		public void Show(string placementName = "default", Action<bool> callback = null)
		{
		}

		public void Hide()
		{
		}

		public bool IsShowing()
		{
			return false;
		}

		protected void TriggerLoadedEvent(FGAdInfo adInfo)
		{
		}

		protected void TriggerDisplayedEvent(FGAdInfo adInfo)
		{
		}

		protected void TriggerImpressionEvent(FGAdInfo adInfo)
		{
		}

		protected void TriggerClosedEvent()
		{
		}

		protected void TriggerClickedEvent()
		{
		}

		protected void TriggerLoadFailedEvent()
		{
		}

		protected void TriggerDisplayFailedEvent()
		{
		}

		private void SendLoadingTimeEvent()
		{
		}

		protected void SendLoadingTimeEvent(string eventID, float timeToLoad)
		{
		}

		private int CompareByAdType(IFGMediationAd x, IFGMediationAd y)
		{
			return 0;
		}
	}
}
