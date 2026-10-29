using UnityEngine;

namespace CBS.Scriptable
{
	[CreateAssetMenu(fileName = "LootboxPrefabs", menuName = "CBS/Add new Lootbox Prefabs")]
	public class LootboxPrefabs : CBSScriptable
	{
		public GameObject LootBoxes;

		public GameObject LootBoxSlot;

		public GameObject LootBoxResult;

		public override string ResourcePath => null;
	}
}
