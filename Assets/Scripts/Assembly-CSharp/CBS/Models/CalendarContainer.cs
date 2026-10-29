using System.Collections.Generic;

namespace CBS.Models
{
	public class CalendarContainer
	{
		public List<CalendarInstance> Instances;

		public void Add(CalendarInstance instance)
		{
		}

		public void Remove(CalendarInstance instance)
		{
		}

		public CalendarInstance GetInstanceByID(string id)
		{
			return null;
		}

		public void CleanUp()
		{
		}

		public bool IsEmpty()
		{
			return false;
		}
	}
}
