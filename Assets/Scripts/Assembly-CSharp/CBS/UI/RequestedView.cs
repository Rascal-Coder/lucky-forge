using CBS.Models;
using UnityEngine;

namespace CBS.UI
{
	public class RequestedView : FriendsSection
	{
		[SerializeField]
		private FriendsListScroller Scroller;

		public override FriendsTabTitle TabTitle => FriendsTabTitle.FRIENDS;

		private void Start()
		{
		}

		private void OnDestroy()
		{
		}

		public override void Clean()
		{
		}

		public override void Display()
		{
		}

		private void OnFriendsGet(CBSGetFriendsResult result)
		{
		}

		private void OnFriendDeclined(string profileID)
		{
		}

		private void OnFriendAccepted(string profileID)
		{
		}
	}
}
