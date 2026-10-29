using System;
using CBS.Models;

namespace CBS
{
	public interface ICalendar
	{
		event Action<GrantRewardResult> OnRewardCollected;

		event Action<CalendarInstance> OnCalendarReseted;

		event Action<CalendarInstance> OnCalendarGranted;

		event Action<CalendarInstance> OnCalendarPurchased;

		void GetAllAvailableCalendars(Action<CBSGetAllCalendarsResult> result);

		void GetCalendarByID(string calendarID, Action<CBSGetCalendarResult> result);

		void PickupReward(string calendarID, int positionIndex, Action<CBSPickupCalendarReward> result);

		void ResetCalendar(string calendarID, Action<CBSResetCalendarResult> result);

		void GetCalendarBadge(Action<CBSBadgeResult> result);

		void GrantCalendar(string calendarID, Action<CBSGrantCalendarResult> result);

		void PurchaseCalendar(string calendarID, Action<CBSPurchaseCalendarResult> result);

		void PurchaseCalendarWithRM(string calendarID, Action<CBSPurchaseCalendarWithRMResult> result);
	}
}
