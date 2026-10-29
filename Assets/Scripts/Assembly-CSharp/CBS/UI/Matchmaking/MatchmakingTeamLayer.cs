using System.Collections.Generic;
using CBS.Models;
using CBS.Scriptable;
using UnityEngine;
using UnityEngine.UI;

namespace CBS.UI.Matchmaking
{
	public class MatchmakingTeamLayer : MonoBehaviour
	{
		[SerializeField]
		private Text TeamLabel;

		private MatchmakingPrefabs Prefabs { get; set; }

		private void Awake()
		{
		}

		public void DrawTeam(List<CBSMatchmakingPlayer> list, string teamID)
		{
		}
	}
}
