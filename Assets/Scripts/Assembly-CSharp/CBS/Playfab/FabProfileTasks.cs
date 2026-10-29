using System;
using System.Collections.Generic;
using CBS.Models;
using PlayFab;
using PlayFab.CloudScriptModels;

namespace CBS.Playfab
{
	public class FabProfileTasks : FabExecuter, IFabProfileTasks
	{
		public void GetTasksPool(string profileID, string tasksPoolID, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void GetTasksForProfile(string profileID, string tasksPoolID, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void ModifyTasksPoint(string profileID, string taskID, string tasksPoolID, int points, ModifyMethod method, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void ModifyTasksPoint(string profileID, string tasksPoolID, ModifyMethod method, Dictionary<string, int> modifyPair, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void PickupReward(string profileID, string taskID, string tasksPoolID, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void RegenerateNewTasks(string profileID, string tasksPoolID, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void GetProfileTasksBadge(string profileID, string tasksPoolID, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}
	}
}
