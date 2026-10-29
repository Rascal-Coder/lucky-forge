using System;
using CBS.Models;

namespace CBS
{
	public interface IBattlePass
	{
		event Action<GrantRewardResult> OnRewardRecived;

		event Action<string, int> OnExpirienceAdded;

		event Action<BattlePassTicket> OnTicketPurchased;

		void GetBattlePassStates(Action<CBSGetPlayerBattlePassStatesResult> result);

		void GetBattlePassState(string battlePassID, Action<CBSGetPlayerBattlePassStatesResult> result);

		void GetBattlePassFullInformation(string battlePassID, Action<CBSGetBattlePassFullInformationResult> result);

		void AddExpirienceToInstance(string instanceID, int exp, Action<CBSAddExpirienceToInstanceResult> result);

		void AddExpirienceToAllActiveInstances(int exp, Action<CBSAddExpirienceToAllInstancesResult> result);

		void GrantAwardToProfile(string battlePassID, int level, bool isPremium, Action<CBSGrantAwardToPlayerResult> result);

		void ResetBattlePassStateForProfile(string battlePassID, Action<CBSResetBattlePassStateResult> result);

		void GrantTicket(string battlePassID, string ticketID, Action<CBSGrantTicketResult> result);

		void PurchaseTicket(string battlePassID, string ticketID, Action<CBSPurchaseTicketResult> result);

		void PurchaseTicketWithRealMoney(string battlePassID, string ticketID, Action<CBSPurchaseTicketWithRMResult> result);

		void AddBattlePassTaskPoints(string battlePassID, string taskID, int points, Action<CBSModifyProfileTaskPointsResult> result);

		void GetBattlePassTasksForProfile(string battlePassID, Action<CBSGetTasksForProfileResult> result);

		void PickupBattlePassTaskReward(string battlepassID, string taskID, Action<CBSModifyProfileTaskPointsResult> result);
	}
}
