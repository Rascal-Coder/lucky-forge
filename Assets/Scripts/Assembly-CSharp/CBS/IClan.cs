using System;
using System.Collections.Generic;
using CBS.Models;

namespace CBS
{
	public interface IClan : IClanExpirience, IClanEconomy, IClanTasks
	{
		string CurrentClanID { get; }

		string CurrentRoleID { get; }

		bool ExistInClan { get; }

		ClanEntity CurrentClanEntity { get; }

		event Action<CBSCreateClanResult> OnCreateClan;

		event Action<CBSJoinToClanResult> OnJoinClan;

		event Action OnLeaveClan;

		event Action OnDisbandClan;

		event Action<CBSAcceptDeclineClanRequestResult> OnProfileAccepted;

		event Action<CBSAcceptDeclineClanRequestResult> OnProfileDeclined;

		event Action<CBSDeclineInviteResult> OnDeclineInvation;

		event Action<CBSJoinToClanResult> OnProfileAcceptInvation;

		void CreateClan(CBSCreateClanRequest request, Action<CBSCreateClanResult> result);

		void SearchClanByName(string clanName, Action<CBSGetClanEntityResult> result);

		void GetClanEntity(string clanID, CBSClanConstraints constraints, Action<CBSGetClanEntityResult> result);

		void GetClanOfProfile(string profileID, CBSClanConstraints constraints, Action<CBSGetClanEntityResult> result);

		void GetClanFullInformation(string clanID, Action<CBSGetClanFullInfoResult> result);

		void SendJoinRequest(string clanID, Action<CBSBaseResult> result);

		void LeaveClan(Action<CBSBaseResult> result);

		void DisbandClan(Action<CBSBaseResult> result);

		void InviteToClan(string profileIDToInvite, Action<CBSInviteToClanResult> result);

		void GetProfileInvitations(CBSClanConstraints constraints, Action<CBSGetProfileInvationsResult> result);

		void DeclineInvite(string clanID, Action<CBSDeclineInviteResult> result);

		void AcceptInvite(string clanID, Action<CBSJoinToClanResult> result);

		void JoinToClan(string clanID, Action<CBSJoinToClanResult> result);

		void UpdateClanDescription(string description, Action<CBSBaseResult> result);

		void UpdateClanAvatar(ClanAvatarInfo clanAvatarInfo, Action<CBSBaseResult> result);

		void UpdateClanVisibility(ClanVisibility visibility, Action<CBSBaseResult> result);

		void UpdateClanDisplayName(string displayName, Action<CBSBaseResult> result);

		void UpdateClanCustomData(string clanID, Dictionary<string, string> updateRequest, Action<CBSBaseResult> result);

		void GetClanCustomData(string clanID, Action<CBSGetClanCustomDataResult> result);

		void GetClanJoinRequestsList(CBSProfileConstraints constraints, Action<CBSGetClanJoinRequestListResult> result);

		void AcceptProfileJoinRequest(string profileIDToAccept, Action<CBSAcceptDeclineClanRequestResult> result);

		void DeclineProfileJoinRequest(string profileIDToDecline, Action<CBSAcceptDeclineClanRequestResult> result);

		void GetClanMemberships(string clanID, CBSProfileConstraints constraints, Action<CBSGetClanMembersResult> result);

		void GetClanBadge(Action<CBSGetClanBadgeResult> result);

		void KickClanMember(string profileIdToKick, Action<CBSBaseResult> result);

		void ChangeMemberRole(string memberProfileID, string newRoleID, Action<CBSChangeRoleResult> result);
	}
}
