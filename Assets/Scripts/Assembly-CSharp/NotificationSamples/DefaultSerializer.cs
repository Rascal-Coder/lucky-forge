using System.Collections.Generic;

namespace NotificationSamples
{
	public class DefaultSerializer : IPendingNotificationsSerializer
	{
		private const byte Version = 1;

		private readonly string filename;

		public DefaultSerializer(string filename)
		{
		}

		public void Serialize(IList<PendingNotification> notifications)
		{
		}

		public IList<PendingNotification> Deserialize(GameNotificationsPlatform platform)
		{
			return null;
		}
	}
}
