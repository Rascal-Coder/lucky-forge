using System;
using PlayFab;
using PlayFab.CloudScriptModels;

namespace CBS.Playfab
{
	public class FabEvents : FabExecuter, IFabEvents
	{
		public void GetEventsList(bool activeonly, string specificCategory, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void GetEventByID(string eventID, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void GetEventsBadge(string category, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}
	}
}
