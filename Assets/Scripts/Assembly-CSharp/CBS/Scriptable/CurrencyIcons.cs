using UnityEngine;

namespace CBS.Scriptable
{
	[CreateAssetMenu(fileName = "CurrencyIcons", menuName = "CBS/Add new Currency Sprite pack")]
	public class CurrencyIcons : IconsData
	{
		public override string ResourcePath => null;

		public override string EditorPath => null;

		public override string EditorAssetName => null;

		public override Sprite GetSprite(string id)
		{
			return null;
		}
	}
}
