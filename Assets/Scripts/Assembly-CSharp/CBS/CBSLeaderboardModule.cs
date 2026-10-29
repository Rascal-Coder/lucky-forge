using System;
using CBS.Models;
using CBS.Playfab;
using CBS.Scriptable;

namespace CBS
{
	public class CBSLeaderboardModule : CBSModule, ILeaderboard
	{
		private IFabLeaderboard FabLeaderboard { get; set; }

		private IProfile Profile { get; set; }

		private ProfileConfigData ProfileConfig { get; set; }

		protected override void Init()
		{
		}

		public void GetLevelLeadearboard(CBSGetLevelLeaderboardRequest request, Action<CBSGetLeaderboardResult> result)
		{
		}

		public void GetLevelLeadearboardAroundProfile(CBSGetLevelLeaderboardRequest request, Action<CBSGetLeaderboardResult> result)
		{
		}

		public void GetLeadearboard(CBSGetLeaderboardRequest request, Action<CBSGetLeaderboardResult> result)
		{
		}

		public void GetLeadearboardByProfileID(string profileID, CBSGetLeaderboardRequest request, Action<CBSGetLeaderboardResult> result)
		{
		}

		public void GetLeadearboardAround(CBSGetLeaderboardRequest request, Action<CBSGetLeaderboardResult> result)
		{
		}

		public void GetLeadearboardAroundByProfileID(string profileID, CBSGetLeaderboardRequest request, Action<CBSGetLeaderboardResult> result)
		{
		}

		public void GetFriendsLeadearboard(CBSGetLeaderboardRequest request, Action<CBSGetLeaderboardResult> result)
		{
		}

		public void UpdateStatisticPoint(string statisticName, int value, Action<CBSUpdateStatisticResult> result)
		{
		}

		public void AddStatisticPoint(string statisticName, int value, Action<CBSUpdateStatisticResult> result)
		{
		}

		public void ResetAllProfileStatistics(Action<CBSBaseResult> result)
		{
		}

		public void GetLeaderboardAroundClan(string clanID, CBSGetClanLeaderboardRequest request, Action<CBSGetClanLeaderboardResult> result)
		{
		}

		public void GetClanLeaderboard(CBSGetClanLeaderboardRequest request, Action<CBSGetClanLeaderboardResult> result)
		{
		}

		public void AddClanStatisticPoint(string statisticName, int value, Action<CBSUpdateClanStatisticResult> result)
		{
		}

		public void UpdateClanStatisticPoint(string statisticName, int value, Action<CBSUpdateClanStatisticResult> result)
		{
		}

		private void InternalGetProfileLeaderboard(string profileID, CBSGetLeaderboardRequest request, Action<CBSGetLeaderboardResult> result)
		{
		}

		private void InternalGetLeaderboardAroundProfile(string profileID, CBSGetLeaderboardRequest request, Action<CBSGetLeaderboardResult> result)
		{
		}

		private CBSProfileConstraints GetDefaultProfileConstraints()
		{
			return null;
		}

		private CBSClanConstraints GetDefaultClanConstraints()
		{
			return null;
		}
	}
}
