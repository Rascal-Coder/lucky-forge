using System;
using PlayFab;
using PlayFab.CloudScriptModels;

namespace CBS.Playfab
{
	public interface IFabEvents
	{
		void GetEventsList(bool activeonly, string specificCategory, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed);

		void GetEventByID(string eventID, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed);

		void GetEventsBadge(string category, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed);
	}
}
