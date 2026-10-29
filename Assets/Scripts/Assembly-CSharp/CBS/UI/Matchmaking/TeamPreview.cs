using System.Collections.Generic;
using CBS.Models;
using CBS.Scriptable;
using UnityEngine;

namespace CBS.UI.Matchmaking
{
	public class TeamPreview : MonoBehaviour, IMatchmakingPreview
	{
		[SerializeField]
		private Transform Root;

		private Dictionary<string, List<CBSMatchmakingPlayer>> TeamList;

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
