using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using FunGames.Core.Settings;
using FunGames.Core.Utils;
using UnityEngine;

namespace FunGames.Core.Modules
{
	[DefaultExecutionOrder(-42)]
	public abstract class FGModuleAbstract<M, C, S> : FGSingleton<M>, FGModule where M : FGModuleAbstract<M, C, S> where C : FGModuleCallbacks, new() where S : IFGModuleSettings
	{
		[CompilerGenerated]
		private sealed class _003CCheckInitialization_003Ed__63 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public FGModuleAbstract<M, C, S> _003C_003E4__this;

			private float _003Ccounter_003E5__2;

			private float _003Citeration_003E5__3;

			private float _003CmaxWaitingDelay_003E5__4;

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
			public _003CCheckInitialization_003Ed__63(int _003C_003E1__state)
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

		private C _callbacks;

		private readonly List<FGModule> _children;

		private bool _isSelfInitialized;

		private float _timer;

		private float _totalInitTime;

		private IEnumerator _checkInitCoroutine;

		private bool _useCheckInit;

		private float _maxInitTime;

		private bool _initLock;

		private bool _initAlreadySucceeded;

		private bool _initAlreadyFailed;

		private InitializationStatus _initializationStatus;

		private InitializationStatus _selfInitializationStatus;

		private readonly List<FGModule> _recursiveChildrenInitializationStatus;

		public const string EVENT_INITIALISATION_START = "InitialisationStart";

		public const string EVENT_INITIALISATION_COMPLETE = "InitialisationComplete";

		private const string EVENT_PARAM_VERSION = "version";

		private const string EVENT_PARAM_SUCCESS = "success";

		private const string EVENT_PARAM_INIT_TIME = "initTime";

		public InitializationStatus InitializationStatus => InitializationStatus.NOT_INITIALIZED;

		public FGModuleInfo ModuleInfo => null;

		public C Callbacks => null;

		public abstract S Settings { get; }

		protected abstract FGModule Parent { get; }

		public List<FGModule> SubModules => null;

		protected abstract string EventName { get; }

		protected abstract string RemoteConfigKey { get; }

		public bool IsInitialized => false;

		public float TotalSubModules => 0f;

		public float TotalSubModulesCompleted => 0f;

		public bool IsChildCompleted => false;

		protected abstract void InitializeCallbacks();

		protected abstract void OnAwake();

		protected abstract void OnStart();

		protected abstract void InitializeModule();

		protected abstract void ClearInitialization();

		public void Awake()
		{
		}

		public void Start()
		{
		}

		public void Initialize()
		{
		}

		public void SetManualInit()
		{
		}

		public void UnlockManualInit()
		{
		}

		public virtual bool MustBeInitialized()
		{
			return false;
		}

		public void CheckModuleInitialization()
		{
		}

		protected void InitializationComplete(bool success)
		{
		}

		public void AddChild(FGModule child)
		{
		}

		public void Log(params string[] message)
		{
		}

		public void Log(string message, LogLevel logLevel)
		{
		}

		public void LogError(params string[] message)
		{
		}

		public void LogWarning(params string[] message)
		{
		}

		public void LogCritical(params string[] message)
		{
		}

		private string FormatLog(string[] messages)
		{
			return null;
		}

		[IteratorStateMachine(typeof(FGModuleAbstract<, , >._003CCheckInitialization_003Ed__63))]
		private IEnumerator CheckInitialization()
		{
			return null;
		}

		public void InitWithoutTimer()
		{
		}

		public void SetMaxInitTime(float time)
		{
		}

		private void MapRecursiveChildren(FGModule module)
		{
		}

		private bool MustShowLogs()
		{
			return false;
		}

		public void Clear()
		{
		}

		private void OnDestroy()
		{
		}
	}
}
