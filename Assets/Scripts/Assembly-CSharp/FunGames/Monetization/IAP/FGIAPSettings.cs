using System.Collections.Generic;
using UnityEngine;

namespace FunGames.Monetization.IAP
{
	[CreateAssetMenu(fileName = "Assets/Resources/FunGames/FGIAPSettings", menuName = "FunGames/FGIAPSettings", order = 10)]
	public class FGIAPSettings : FGModuleSettingsAbstract<FGIAPSettings>
	{
		public const string NAME = "FGIAPSettings";

		private const string PATH = "FunGames/FGIAPSettings";

		public List<FGIAPProduct> Products;

		protected override FGIAPSettings LoadResources()
		{
			return null;
		}
	}
}
