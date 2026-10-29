using UnityEngine;

namespace CBS.Scriptable
{
	[CreateAssetMenu(fileName = "ProfileTasksPrefabs", menuName = "CBS/Add new Profile Tasks Prefabs")]
	public class ProfileTasksPrefabs : CBSScriptable
	{
		public GameObject ProfileTasksWindow;

		public GameObject TaskSlot;

		public override string ResourcePath => null;
	}
}
