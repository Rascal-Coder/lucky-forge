using CBS.Models;
using UnityEngine;

namespace CBS.UI
{
	public class FriendsView : FriendsSection
	{
		[SerializeField]
		protected FriendsListScroller Scroller;

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

		protected virtual void OnFriendsGet(CBSGetFriendsResult result)
		{
		}

		private void OnFriendRemoved(string profileID)
		{
		}
	}
}
