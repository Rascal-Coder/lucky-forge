using CBS.Models;
using CBS.Scriptable;
using UnityEngine;

namespace CBS.UI
{
	public class MatchmakingWindow : MonoBehaviour
	{
		[SerializeField]
		private MatchmakingScroller Scroller;

		private IMatchmaking Matchmaking { get; set; }

		private MatchmakingPrefabs Prefabs { get; set; }

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void OnGetQueueList(CBSGetMatchmakingListResult result)
		{
		}
	}
}
