using System;
using PlayFab;
using PlayFab.ClientModels;
using PlayFab.CloudScriptModels;

namespace CBS.Playfab
{
	public class FabBattlePass : FabExecuter, IFabBattlePass
	{
		public void GetProfileBattlePassStates(string profileID, string battlePassID, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void GetBattlePassFullInformation(string profileID, string battlePassID, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void AddExpirienceToInstance(string profileID, int exp, string battlePassID, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void GetRewardFromInstance(string profileID, string battlePassID, int level, bool IsPremium, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void GetPremiumAccess(string profileID, string battlePassID, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void ResetInstanceForProfile(string profileID, string battlePassID, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void PrePurchaseValidation(string profileID, string battlePassID, string ticketID, Action<ExecuteFunctionResult> onValidate, Action<PlayFabError> onFailed)
		{
		}

		public void PostPurchaseValidation(string profileID, string battlePassID, string ticketID, Action<ExecuteFunctionResult> onValidate, Action<PlayFabError> onFailed)
		{
		}

		public void PurchaseTicket(string ticketCatalogID, string currencyCode, int currencyValue, Action<PurchaseItemResult> onPurchase, Action<PlayFabError> onFailed)
		{
		}

		public void GrantTicket(string profileID, string battlePassID, string ticketID, Action<ExecuteFunctionResult> onGrant, Action<PlayFabError> onFailed)
		{
		}

		public void GetBattlePassTasks(string profileID, string battlePassID, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void AddBattlePassTaskPoints(string profileID, string battlePassID, string taskID, int points, Action<ExecuteFunctionResult> onAdd, Action<PlayFabError> onFailed)
		{
		}

		public void PickupBattlePassTaskReward(string profileID, string battlePassID, string taskID, Action<ExecuteFunctionResult> onPick, Action<PlayFabError> onFailed)
		{
		}
	}
}
