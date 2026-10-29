using UnityEngine;

namespace CBS.Scriptable
{
	[CreateAssetMenu(fileName = "MatchmakingPrefabs", menuName = "CBS/Add new Matchmaking Prefabs")]
	public class MatchmakingPrefabs : CBSScriptable
	{
		public GameObject MatchmakingWindow;

		public GameObject MatchmakingQueue;

		public GameObject WaitOpponentWindow;

		public GameObject DuelPreview;

		public GameObject SinglePreview;

		public GameObject TeamPreview;

		public GameObject SinglePlayer;

		public GameObject TeamLayer;

		public override string ResourcePath => null;
	}
}
