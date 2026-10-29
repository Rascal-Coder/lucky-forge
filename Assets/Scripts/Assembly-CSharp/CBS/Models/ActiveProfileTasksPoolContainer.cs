using System.Collections.Generic;

namespace CBS.Models
{
	public class ActiveProfileTasksPoolContainer
	{
		public Dictionary<string, List<string>> PoolStates;

		public List<string> GetSavedForPool(string poolID)
		{
			return null;
		}

		public void AddState(string poolID, List<string> tasksIDs)
		{
		}
	}
}
