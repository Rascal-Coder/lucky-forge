using UnityEngine;

namespace FunGames.UserConsent
{
	[CreateAssetMenu(fileName = "Assets/Resources/FunGames/FGATTPrePopupSettings", menuName = "FunGames/FGATTPrePopupSettings", order = 10)]
	public class FGATTPrePopupSettings : FGModuleSettingsAbstract<FGATTPrePopupSettings>
	{
		public const string NAME = "FGATTPrePopupSettings";

		private const string PATH = "FunGames/FGATTPrePopupSettings";

		protected override FGATTPrePopupSettings LoadResources()
		{
			return null;
		}
	}
}
