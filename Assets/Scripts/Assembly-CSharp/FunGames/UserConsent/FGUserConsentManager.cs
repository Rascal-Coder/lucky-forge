using System;
using FunGames.Core.Modules;

namespace FunGames.UserConsent
{
	public class FGUserConsentManager : FGModuleAbstract<FGUserConsentManager, FGModuleCallbacks, FGUserConsentSettings>
	{
		public const string RC_GDPR_BEFORE_ATT = "GdprBeforeAtt";

		public const string RC_GDPR_IF_ATT_REFUSED = "GdprIfAttRefused";

		private Action<bool> _initializePrepopupATT;

		private Action<bool> _initializeATT;

		private Action<bool> _initializeGDPR;

		private Action<bool> _onComplete;

		private Action<bool> _onInitialize;

		private bool initialized;

		private bool _isGdprBeforeATT;

		private bool _mustShowGdprIfAttRefused;

		public bool IsGdprBeforeATT => false;

		public bool MustShowGdprIfAttRefused => false;

		public override FGUserConsentSettings Settings => null;

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

		private void InitializeOrder()
		{
		}
	}
}
