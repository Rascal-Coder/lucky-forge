using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace NotificationSamples
{
	public class GameNotificationsManager : MonoBehaviour
	{
		[Flags]
		public enum OperatingMode
		{
			NoQueue = 0,
			Queue = 1,
			ClearOnForegrounding = 2,
			RescheduleAfterClearing = 4,
			QueueAndClear = Queue | ClearOnForegrounding,
			QueueClearAndReschedule = QueueAndClear | RescheduleAfterClearing
		}

		[CompilerGenerated]
		private sealed class _003CInitialize_003Ed__35 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public GameNotificationsManager _003C_003E4__this;

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
			public _003CInitialize_003Ed__35(int _003C_003E1__state)
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

		private const string DefaultFilename = "notifications.bin";

		private static readonly TimeSpan MinimumNotificationTime;

		[SerializeField]
		[Tooltip("The operating mode for the notifications manager.")]
		private OperatingMode mode;

		[SerializeField]
		[Tooltip("Check to make the notifications manager automatically set badge numbers so that they increment.\nSchedule notifications with no numbers manually set to make use of this feature.")]
		private bool autoBadging;

		[CompilerGenerated]
		private Action<PendingNotification> m_LocalNotificationDelivered;

		[CompilerGenerated]
		private Action<PendingNotification> m_LocalNotificationExpired;

		private bool inForeground;

		public GameNotificationsPlatform Platform { get; private set; }

		public List<PendingNotification> PendingNotifications { get; private set; }

		public IPendingNotificationsSerializer Serializer { get; set; }

		public OperatingMode Mode => OperatingMode.NoQueue;

		public bool AutoBadging => false;

		public bool Initialized { get; private set; }

		public event Action<PendingNotification> LocalNotificationDelivered
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

		public event Action<PendingNotification> LocalNotificationExpired
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

		protected virtual void OnDestroy()
		{
		}

		protected virtual void Update()
		{
		}

		protected void OnApplicationFocus(bool hasFocus)
		{
		}

		[IteratorStateMachine(typeof(_003CInitialize_003Ed__35))]
		public IEnumerator Initialize()
		{
			return null;
		}

		public GameNotification CreateNotification()
		{
			return null;
		}

		public PendingNotification ScheduleNotification(GameNotification notification, DateTime deliveryTime)
		{
			return null;
		}

		public void CancelNotification(int notificationId)
		{
		}

		public void CancelAllNotifications()
		{
		}

		public void DismissNotification(int notificationId)
		{
		}

		public void DismissAllNotifications()
		{
		}

		public GameNotification GetLastNotification()
		{
			return null;
		}

		private void OnNotificationReceived(GameNotification deliveredNotification)
		{
		}

		private void OnForegrounding()
		{
		}
	}
}
