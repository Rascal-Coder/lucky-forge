using System;
using System.Collections.Generic;
using CBS.Models;

namespace CBS
{
	public interface IProfileTasks
	{
		event Action<CBSTask> OnCompleteTask;

		event Action<CBSTask> OnCompleteTaskTier;

		event Action<GrantRewardResult> OnRewardGranted;

		event Action<List<CBSTask>> OnTasksReseted;

		void GetAllTasksFromPool(string tasksPoolID, Action<CBSGetTasksFromPoolResult> result);

		void GetTasksForProfile(string tasksPoolID, Action<CBSGetTasksForProfileResult> result);

		void AddMultiplicityTasksPoint(string tasksPoolID, Dictionary<string, int> modifyPair, Action<CBSModifyProfileMultiplyTaskResult> result);

		void UpdateMultiplicityTasksPoint(string tasksPoolID, Dictionary<string, int> modifyPair, Action<CBSModifyProfileMultiplyTaskResult> result);

		void AddTaskPoint(string tasksPoolID, string taskID, Action<CBSModifyProfileTaskPointsResult> result);

		void AddTaskPoints(string tasksPoolID, string taskID, int points, Action<CBSModifyProfileTaskPointsResult> result);

		void AddTaskPoints(CBSTask task, int points, Action<CBSModifyProfileTaskPointsResult> result);

		void UpdateTaskPoint(string tasksPoolID, string taskID, int points, Action<CBSModifyProfileTaskPointsResult> result);

		void UpdateTaskPoint(CBSTask task, int points, Action<CBSModifyProfileTaskPointsResult> result);

		void PickupTaskReward(string tasksPoolID, string taskID, Action<CBSModifyProfileTaskPointsResult> result);

		void ResetAndGetNewTasks(string tasksPoolID, Action<CBSGetTasksForProfileResult> result);

		void GetTasksBadge(string tasksPoolID, Action<CBSBadgeResult> result);
	}
}
