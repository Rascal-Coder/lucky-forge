using System.Collections.Generic;

namespace CBS.Models
{
	public class NotificationsData
	{
		public const string ALL_CATEGORY = "ALL";

		public const string UNDEFINED_CATEGORY = "undefined";

		public const int MAX_NOTIFICATIONS_LENGTH = 100;

		public Categories Categories;

		public List<CBSNotification> NotificationsList;

		public CBSTTL TTL;

		public int? NotificationSecondsTTL;

		public void SetCategories(Categories categories)
		{
		}

		public List<string> GetCategories()
		{
			return null;
		}

		public List<string> GetCategoriesToSelect()
		{
			return null;
		}

		public void AddNotification(CBSNotification notification)
		{
		}

		public void RemoveNotification(CBSNotification notification)
		{
		}

		public List<CBSNotification> GetNotifications()
		{
			return null;
		}

		public Dictionary<string, CBSNotification> GetNotificationsAsDictionary()
		{
			return null;
		}

		public int GetTTL()
		{
			return 0;
		}
	}
}
