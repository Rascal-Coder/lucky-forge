using System;
using System.Collections.Generic;
using CBS.Models;
using PlayFab;
using PlayFab.ClientModels;
using PlayFab.CloudScriptModels;

namespace CBS.Playfab
{
	public class FabProfile : FabExecuter, IFabProfile
	{
		public void GetUserAccountInfo(string playerID, Action<GetAccountInfoResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void UpdateUserDisplayName(string profileID, string displayName, bool profanityCheck, Action<ExecuteFunctionResult> onUpdate, Action<PlayFabError> onFailed)
		{
		}

		public void AddPlayerExpirience(string profileID, int expToAdd, Action<ExecuteFunctionResult> onAdd, Action<PlayFabError> onFailed)
		{
		}

		public void GetProfileExpirienceDetail(string profileID, Action<ExecuteFunctionResult> onUpdate, Action<PlayFabError> onFailed)
		{
		}

		public void GetProfileDetail(string profileID, CBSProfileConstraints constraints, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void GetProfileDetailByDisplayName(string displayName, CBSProfileConstraints constraints, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void GetProfilesDetails(string[] profilesIDs, CBSProfileConstraints constraints, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void GetLevelTable(string profileID, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void SetAvatarUrl(string profileID, string imageUrl, Action<ExecuteFunctionResult> onSet, Action<PlayFabError> onFailed)
		{
		}

		public void SetProfileData(string profileID, string key, string value, Action<ExecuteFunctionResult> onSet, Action<PlayFabError> onFailed)
		{
		}

		public void SetProfileData(string profileID, Dictionary<string, string> dataSet, Action<ExecuteFunctionResult> onSet, Action<PlayFabError> onFailed)
		{
		}

		public void GetProfileData(string profileID, string[] keys, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void GetCombinedAccountInfo(string profileID, Action<GetAccountInfoResult> onSuccess, Action<PlayFabError> onFailed)
		{
		}

		public void UpdateProfileOnlineState(string profileID, int onlineThreshold, Action<ExecuteFunctionResult> onUpdate, Action<PlayFabError> onFailed)
		{
		}

		public void BanProfile(string profileID, string reason, uint hours, Action<ExecuteFunctionResult> onBan, Action<PlayFabError> onFailed)
		{
		}

		public void RevokeAllBans(string profileID, Action<ExecuteFunctionResult> onBan, Action<PlayFabError> onFailed)
		{
		}

		public void RevokeProfileBan(string banID, Action<ExecuteFunctionResult> onBan, Action<PlayFabError> onFailed)
		{
		}

		public void GetProfileBans(string profileID, Action<ExecuteFunctionResult> onBan, Action<PlayFabError> onFailed)
		{
		}

		public void UpdateProfileAvatarID(string profileID, string avatarID, Action<ExecuteFunctionResult> onUpdate, Action<PlayFabError> onFailed)
		{
		}

		public void PurchaseAvatar(string profileID, string avatarID, Action<ExecuteFunctionResult> onPurchase, Action<PlayFabError> onFailed)
		{
		}

		public void GrantAvatar(string profileID, string avatarID, Action<ExecuteFunctionResult> onGrant, Action<PlayFabError> onFailed)
		{
		}

		public void GetProfileAvatarID(string profileID, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void GetProfileAvatarTable(Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void GetProfileAvatarTableWithStates(string profileID, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void DeleteMasterPlayerAccount(Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}
	}
}
