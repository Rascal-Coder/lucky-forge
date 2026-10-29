using CBS.Models;

namespace CBS.UI
{
	public class FriendsBadge : BaseBadge
	{
		private IFriends Friends { get; set; }

		private int FriendsCount { get; set; }

		private void Awake()
		{
		}

		protected virtual void OnEnable()
		{
		}

		protected virtual void OnDisable()
		{
		}

		private void OnGetBadge(CBSBadgeResult result)
		{
		}

		private void OnFriendAccepted(string profileID)
		{
		}

		private void OnFriendDeclined(string profileID)
		{
		}

		protected override void OnUpdateInterval()
		{
		}
	}
}
