using System;

namespace NotificationSamples
{
	public class PendingNotification
	{
		public bool Reschedule;

		public readonly GameNotification Notification;

		public readonly DateTime DeliveryTime;

		public bool Scheduled { get; private set; }

		public PendingNotification(GameNotification notification, DateTime deliveryTime, bool scheduled = false)
		{
		}

		public void Schedule()
		{
		}
	}
}
