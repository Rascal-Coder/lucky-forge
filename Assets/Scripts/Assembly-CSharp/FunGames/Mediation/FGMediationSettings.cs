using UnityEngine;

namespace FunGames.Mediation
{
	[CreateAssetMenu(fileName = "Assets/Resources/FunGames/FGMediationSettings", menuName = "FunGames/FGMediationSettings", order = 10)]
	public class FGMediationSettings : FGModuleSettingsAbstract<FGMediationSettings>
	{
		public const string NAME = "FGMediationSettings";

		private const string PATH = "FunGames/FGMediationSettings";

		protected override FGMediationSettings LoadResources()
		{
			return null;
		}
	}
}
