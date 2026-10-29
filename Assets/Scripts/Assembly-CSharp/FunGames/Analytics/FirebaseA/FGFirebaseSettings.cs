using UnityEngine;

namespace FunGames.Analytics.FirebaseA
{
	[CreateAssetMenu(fileName = "Assets/Resources/FunGames/FGFirebaseSettings", menuName = "FunGames/FGFirebaseSettings", order = 10)]
	public class FGFirebaseSettings : FGModuleSettingsAbstract<FGFirebaseSettings>
	{
		public const string NAME = "FGFirebaseSettings";

		private const string PATH = "FunGames/FGFirebaseSettings";

		protected override FGFirebaseSettings LoadResources()
		{
			return null;
		}
	}
}
