using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CBS.Core.Auth;
using CBS.Models;
using CBS.Playfab;
using CBS.Scriptable;
using PlayFab;
using PlayFab.ClientModels;

namespace CBS
{
	public class CBSProfileModule : CBSModule, IProfile
	{
		[CompilerGenerated]
		private Action<CBSUpdateDisplayNameResult> m_OnDisplayNameUpdated;

		[CompilerGenerated]
		private Action<AvatarInfo> m_OnAvatarUpdated;

		[CompilerGenerated]
		private Action<CBSGetAccountInfoResult> m_OnAcountInfoGetted;

		[CompilerGenerated]
		private Action<CBSLevelDataResult> m_OnPlayerExperienceUpdated;

		[CompilerGenerated]
		private Action<AccountLinkedInfo> m_OnLinkedAccountInfoChanged;

		private IAuth Auth { get; set; }

		private IFabProfile FabProfile { get; set; }

		private OnlineStatusProcessor OnlineProcessor { get; set; }

		private int OnlineThreshold { get; set; }

		private AuthData AuthData { get; set; }

		private ProfileConfigData ProfileData { get; set; }

		public string ProfileID { get; private set; }

		public string DisplayName { get; private set; }

		public string ClanID { get; private set; }

		public DateTime RegistrationDate { get; private set; }

		public string EntityID { get; private set; }

		public string EntityType { get; private set; }

		public EntityKey EntityKey => null;

		public LevelInfo CachedLevelInfo { get; private set; }

		public AccountLinkedInfo LinkedAccounts { get; private set; }

		public Dictionary<string, UserDataRecord> CachedProfileData { get; private set; }

		public AvatarInfo Avatar { get; private set; }

		public bool ExistInClan { get; private set; }

		public ClanEntity ClanEntity { get; private set; }

		public PlayFabAuthenticationContext AuthenticationContex { get; private set; }

		public event Action<CBSUpdateDisplayNameResult> OnDisplayNameUpdated
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<AvatarInfo> OnAvatarUpdated
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<CBSGetAccountInfoResult> OnAcountInfoGetted
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<CBSLevelDataResult> OnPlayerExperienceUpdated
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<AccountLinkedInfo> OnLinkedAccountInfoChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		protected override void Init()
		{
		}

		public void UpdateDisplayName(string displayName, Action<CBSUpdateDisplayNameResult> result = null)
		{
		}

		public void GetAccountInfo(Action<CBSGetAccountInfoResult> result)
		{
		}

		public void GetProfileAccountInfo(string profileID, Action<CBSGetAccountInfoResult> result)
		{
		}

		public void AddExpirienceToProfile(int expToAdd, Action<CBSLevelDataResult> result = null)
		{
		}

		public void GetProfileLevelDetail(Action<CBSLevelDataResult> result)
		{
		}

		public void GetProfileLevelDetail(string profileID, Action<CBSLevelDataResult> result)
		{
		}

		public void GetLevelTable(Action<CBSGetLevelTableResult> result)
		{
		}

		public void GetProfileDetail(CBSGetProfileRequest request, Action<CBSGetProfileResult> result)
		{
		}

		public void GetProfileDetailByDisplayName(string displayName, CBSProfileConstraints constraints, Action<CBSGetProfileResult> result)
		{
		}

		public void GetProfilesDetails(CBSGetProfilesRequest request, Action<CBSGetProfilesResult> result)
		{
		}

		public void GetProfileData(string key, Action<CBSGetProfileDataResult> result)
		{
		}

		public void GetProfileData(string[] keys, Action<CBSGetProfileDataResult> result)
		{
		}

		public void GetProfileDataByPlayerID(string playerID, string key, Action<CBSGetProfileDataResult> result)
		{
		}

		public void GetProfileDataByPlayerID(string playerID, string[] keys, Action<CBSGetProfileDataResult> result)
		{
		}

		public void SaveProfileData(string key, string value, Action<CBSBaseResult> result)
		{
		}

		public void SaveProfileData(Dictionary<string, string> dataSet, Action<CBSBaseResult> result)
		{
		}

		public void UpdateAvatarUrl(string url, Action<CBSUpdateAvatarUrlResult> result)
		{
		}

		public void UpdateAvatarID(string avatarID, Action<CBSUpdateAvatarIDResult> result)
		{
		}

		public void GrantAvatar(string avatarID, Action<CBSGrantAvatarResult> result)
		{
		}

		public void PurchaseAvatar(string avatarID, Action<CBSPurchaseAvatarResult> result)
		{
		}

		public void GetAccountLinkedInfo(Action<CBSGetAccountLinkedInfoResult> result)
		{
		}

		public void UpdateOnlineState(Action<CBSBaseResult> result = null)
		{
		}

		public void BanProfile(CBSBanProfileRequest request, Action<CBSBanProfileResult> result)
		{
		}

		public void RevokeAllProfileBans(string profileID, Action<CBSBaseResult> result)
		{
		}

		public void RevokeProfileBan(string banID, Action<CBSBaseResult> result)
		{
		}

		public void GetProfileBanList(string profileID, Action<CBSBanListResult> result)
		{
		}

		public void GetProfileAvatarID(Action<CBSGetProfileAvatarIDResult> result)
		{
		}

		public void GetProfileAvatarID(string profileID, Action<CBSGetProfileAvatarIDResult> result)
		{
		}

		public void GetProfileAvatarTable(Action<CBSGetProfileAvatarTableResult> result)
		{
		}

		public void GetProfileAvatarTableWithStates(Action<CBSGetProfileAvatarTableWithStatesResult> result)
		{
		}

		public void DeleteMasterPlayerAccount(Action<CBSBaseResult> result)
		{
		}

		private void InternalGetProfileData(string profileID, string[] keys, Action<CBSGetProfileDataResult> result)
		{
		}

		internal void ParseUserData(Dictionary<string, UserDataRecord> data)
		{
		}

		internal AccountLinkedInfo ParseLinkedInfo(UserAccountInfo info)
		{
			return null;
		}

		internal void CacheLinkedInfo(AccountLinkedInfo info)
		{
		}

		internal LevelInfo ParseLevelData(string rawData, bool updateCache = true)
		{
			return null;
		}

		internal LevelInfo ParseLevelData(LevelInfo info)
		{
			return null;
		}

		internal void ParseAvatarID(string avatarID)
		{
		}

		internal void ParseClanInfo(string clanID, ClanEntity clanEntity)
		{
		}

		internal void ParseAvatarUrl(string avatarURL)
		{
		}

		internal void ParseLoginResult(CBSLoginResult resultData)
		{
		}

		internal void ParseAccountInfo(UserAccountInfo resultData)
		{
		}

		internal void NotifyAboutChangingLinkedAccount(CredentialType type, bool isLinked)
		{
		}

		protected override void OnLogout()
		{
		}

		private void OnProfileLoggedIn(CBSLoginResult result)
		{
		}
	}
}
