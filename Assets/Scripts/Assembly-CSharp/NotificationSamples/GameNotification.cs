using Unity.Notifications;

namespace NotificationSamples
{
	public class GameNotification
	{
		private Notification internalNotification;

		public Notification InternalNotification => default;

		public int? Id
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string Title
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string Body
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string Data
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int BadgeNumber
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public GameNotification()
		{
		}

		internal GameNotification(Notification notification)
		{
		}
	}
}
