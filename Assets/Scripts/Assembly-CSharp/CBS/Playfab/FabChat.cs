using System;
using CBS.Models;
using PlayFab;
using PlayFab.CloudScriptModels;

namespace CBS.Playfab
{
	public class FabChat : FabExecuter, IFabChat
	{
		public void ClearDialogEntryBadge(string profileID, string withProfileID, Action<ExecuteFunctionResult> onClear, Action<PlayFabError> onFailed)
		{
		}

		public void GetMessages(string chatID, int maxCount, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void SendMessage(FunctionSendChatMessageRequest messageRequest, Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void ChangeMessageText(string profileID, string messageID, string chatID, string textToEdit, Action<ExecuteFunctionResult> onEdit, Action<PlayFabError> onFailed)
		{
		}

		public void DeleteMessageText(string profileID, string messageID, string chatID, Action<ExecuteFunctionResult> onEdit, Action<PlayFabError> onFailed)
		{
		}

		public void BanProfileInChat(string profileID, string profileIDToBan, string chatID, int banHours, string reason, Action<ExecuteFunctionResult> onBan, Action<PlayFabError> onFailed)
		{
		}

		public void GetStickersPack(Action<ExecuteFunctionResult> onGet, Action<PlayFabError> onFailed)
		{
		}

		public void ClaimItemFromMessage(string profileID, string messageID, string chatID, Action<ExecuteFunctionResult> onClaim, Action<PlayFabError> onFailed)
		{
		}

		public void GetDialogList(string profileID, Action<ExecuteFunctionResult> onClaim, Action<PlayFabError> onFailed)
		{
		}

		public void GetDialogBadge(string profileID, Action<ExecuteFunctionResult> onClaim, Action<PlayFabError> onFailed)
		{
		}
	}
}
