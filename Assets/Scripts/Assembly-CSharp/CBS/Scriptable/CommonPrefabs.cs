using UnityEngine;

namespace CBS.Scriptable
{
	[CreateAssetMenu(fileName = "CommonPrefabs", menuName = "CBS/Add new Common Prefabs")]
	public class CommonPrefabs : CBSScriptable
	{
		public GameObject Canvas;

		public GameObject BaseTab;

		public GameObject IconsPanel;

		public GameObject PurchaseButton;

		public GameObject SimpleIcon;

		public GameObject GameContext;

		public override string ResourcePath => null;
	}
}
