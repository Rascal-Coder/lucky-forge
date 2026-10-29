using System;
using CBS.Models;

namespace CBS
{
	public interface IFriends
	{
		event Action<string> OnFriendAccepted;

		event Action<string> OnFriendDeclined;

		event Action<string> OnFriendAdded;

		void GetFriends(CBSProfileConstraints profileConstraints, Action<CBSGetFriendsResult> result);

		void GetProfileFriends(string profileID, CBSProfileConstraints profileConstraints, Action<CBSGetFriendsResult> result);

		void GetRequestedFriends(CBSProfileConstraints profileConstraints, Action<CBSGetFriendsResult> result);

		void CheckFriendship(string profileID, Action<CBSCheckFriendshipResult> result);

		void SendFriendsRequest(string profileID, Action<CBSSendFriendsRequestResult> result);

		void RemoveFriend(string profileID, Action<CBSActionWithFriendResult> result);

		void DeclineFriendRequest(string profileID, Action<CBSActionWithFriendResult> result);

		void AcceptFriend(string profileID, Action<CBSActionWithFriendResult> result);

		void ForceAddFriend(string profileID, Action<CBSActionWithFriendResult> result);

		void GetFriendsBadge(Action<CBSBadgeResult> result);

		void GetSharedFriendsWithProfile(string withProfileID, CBSProfileConstraints profileConstraints, Action<CBSGetFriendsResult> result);

		void GetOutgoingRequests(CBSProfileConstraints profileConstraints, Action<CBSGetFriendsResult> result);
	}
}
