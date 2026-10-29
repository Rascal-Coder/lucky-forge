using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CBS.Models;
using CBS.Playfab;

namespace CBS
{
	public class CBSProfileTasksModule : CBSModule, IProfileTasks
	{
		[CompilerGenerated]
		private Action<CBSTask> m_OnCompleteTask;

		[CompilerGenerated]
		private Action<CBSTask> m_OnCompleteTaskTier;

		[CompilerGenerated]
		private Action<List<CBSTask>> m_OnTasksReseted;

		[CompilerGenerated]
		private Action<GrantRewardResult> m_OnRewardGranted;

		private IProfile Profile { get; set; }

		private IFabProfileTasks FabProfileTasks { get; set; }

		public event Action<CBSTask> OnCompleteTask
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<CBSTask> OnCompleteTaskTier
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<List<CBSTask>> OnTasksReseted
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<GrantRewardResult> OnRewardGranted
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		protected override void Init()
		{
		}

		public void GetAllTasksFromPool(string tasksPoolID, Action<CBSGetTasksFromPoolResult> result)
		{
		}

		public void GetTasksForProfile(string tasksPoolID, Action<CBSGetTasksForProfileResult> result)
		{
		}

		public void AddMultiplicityTasksPoint(string tasksPoolID, Dictionary<string, int> modifyPair, Action<CBSModifyProfileMultiplyTaskResult> result)
		{
		}

		public void UpdateMultiplicityTasksPoint(string tasksPoolID, Dictionary<string, int> modifyPair, Action<CBSModifyProfileMultiplyTaskResult> result)
		{
		}

		public void AddTaskPoint(string tasksPoolID, string taskID, Action<CBSModifyProfileTaskPointsResult> result)
		{
		}

		public void AddTaskPoints(string tasksPoolID, string taskID, int points, Action<CBSModifyProfileTaskPointsResult> result)
		{
		}

		public void AddTaskPoints(CBSTask task, int points, Action<CBSModifyProfileTaskPointsResult> result)
		{
		}

		public void UpdateTaskPoint(string tasksPoolID, string taskID, int points, Action<CBSModifyProfileTaskPointsResult> result)
		{
		}

		public void UpdateTaskPoint(CBSTask task, int points, Action<CBSModifyProfileTaskPointsResult> result)
		{
		}

		public void PickupTaskReward(string tasksPoolID, string taskID, Action<CBSModifyProfileTaskPointsResult> result)
		{
		}

		public void ResetAndGetNewTasks(string tasksPoolID, Action<CBSGetTasksForProfileResult> result)
		{
		}

		public void GetTasksBadge(string tasksPoolID, Action<CBSBadgeResult> result)
		{
		}

		private void InternalModifyPoints(string tasksPoolID, string taskID, int points, ModifyMethod modify, Action<CBSModifyProfileTaskPointsResult> result)
		{
		}

		private void InternalModifyMultiplyPoints(string tasksPoolID, ModifyMethod modify, Dictionary<string, int> modifyPair, Action<CBSModifyProfileMultiplyTaskResult> result)
		{
		}
	}
}
