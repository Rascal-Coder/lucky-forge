using UnityEngine;

namespace CBS.Scriptable
{
	[CreateAssetMenu(fileName = "CurrencyConfigData", menuName = "CBS/Add new Currency Config Data")]
	public class CurrencyConfigData : CBSScriptable
	{
		public Sprite RMCurrencyIcon;

		public override string ResourcePath => null;
	}
}
