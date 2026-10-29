using System;
using CBS.Core;
using CBS.Models;
using UnityEngine;
using UnityEngine.UI;

namespace CBS.UI
{
	[RequireComponent(typeof(Toggle))]
	public class CalendarTitle : MonoBehaviour, IScrollableItem<CalendarInstance>
	{
		[SerializeField]
		private Text DisplayName;

		[SerializeField]
		private Text Notification;

		[SerializeField]
		private Text Badge;

		[SerializeField]
		private GameObject LockObject;

		[SerializeField]
		private GameObject BadgeObject;

		[SerializeField]
		private Image Icon;

		private Toggle Toggle { get; set; }

		private CalendarInstance Title { get; set; }

		private Action<CalendarInstance, CalendarTitle> SelectAction { get; set; }

		private void Awake()
		{
		}

		private void OnDisable()
		{
		}

		private void OnDestroy()
		{
		}

		public void Display(CalendarInstance title)
		{
		}

		public void SetSelectionAction(Action<CalendarInstance, CalendarTitle> action)
		{
		}

		private void LateUpdate()
		{
		}

		private void OnToggleStateChange(bool val)
		{
		}
	}
}
