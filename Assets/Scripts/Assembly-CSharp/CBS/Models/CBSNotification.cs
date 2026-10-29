using System;
using CBS.Core;

namespace CBS.Models
{
	public class CBSNotification : ICustomData<CBSNotificationCustomData>
	{
		public string ID;

		public string InstanceID;

		public DateTime CreatedDate;

		public string Title;

		public string Message;

		public string Category;

		public string ExternalURL;

		public bool Read;

		public NotificationTarget Target;

		public bool HasReward;

		public bool VisibleForNewPlayer;

		public bool Rewarded;

		public RewardObject Reward;

		public string CustomDataClassName { get; set; }

		public string CustomRawData { get; set; }

		public bool CompressCustomData => false;

		public T GetCustomData<T>() where T : CBSNotificationCustomData
		{
			return null;
		}

		public bool ReadAndRewarded()
		{
			return false;
		}

		public static CBSNotification FromRewardDelivery(RewardDelivery delivery, RewardObject reward)
		{
			return null;
		}

		public static CBSNotification FromProfileTemplate(ProfileNotificationTemplate notificationTemplate)
		{
			return null;
		}
	}
}
