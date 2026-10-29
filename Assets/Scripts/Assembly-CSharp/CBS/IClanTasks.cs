using System;
using CBS.Models;

namespace CBS
{
	public interface IClanTasks
	{
		void GetTasksForClan(Action<CBSGetTasksForClanResult> result);

		void AddTaskPoint(string taskID, Action<CBSModifyClanTaskPointsResult> result);

		void AddTaskPoints(string taskID, int points, Action<CBSModifyClanTaskPointsResult> result);

		void ResetTasksForClan(Action<CBSGetTasksForClanResult> result);
	}
}
