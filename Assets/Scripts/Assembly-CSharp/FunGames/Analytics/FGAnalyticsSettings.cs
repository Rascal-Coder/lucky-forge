using UnityEngine;

namespace FunGames.Analytics
{
	[CreateAssetMenu(fileName = "Assets/Resources/FunGames/FGAnalyticsSettings", menuName = "FunGames/FGAnalyticsSettings", order = 10)]
	public class FGAnalyticsSettings : FGModuleSettingsAbstract<FGAnalyticsSettings>
	{
		public const string NAME = "FGAnalyticsSettings";

		private const string PATH = "FunGames/FGAnalyticsSettings";

		protected override FGAnalyticsSettings LoadResources()
		{
			return null;
		}
	}
}
