using UnityEngine;

namespace FunGames.UserConsent
{
	[CreateAssetMenu(fileName = "Assets/Resources/FunGames/FGATTSettings", menuName = "FunGames/FGATTSettings", order = 10)]
	public class FGATTSettings : FGModuleSettingsAbstract<FGATTSettings>
	{
		public const string NAME = "FGATTSettings";

		private const string PATH = "FunGames/FGATTSettings";

		protected override FGATTSettings LoadResources()
		{
			return null;
		}
	}
}
