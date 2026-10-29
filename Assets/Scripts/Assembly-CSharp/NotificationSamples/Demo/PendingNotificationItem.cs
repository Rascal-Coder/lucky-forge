using TMPro;
using UnityEngine;

namespace NotificationSamples.Demo
{
	public class PendingNotificationItem : MonoBehaviour
	{
		[SerializeField]
		protected TextMeshProUGUI idLabel;

		[SerializeField]
		protected TextMeshProUGUI titleLabel;

		[SerializeField]
		protected TextMeshProUGUI timeLabel;

		private NotificationConsole console;

		private PendingNotification notification;

		public void Show(PendingNotification notificationToDisplay, NotificationConsole containingConsole)
		{
		}

		public void Cancel()
		{
		}
	}
}
