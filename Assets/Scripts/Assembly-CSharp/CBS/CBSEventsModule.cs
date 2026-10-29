using System;
using CBS.Models;
using CBS.Playfab;

namespace CBS
{
	public class CBSEventsModule : CBSModule, IEventsModule
	{
		private IFabEvents FabEvents { get; set; }

		protected override void Init()
		{
		}

		public void GetEvents(CBSGetEventsRequest request, Action<CBSGetEventsResult> result)
		{
		}

		public void GetEventByID(string eventID, Action<CBSGetEventResult> result)
		{
		}

		public void GetEventsBadge(string category, Action<CBSBadgeResult> result)
		{
		}
	}
}
