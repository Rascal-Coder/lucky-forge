using System;
using CBS.Models;
using PlayFab;
using PlayFab.CloudScriptModels;

namespace CBS.Playfab
{
	public class FabFriends : FabExecuter, IFabFriends
	{
		public void GetFriendsList(string profileID, CBSProfileConstraints constraints, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void GetRequestedFriendsList(string profileID, CBSProfileConstraints constraints, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void GetOutgoingRequests(string profileID, CBSProfileConstraints constraints, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void SendFriendsRequest(string profileID, string friendProfileID, Action<ExecuteFunctionResult> onAdd, Action<PlayFabError> onFailed)
		{
		}

		public void RemoveFriend(string profileID, string friendProfileID, Action<ExecuteFunctionResult> onRemove, Action<PlayFabError> onFailed)
		{
		}

		public void AcceptFriend(string profileID, string friendProfileID, Action<ExecuteFunctionResult> onAccept, Action<PlayFabError> onFailed)
		{
		}

		public void DeclineFriend(string profileID, string friendProfileID, Action<ExecuteFunctionResult> onDecline, Action<PlayFabError> onFailed)
		{
		}

		public void ForceAddFriend(string profileID, string friendProfileID, Action<ExecuteFunctionResult> onAdd, Action<PlayFabError> onFailed)
		{
		}

		public void CheckFriendship(string profileID, string friendProfileID, Action<ExecuteFunctionResult> onCheck, Action<PlayFabError> onFailed)
		{
		}

		public void GetFriendsBadge(string profileID, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void GetSharedFriends(string profileID, string withProfileID, CBSProfileConstraints constraints, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}
	}
}
