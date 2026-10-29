using System;
using System.Runtime.CompilerServices;
using CBS.Models;
using CBS.Playfab;

namespace CBS
{
	public class CBSBattlePassModule : CBSModule, IBattlePass
	{
		[CompilerGenerated]
		private Action<string, int> m_OnExpirienceAdded;

		[CompilerGenerated]
		private Action<GrantRewardResult> m_OnRewardRecived;

		[CompilerGenerated]
		private Action<BattlePassTicket> m_OnTicketPurchased;

		private IFabBattlePass FabBattlePass { get; set; }

		private IProfile Profile { get; set; }

		private ICBSInAppPurchase InAppPurchase { get; set; }

		public event Action<string, int> OnExpirienceAdded
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

		public event Action<GrantRewardResult> OnRewardRecived
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

		public event Action<BattlePassTicket> OnTicketPurchased
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

		public void GetBattlePassStates(Action<CBSGetPlayerBattlePassStatesResult> result)
		{
		}

		public void GetBattlePassState(string battlePassID, Action<CBSGetPlayerBattlePassStatesResult> result)
		{
		}

		public void GetBattlePassFullInformation(string battlePassID, Action<CBSGetBattlePassFullInformationResult> result)
		{
		}

		public void AddExpirienceToInstance(string battlePassID, int exp, Action<CBSAddExpirienceToInstanceResult> result)
		{
		}

		public void AddExpirienceToAllActiveInstances(int exp, Action<CBSAddExpirienceToAllInstancesResult> result)
		{
		}

		public void GrantAwardToProfile(string battlePassID, int level, bool isPremium, Action<CBSGrantAwardToPlayerResult> result)
		{
		}

		public void GrantTicket(string battlePassID, string ticketID, Action<CBSGrantTicketResult> result)
		{
		}

		public void ResetBattlePassStateForProfile(string battlePassID, Action<CBSResetBattlePassStateResult> result)
		{
		}

		public void PurchaseTicket(string battlePassID, string ticketID, Action<CBSPurchaseTicketResult> result)
		{
		}

		public void PurchaseTicketWithRealMoney(string battlePassID, string ticketID, Action<CBSPurchaseTicketWithRMResult> result)
		{
		}

		public void GetBattlePassTasksForProfile(string battlePassID, Action<CBSGetTasksForProfileResult> result)
		{
		}

		public void AddBattlePassTaskPoints(string battlePassID, string taskID, int points, Action<CBSModifyProfileTaskPointsResult> result)
		{
		}

		public void PickupBattlePassTaskReward(string battlepassID, string taskID, Action<CBSModifyProfileTaskPointsResult> result)
		{
		}

		private void GetProfileStatesFromRequest(CBSBattlePassProfileStateRequest request, Action<CBSGetPlayerBattlePassStatesResult> result)
		{
		}
	}
}
