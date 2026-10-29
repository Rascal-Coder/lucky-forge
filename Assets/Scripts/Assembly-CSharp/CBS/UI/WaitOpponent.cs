using CBS.Models;
using CBS.Scriptable;
using UnityEngine;

namespace CBS.UI
{
	public class WaitOpponent : MonoBehaviour
	{
		private CBSMatchmakingQueue Queue { get; set; }

		private MatchmakingPrefabs Prefabs { get; set; }

		private IMatchmaking Matchmaking { get; set; }

		private IMatchmakingFactory MatchmakingFactory { get; set; }

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		private void OnStatusChanged(MatchmakingStatus status)
		{
		}

		private void OnMatchStart(CBSStartMatchResult result)
		{
		}

		public void SetQueue(CBSMatchmakingQueue queue)
		{
		}

		public void OnCancel()
		{
		}
	}
}
