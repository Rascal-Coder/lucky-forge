using System.Collections.Generic;
using CBS.Models;
using CBS.Scriptable;
using UnityEngine;
using UnityEngine.UI;

namespace CBS.UI
{
	public class NotificationWindow : MonoBehaviour
	{
		[SerializeField]
		private NotificationTabListener TabListener;

		[SerializeField]
		private NotificationTitleScroller NotificationScroller;

		[SerializeField]
		private MessageDialogScroller DialogScroller;

		[SerializeField]
		private NotificationDrawer NotificationDrawer;

		[SerializeField]
		private ManualUpdateBadge MessageBadge;

		[SerializeField]
		private ChatView ChatView;

		[SerializeField]
		private ToggleGroup DialogGroup;

		[SerializeField]
		private string SpecificCategory;

		[SerializeField]
		private NotificationRequest Query;

		private NotificationSlot ActiveSlot { get; set; }

		private INotificationCenter Notification { get; set; }

		private ICBSChat CBSChat { get; set; }

		private NotificationPrefabs NotificationPrefabs { get; set; }

		private ChatPrefabs ChatPrefabs { get; set; }

		private List<CBSNotification> ActiveNotifications { get; set; }

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void DisplayTab(NotificationMenu tab)
		{
		}

		private void DisplayNotification(NotificationSlot notificationSlot)
		{
		}

		private void DrawNotificationList(List<CBSNotification> notifications)
		{
		}

		private void DrawDialogList(List<ChatDialogEntry> dialogList)
		{
		}

		private void UpdateMessagesBadge(List<CBSNotification> notifications = null)
		{
		}

		private void ClearContent()
		{
		}

		private void OnTabSelected(NotificationMenu tab)
		{
		}

		private void OnGetNotificationList(CBSGetNotificationsResult result)
		{
		}

		private void OnGetDialogList(CBSGetDialogListResult result)
		{
		}

		private void OnSelectNotification(NotificationSlot slot)
		{
		}

		private void OnSelectDialog(ChatDialogEntry dialogEntry)
		{
		}

		private void OnModifyNotification(CBSNotification notification)
		{
		}

		private void OnRemoveNotification(CBSNotification notification)
		{
		}
	}
}
