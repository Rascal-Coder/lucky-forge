using System;
using System.Collections.Generic;
using CBS.Models;

namespace CBS
{
	[Serializable]
	public class ClanTaskData : CBSTasksData<CBSClanTask>
	{
		public const string ClanTasksTitlePrefix = "CTP_";

		public const string ClanTasksTablePrefix = "CTP";

		public int DailyTasksCount;

		public DatePeriod UpdatePeriod;

		public TaskRewardBehavior RewardBehavior;

		public List<CBSClanTask> Tasks;

		public override void Add(CBSClanTask task)
		{
		}

		public override List<CBSClanTask> GetTasks()
		{
			return null;
		}

		public override List<CBSClanTask> NewInstance()
		{
			return null;
		}

		public override void Remove(CBSClanTask task)
		{
		}
	}
}
