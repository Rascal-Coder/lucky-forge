using System;
using CBS.Models;

namespace CBS
{
	public interface INotificationCenter
	{
		event Action<GrantRewardResult> OnRewardCollected;

		event Action<CBSNotification> OnReadNotification;

		event Action<CBSNotification> OnRemoveNotification;

		void GetNotificationList(CBSGetNotificationsRequest request, Action<CBSGetNotificationsResult> result);

		void MarkNotificationAsRead(string notificationInstanceID, Action<CBSModifyNotificationResult> result);

		void ClaimNotificationReward(string notificationInstanceID, Action<CBSClaimNotificationRewardResult> result);

		void RemoveNotification(string notificationInstanceID, Action<CBSModifyNotificationResult> result);

		void GetNotificationBadge(Action<CBSBadgeResult> result);

		void SendNotificationToProfile(CBSSendNotificationRequest request, Action<CBSSendNotificationResult> result);
	}
}
