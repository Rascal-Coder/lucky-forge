using System;
using System.Collections.Generic;
using CBS.Models;
using PlayFab;
using PlayFab.ClientModels;

namespace CBS
{
	public interface IProfile
	{
		string ProfileID { get; }

		string DisplayName { get; }

		string ClanID { get; }

		DateTime RegistrationDate { get; }

		string EntityID { get; }

		string EntityType { get; }

		EntityKey EntityKey { get; }

		LevelInfo CachedLevelInfo { get; }

		Dictionary<string, UserDataRecord> CachedProfileData { get; }

		AccountLinkedInfo LinkedAccounts { get; }

		AvatarInfo Avatar { get; }

		bool ExistInClan { get; }

		ClanEntity ClanEntity { get; }

		PlayFabAuthenticationContext AuthenticationContex { get; }

		event Action<CBSUpdateDisplayNameResult> OnDisplayNameUpdated;

		event Action<CBSGetAccountInfoResult> OnAcountInfoGetted;

		event Action<CBSLevelDataResult> OnPlayerExperienceUpdated;

		event Action<AvatarInfo> OnAvatarUpdated;

		event Action<AccountLinkedInfo> OnLinkedAccountInfoChanged;

		void UpdateDisplayName(string userName, Action<CBSUpdateDisplayNameResult> result = null);

		void GetAccountInfo(Action<CBSGetAccountInfoResult> result);

		void GetProfileAccountInfo(string userID, Action<CBSGetAccountInfoResult> result);

		void AddExpirienceToProfile(int expToAdd, Action<CBSLevelDataResult> result = null);

		void GetProfileLevelDetail(Action<CBSLevelDataResult> result);

		void GetProfileLevelDetail(string profileID, Action<CBSLevelDataResult> result);

		void GetLevelTable(Action<CBSGetLevelTableResult> result);

		void GetProfileDetail(CBSGetProfileRequest request, Action<CBSGetProfileResult> result);

		void GetProfileDetailByDisplayName(string displayName, CBSProfileConstraints constraints, Action<CBSGetProfileResult> result);

		void GetProfilesDetails(CBSGetProfilesRequest request, Action<CBSGetProfilesResult> result);

		void UpdateAvatarUrl(string url, Action<CBSUpdateAvatarUrlResult> result);

		void UpdateAvatarID(string avatarID, Action<CBSUpdateAvatarIDResult> result);

		void PurchaseAvatar(string avatarID, Action<CBSPurchaseAvatarResult> result);

		void GrantAvatar(string avatarID, Action<CBSGrantAvatarResult> result);

		void GetProfileData(string key, Action<CBSGetProfileDataResult> result);

		void GetProfileData(string[] keys, Action<CBSGetProfileDataResult> result);

		void GetProfileDataByPlayerID(string playerID, string key, Action<CBSGetProfileDataResult> result);

		void GetProfileDataByPlayerID(string playerID, string[] keys, Action<CBSGetProfileDataResult> result);

		void SaveProfileData(string key, string value, Action<CBSBaseResult> result);

		void SaveProfileData(Dictionary<string, string> dataSet, Action<CBSBaseResult> result);

		void GetAccountLinkedInfo(Action<CBSGetAccountLinkedInfoResult> result);

		void UpdateOnlineState(Action<CBSBaseResult> result = null);

		void BanProfile(CBSBanProfileRequest request, Action<CBSBanProfileResult> result);

		void RevokeAllProfileBans(string profileID, Action<CBSBaseResult> result);

		void RevokeProfileBan(string banID, Action<CBSBaseResult> result);

		void GetProfileBanList(string profileID, Action<CBSBanListResult> result);

		void GetProfileAvatarID(Action<CBSGetProfileAvatarIDResult> result);

		void GetProfileAvatarID(string profileID, Action<CBSGetProfileAvatarIDResult> result);

		void GetProfileAvatarTable(Action<CBSGetProfileAvatarTableResult> result);

		void GetProfileAvatarTableWithStates(Action<CBSGetProfileAvatarTableWithStatesResult> result);

		void DeleteMasterPlayerAccount(Action<CBSBaseResult> result);
	}
}
