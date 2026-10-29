using UnityEngine;

namespace FunGames.UserConsent.GDPR.CustomGDPR
{
	[CreateAssetMenu(fileName = "Assets/Resources/FunGames/FGCustomGDPRSettings", menuName = "FunGames/FGCustomGDPRSettings", order = 10)]
	public class FGCustomGDPRSettings : FGModuleSettingsAbstract<FGCustomGDPRSettings>
	{
		public const string NAME = "FGCustomGDPRSettings";

		private const string PATH = "FunGames/FGCustomGDPRSettings";

		protected override FGCustomGDPRSettings LoadResources()
		{
			return null;
		}
	}
}
