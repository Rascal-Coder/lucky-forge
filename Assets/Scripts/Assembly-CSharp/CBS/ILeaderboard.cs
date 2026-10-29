using System;
using CBS.Models;

namespace CBS
{
	public interface ILeaderboard
	{
		void GetLevelLeadearboard(CBSGetLevelLeaderboardRequest request, Action<CBSGetLeaderboardResult> result);

		void GetFriendsLeadearboard(CBSGetLeaderboardRequest request, Action<CBSGetLeaderboardResult> result);

		void GetLeadearboard(CBSGetLeaderboardRequest request, Action<CBSGetLeaderboardResult> result);

		void GetLeadearboardByProfileID(string profileID, CBSGetLeaderboardRequest request, Action<CBSGetLeaderboardResult> result);

		void UpdateStatisticPoint(string statisticName, int value, Action<CBSUpdateStatisticResult> result);

		void AddStatisticPoint(string statisticName, int value, Action<CBSUpdateStatisticResult> result);

		void ResetAllProfileStatistics(Action<CBSBaseResult> result);

		void GetLevelLeadearboardAroundProfile(CBSGetLevelLeaderboardRequest request, Action<CBSGetLeaderboardResult> result);

		void GetLeadearboardAround(CBSGetLeaderboardRequest request, Action<CBSGetLeaderboardResult> result);

		void GetLeadearboardAroundByProfileID(string profileID, CBSGetLeaderboardRequest request, Action<CBSGetLeaderboardResult> result);

		void AddClanStatisticPoint(string statisticName, int value, Action<CBSUpdateClanStatisticResult> result);

		void UpdateClanStatisticPoint(string statisticName, int value, Action<CBSUpdateClanStatisticResult> result);

		void GetClanLeaderboard(CBSGetClanLeaderboardRequest request, Action<CBSGetClanLeaderboardResult> result);

		void GetLeaderboardAroundClan(string clanID, CBSGetClanLeaderboardRequest request, Action<CBSGetClanLeaderboardResult> result);
	}
}
