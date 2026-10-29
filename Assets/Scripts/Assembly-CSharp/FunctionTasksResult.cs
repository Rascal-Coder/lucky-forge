using System.Collections.Generic;
using CBS;

public class FunctionTasksResult<TTask> where TTask : CBSTask
{
	public List<TTask> Tasks;

	public Dictionary<string, BaseTaskState> TasksStates;

	public int EntityLevel;

	public bool AutoReward;
}
