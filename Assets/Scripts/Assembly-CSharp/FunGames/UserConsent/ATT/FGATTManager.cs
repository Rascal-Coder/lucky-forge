using FunGames.Core.Modules;
using UnityEngine;

namespace FunGames.UserConsent.ATT
{
	public class FGATTManager : FGModuleAbstract<FGATTManager, FGATTCallbacks, FGATTSettings>
	{
		[HideInInspector]
		public bool isATTCompliant;

		public override FGATTSettings Settings => null;

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

		public void ShowATT()
		{
		}

		protected override void ClearInitialization()
		{
		}
	}
}
