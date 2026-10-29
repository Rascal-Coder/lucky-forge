using System;
using System.Runtime.CompilerServices;
using CBS.Models;
using CBS.Playfab;
using CBS.Scriptable;

namespace CBS
{
	public class CBSFriendsModule : CBSModule, IFriends
	{
		[CompilerGenerated]
		private Action<string> m_OnFriendAccepted;

		[CompilerGenerated]
		private Action<string> m_OnFriendDeclined;

		[CompilerGenerated]
		private Action<string> m_OnFriendAdded;

		private IFabFriends FabFriends { get; set; }

		private IProfile Profile { get; set; }

		private ProfileConfigData ProfileConfig { get; set; }

		public event Action<string> OnFriendAccepted
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

		public event Action<string> OnFriendDeclined
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

		public event Action<string> OnFriendAdded
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

		public void GetFriends(CBSProfileConstraints profileConstraints, Action<CBSGetFriendsResult> result)
		{
		}

		public void GetProfileFriends(string profileID, CBSProfileConstraints profileConstraints, Action<CBSGetFriendsResult> result)
		{
		}

		public void GetRequestedFriends(CBSProfileConstraints profileConstraints, Action<CBSGetFriendsResult> result)
		{
		}

		public void GetOutgoingRequests(CBSProfileConstraints profileConstraints, Action<CBSGetFriendsResult> result)
		{
		}

		public void CheckFriendship(string friendProfileID, Action<CBSCheckFriendshipResult> result)
		{
		}

		public void SendFriendsRequest(string friendID, Action<CBSSendFriendsRequestResult> result)
		{
		}

		public void RemoveFriend(string friendProfileID, Action<CBSActionWithFriendResult> result)
		{
		}

		public void DeclineFriendRequest(string friendProfileID, Action<CBSActionWithFriendResult> result)
		{
		}

		public void AcceptFriend(string friendProfileID, Action<CBSActionWithFriendResult> result)
		{
		}

		public void ForceAddFriend(string friendProfileID, Action<CBSActionWithFriendResult> result)
		{
		}

		public void GetFriendsBadge(Action<CBSBadgeResult> result)
		{
		}

		public void GetSharedFriendsWithProfile(string withProfileID, CBSProfileConstraints profileConstraints, Action<CBSGetFriendsResult> result)
		{
		}

		public void InternalGetProfileFriends(string profileID, CBSProfileConstraints profileConstraints, Action<CBSGetFriendsResult> result)
		{
		}

		private CBSProfileConstraints GetDefaultProfileConstraints()
		{
			return null;
		}
	}
}
