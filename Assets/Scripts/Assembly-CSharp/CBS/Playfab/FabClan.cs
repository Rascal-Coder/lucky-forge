using System;
using System.Collections.Generic;
using CBS.Models;
using PlayFab;
using PlayFab.CloudScriptModels;

namespace CBS.Playfab
{
	public class FabClan : FabExecuter, IFabClan
	{
		public void CreateClan(FunctionCreateClanRequest clanRequest, Action<ExecuteFunctionResult> onCreate, Action<PlayFabError> onFailed)
		{
		}

		public void SearchClan(string clanName, Action<ExecuteFunctionResult> onSearch, Action<PlayFabError> onFailed)
		{
		}

		public void GetClanEntity(string clanID, CBSClanConstraints constraints, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void GetClanOfProfile(string profileID, CBSClanConstraints constraints, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void InviteToClan(string profileID, string profileIDToInvite, Action<ExecuteFunctionResult> onInvite, Action<PlayFabError> onFailed)
		{
		}

		public void GetProfileInvations(string profileID, CBSClanConstraints constraints, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void SendJoinRequest(string profileID, string clanID, Action<ExecuteFunctionResult> onSend, Action<PlayFabError> onFailed)
		{
		}

		public void GetJoinRequestList(string clanID, CBSProfileConstraints constraints, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void AcceptJoinRequest(string profileID, string profileIDToAccept, string clanID, Action<ExecuteFunctionResult> onAccept, Action<PlayFabError> onFailed)
		{
		}

		public void DeclineJoinRequest(string profileID, string profileIDToDecline, string clanID, Action<ExecuteFunctionResult> onDecline, Action<PlayFabError> onFailed)
		{
		}

		public void GetClanFullInfo(string clanID, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void AcceptInvite(string profileID, string clanID, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void DeclineInvite(string profileID, string clanID, Action<ExecuteFunctionResult> onDecline, Action<PlayFabError> onFailed)
		{
		}

		public void JoinToClan(string profileID, string clanID, Action<ExecuteFunctionResult> onJoin, Action<PlayFabError> onFailed)
		{
		}

		public void LeaveClan(string profileID, string clanID, Action<ExecuteFunctionResult> onLeave, Action<PlayFabError> onFailed)
		{
		}

		public void UpdateDisplayName(string profileID, string clanID, string displayName, Action<ExecuteFunctionResult> onUpdate, Action<PlayFabError> onFailed)
		{
		}

		public void UpdateDescription(string profileID, string clanID, string description, Action<ExecuteFunctionResult> onUpdate, Action<PlayFabError> onFailed)
		{
		}

		public void UpdateVisibility(string profileID, string clanID, ClanVisibility visibility, Action<ExecuteFunctionResult> onUpdate, Action<PlayFabError> onFailed)
		{
		}

		public void UpdateAvatar(string profileID, string clanID, ClanAvatarInfo avatarInfo, Action<ExecuteFunctionResult> onUpdate, Action<PlayFabError> onFailed)
		{
		}

		public void UpdateCustomData(string profileID, string clanID, Dictionary<string, string> updateRequest, Action<ExecuteFunctionResult> onUpdate, Action<PlayFabError> onFailed)
		{
		}

		public void GetCustomData(string profileID, string clanID, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void GetBadge(string profileID, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void GetClanMembers(string clanID, CBSProfileConstraints constraints, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void KickMember(string profileID, string profileIDToKick, string clanID, Action<ExecuteFunctionResult> onKick, Action<PlayFabError> onFailed)
		{
		}

		public void ChangeMemberRole(string profileID, string profileIDToChange, string clanID, string newRoleID, Action<ExecuteFunctionResult> onChange, Action<PlayFabError> onFailed)
		{
		}

		public void DisbandClan(string profileID, string clanID, Action<ExecuteFunctionResult> onDisband, Action<PlayFabError> onFailed)
		{
		}

		public void AddExpirience(string profileID, string clanID, int expToAdd, Action<ExecuteFunctionResult> onAdd, Action<PlayFabError> onFailed)
		{
		}

		public void GetLevelInfo(string profileID, string clanID, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void GetInventory(string profileID, string clanID, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void GrantItems(string profileID, string clanID, string[] itemsIDs, bool containPack, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void GetCurrency(string profileID, string clanID, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void AddCurrency(string profileID, string clanID, string code, int amount, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void SubtractCurrency(string profileID, string clanID, string code, int amount, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void TransferItemFromProfileToClan(string profileID, string clanID, PlayFabAuthenticationContext auth, string itemInstanceID, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void TransferItemFromClanToProfile(string profileID, string clanID, PlayFabAuthenticationContext auth, string itemInstanceID, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void GetTasksForClan(string profileID, string clanID, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void ModifyTasksPoint(string profileID, string clanID, string taskID, int points, ModifyMethod method, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void ResetTasksForClan(string profileID, string clanID, Action<ExecuteFunctionResult> onReset, Action<PlayFabError> onFailed)
		{
		}
	}
}
