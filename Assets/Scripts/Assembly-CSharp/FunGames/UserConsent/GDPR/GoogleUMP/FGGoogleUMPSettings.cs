using UnityEngine;

namespace FunGames.UserConsent.GDPR.GoogleUMP
{
	[CreateAssetMenu(fileName = "Assets/Resources/FunGames/FGGoogleUMPSettings", menuName = "FunGames/FGGoogleUMPSettings", order = 10)]
	public class FGGoogleUMPSettings : FGModuleSettingsAbstract<FGGoogleUMPSettings>
	{
		public const string NAME = "FGGoogleUMPSettings";

		private const string PATH = "FunGames/FGGoogleUMPSettings";

		private const string AndroidAdmobAppIdParam = "AndroidAdmobAppIdParam";

		private const string IosAdmobAppIdParam = "IosAdmobAppIdParam";

		[Header("Test mode")]
		public bool TestMode;

		public string TestDeviceID;

		protected override FGGoogleUMPSettings LoadResources()
		{
			return null;
		}
	}
}
