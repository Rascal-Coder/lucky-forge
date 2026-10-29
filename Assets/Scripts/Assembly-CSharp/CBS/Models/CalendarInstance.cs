using System;
using System.Collections.Generic;
using CBS.Core;

namespace CBS.Models
{
	[Serializable]
	public class CalendarInstance : ICustomData<CBSCalendarCustomData>
	{
		public string ID;

		public string InstanceID;

		public string DisplayName;

		public string Description;

		public bool Enabled;

		public bool Looped;

		public bool NoPenalty;

		public bool DontIncrementIndexWhenSkipping;

		public CBSPrice Price;

		public CalendarTemplate Template;

		public ActivationType Activation;

		public List<CalendarPosition> Positions;

		public CalendarWeekTemplate WeekTemplate;

		public CalendarMonthTemplate MonthTemplate;

		public int CurrentIndex;

		public bool IsAvailable;

		public int BadgeCount;

		public DateTime EndDate;

		public string CustomDataClassName { get; set; }

		public string CustomRawData { get; set; }

		public bool CompressCustomData => false;

		public virtual T GetCustomData<T>() where T : CBSCalendarCustomData
		{
			return null;
		}

		public void AddPostion(CalendarPosition position)
		{
		}

		public void RemoveLastPosition()
		{
		}

		public List<CalendarPosition> GetCustomPositions()
		{
			return null;
		}

		public List<CalendarPosition> GetWeeklyPositions()
		{
			return null;
		}

		public List<CalendarPosition> GetMonthlyPositions(int monthIndex)
		{
			return null;
		}

		public void CleanUp()
		{
		}

		public string GetTemplateInstanceID()
		{
			return null;
		}

		public void UpdatePosition(CalendarPosition position, int index)
		{
		}
	}
}
