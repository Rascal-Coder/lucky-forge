using System.Collections.Generic;

namespace CBS.Models
{
	public class TaskEventContainer
	{
		public List<TaskEvent> Events;

		public void AddEvent(TaskEvent taskEvent)
		{
		}

		public void RemoveEvent(TaskEvent taskEvent)
		{
		}

		public bool IsEmpty()
		{
			return false;
		}

		public TaskEventContainer Merge(TaskEventContainer eventContainer)
		{
			return null;
		}
	}
}
