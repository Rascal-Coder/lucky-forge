using UnityEngine;

namespace FunGames.UserConsent
{
	[CreateAssetMenu(fileName = "Assets/Resources/FunGames/FGUserConsentSettings", menuName = "FunGames/FGUserConsentSettings", order = 10)]
	public class FGUserConsentSettings : FGModuleSettingsAbstract<FGUserConsentSettings>
	{
		public const string NAME = "FGUserConsentSettings";

		private const string PATH = "FunGames/FGUserConsentSettings";

		protected override FGUserConsentSettings LoadResources()
		{
			return null;
		}
	}
}
