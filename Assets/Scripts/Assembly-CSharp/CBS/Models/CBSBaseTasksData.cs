using System.Collections.Generic;

namespace CBS.Models
{
	public class CBSBaseTasksData<T> : CBSTasksData<T> where T : CBSTask
	{
		public List<T> Tasks;

		public override void Add(T task)
		{
		}

		public override List<T> GetTasks()
		{
			return null;
		}

		public override List<T> NewInstance()
		{
			return null;
		}

		public override void Remove(T task)
		{
		}
	}
}
