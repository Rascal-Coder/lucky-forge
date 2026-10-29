using System;
using CBS.Models;

namespace CBS
{
	public interface IEventsModule
	{
		void GetEvents(CBSGetEventsRequest request, Action<CBSGetEventsResult> result);

		void GetEventByID(string eventID, Action<CBSGetEventResult> result);

		void GetEventsBadge(string category, Action<CBSBadgeResult> result);
	}
}
