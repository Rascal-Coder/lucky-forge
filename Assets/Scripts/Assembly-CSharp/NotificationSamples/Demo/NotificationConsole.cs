using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NotificationSamples.Demo
{
	public class NotificationConsole : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CShowDeliveryNotificationCoroutine_003Ed__23 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public NotificationConsole _003C_003E4__this;

			public GameNotification deliveredNotification;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CShowDeliveryNotificationCoroutine_003Ed__23(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CUpdatePendingNotificationsNextFrame_003Ed__24 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public NotificationConsole _003C_003E4__this;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CUpdatePendingNotificationsNextFrame_003Ed__24(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[SerializeField]
		protected Button sendButton;

		[SerializeField]
		protected Button clearEventButton;

		[SerializeField]
		protected TMP_InputField titleField;

		[SerializeField]
		protected TMP_InputField bodyField;

		[SerializeField]
		protected TMP_InputField timeField;

		[SerializeField]
		protected TMP_InputField badgeField;

		[SerializeField]
		protected GameNotificationsManager manager;

		[SerializeField]
		protected Transform pendingNotificationsListParent;

		[SerializeField]
		protected PendingNotificationItem pendingNotificationPrefab;

		[SerializeField]
		protected Transform pendingEventParent;

		[SerializeField]
		protected NotificationEventItem eventPrefab;

		private bool updatePendingNotifications;

		private void Awake()
		{
		}

		private IEnumerator Start()
		{
			return null;
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

		public void SendNotification(string title, string body, DateTime deliveryTime, int? badgeNumber = null, bool reschedule = false)
		{
		}

		public void CancelPendingNotificationItem(PendingNotification itemToCancel)
		{
		}

		private void OnApplicationFocus(bool hasFocus)
		{
		}

		private void SendNotificationFromUi()
		{
		}

		private void OnDelivered(PendingNotification deliveredNotification)
		{
		}

		private void OnExpired(PendingNotification obj)
		{
		}

		[IteratorStateMachine(typeof(_003CShowDeliveryNotificationCoroutine_003Ed__23))]
		private IEnumerator ShowDeliveryNotificationCoroutine(GameNotification deliveredNotification)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CUpdatePendingNotificationsNextFrame_003Ed__24))]
		private IEnumerator UpdatePendingNotificationsNextFrame()
		{
			return null;
		}

		private void Update()
		{
		}

		private void UpdatePendingNotifications()
		{
		}

		private void QueueEvent(string eventText)
		{
		}

		private void ClearEvents()
		{
		}
	}
}
