using System;
using System.Collections.Generic;
using CBS.Models;

namespace CBS
{
	public interface IChat : IDisposable
	{
		string ChatID { get; }

		string[] PrivateChatMembers { get; }

		event Action<ChatMessage> OnNewMessage;

		event Action<List<ChatMessage>> OnGetHistory;

		void Load();

		void SetMaxMessagesCount(int maxMessagesToLoad);

		void SetUpdateIntervalMiliseconds(float updateInterval);

		void SendMessage(CBSSendTextMessageRequest request, Action<CBSSendChatMessageResult> result = null);

		void SendSticker(CBSSendStickerMessageRequest request, Action<CBSSendChatMessageResult> result = null);

		void SendItem(CBSSendItemMessageRequest request, Action<CBSSendChatMessageResult> result = null);

		void GetChatHistory(Action<CBSGetMessagesFromChatResult> result = null);
	}
}
