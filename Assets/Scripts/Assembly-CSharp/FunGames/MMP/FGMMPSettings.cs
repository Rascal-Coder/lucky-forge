using UnityEngine;

namespace FunGames.MMP
{
	[CreateAssetMenu(fileName = "Assets/Resources/FunGames/FGMMPSettings", menuName = "FunGames/FGMMPSettings", order = 10)]
	public class FGMMPSettings : FGModuleSettingsAbstract<FGMMPSettings>
	{
		public const string NAME = "FGMMPSettings";

		private const string PATH = "FunGames/FGMMPSettings";

		protected override FGMMPSettings LoadResources()
		{
			return null;
		}
	}
}
