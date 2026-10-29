using UnityEngine;

namespace CBS.Scriptable
{
	[CreateAssetMenu(fileName = "LinkedPrefabData", menuName = "CBS/Add new Linked Prefab Data")]
	public class LinkedPrefabData : LinkedData<GameObject>
	{
		public override string ResourcePath => null;

		public override string EditorPath => null;

		public override string EditorAssetName => null;
	}
}
