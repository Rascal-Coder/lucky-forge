using UnityEngine;

namespace CBS.Scriptable
{
	[CreateAssetMenu(fileName = "AchievementsPrefabs", menuName = "CBS/Add new Achievements Prefabs")]
	public class AchievementsPrefabs : CBSScriptable
	{
		public GameObject AchievementsWindow;

		public GameObject AchievementsSlot;

		public override string ResourcePath => null;
	}
}
