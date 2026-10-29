using System;
using System.Collections.Generic;
using CBS.Context;
using CBS.Models;

namespace CBS
{
	public interface ICBSChat
	{
		bool IsModerator { get; }

		ProfileChatData ProfileChatData { get; }

		ICoroutineRunner CoroutineRunner { get; }

		event Action<ChatDialogEntry> OnUnreadMessageClear;

		void SetServerID(string serverID);

		void SetRegion(string region);

		ChatInstance GetOrCreateChat(ChatTitle chatTitle);

		ChatInstance GetOrCreateGroupChatByID(string chatID);

		ChatInstance GetOrCreatePrivateChatWithProfile(string withProfileID);

		List<ChatTitle> GetChatTitles();

		string GetChatIdBetweenTwoProfiles(string profileID1, string profileID2);

		void GetProfileDialogList(Action<CBSGetDialogListResult> result);

		void GetProfileDialogBadge(Action<CBSBadgeResult> result);

		void ClearDialogBadgeWithProfile(string profileID, Action<CBSClearDialogBadgeResult> result);

		void GetMessagesFromChat(string chatID, int maxCount, Action<CBSGetMessagesFromChatResult> result);

		void SendTextMessageToGroupChat(string chatID, CBSSendTextMessageRequest messageRequest, Action<CBSSendChatMessageResult> result);

		void SendStickerMessageToGroupChat(string chatID, CBSSendStickerMessageRequest messageRequest, Action<CBSSendChatMessageResult> result);

		void SendItemMessageToGroupChat(string chatID, CBSSendItemMessageRequest messageRequest, Action<CBSSendChatMessageResult> result);

		void SendTextMessageToPrivateChat(string withProfileID, CBSSendTextMessageRequest messageRequest, Action<CBSSendChatMessageResult> result);

		void SendStickerMessageToPrivateChat(string withProfileID, CBSSendStickerMessageRequest messageRequest, Action<CBSSendChatMessageResult> result);

		void SendItemMessageToPrivateChat(string withProfileID, CBSSendItemMessageRequest messageRequest, Action<CBSSendChatMessageResult> result);

		void ChangeMessageText(string messageID, string chatID, string textToChange, Action<CBSModifyMessageResult> result);

		void DeleteChatMessage(string messageID, string chatID, Action<CBSModifyMessageResult> result);

		void BanProfile(string profileIDForBan, string chatID, string reason, int banHours, Action<CBSBanProfileInChatResult> result);

		void GetStickersPack(Action<CBSGetStickersResult> result);

		void ClaimItemFromChat(string chatID, string messageID, Action<CBSClaimItemFromMessageResult> result);
	}
}
