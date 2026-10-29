using System;
using CBS.Models;
using PlayFab;
using PlayFab.CloudScriptModels;

namespace CBS.Playfab
{
	public class FabAchievements : FabExecuter, IFabAchievements
	{
		public void GetProfileAchievements(string profileID, TasksState state, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void ModifyAchievementPoint(string profileID, string achievementID, int points, ModifyMethod method, Action<ExecuteFunctionResult> onAdd, Action<PlayFabError> onFailed)
		{
		}

		public void PickupReward(string profileID, string achievementID, Action<ExecuteFunctionResult> onPick, Action<PlayFabError> onFailed)
		{
		}

		public void ResetAchievement(string profileID, string achievementID, Action<ExecuteFunctionResult> onReset, Action<PlayFabError> onFailed)
		{
		}

		public void GetAchievementsBadge(string profileID, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}
	}
}
