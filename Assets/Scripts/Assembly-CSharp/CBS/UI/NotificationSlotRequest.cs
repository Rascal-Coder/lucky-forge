using System;
using CBS.Models;

namespace CBS.UI
{
	public class NotificationSlotRequest
	{
		public CBSNotification Notification;

		public CBSNotification Active;

		public Action<NotificationSlot> SelectAction;
	}
}
