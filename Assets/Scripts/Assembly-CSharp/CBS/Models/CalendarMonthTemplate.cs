using System.Collections.Generic;

namespace CBS.Models
{
	public class CalendarMonthTemplate
	{
		private readonly int MonthInYear;

		public List<List<CalendarPosition>> Positions;

		public List<CalendarPosition> GetPositions(int monthIndex)
		{
			return null;
		}
	}
}
