using UnityEngine;

namespace CBS.Scriptable
{
	[CreateAssetMenu(fileName = "StorePrefabs", menuName = "CBS/Add new Store Prefabs")]
	public class StorePrefabs : CBSScriptable
	{
		public GameObject StoreWindows;

		public GameObject StoreTitle;

		public GameObject StoreItem;

		public GameObject PurchaseButton;

		public GameObject SpecialOfferFrame;

		public GameObject SpecialOfferWindow;

		public override string ResourcePath => null;
	}
}
