using System;
using System.Collections;
using System.Runtime.CompilerServices;
using Unity.Notifications;

namespace NotificationSamples
{
	public class GameNotificationsPlatform : IDisposable
	{
		[CompilerGenerated]
		private Action<GameNotification> m_NotificationReceived;

		public event Action<GameNotification> NotificationReceived
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

		public GameNotificationsPlatform(NotificationCenterArgs args)
		{
		}

		public IEnumerator RequestNotificationPermission()
		{
			return null;
		}

		public GameNotification CreateNotification()
		{
			return null;
		}

		public void ScheduleNotification(GameNotification gameNotification, DateTime deliveryTime)
		{
		}

		public void CancelNotification(int notificationId)
		{
		}

		public void DismissNotification(int notificationId)
		{
		}

		public void CancelAllScheduledNotifications()
		{
		}

		public void DismissAllDisplayedNotifications()
		{
		}

		public GameNotification GetLastNotification()
		{
			return null;
		}

		public void OnForeground()
		{
		}

		public void OnBackground()
		{
		}

		public void Dispose()
		{
		}

		private void OnLocalNotificationReceived(Notification notification)
		{
		}
	}
}
