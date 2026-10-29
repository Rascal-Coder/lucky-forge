using UnityEngine;

namespace FunGames.UserConsent
{
	[CreateAssetMenu(fileName = "Assets/Resources/FunGames/FGGDPRSettings", menuName = "FunGames/FGGDPRSettings", order = 10)]
	public class FGGDPRSettings : FGModuleSettingsAbstract<FGGDPRSettings>
	{
		public const string NAME = "FGGDPRSettings";

		private const string PATH = "FunGames/FGGDPRSettings";

		protected override FGGDPRSettings LoadResources()
		{
			return null;
		}
	}
}
