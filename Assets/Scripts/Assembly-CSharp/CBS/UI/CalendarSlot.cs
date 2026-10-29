using System;
using CBS.Core;
using CBS.Models;
using UnityEngine;
using UnityEngine.UI;

namespace CBS.UI
{
	[RequireComponent(typeof(Toggle))]
	public class CalendarSlot : MonoBehaviour, IScrollableItem<CalendarPosition>
	{
		[SerializeField]
		private Text Title;

		[SerializeField]
		private GameObject Rewarded;

		[SerializeField]
		private GameObject Missed;

		[SerializeField]
		private GameObject Active;

		[SerializeField]
		private SimpleIcon RewardDrawer;

		private CalendarPosition Position { get; set; }

		private Toggle Toggle { get; set; }

		private Action<CalendarPosition> SelectAction { get; set; }

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		private void OnDisable()
		{
		}

		public void Display(CalendarPosition data)
		{
		}

		public void CheckActive()
		{
		}

		public void SetSelectionAction(Action<CalendarPosition> action)
		{
		}

		private void DrawReward(RewardObject reward)
		{
		}

		private void OnToggleStateChange(bool val)
		{
		}
	}
}
