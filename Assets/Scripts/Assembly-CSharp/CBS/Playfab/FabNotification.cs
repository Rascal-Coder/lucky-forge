using System;
using CBS.Models;
using PlayFab;
using PlayFab.CloudScriptModels;

namespace CBS.Playfab
{
	public class FabNotification : FabExecuter, IFabNotification
	{
		public void GetNotifications(string profileID, int maxCount, string category, NotificationRequest query, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void ReadNotification(string profileID, string notificationInstanceID, Action<ExecuteFunctionResult> onCraft, Action<PlayFabError> onFailed)
		{
		}

		public void ClaimNotificationReward(string profileID, string notificationInstanceID, Action<ExecuteFunctionResult> onClain, Action<PlayFabError> onFailed)
		{
		}

		public void RemoveNotification(string profileID, string notificationInstanceID, Action<ExecuteFunctionResult> onClain, Action<PlayFabError> onFailed)
		{
		}

		public void GetNotificationBadge(string profileID, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void SendNotificationToProfile(string profileID, string toProfileID, ProfileNotificationTemplate template, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}
	}
}
