using UnityEngine;

namespace FunGames.UserConsent.ATT.UnityATT
{
	[CreateAssetMenu(fileName = "Assets/Resources/FunGames/FGUnityATTSettings", menuName = "FunGames/FGUnityATTSettings", order = 10)]
	public class FGUnityATTSettings : FGModuleSettingsAbstract<FGUnityATTSettings>
	{
		public const string NAME = "FGUnityATTSettings";

		private const string PATH = "FunGames/FGUnityATTSettings";

		protected override FGUnityATTSettings LoadResources()
		{
			return null;
		}
	}
}
