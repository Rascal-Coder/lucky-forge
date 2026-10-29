using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CBS.Models;
using CBS.Playfab;

namespace CBS
{
	public class CBSClanModule : CBSModule, IClan, IClanExpirience, IClanEconomy, IClanTasks
	{
		[CompilerGenerated]
		private Action<CBSCreateClanResult> m_OnCreateClan;

		[CompilerGenerated]
		private Action<CBSJoinToClanResult> m_OnJoinClan;

		[CompilerGenerated]
		private Action m_OnLeaveClan;

		[CompilerGenerated]
		private Action m_OnDisbandClan;

		[CompilerGenerated]
		private Action<CBSAcceptDeclineClanRequestResult> m_OnProfileAccepted;

		[CompilerGenerated]
		private Action<CBSAcceptDeclineClanRequestResult> m_OnProfileDeclined;

		[CompilerGenerated]
		private Action<CBSDeclineInviteResult> m_OnDeclineInvation;

		[CompilerGenerated]
		private Action<CBSJoinToClanResult> m_OnProfileAcceptInvation;

		public string CurrentClanID { get; private set; }

		public string CurrentRoleID { get; private set; }

		public bool ExistInClan { get; private set; }

		public ClanEntity CurrentClanEntity { get; private set; }

		private IFabClan FabClan { get; set; }

		private IProfile Profile { get; set; }

		private ICBSItems Items { get; set; }

		public event Action<CBSCreateClanResult> OnCreateClan
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

		public event Action<CBSJoinToClanResult> OnJoinClan
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

		public event Action OnLeaveClan
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

		public event Action OnDisbandClan
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

		public event Action<CBSAcceptDeclineClanRequestResult> OnProfileAccepted
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

		public event Action<CBSAcceptDeclineClanRequestResult> OnProfileDeclined
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

		public event Action<CBSDeclineInviteResult> OnDeclineInvation
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

		public event Action<CBSJoinToClanResult> OnProfileAcceptInvation
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

		public void GetClanFullInformation(string clanID, Action<CBSGetClanFullInfoResult> result)
		{
		}

		public void CreateClan(CBSCreateClanRequest request, Action<CBSCreateClanResult> result)
		{
		}

		public void SearchClanByName(string clanName, Action<CBSGetClanEntityResult> result)
		{
		}

		public void GetClanEntity(string clanID, CBSClanConstraints constraints, Action<CBSGetClanEntityResult> result)
		{
		}

		public void GetClanOfProfile(string profileID, CBSClanConstraints constraints, Action<CBSGetClanEntityResult> result)
		{
		}

		public void InviteToClan(string profileIDToInvite, Action<CBSInviteToClanResult> result)
		{
		}

		public void GetProfileInvitations(CBSClanConstraints constraints, Action<CBSGetProfileInvationsResult> result)
		{
		}

		public void DeclineInvite(string clanID, Action<CBSDeclineInviteResult> result)
		{
		}

		public void AcceptInvite(string clanID, Action<CBSJoinToClanResult> result)
		{
		}

		public void JoinToClan(string clanID, Action<CBSJoinToClanResult> result)
		{
		}

		public void SendJoinRequest(string clanID, Action<CBSBaseResult> result)
		{
		}

		public void GetClanJoinRequestsList(CBSProfileConstraints constraints, Action<CBSGetClanJoinRequestListResult> result)
		{
		}

		public void AcceptProfileJoinRequest(string profileIDToAccept, Action<CBSAcceptDeclineClanRequestResult> result)
		{
		}

		public void DeclineProfileJoinRequest(string profileIDToDecline, Action<CBSAcceptDeclineClanRequestResult> result)
		{
		}

		public void LeaveClan(Action<CBSBaseResult> result)
		{
		}

		public void UpdateClanDescription(string description, Action<CBSBaseResult> result)
		{
		}

		public void UpdateClanAvatar(ClanAvatarInfo avatarInfo, Action<CBSBaseResult> result)
		{
		}

		public void UpdateClanVisibility(ClanVisibility visibility, Action<CBSBaseResult> result)
		{
		}

		public void UpdateClanDisplayName(string displayName, Action<CBSBaseResult> result)
		{
		}

		public void UpdateClanCustomData(string clanID, Dictionary<string, string> updateRequest, Action<CBSBaseResult> result)
		{
		}

		public void GetClanCustomData(string clanID, Action<CBSGetClanCustomDataResult> result)
		{
		}

		public void GetClanBadge(Action<CBSGetClanBadgeResult> result)
		{
		}

		public void GetClanMemberships(string clanID, CBSProfileConstraints constraints, Action<CBSGetClanMembersResult> result)
		{
		}

		public void KickClanMember(string profileIDToKick, Action<CBSBaseResult> result)
		{
		}

		public void ChangeMemberRole(string memberProfileID, string newRoleID, Action<CBSChangeRoleResult> result)
		{
		}

		public void DisbandClan(Action<CBSBaseResult> result)
		{
		}

		public void AddExpirienceToClan(string clanID, int expToAdd, Action<CBSLevelDataResult> result = null)
		{
		}

		public void GetClanLevelDetail(string clanID, Action<CBSLevelDataResult> result)
		{
		}

		public void GetClanInventory(string clanID, Action<CBSGetInventoryResult> result)
		{
		}

		public void GrantItemToClan(string clanID, string itemID, Action<CBSGrantItemsResult> result)
		{
		}

		public void GrantItemsToClan(string clanID, string[] itemsID, Action<CBSGrantItemsResult> result)
		{
		}

		public void GetClanCurrencies(string clanID, Action<CBSGetCurrenciesResult> result)
		{
		}

		public void AddCurrencyToClan(string clanID, string code, int amount, Action<CBSUpdateCurrencyResult> result = null)
		{
		}

		public void SubtractCurrencyFromClan(string clanID, string code, int amount, Action<CBSUpdateCurrencyResult> result = null)
		{
		}

		public void TransferItemFromProfileToClan(string itemInstanceID, Action<CBSClanTransferItemResult> result)
		{
		}

		public void TransferItemFromClanToProfile(string itemInstanceID, Action<CBSClanTransferItemResult> result)
		{
		}

		public void GetTasksForClan(Action<CBSGetTasksForClanResult> result)
		{
		}

		public void AddTaskPoint(string taskID, Action<CBSModifyClanTaskPointsResult> result)
		{
		}

		public void AddTaskPoints(string taskID, int points, Action<CBSModifyClanTaskPointsResult> result)
		{
		}

		public void ResetTasksForClan(Action<CBSGetTasksForClanResult> result)
		{
		}

		private void InternalGrantItemsToClan(string profileID, string clanID, string[] itemsIDs, Action<CBSGrantItemsResult> result)
		{
		}

		private void InternalModifyPoints(string clanID, string taskID, int points, ModifyMethod modify, Action<CBSModifyClanTaskPointsResult> result)
		{
		}

		internal void ParseClanInfo(string clanID, string roleID, ClanEntity clanEntity)
		{
		}
	}
}
