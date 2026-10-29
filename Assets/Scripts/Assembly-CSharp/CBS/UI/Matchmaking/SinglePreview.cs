using CBS.Models;
using CBS.Scriptable;
using UnityEngine;

namespace CBS.UI.Matchmaking
{
	public class SinglePreview : MonoBehaviour, IMatchmakingPreview
	{
		[SerializeField]
		private Transform Root;

		private MatchmakingPrefabs Prefabs { get; set; }

		private void Awake()
		{
		}

		public void Draw(CBSStartMatchResult result)
		{
		}

		public void StartMatch()
		{
		}
	}
}
