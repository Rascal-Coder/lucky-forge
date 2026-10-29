using System;
using PlayFab;
using PlayFab.ClientModels;
using PlayFab.CloudScriptModels;

namespace CBS.Playfab
{
	public class FabCalendar : FabExecuter, IFabCalendar
	{
		public void GetAllAvailableCalendars(string profileID, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void GetCalendarByID(string profileID, string calendarID, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void PickupReward(string profileID, string calendarID, int index, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void ResetCalendar(string profileID, string calendarID, Action<ExecuteFunctionResult> onReset, Action<PlayFabError> onFailed)
		{
		}

		public void GetCalendarBadge(string profileID, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void GrantCalendar(string profileID, string calendarID, Action<ExecuteFunctionResult> onGrant, Action<PlayFabError> onFailed)
		{
		}

		public void PrePurchaseValidation(string profileID, string calendarID, Action<ExecuteFunctionResult> onValidate, Action<PlayFabError> onFailed)
		{
		}

		public void PurchaseCalendar(string calendarID, string currencyCode, int currencyValue, Action<PurchaseItemResult> onPurchase, Action<PlayFabError> onFailed)
		{
		}
	}
}
