using System.Collections.Generic;

namespace NotificationSamples
{
	public interface IPendingNotificationsSerializer
	{
		void Serialize(IList<PendingNotification> notifications);

		IList<PendingNotification> Deserialize(GameNotificationsPlatform platform);
	}
}
