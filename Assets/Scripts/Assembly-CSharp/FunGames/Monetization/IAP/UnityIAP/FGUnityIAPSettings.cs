using UnityEngine;

namespace FunGames.Monetization.IAP.UnityIAP
{
	[CreateAssetMenu(fileName = "Assets/Resources/FunGames/FGUnityIAPSettings", menuName = "FunGames/FGUnityIAPSettings", order = 10)]
	public class FGUnityIAPSettings : FGModuleSettingsAbstract<FGUnityIAPSettings>
	{
		public const string NAME = "FGUnityIAPSettings";

		private const string PATH = "FunGames/FGUnityIAPSettings";

		protected override FGUnityIAPSettings LoadResources()
		{
			return null;
		}
	}
}
