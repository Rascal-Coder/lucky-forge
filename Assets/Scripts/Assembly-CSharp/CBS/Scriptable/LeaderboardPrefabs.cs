using UnityEngine;

namespace CBS.Scriptable
{
	[CreateAssetMenu(fileName = "LeaderboardPrefabs", menuName = "CBS/Add new Leaderboard Prefabs")]
	public class LeaderboardPrefabs : CBSScriptable
	{
		public GameObject LeaderboardsWindow;

		public GameObject LeaderboardUser;

		public GameObject LeaderboardClan;

		public override string ResourcePath => null;
	}
}
