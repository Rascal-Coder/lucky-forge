using CBS.Core;
using CBS.Models;
using CBS.Scriptable;
using UnityEngine;
using UnityEngine.UI;

namespace CBS.UI
{
	public class MatchmakingQueue : MonoBehaviour, IScrollableItem<CBSMatchmakingQueue>
	{
		[SerializeField]
		private Text TeamLabel;

		[SerializeField]
		private Text CountLabel;

		[SerializeField]
		private Text NameLabel;

		private IMatchmaking Matchmaking { get; set; }

		private CBSMatchmakingQueue Queue { get; set; }

		private MatchmakingPrefabs Prefabs { get; set; }

		private void Awake()
		{
		}

		public void Display(CBSMatchmakingQueue queue)
		{
		}

		public void StartMatchmaking()
		{
		}

		private void OnFindMatch(CBSFindMatchResult result)
		{
		}
	}
}
