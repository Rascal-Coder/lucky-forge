using FunGames.Core.Modules;
using UnityEngine;

namespace FunGames.UserConsent.GDPR
{
	public class FGGDPRManager : FGModuleAbstract<FGGDPRManager, FGGdprCallbacks, FGGDPRSettings>
	{
		private bool _isGDPRAlreadyAnswered;

		private FGGDPRStatus _gdprStatus;

		private string _TcfV2String;

		private const string PP_GDPR_ANSWERED = "isGdrpAnswered";

		private const string PP_GDPR_CONSENT = "hasGdprConsent";

		public const string RC_GDPR_TYPE = "GdprType";

		public const string RC_GDPR_DISPLAY = "GdprDisplay";

		[HideInInspector]
		public Location location;

		public override FGGDPRSettings Settings => null;

		protected override FGModule Parent => null;

		protected override string EventName => null;

		protected override string RemoteConfigKey => null;

		public bool IsGDPRAlreadyAnswered => false;

		public FGGDPRStatus GdprStatus => null;

		public bool IsIABCompliant => false;

		public string TcfV2String => null;

		private bool _isIABCompliant => false;

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

		protected void GDPRInitialized(bool result)
		{
		}

		public void ShowGDPR()
		{
		}

		private void InitializePlayerPrefs()
		{
		}

		private bool CheckPlayerPref(string ppKey)
		{
			return false;
		}

		private void SetPlayerPrefsAfterGdpr(bool result)
		{
		}

		public void ResetPlayerPrefs()
		{
		}

		protected override void ClearInitialization()
		{
		}

		public void SetTCFString(string tcfV2)
		{
		}
	}
}
