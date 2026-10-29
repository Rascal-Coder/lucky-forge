using UnityEngine;

namespace CBS.Scriptable
{
	[CreateAssetMenu(fileName = "EventsPrefabs", menuName = "CBS/Add new Events Prefabs")]
	public class EventsPrefabs : CBSScriptable
	{
		public GameObject EventWindow;

		public GameObject EventSlot;

		public override string ResourcePath => null;
	}
}
