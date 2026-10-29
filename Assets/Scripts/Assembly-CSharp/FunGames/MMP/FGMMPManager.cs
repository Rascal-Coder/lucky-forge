using System;
using FunGames.Core.Modules;

namespace FunGames.MMP
{
	public class FGMMPManager : FGModuleAbstract<FGMMPManager, FGMMPCallbacks, FGMMPSettings>
	{
		private Action _initialization;

		public override FGMMPSettings Settings => null;

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

		protected override void ClearInitialization()
		{
		}
	}
}
