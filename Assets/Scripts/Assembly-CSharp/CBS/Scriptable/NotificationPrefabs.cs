using UnityEngine;

namespace CBS.Scriptable
{
	[CreateAssetMenu(fileName = "NotificationPrefabs", menuName = "CBS/Add new Notification Prefabs")]
	public class NotificationPrefabs : CBSScriptable
	{
		public GameObject NotificationWindow;

		public GameObject NotificationTitle;

		public override string ResourcePath => null;
	}
}
