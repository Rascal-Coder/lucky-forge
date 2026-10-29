using System;
using System.Runtime.CompilerServices;
using CBS.Models;
using CBS.Playfab;

namespace CBS
{
	public class CBSNotificationModule : CBSModule, INotificationCenter
	{
		[CompilerGenerated]
		private Action<GrantRewardResult> m_OnRewardCollected;

		[CompilerGenerated]
		private Action<CBSNotification> m_OnReadNotification;

		[CompilerGenerated]
		private Action<CBSNotification> m_OnRemoveNotification;

		private IFabNotification FabNotification { get; set; }

		private IProfile Profile { get; set; }

		public event Action<GrantRewardResult> OnRewardCollected
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

		public event Action<CBSNotification> OnReadNotification
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

		public event Action<CBSNotification> OnRemoveNotification
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

		protected override void Init()
		{
		}

		public void GetNotificationList(CBSGetNotificationsRequest request, Action<CBSGetNotificationsResult> result)
		{
		}

		public void MarkNotificationAsRead(string notificationInstanceID, Action<CBSModifyNotificationResult> result)
		{
		}

		public void ClaimNotificationReward(string notificationInstanceID, Action<CBSClaimNotificationRewardResult> result)
		{
		}

		public void RemoveNotification(string notificationInstanceID, Action<CBSModifyNotificationResult> result)
		{
		}

		public void GetNotificationBadge(Action<CBSBadgeResult> result)
		{
		}

		public void SendNotificationToProfile(CBSSendNotificationRequest request, Action<CBSSendNotificationResult> result)
		{
		}
	}
}
