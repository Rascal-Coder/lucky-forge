using System;
using CBS.Models;
using UnityEngine;
using UnityEngine.UI;

namespace CBS.UI
{
	public class NotificationDrawer : MonoBehaviour
	{
		[SerializeField]
		private Text Title;

		[SerializeField]
		private Text Body;

		[SerializeField]
		private RewardDrawer RewardDrawer;

		[SerializeField]
		private GameObject ClaimButtom;

		[SerializeField]
		private GameObject RemoveButtom;

		public Action<CBSNotification> OnModifyNotification;

		public Action<CBSNotification> OnRemoveNotification;

		private INotificationCenter NotificationCenter { get; set; }

		private CBSNotification Notification { get; set; }

		private NotificationSlot NotificationSlot { get; set; }

		private void Awake()
		{
		}

		public void Draw(CBSNotification notification, NotificationSlot slot)
		{
		}

		private void MarkAsRead()
		{
		}

		public void Clear()
		{
		}

		public void ClaimHandler()
		{
		}

		public void RemoveHandler()
		{
		}

		private void OnReadNotification(CBSModifyNotificationResult result)
		{
		}

		private void OnGrantReward(CBSClaimNotificationRewardResult result)
		{
		}

		private void OnRemoveNotificationEvent(CBSModifyNotificationResult result)
		{
		}
	}
}
