using CBS.Models;

namespace CBS.UI
{
	public class NotificationBadge : BaseBadge
	{
		private INotificationCenter Notifications { get; set; }

		private ICBSChat Chat { get; set; }

		private int NotificationsCount { get; set; }

		private int DialogsCount { get; set; }

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void GetNotificationsBadge()
		{
		}

		private void GetDialogsBadge()
		{
		}

		private void OnRewardCollected(GrantRewardResult result)
		{
		}

		private void OnReadNotification(CBSNotification result)
		{
		}

		private void OnGetNotificationBadge(CBSBadgeResult result)
		{
		}

		private void OnGetDialogBadge(CBSBadgeResult result)
		{
		}

		private void OnDialogBadgeChange(ChatDialogEntry dialogEntry)
		{
		}
	}
}
