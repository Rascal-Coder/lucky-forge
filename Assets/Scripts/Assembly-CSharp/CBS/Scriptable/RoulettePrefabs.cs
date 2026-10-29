using UnityEngine;

namespace CBS.Scriptable
{
	[CreateAssetMenu(fileName = "RoulettePrefabs", menuName = "CBS/Add new Roulette Prefabs")]
	public class RoulettePrefabs : CBSScriptable
	{
		public GameObject RouletteWindow;

		public GameObject RouletteSlot;

		public override string ResourcePath => null;
	}
}
