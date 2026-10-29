using System.Collections.Generic;

namespace CBS.Models
{
	public class ProfileTasksData
	{
		public const string ProfileTasksTitlePrefix = "PTP_";

		public const string ProfileTasksTablePrefix = "ptp";

		public List<string> TasksList;

		public void AddNewID(string id)
		{
		}

		public void RemoveID(string id)
		{
		}

		public bool IsEmpty()
		{
			return false;
		}
	}
}
