using UnityEngine;

namespace CBS.Scriptable
{
	[CreateAssetMenu(fileName = "InventoryPrefabs", menuName = "CBS/Add new Inventory Prefabs")]
	public class InventoryPrefabs : CBSScriptable
	{
		public GameObject Inventory;

		public GameObject InventorySlot;

		public GameObject ItemInfo;

		public GameObject CategoryTab;

		public override string ResourcePath => null;
	}
}
