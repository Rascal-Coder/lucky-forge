using System;
using System.Collections.Generic;
using CBS.Context;

namespace CBS
{
	public abstract class CBSModule
	{
		private readonly string CoroutineRunnerTitle;

		private ICoroutineRunner CoroutineRunnerInstance;

		private static Dictionary<Type, CBSModule> Modules { get; set; }

		public ICoroutineRunner CoroutineRunner => null;

		public CBSModule()
		{
		}

		protected virtual void Init()
		{
		}

		public virtual void Bind()
		{
		}

		public static T Get<T>() where T : CBSModule, new()
		{
			return null;
		}

		internal void LogoutProcces()
		{
		}

		protected virtual void OnLogout()
		{
		}
	}
}
