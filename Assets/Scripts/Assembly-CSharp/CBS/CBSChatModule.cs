using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CBS.Models;
using CBS.Playfab;

namespace CBS
{
	public class CBSChatModule : CBSModule, ICBSChat
	{
		[CompilerGenerated]
		private Action<ChatDialogEntry> m_OnUnreadMessageClear;

		public bool IsModerator => false;

		public ProfileChatData ProfileChatData { get; private set; }

		private Dictionary<string, ChatInstance> ChatCache { get; set; }

		private string ServerID { get; set; }

		private string RegionID { get; set; }

		private IProfile Profile { get; set; }

		private IFabChat FabChat { get; set; }

		public event Action<ChatDialogEntry> OnUnreadMessageClear
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

		public void SetServerID(string serverID)
		{
		}

		public void SetRegion(string region)
		{
		}

		public ChatInstance GetOrCreateChat(ChatTitle chatTitle)
		{
			return null;
		}

		public ChatInstance GetOrCreateGroupChatByID(string chatID)
		{
			return null;
		}

		public ChatInstance GetOrCreatePrivateChatWithProfile(string withProfileID)
		{
			return null;
		}

		public List<ChatTitle> GetChatTitles()
		{
			return null;
		}

		public string GetChatIdBetweenTwoProfiles(string profileID1, string profileID2)
		{
			return null;
		}

		public void GetProfileDialogList(Action<CBSGetDialogListResult> result)
		{
		}

		public void GetProfileDialogBadge(Action<CBSBadgeResult> result)
		{
		}

		public void ClearDialogBadgeWithProfile(string withProfileID, Action<CBSClearDialogBadgeResult> result)
		{
		}

		public void GetMessagesFromChat(string chatID, int maxCount, Action<CBSGetMessagesFromChatResult> result)
		{
		}

		public void SendTextMessageToGroupChat(string chatID, CBSSendTextMessageRequest messageRequest, Action<CBSSendChatMessageResult> result)
		{
		}

		public void SendStickerMessageToGroupChat(string chatID, CBSSendStickerMessageRequest messageRequest, Action<CBSSendChatMessageResult> result)
		{
		}

		public void SendItemMessageToGroupChat(string chatID, CBSSendItemMessageRequest messageRequest, Action<CBSSendChatMessageResult> result)
		{
		}

		public void SendTextMessageToPrivateChat(string withProfileID, CBSSendTextMessageRequest messageRequest, Action<CBSSendChatMessageResult> result)
		{
		}

		public void SendStickerMessageToPrivateChat(string withProfileID, CBSSendStickerMessageRequest messageRequest, Action<CBSSendChatMessageResult> result)
		{
		}

		public void SendItemMessageToPrivateChat(string withProfileID, CBSSendItemMessageRequest messageRequest, Action<CBSSendChatMessageResult> result)
		{
		}

		public void ChangeMessageText(string messageID, string chatID, string textToChange, Action<CBSModifyMessageResult> result)
		{
		}

		public void DeleteChatMessage(string messageID, string chatID, Action<CBSModifyMessageResult> result)
		{
		}

		public void BanProfile(string profileIDForBan, string chatID, string reason, int banHours, Action<CBSBanProfileInChatResult> result)
		{
		}

		public void GetStickersPack(Action<CBSGetStickersResult> result)
		{
		}

		public void ClaimItemFromChat(string chatID, string messageID, Action<CBSClaimItemFromMessageResult> result)
		{
		}

		private void InternalSendMessage(FunctionSendChatMessageRequest request, Action<CBSSendChatMessageResult> result)
		{
		}

		private string GetChatID(ChatTitle chatTitle)
		{
			return null;
		}

		internal void ParseChatData(ProfileChatData chatData)
		{
		}

		protected override void OnLogout()
		{
		}
	}
}
