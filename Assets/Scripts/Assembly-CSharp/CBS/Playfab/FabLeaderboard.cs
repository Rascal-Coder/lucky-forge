using System;
using CBS.Models;
using PlayFab;
using PlayFab.CloudScriptModels;

namespace CBS.Playfab
{
	public class FabLeaderboard : FabExecuter, IFabLeaderboard
	{
		public void GetLeaderboard(string profileID, CBSGetLeaderboardRequest leaderboardRequest, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void GetLeaderboardAroundProfile(string profileID, CBSGetLeaderboardRequest leaderboardRequest, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void GetFriendsLeaderboard(string profileID, CBSGetLeaderboardRequest leaderboardRequest, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void UpdateStatisticPoint(string profileID, string staticticName, int statisticValue, Action<ExecuteFunctionResult> onUpdate, Action<PlayFabError> onFailed)
		{
		}

		public void AddStatisticPoint(string profileID, string staticticName, int statisticValue, Action<ExecuteFunctionResult> onAdd, Action<PlayFabError> onFailed)
		{
		}

		public void ResetProfileLeaderboards(string profileID, Action<ExecuteFunctionResult> onReset, Action<PlayFabError> onFailed)
		{
		}

		public void AddClanStatisticPoint(string profileID, string clanID, string staticticName, int statisticValue, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void UpdateClanStatisticPoint(string profileID, string clanID, string staticticName, int statisticValue, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void GetClanLeaderboard(string clanID, CBSGetClanLeaderboardRequest leaderboardRequest, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void GetLeaderboardAroundClan(string clanID, CBSGetClanLeaderboardRequest leaderboardRequest, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}
	}
}
