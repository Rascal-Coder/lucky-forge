using System.Collections.Generic;
using CBS.Models;
using CBS.Scriptable;

namespace CBS.UI
{
	public class ProfileTasksBadge : BaseBadge
	{
		private IProfileTasks CBSProfileTasks { get; set; }

		private ProfileTasksPrefabs TasksPrefabs { get; set; }

		private string TasksPoolID { get; set; }

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		private void OnEnable()
		{
		}

		private void GetCompleteTasks()
		{
		}

		private void OnGetPlayerTasks(CBSBadgeResult result)
		{
		}

		private void OnProfileRewarded(GrantRewardResult reward)
		{
		}

		private void OnCompleteTask(CBSTask result)
		{
		}

		private void OnCompleteTaskTier(CBSTask result)
		{
		}

		private void OnTaskReseted(List<CBSTask> result)
		{
		}
	}
}
