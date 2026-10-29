using UnityEngine;

namespace CBS.Scriptable
{
	[CreateAssetMenu(fileName = "CalendarPrefabs", menuName = "CBS/Add new Calendar Prefabs")]
	public class CalendarPrefabs : CBSScriptable
	{
		public GameObject CalendarWindow;

		public GameObject CalendarTitle;

		public GameObject CalendarSlot;

		public override string ResourcePath => null;
	}
}
