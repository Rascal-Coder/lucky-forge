using System;
using CBS.Models;

namespace CBS
{
	public interface IMatchmaking
	{
		string ActiveQueue { get; }

		string ActiveTicketID { get; }

		MatchmakingStatus Status { get; }

		event Action<MatchmakingStatus> OnStatusChanged;

		event Action<CBSStartMatchResult> OnMatchStart;

		void GetMatchmakingQueuesList(Action<CBSGetMatchmakingListResult> result);

		void FindMatch(CBSFindMatchRequest request, Action<CBSFindMatchResult> result);

		void GetMatchmakingQueue(string queueName, Action<CBSGetQueueResult> result);

		void CancelMatch(string queueName, Action<CBSBaseResult> result);

		void GetMatch(string queueName, string matchID, Action<CBSGetMatchResult> result);
	}
}
