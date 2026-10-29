using System;
using System.Collections.Generic;
using PlayFab;
using PlayFab.CloudScriptModels;
using PlayFab.MultiplayerModels;

namespace CBS.Playfab
{
	public class FabMatchmaking : FabExecuter, IFabMatchmaking
	{
		public void GetMatchmakingList(Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void CreateTicket(string queueName, int waitTime, string entityID, List<PlayFab.MultiplayerModels.EntityKey> membersToMatchWith, MatchmakingPlayerAttributes attributes, Action<CreateMatchmakingTicketResult> onCreate, Action<PlayFabError> onFailed)
		{
		}

		public void GetMatchmakingTicket(string queueName, string ticketID, Action<GetMatchmakingTicketResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void GetQueue(string queueName, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void GetMatch(string queueName, string matchID, Action<GetMatchResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void CancelMatchForPlayer(string queueName, string entityID, Action<CancelAllMatchmakingTicketsForPlayerResult> onCancel, Action<PlayFabError> onFailed)
		{
		}

		public void GetMatch(string queueName, string matchID, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}
	}
}
