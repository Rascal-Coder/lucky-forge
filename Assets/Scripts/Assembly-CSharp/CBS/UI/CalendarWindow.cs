using System.Collections.Generic;
using CBS.Models;
using CBS.Scriptable;
using UnityEngine;
using UnityEngine.UI;

namespace CBS.UI
{
	public class CalendarWindow : MonoBehaviour
	{
		[SerializeField]
		private Text DisplayName;

		[SerializeField]
		private Text Description;

		[SerializeField]
		private Image Icon;

		[SerializeField]
		private Button CollectBtn;

		[SerializeField]
		private Button PurchaseBtn;

		[SerializeField]
		private CalendarScroller PositionScroller;

		[SerializeField]
		private CalendarTitleScroller TitleScroller;

		[SerializeField]
		private ToggleGroup TitleGroup;

		[SerializeField]
		private ToggleGroup PositionGroup;

		private ICalendar Calendar { get; set; }

		private CalendarPrefabs Prefabs { get; set; }

		private CalendarInstance CurrentCalendar { get; set; }

		private CalendarPosition CurrentPosition { get; set; }

		private CalendarTitle CurrentTitle { get; set; }

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void LoadAllCalendars()
		{
		}

		private void DrawTitles(List<CalendarInstance> titles)
		{
		}

		private void DrawInstance(CalendarInstance instance)
		{
		}

		private void DrawPosition(CalendarPosition position)
		{
		}

		public void OnCollectClick()
		{
		}

		private void OnGetCalendar(CBSGetAllCalendarsResult result)
		{
		}

		private void OnRewardCollected(CBSPickupCalendarReward result)
		{
		}

		private void OnSelectTitle(CalendarInstance instance, CalendarTitle title)
		{
		}

		private void OnSelectPosition(CalendarPosition position)
		{
		}

		private void PurchaseRequest(string code, int value)
		{
		}

		private void OnPurchaseCalendar(CBSPurchaseCalendarResult result)
		{
		}

		private void OnPurchaseCalendarWithRM(CBSPurchaseCalendarWithRMResult result)
		{
		}
	}
}
