using System;
using CBS.Core;
using CBS.Models;
using UnityEngine;
using UnityEngine.UI;

namespace CBS.UI
{
	[RequireComponent(typeof(Button))]
	public class NotificationSlot : MonoBehaviour, IScrollableItem<NotificationSlotRequest>
	{
		[SerializeField]
		private Text DisplayName;

		[SerializeField]
		private Text DateTitle;

		[SerializeField]
		private GameObject UnreadDot;

		[SerializeField]
		private GameObject SelectView;

		private Action<NotificationSlot> SelectAction { get; set; }

		private Button Button { get; set; }

		private CBSNotification ActiveNotification { get; set; }

		public CBSNotification Notification { get; private set; }

		private void Start()
		{
		}

		private void OnDestroy()
		{
		}

		private void OnDisable()
		{
		}

		public void Display(NotificationSlotRequest data)
		{
		}

		public void DrawSlot(CBSNotification notification)
		{
		}

		public void SetAsActive(CBSNotification notification)
		{
		}

		public void Select()
		{
		}

		public void DeSelect()
		{
		}

		public void Hide()
		{
		}

		private void OnClick()
		{
		}
	}
}
