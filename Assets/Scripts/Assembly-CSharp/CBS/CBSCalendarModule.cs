using System;
using System.Runtime.CompilerServices;
using CBS.Models;

namespace CBS
{
	public class CBSCalendarModule : CBSModule, ICalendar
	{
		[CompilerGenerated]
		private Action<GrantRewardResult> m_OnRewardCollected;

		[CompilerGenerated]
		private Action<CalendarInstance> m_OnCalendarReseted;

		[CompilerGenerated]
		private Action<CalendarInstance> m_OnCalendarGranted;

		[CompilerGenerated]
		private Action<CalendarInstance> m_OnCalendarPurchased;

		private IFabCalendar FabCalendar { get; set; }

		private IProfile Profile { get; set; }

		private ICBSInAppPurchase InAppPurchase { get; set; }

		public event Action<GrantRewardResult> OnRewardCollected
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

		public event Action<CalendarInstance> OnCalendarReseted
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

		public event Action<CalendarInstance> OnCalendarGranted
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

		public event Action<CalendarInstance> OnCalendarPurchased
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

		protected override void Init()
		{
		}

		public void GetAllAvailableCalendars(Action<CBSGetAllCalendarsResult> result)
		{
		}

		public void GetCalendarByID(string calendarID, Action<CBSGetCalendarResult> result)
		{
		}

		public void PickupReward(string calendarID, int positionIndex, Action<CBSPickupCalendarReward> result)
		{
		}

		public void ResetCalendar(string calendarID, Action<CBSResetCalendarResult> result)
		{
		}

		public void GetCalendarBadge(Action<CBSBadgeResult> result)
		{
		}

		public void GrantCalendar(string calendarID, Action<CBSGrantCalendarResult> result)
		{
		}

		public void PurchaseCalendar(string calendarID, Action<CBSPurchaseCalendarResult> result)
		{
		}

		public void PurchaseCalendarWithRM(string calendarID, Action<CBSPurchaseCalendarWithRMResult> result)
		{
		}
	}
}
