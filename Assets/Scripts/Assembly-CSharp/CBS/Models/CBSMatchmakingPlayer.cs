using System;
using PlayFab.MultiplayerModels;

namespace CBS.Models
{
	[Serializable]
	public class CBSMatchmakingPlayer
	{
		public string ProfileID;

		public string PlayerEntityID;

		public string Team;

		public static CBSMatchmakingPlayer FromFabModel(MatchmakingPlayerWithTeamAssignment fabPlayer)
		{
			return null;
		}

		public static CBSMatchmakingPlayer FromFabModel(MatchmakingPlayer fabPlayer)
		{
			return null;
		}
	}
}
