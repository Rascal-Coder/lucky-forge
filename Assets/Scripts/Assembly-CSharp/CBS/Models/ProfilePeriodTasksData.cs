using System;
using System.Collections.Generic;

namespace CBS.Models
{
	[Serializable]
	public class ProfilePeriodTasksData : CBSTasksData<CBSProfileTask>
	{
		public int DailyTasksCount;

		public DatePeriod UpdatePeriod;

		public List<CBSProfileTask> Tasks;

		public override void Add(CBSProfileTask task)
		{
		}

		public override List<CBSProfileTask> GetTasks()
		{
			return null;
		}

		public override List<CBSProfileTask> NewInstance()
		{
			return null;
		}

		public override void Remove(CBSProfileTask task)
		{
		}
	}
}
